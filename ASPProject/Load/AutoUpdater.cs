using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms; // Dùng để hiển thị thông báo
using System.Diagnostics;
using System.Collections.Generic; // Dùng để lấy thông tin phiên bản

namespace ASPProject.Load
{
    public class AutoUpdater
    {
        // Đường dẫn tới thư mục chứa các DLL trên server
        private static readonly string ServerDllFolder = @"\\192.168.10.10\ERPProject\10. UpdateASM1";
        // Đường dẫn tới thư mục cục bộ (thư mục cài đặt phần mềm)
        private static readonly string LocalDllFolder = AppDomain.CurrentDomain.BaseDirectory;
        // Đường dẫn tới thư mục tạm để tải DLL về trước khi ghi đè
        private static readonly string TempDllFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempUpdates");

        /// <summary>
        /// Tải về và cập nhật tất cả DLL từ thư mục chia sẻ khi người dùng đăng nhập
        /// </summary>
        public static void UpdateAllDlls()
        {
            try
            {
                // Bước 1: Kiểm tra xem thư mục trên server có tồn tại không
                if (!Directory.Exists(ServerDllFolder))
                {
                    MessageBox.Show($"Không tìm thấy thư mục trên server tại: {ServerDllFolder}", "Lỗi cập nhật",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo thư mục tạm nếu chưa tồn tại
                if (!Directory.Exists(TempDllFolder))
                {
                    Directory.CreateDirectory(TempDllFolder);
                }

                // Bước 2: Lấy danh sách các file DLL từ server
                string[] serverDllFiles = Directory.GetFiles(ServerDllFolder, "*.dll", SearchOption.TopDirectoryOnly);
                if (serverDllFiles.Length == 0)
                {
                    MessageBox.Show($"Không tìm thấy file DLL nào trong thư mục: {ServerDllFolder}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Danh sách các DLL đã được cập nhật (để thông báo sau)
                List<string> updatedDlls = new List<string>();

                // Bước 3: Duyệt qua từng DLL trên server
                foreach (string serverDllPath in serverDllFiles)
                {
                    try
                    {
                        string dllFileName = Path.GetFileName(serverDllPath);
                        string localDllPath = Path.Combine(LocalDllFolder, dllFileName);
                        string tempDllPath = Path.Combine(TempDllFolder, dllFileName);

                        // Bước 4: Tải DLL từ server về thư mục tạm
                        File.Copy(serverDllPath, tempDllPath, true);

                        // Bước 5: Ghi đè DLL cục bộ
                        try
                        {
                            File.Copy(tempDllPath, localDllPath, true);
                            File.Delete(tempDllPath); // Xóa file tạm
                            updatedDlls.Add(dllFileName);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show($"Không có quyền ghi vào thư mục cài đặt cho {dllFileName}: {ex.Message}\nVui lòng chạy phần mềm với quyền Administrator.",
                                "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            File.Delete(tempDllPath); // Xóa file tạm nếu có lỗi
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Không thể ghi đè {dllFileName}: {ex.Message}\nCó thể DLL đang được sử dụng. Vui lòng đóng ứng dụng và thử lại.",
                                "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            File.Delete(tempDllPath); // Xóa file tạm nếu có lỗi
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi cho từng DLL nhưng không dừng quá trình
                        Console.WriteLine($"Lỗi khi xử lý {Path.GetFileName(serverDllPath)}: {ex.Message}");
                    }
                }

                // Bước 6: Thông báo kết quả
                if (updatedDlls.Count > 0)
                {
                    MessageBox.Show($"Đã cập nhật các DLL sau:\n{string.Join("\n", updatedDlls)}", "Cập nhật thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có DLL nào được cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bước 7: Xóa thư mục tạm nếu rỗng
                if (Directory.Exists(TempDllFolder) && Directory.GetFiles(TempDllFolder).Length == 0)
                {
                    Directory.Delete(TempDllFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra cập nhật: {ex.Message}", "Lỗi cập nhật",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
