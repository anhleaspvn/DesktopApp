using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace ASPUpdater
{
    internal static class Program
    {
        private const string UpdaterLogFileName = "update-log.txt";

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UpdateProgressForm progressForm = new UpdateProgressForm();
            string tempLogPath = GetTempLogPath();
            string targetPath = null;
            string logPath = tempLogPath;
            string backupPath = Path.Combine(Path.GetTempPath(), "ASPProjectUpdateBackup", DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));

            try
            {
                progressForm.Show();
                progressForm.ForceToFront();
                SetStatus(progressForm, "Dang chuan bi cap nhat...");

                AppendLog(tempLogPath, "Updater started. Args: " + string.Join(" ", args));

                Dictionary<string, string> options = ParseArgs(args);
                string sourcePath = GetRequiredOption(options, "source");
                targetPath = GetRequiredOption(options, "target");
                string restartPath = GetRequiredOption(options, "restart");
                string pidText = GetRequiredOption(options, "pid");
                string manifestFileName = GetOption(options, "manifest", "update.json");
                logPath = Path.Combine(targetPath, UpdaterLogFileName);

                AppendLogBoth(logPath, tempLogPath, "Source: " + sourcePath);
                AppendLogBoth(logPath, tempLogPath, "Target: " + targetPath);
                AppendLogBoth(logPath, tempLogPath, "Manifest: " + manifestFileName);

                SetStatus(progressForm, "Dang tai thong tin phien ban...");
                UpdateManifest manifest = ReadManifest(sourcePath, manifestFileName);
                AppendLogBoth(logPath, tempLogPath, "Manifest version: " + manifest.Version);

                SetStatus(progressForm, "Dang dong phien ban cu...");
                WaitForProcessToExit(pidText);
                AppendLogBoth(logPath, tempLogPath, "Main application exited.");

                SetStatus(progressForm, "Dang tao ban sao luu...");
                Directory.CreateDirectory(backupPath);

                ApplyUpdate(sourcePath, targetPath, backupPath, manifest, manifestFileName, logPath, tempLogPath, progressForm);
                AppendLogBoth(logPath, tempLogPath, "Update completed.");

                SetStatus(progressForm, "Cap nhat thanh cong.");
                progressForm.StopProgress();
                progressForm.ForceToFront();
                MessageBox.Show(progressForm,
                    "Cap nhat thanh cong. Bam OK de mo lai phan mem.",
                    "Cap nhat phan mem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SetStatus(progressForm, "Dang mo lai phan mem...");
                StartApplication(restartPath);
                AppendLogBoth(logPath, tempLogPath, "Restart requested: " + restartPath);
            }
            catch (Exception ex)
            {
                SetStatus(progressForm, "Cap nhat that bai.");
                AppendLogBoth(logPath, tempLogPath, "Update failed: " + ex);
                TryRollback(backupPath, targetPath, logPath, tempLogPath, progressForm);
                progressForm.StopProgress();
                progressForm.ForceToFront();

                MessageBox.Show(progressForm,
                    "Cap nhat that bai: " + ex.Message,
                    "Cap nhat phan mem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressForm.Close();
                progressForm.Dispose();
            }
        }

        private static UpdateManifest ReadManifest(string sourcePath, string manifestFileName)
        {
            if (IsHttpSource(sourcePath))
            {
                using (Stream stream = OpenUrlStream(CombineSourceUrl(sourcePath, manifestFileName)))
                {
                    return DeserializeManifest(stream);
                }
            }

            string manifestPath = Path.Combine(sourcePath, manifestFileName);
            if (!File.Exists(manifestPath))
            {
                throw new FileNotFoundException("Khong tim thay manifest update.", manifestPath);
            }

            using (FileStream stream = File.OpenRead(manifestPath))
            {
                return DeserializeManifest(stream);
            }
        }

        private static UpdateManifest DeserializeManifest(Stream stream)
        {
            string manifestContent;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true))
            {
                manifestContent = reader.ReadToEnd();
            }

            manifestContent = NormalizeManifestContent(manifestContent);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UpdateManifest));
            using (MemoryStream manifestStream = new MemoryStream(Encoding.UTF8.GetBytes(manifestContent)))
            {
                UpdateManifest manifest = serializer.ReadObject(manifestStream) as UpdateManifest;
                if (manifest == null || string.IsNullOrWhiteSpace(manifest.Version))
                {
                    throw new InvalidOperationException("Manifest update khong hop le.");
                }

                if (string.IsNullOrWhiteSpace(manifest.Package) && (manifest.Files == null || manifest.Files.Count == 0))
                {
                    throw new InvalidOperationException("Manifest update chua khai bao package hoac danh sach files.");
                }

                return manifest;
            }
        }

        private static string NormalizeManifestContent(string manifestContent)
        {
            if (manifestContent == null)
            {
                return string.Empty;
            }

            manifestContent = manifestContent.TrimStart('\uFEFF');
            if (manifestContent.StartsWith("ï»¿", StringComparison.Ordinal))
            {
                manifestContent = manifestContent.Substring(3);
            }

            return manifestContent.TrimStart();
        }

        private static void ValidateManifest(UpdateManifest manifest)
        {
            if (manifest == null || string.IsNullOrWhiteSpace(manifest.Version))
            {
                throw new InvalidOperationException("Manifest update khong hop le.");
            }

            if (string.IsNullOrWhiteSpace(manifest.Package) && (manifest.Files == null || manifest.Files.Count == 0))
            {
                throw new InvalidOperationException("Manifest update chua khai bao package hoac danh sach files.");
            }

        }

        private static Stream OpenUrlStream(string url)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            try
            {
                byte[] content = client.DownloadData(url);
                return new MemoryStream(content);
            }
            finally
            {
                client.Dispose();
            }
        }

        private static void WaitForProcessToExit(string pidText)
        {
            int pid;
            if (!int.TryParse(pidText, out pid) || pid <= 0)
            {
                return;
            }

            try
            {
                Process process = Process.GetProcessById(pid);
                process.WaitForExit(30000);
            }
            catch (ArgumentException)
            {
            }
        }

        private static void ApplyUpdate(string sourcePath, string targetPath, string backupPath, UpdateManifest manifest, string manifestFileName, string logPath, string tempLogPath, UpdateProgressForm progressForm)
        {
            if (!string.IsNullOrWhiteSpace(manifest.Package))
            {
                CopyPackageUpdate(sourcePath, targetPath, backupPath, manifest, manifestFileName, logPath, tempLogPath, progressForm);
                return;
            }

            CopyManifestFiles(sourcePath, targetPath, backupPath, manifest, manifestFileName, logPath, tempLogPath, progressForm);
        }

        private static void CopyPackageUpdate(string sourcePath, string targetPath, string backupPath, UpdateManifest manifest, string manifestFileName, string logPath, string tempLogPath, UpdateProgressForm progressForm)
        {
            string packageRelativePath = NormalizeRelativePath(manifest.Package);
            string packageWorkFolder = Path.Combine(Path.GetTempPath(), "ASPProjectUpdatePackage", Guid.NewGuid().ToString("N"));
            string extractPath = Path.Combine(packageWorkFolder, "extracted");
            string packagePath = Path.Combine(packageWorkFolder, Path.GetFileName(packageRelativePath));

            Directory.CreateDirectory(packageWorkFolder);
            Directory.CreateDirectory(extractPath);

            SetStatus(progressForm, "Dang tai goi cap nhat...");
            AppendLogBoth(logPath, tempLogPath, "Package: " + packageRelativePath);
            DownloadOrCopySourceFile(sourcePath, packageRelativePath, packagePath);
            AppendLogBoth(logPath, tempLogPath, "Package downloaded: " + packagePath);

            SetStatus(progressForm, "Dang giai nen goi cap nhat...");
            ExtractZipSafely(packagePath, extractPath);
            AppendLogBoth(logPath, tempLogPath, "Package extracted: " + extractPath);

            CopyExtractedPackageFiles(extractPath, targetPath, backupPath, logPath, tempLogPath, progressForm);

            if (!ContainsExtractedFile(extractPath, manifestFileName))
            {
                SetStatus(progressForm, "Dang cap nhat: " + manifestFileName);
                CopyFileWithBackup(sourcePath, targetPath, backupPath, manifestFileName);
                AppendLogBoth(logPath, tempLogPath, "Copied manifest from source: " + manifestFileName);
            }
        }

        private static void CopyManifestFiles(string sourcePath, string targetPath, string backupPath, UpdateManifest manifest, string manifestFileName, string logPath, string tempLogPath, UpdateProgressForm progressForm)
        {
            List<string> files = new List<string>(manifest.Files);
            if (!ContainsFile(files, manifestFileName))
            {
                files.Add(manifestFileName);
            }

            foreach (string relativePath in files)
            {
                SetStatus(progressForm, "Dang cap nhat: " + relativePath);
                AppendLogBoth(logPath, tempLogPath, "Copying: " + relativePath);
                if (IsProtectedLocalFile(relativePath))
                {
                    AppendLogBoth(logPath, tempLogPath, "Skipped protected file: " + relativePath);
                    continue;
                }

                CopyFileWithBackup(sourcePath, targetPath, backupPath, relativePath);
                AppendLogBoth(logPath, tempLogPath, "Copied: " + relativePath);
            }
        }

        private static void CopyExtractedPackageFiles(string extractPath, string targetPath, string backupPath, string logPath, string tempLogPath, UpdateProgressForm progressForm)
        {
            foreach (string sourceFilePath in Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories))
            {
                string relativePath = GetRelativePath(extractPath, sourceFilePath);
                if (IsProtectedLocalFile(relativePath))
                {
                    AppendLogBoth(logPath, tempLogPath, "Skipped protected file: " + relativePath);
                    continue;
                }

                SetStatus(progressForm, "Dang cap nhat: " + relativePath);
                AppendLogBoth(logPath, tempLogPath, "Copying extracted file: " + relativePath);
                CopyExtractedFileWithBackup(extractPath, targetPath, backupPath, relativePath);
                AppendLogBoth(logPath, tempLogPath, "Copied extracted file: " + relativePath);
            }
        }

        private static bool ContainsFile(List<string> files, string fileName)
        {
            foreach (string file in files)
            {
                if (string.Equals(NormalizeRelativePath(file), NormalizeRelativePath(fileName), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static void CopyFileWithBackup(string sourcePath, string targetPath, string backupPath, string relativePath)
        {
            string normalizedRelativePath = NormalizeRelativePath(relativePath);
            string sourceFilePath = IsHttpSource(sourcePath) ? null : ResolveChildPath(sourcePath, normalizedRelativePath);
            string targetFilePath = ResolveChildPath(targetPath, normalizedRelativePath);

            if (!IsHttpSource(sourcePath) && !File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Khong tim thay file update: " + normalizedRelativePath, sourceFilePath);
            }

            string targetFolder = Path.GetDirectoryName(targetFilePath);
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            if (File.Exists(targetFilePath))
            {
                string backupFilePath = ResolveChildPath(backupPath, normalizedRelativePath);
                string backupFolder = Path.GetDirectoryName(backupFilePath);
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                File.Copy(targetFilePath, backupFilePath, true);
                File.SetAttributes(targetFilePath, FileAttributes.Normal);
            }

            if (IsHttpSource(sourcePath))
            {
                DownloadFile(CombineSourceUrl(sourcePath, normalizedRelativePath), targetFilePath);
            }
            else
            {
                File.Copy(sourceFilePath, targetFilePath, true);
            }

            File.SetAttributes(targetFilePath, FileAttributes.Normal);
        }

        private static void CopyExtractedFileWithBackup(string extractPath, string targetPath, string backupPath, string relativePath)
        {
            string normalizedRelativePath = NormalizeRelativePath(relativePath);
            string sourceFilePath = ResolveChildPath(extractPath, normalizedRelativePath);
            string targetFilePath = ResolveChildPath(targetPath, normalizedRelativePath);
            CopyPhysicalFileWithBackup(sourceFilePath, targetFilePath, backupPath, normalizedRelativePath);
        }

        private static void CopyPhysicalFileWithBackup(string sourceFilePath, string targetFilePath, string backupPath, string relativePath)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Khong tim thay file update: " + relativePath, sourceFilePath);
            }

            string targetFolder = Path.GetDirectoryName(targetFilePath);
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            if (File.Exists(targetFilePath))
            {
                string backupFilePath = ResolveChildPath(backupPath, relativePath);
                string backupFolder = Path.GetDirectoryName(backupFilePath);
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                File.Copy(targetFilePath, backupFilePath, true);
                File.SetAttributes(targetFilePath, FileAttributes.Normal);
            }

            File.Copy(sourceFilePath, targetFilePath, true);
            File.SetAttributes(targetFilePath, FileAttributes.Normal);
        }

        private static void CopyDirectory(string sourcePath, string targetPath, string backupPath)
        {
            foreach (string sourceFilePath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                string relativePath = GetRelativePath(sourcePath, sourceFilePath);
                string targetFilePath = Path.Combine(targetPath, relativePath);
                string targetFolder = Path.GetDirectoryName(targetFilePath);
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                if (File.Exists(targetFilePath))
                {
                    string backupFilePath = Path.Combine(backupPath, relativePath);
                    string backupFolder = Path.GetDirectoryName(backupFilePath);
                    if (!Directory.Exists(backupFolder))
                    {
                        Directory.CreateDirectory(backupFolder);
                    }

                    File.Copy(targetFilePath, backupFilePath, true);
                    File.SetAttributes(targetFilePath, FileAttributes.Normal);
                }

                File.Copy(sourceFilePath, targetFilePath, true);
                File.SetAttributes(targetFilePath, FileAttributes.Normal);
            }
        }

        private static void TryRollback(string backupPath, string targetPath, string logPath, string tempLogPath, UpdateProgressForm progressForm)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(targetPath) && Directory.Exists(backupPath))
                {
                    SetStatus(progressForm, "Dang khoi phuc file cu...");
                    CopyDirectory(backupPath, targetPath, Path.Combine(Path.GetTempPath(), "ASPProjectRollbackBackup"));
                    AppendLogBoth(logPath, tempLogPath, "Rollback completed from " + backupPath);
                }
            }
            catch (Exception rollbackEx)
            {
                AppendLogBoth(logPath, tempLogPath, "Rollback failed: " + rollbackEx);
            }
        }

        private static void StartApplication(string restartPath)
        {
            if (File.Exists(restartPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = restartPath,
                    WorkingDirectory = Path.GetDirectoryName(restartPath),
                    UseShellExecute = true
                });
            }
        }

        private static string NormalizeRelativePath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new InvalidOperationException("Manifest co file path rong.");
            }

            string normalized = relativePath.Trim().Replace('/', Path.DirectorySeparatorChar);
            if (Path.IsPathRooted(normalized))
            {
                throw new InvalidOperationException("Manifest khong duoc dung absolute path: " + relativePath);
            }

            string[] pathParts = normalized.Split(Path.DirectorySeparatorChar);
            foreach (string part in pathParts)
            {
                if (string.IsNullOrWhiteSpace(part) || part == "." || part == "..")
                {
                    throw new InvalidOperationException("Manifest co file path khong hop le: " + relativePath);
                }
            }

            return normalized;
        }

        private static string ResolveChildPath(string rootPath, string relativePath)
        {
            string rootFullPath = AppendDirectorySeparatorChar(Path.GetFullPath(rootPath));
            string childFullPath = Path.GetFullPath(Path.Combine(rootFullPath, relativePath));
            if (!childFullPath.StartsWith(rootFullPath, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("File update nam ngoai thu muc cho phep: " + relativePath);
            }

            return childFullPath;
        }

        private static bool IsHttpSource(string sourcePath)
        {
            Uri uri;
            return Uri.TryCreate(sourcePath, UriKind.Absolute, out uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        private static string CombineSourceUrl(string sourceUrl, string relativePath)
        {
            Uri baseUri = new Uri(sourceUrl.EndsWith("/", StringComparison.Ordinal) ? sourceUrl : sourceUrl + "/");
            return new Uri(baseUri, relativePath.Replace("\\", "/")).ToString();
        }

        private static void DownloadOrCopySourceFile(string sourcePath, string relativePath, string targetFilePath)
        {
            if (IsHttpSource(sourcePath))
            {
                DownloadFile(CombineSourceUrl(sourcePath, relativePath), targetFilePath);
                return;
            }

            string sourceFilePath = ResolveChildPath(sourcePath, relativePath);
            CopyPhysicalFileWithBackup(sourceFilePath, targetFilePath, Path.Combine(Path.GetTempPath(), "ASPProjectPackageBackup"), relativePath);
        }

        private static void ExtractZipSafely(string packagePath, string extractPath)
        {
            string extractFullPath = AppendDirectorySeparatorChar(Path.GetFullPath(extractPath));
            using (ZipArchive archive = ZipFile.OpenRead(packagePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name))
                    {
                        continue;
                    }

                    string normalizedEntryPath = NormalizeRelativePath(entry.FullName);
                    string destinationPath = Path.GetFullPath(Path.Combine(extractFullPath, normalizedEntryPath));
                    if (!destinationPath.StartsWith(extractFullPath, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException("Zip co file path khong hop le: " + entry.FullName);
                    }

                    string destinationFolder = Path.GetDirectoryName(destinationPath);
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    entry.ExtractToFile(destinationPath, true);
                }
            }
        }

        private static bool ContainsExtractedFile(string extractPath, string fileName)
        {
            string expectedPath = ResolveChildPath(extractPath, NormalizeRelativePath(fileName));
            return File.Exists(expectedPath);
        }

        private static bool IsProtectedLocalFile(string relativePath)
        {
            string normalized = NormalizeRelativePath(relativePath);
            return string.Equals(normalized, "ASPProject.exe.config", StringComparison.OrdinalIgnoreCase);
        }

        private static void DownloadFile(string url, string targetFilePath)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            string tempDownloadPath = targetFilePath + ".download";
            if (File.Exists(tempDownloadPath))
            {
                File.SetAttributes(tempDownloadPath, FileAttributes.Normal);
                File.Delete(tempDownloadPath);
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, tempDownloadPath);
            }

            if (File.Exists(targetFilePath))
            {
                File.SetAttributes(targetFilePath, FileAttributes.Normal);
                File.Delete(targetFilePath);
            }

            File.Move(tempDownloadPath, targetFilePath);
        }

        private static Dictionary<string, string> ParseArgs(string[] args)
        {
            Dictionary<string, string> options = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                string key = args[i];
                if (!key.StartsWith("--", StringComparison.Ordinal))
                {
                    continue;
                }

                if (i + 1 >= args.Length)
                {
                    break;
                }

                options[key.Substring(2)] = args[++i];
            }

            return options;
        }

        private static string GetRequiredOption(Dictionary<string, string> options, string key)
        {
            string value;
            if (options.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            throw new InvalidOperationException("Thieu tham so updater: " + key);
        }

        private static string GetOption(Dictionary<string, string> options, string key, string defaultValue)
        {
            string value;
            if (options.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return defaultValue;
        }

        private static string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(AppendDirectorySeparatorChar(Path.GetFullPath(basePath)));
            Uri fullUri = new Uri(Path.GetFullPath(fullPath));
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fullUri).ToString()).Replace('/', Path.DirectorySeparatorChar);
        }

        private static string AppendDirectorySeparatorChar(string path)
        {
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                return path + Path.DirectorySeparatorChar;
            }

            return path;
        }

        private static void AppendLog(string logPath, string message)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(logPath);
                if (!string.IsNullOrWhiteSpace(folderPath) && !Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                File.AppendAllText(logPath,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + " " + message + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static void AppendLogBoth(string logPath, string tempLogPath, string message)
        {
            AppendLog(tempLogPath, message);
            if (!string.Equals(logPath, tempLogPath, StringComparison.OrdinalIgnoreCase))
            {
                AppendLog(logPath, message);
            }
        }

        private static string GetTempLogPath()
        {
            return Path.Combine(Path.GetTempPath(), "ASPProjectUpdate", UpdaterLogFileName);
        }

        private static void SetStatus(UpdateProgressForm progressForm, string status)
        {
            if (progressForm == null || progressForm.IsDisposed)
            {
                return;
            }

            progressForm.SetStatus(status);
            Application.DoEvents();
        }

        [DataContract]
        private sealed class UpdateManifest
        {
            [DataMember(Name = "version")]
            public string Version { get; set; }

            [DataMember(Name = "package")]
            public string Package { get; set; }

            [DataMember(Name = "files")]
            public List<string> Files { get; set; }
        }
    }
}
