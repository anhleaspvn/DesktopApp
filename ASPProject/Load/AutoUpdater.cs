using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ASPProject.Load
{
    public static class AutoUpdater
    {
        private const string DefaultUpdateSourcePath = @"\\192.168.10.10\ERPProject\10. UpdateASM1_TEST";
        private const string DefaultUpdateSourceUrl = "https://api1.airspeedmfg.com.vn:449/updates/ASM1_Test/";
        private const string DefaultManifestFileName = "update.json";
        private const string UpdaterExecutableName = "ASPUpdater.exe";

        public static bool CheckAndStartUpdate(IWin32Window owner)
        {
            if (!GetBooleanSetting("AutoUpdateEnabled", true))
            {
                return false;
            }

            string sourcePath = GetUpdateSource();
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                return false;
            }

            try
            {
                Version currentVersion = GetCurrentVersion();
                UpdateInfo updateInfo = GetUpdateInfo(sourcePath);
                if (updateInfo == null || updateInfo.Version <= currentVersion)
                {
                    return false;
                }

                if (GetBooleanSetting("AutoUpdatePromptUser", true))
                {
                    DialogResult confirm = MessageBox.Show(owner,
                        string.Format(CultureInfo.InvariantCulture,
                            "Co phien ban moi {0}.\nPhien ban hien tai: {1}\n\nBan co muon cap nhat ngay bay gio khong?",
                            updateInfo.Version, currentVersion),
                        "Cap nhat phan mem",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                    if (confirm != DialogResult.Yes)
                    {
                        return false;
                    }
                }

                StartUpdater(sourcePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner,
                    "Khong the kiem tra cap nhat: " + ex.Message,
                    "Cap nhat phan mem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
        }

        private static UpdateInfo GetUpdateInfo(string sourcePath)
        {
            Version manifestVersion = TryReadManifestVersionFromSource(sourcePath);
            if (manifestVersion != null)
            {
                return new UpdateInfo { Version = manifestVersion };
            }

            return null;
        }

        private static Version GetCurrentVersion()
        {
            Version manifestVersion = TryReadLocalManifestVersion(AppDomain.CurrentDomain.BaseDirectory);
            string currentFileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            Version version;
            if (Version.TryParse(currentFileVersion, out version))
            {
                return manifestVersion != null && manifestVersion > version ? manifestVersion : version;
            }

            version = Assembly.GetExecutingAssembly().GetName().Version;
            return manifestVersion != null && manifestVersion > version ? manifestVersion : version;
        }

        private static Version TryReadManifestVersionFromSource(string sourcePath)
        {
            string manifestFileName = GetSetting("AutoUpdateManifestFileName", DefaultManifestFileName);

            if (IsHttpSource(sourcePath))
            {
                string manifestContent = DownloadString(CombineSourceUrl(sourcePath, manifestFileName));
                return ParseManifestVersion(manifestContent, manifestFileName);
            }

            if (!Directory.Exists(sourcePath))
            {
                return null;
            }

            return TryReadLocalManifestVersion(sourcePath);
        }

        private static Version TryReadLocalManifestVersion(string folderPath)
        {
            string manifestFileName = GetSetting("AutoUpdateManifestFileName", DefaultManifestFileName);
            string manifestPath = Path.Combine(folderPath, manifestFileName);
            if (!File.Exists(manifestPath))
            {
                return null;
            }

            string manifestContent = File.ReadAllText(manifestPath);
            return ParseManifestVersion(manifestContent, manifestFileName);
        }

        private static Version ParseManifestVersion(string manifestContent, string manifestFileName)
        {
            string versionText = ReadJsonStringValue(manifestContent, "version");
            Version manifestVersion;
            if (Version.TryParse(versionText, out manifestVersion))
            {
                return manifestVersion;
            }

            throw new InvalidOperationException("File manifest " + manifestFileName + " khong co version hop le.");
        }

        private static void StartUpdater(string sourcePath)
        {
            string localUpdaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UpdaterExecutableName);
            if (!File.Exists(localUpdaterPath))
            {
                throw new FileNotFoundException("Khong tim thay " + UpdaterExecutableName + " trong thu muc cai dat.", localUpdaterPath);
            }

            string updateWorkFolder = Path.Combine(Path.GetTempPath(), "ASPProjectUpdate", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(updateWorkFolder);

            string tempUpdaterPath = Path.Combine(updateWorkFolder, UpdaterExecutableName);
            File.Copy(localUpdaterPath, tempUpdaterPath, true);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = tempUpdaterPath,
                Arguments = string.Format(CultureInfo.InvariantCulture,
                    "--source {0} --target {1} --pid {2} --restart {3} --manifest {4}",
                    Quote(sourcePath),
                    Quote(AppDomain.CurrentDomain.BaseDirectory),
                    Process.GetCurrentProcess().Id,
                    Quote(Application.ExecutablePath),
                    Quote(GetSetting("AutoUpdateManifestFileName", DefaultManifestFileName))),
                UseShellExecute = false,
                WorkingDirectory = updateWorkFolder
            };

            Process.Start(startInfo);
        }

        private static string GetUpdateSource()
        {
            string sourceUrl = GetSetting("AutoUpdateSourceUrl", DefaultUpdateSourceUrl);
            if (!string.IsNullOrWhiteSpace(sourceUrl))
            {
                return sourceUrl;
            }

            return GetSetting("AutoUpdateSourcePath", DefaultUpdateSourcePath);
        }

        private static string GetSetting(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value.Trim();
        }

        private static bool GetBooleanSetting(string key, bool defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            bool parsed;
            return bool.TryParse(value, out parsed) ? parsed : defaultValue;
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

        private static string DownloadString(string url)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        private static string ReadJsonStringValue(string json, string propertyName)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            string token = "\"" + propertyName + "\"";
            int propertyIndex = json.IndexOf(token, StringComparison.OrdinalIgnoreCase);
            if (propertyIndex < 0)
            {
                return null;
            }

            int colonIndex = json.IndexOf(':', propertyIndex + token.Length);
            if (colonIndex < 0)
            {
                return null;
            }

            int firstQuoteIndex = json.IndexOf('"', colonIndex + 1);
            if (firstQuoteIndex < 0)
            {
                return null;
            }

            int secondQuoteIndex = json.IndexOf('"', firstQuoteIndex + 1);
            if (secondQuoteIndex < 0)
            {
                return null;
            }

            return json.Substring(firstQuoteIndex + 1, secondQuoteIndex - firstQuoteIndex - 1);
        }

        private static string Quote(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "\"\"";
            }

            bool requiresQuotes = value.IndexOfAny(new[] { ' ', '\t', '"' }) >= 0 || value.EndsWith("\\", StringComparison.Ordinal);
            if (!requiresQuotes)
            {
                return value;
            }

            StringBuilder builder = new StringBuilder();
            builder.Append('"');

            int backslashCount = 0;
            foreach (char character in value)
            {
                if (character == '\\')
                {
                    backslashCount++;
                    continue;
                }

                if (character == '"')
                {
                    builder.Append('\\', backslashCount * 2 + 1);
                    builder.Append(character);
                    backslashCount = 0;
                    continue;
                }

                builder.Append('\\', backslashCount);
                builder.Append(character);
                backslashCount = 0;
            }

            builder.Append('\\', backslashCount * 2);
            builder.Append('"');
            return builder.ToString();
        }

        private sealed class UpdateInfo
        {
            public Version Version { get; set; }
        }
    }
}
