using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WinFormApp.Models;

namespace WinFormApp.Helpers
{
    public static class DbHelper
    {
        // Customizable Connection String for Link Q SQL Server Database
        public static string ConnectionString = "Server=localhost;Database=LinkQMasterDB;Trusted_Connection=True;Timeout=3;";
        
        // Auto-switches to in-memory mock data if SQL Server is not reachable
        public static bool UseInMemoryMock = false;
        
        private static List<Component> _mockComponents = new List<Component>();
        private static List<UserPermission> _mockPermissions = new List<UserPermission>();
        private static List<HistoryChange> _mockHistory = new List<HistoryChange>();

        static DbHelper()
        {
            InitializeMockData();
            TestConnection();
        }

        private static void TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    UseInMemoryMock = false;
                }
            }
            catch
            {
                // Fall back to in-memory database to allow team review/trial without database setups
                UseInMemoryMock = true;
            }
        }

        private static void InitializeMockData()
        {
            // Seed Data from the quotation phase
            var dataRows = new[]
            {
                new { Id = 1, Rev = "A01", Sec = "ASM1", Date = "2025-11-02", PN = "A0006166735", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "AVNET", PO = 2500m, Qty = 100000m, PIC = "James" },
                new { Id = 2, Rev = "A01", Sec = "ASM1", Date = "2025-11-02", PN = "A0006166735", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "AVNET", PO = 2500m, Qty = 200000m, PIC = "James" },
                new { Id = 3, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 100000m, PIC = "James" },
                new { Id = 4, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 200000m, PIC = "James" },
                new { Id = 5, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 100000m, PIC = "James" },
                new { Id = 6, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 200000m, PIC = "James" },
                new { Id = 7, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 100000m, PIC = "James" },
                new { Id = 8, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 200000m, PIC = "James" },
                new { Id = 9, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 100000m, PIC = "James" },
                new { Id = 10, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 200000m, PIC = "James" },
                new { Id = 11, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 100000m, PIC = "James" },
                new { Id = 12, Rev = "A01", Sec = "ASM1", Date = "2026-01-02", PN = "A0006166735", Ref = "B018721", Mfg = "Molex", LT = 22m, Cost = 0m, Vendor = "Arrow", PO = 6000m, Qty = 200000m, PIC = "James" },
                new { Id = 13, Rev = "A01", Sec = "ASM1", Date = "2025-06-01", PN = "A0007261935", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "WPG VN", PO = 2000m, Qty = 2000m, PIC = "Dang Anh" },
                new { Id = 14, Rev = "A01", Sec = "ASM1", Date = "2025-06-01", PN = "A0007261935", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "SANLI", PO = 5500m, Qty = 27500m, PIC = "Dang Anh" },
                new { Id = 15, Rev = "A01", Sec = "ASM1", Date = "2025-06-01", PN = "A0007261935", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "SANLI", PO = 4000m, Qty = 12000m, PIC = "Dang Anh" },
                new { Id = 16, Rev = "A01", Sec = "ASM1", Date = "2025-06-01", PN = "A0007261935", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "SANLI", PO = 57500m, Qty = 57500m, PIC = "Dang Anh" },
                new { Id = 17, Rev = "A01", Sec = "ASM1", Date = "2025-06-01", PN = "A0007261935", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "WPG VN", PO = 4000m, Qty = 4000m, PIC = "Dang Anh" },
                new { Id = 18, Rev = "A01", Sec = "ASM1", Date = "2025-07-01", PN = "445-0733575", Ref = (string)null, Mfg = "MOLEX", LT = 22m, Cost = 0m, Vendor = "HEILI", PO = 1m, Qty = 1000m, PIC = "Dang Anh" }
            };

            foreach (var r in dataRows)
            {
                _mockComponents.Add(new Component
                {
                    Id = r.Id,
                    Revision = r.Rev,
                    Section = r.Sec,
                    SubSection = null,
                    QuotationDate = DateTime.Parse(r.Date),
                    Customer = r.PN.StartsWith("445") ? "GENTOP" : "GENERAC",
                    InternalPN = r.PN,
                    GIL_PN_Ref = r.Ref,
                    Manufacturer = r.Mfg,
                    LeadTime = r.LT,
                    TargetPrice = 0.0000m,
                    PercentPricing = r.Cost == 0 ? 0.00m : ((r.PO - r.Cost) / r.Cost) * 100,
                    CostBOM = r.Cost,
                    Vendor = r.Vendor,
                    POPrice = r.PO,
                    POQty = r.Qty,
                    PIC_Section = r.PIC,
                    Status = "Active",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                });
            }

            // Trial GIL PN P011428_P
            _mockComponents.Add(new Component
            {
                Id = 19,
                Revision = "A01",
                Section = "ASM2",
                SubSection = null,
                QuotationDate = DateTime.Parse("2026-03-10"),
                Customer = "GENTOP",
                InternalPN = "P011428_P",
                GIL_PN_Ref = "B029981",
                Spec = "Trial GIL Component PN",
                Manufacturer = "MOLEX",
                LeadTime = 10.00m,
                TargetPrice = 5.5000m,
                PercentPricing = 16.00m,
                CostBOM = 5.0000m,
                Vendor = "AVNET",
                POPrice = 5.8000m,
                POQty = 50000.00m,
                PIC_Section = "Dang Anh",
                Status = "Active",
                CreatedBy = "System",
                CreatedDate = DateTime.Now
            });

            // Permissions
            _mockPermissions.Add(new UserPermission { Id = 1, Username = "james", Section = "ASM1", HasRead = true, HasWrite = true, AssignedBy = "Admin", AssignedDate = DateTime.Now });
            _mockPermissions.Add(new UserPermission { Id = 2, Username = "james", Section = "ASM2", HasRead = true, HasWrite = false, AssignedBy = "Admin", AssignedDate = DateTime.Now });
            _mockPermissions.Add(new UserPermission { Id = 3, Username = "danganh", Section = "ASM1", HasRead = true, HasWrite = true, AssignedBy = "Admin", AssignedDate = DateTime.Now });
            _mockPermissions.Add(new UserPermission { Id = 4, Username = "danganh", Section = "ASM2", HasRead = true, HasWrite = true, AssignedBy = "Admin", AssignedDate = DateTime.Now });
        }

        // --- Core Fetching Actions ---

        public static List<Component> GetAllComponents()
        {
            if (UseInMemoryMock)
            {
                return _mockComponents.ToList();
            }

            var list = new List<Component>();
            string query = "SELECT * FROM ComponentsMaster ORDER BY Id";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(ReadComponent(r));
                        }
                    }
                }
            }
            return list;
        }

        public static Component GetById(int id)
        {
            if (UseInMemoryMock)
            {
                return _mockComponents.FirstOrDefault(x => x.Id == id);
            }

            string query = "SELECT * FROM ComponentsMaster WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read()) return ReadComponent(r);
                    }
                }
            }
            return null;
        }

        private static Component ReadComponent(SqlDataReader r)
        {
            return new Component
            {
                Id = Convert.ToInt32(r["Id"]),
                Revision = r["Revision"].ToString(),
                Section = r["Section"].ToString(),
                SubSection = r["SubSection"] == DBNull.Value ? null : r["SubSection"].ToString(),
                QuotationDate = r["QuotationDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["QuotationDate"]),
                EffectiveDate = r["EffectiveDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["EffectiveDate"]),
                Customer = r["Customer"] == DBNull.Value ? null : r["Customer"].ToString(),
                CustomerPN = r["CustomerPN"] == DBNull.Value ? null : r["CustomerPN"].ToString(),
                InternalPN = r["InternalPN"].ToString(),
                GIL_PN_Ref = r["GIL_PN_Ref"] == DBNull.Value ? null : r["GIL_PN_Ref"].ToString(),
                Spec = r["Spec"] == DBNull.Value ? null : r["Spec"].ToString(),
                Manufacturer = r["Manufacturer"] == DBNull.Value ? null : r["Manufacturer"].ToString(),
                LeadTime = Convert.ToDecimal(r["LeadTime"]),
                TargetPrice = Convert.ToDecimal(r["TargetPrice"]),
                PercentPricing = Convert.ToDecimal(r["PercentPricing"]),
                CostBOM = Convert.ToDecimal(r["CostBOM"]),
                Vendor = r["Vendor"] == DBNull.Value ? null : r["Vendor"].ToString(),
                POPrice = Convert.ToDecimal(r["POPrice"]),
                POQty = Convert.ToDecimal(r["POQty"]),
                PIC_Section = r["PIC_Section"] == DBNull.Value ? null : r["PIC_Section"].ToString(),
                Status = r["Status"].ToString(),
                CreatedBy = r["CreatedBy"].ToString(),
                CreatedDate = Convert.ToDateTime(r["CreatedDate"]),
                UpdatedDate = r["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["UpdatedDate"])
            };
        }

        // --- Save / Update Action with Transaction & History Logger ---

        public static bool UpdateComponent(Component comp, string currentUser)
        {
            Component old = GetById(comp.Id);
            if (old == null) return false;

            if (UseInMemoryMock)
            {
                // Log Changes in-memory
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "Revision", old.Revision, comp.Revision, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "Section", old.Section, comp.Section, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "SubSection", old.SubSection, comp.SubSection, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "QuotationDate", old.QuotationDate?.ToString("yyyy-MM-dd"), comp.QuotationDate?.ToString("yyyy-MM-dd"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "Customer", old.Customer, comp.Customer, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "InternalPN", old.InternalPN, comp.InternalPN, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "GIL_PN_Ref", old.GIL_PN_Ref, comp.GIL_PN_Ref, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "Manufacturer", old.Manufacturer, comp.Manufacturer, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "LeadTime", old.LeadTime.ToString("F2"), comp.LeadTime.ToString("F2"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "TargetPrice", old.TargetPrice.ToString("F4"), comp.TargetPrice.ToString("F4"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "CostBOM", old.CostBOM.ToString("F4"), comp.CostBOM.ToString("F4"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "Vendor", old.Vendor, comp.Vendor, currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "POPrice", old.POPrice.ToString("F4"), comp.POPrice.ToString("F4"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "POQty", old.POQty.ToString("F2"), comp.POQty.ToString("F2"), currentUser);
                LogMockChangeIfDifferent(comp.Id, comp.InternalPN, "PIC_Section", old.PIC_Section, comp.PIC_Section, currentUser);

                // Update details
                var index = _mockComponents.FindIndex(x => x.Id == comp.Id);
                if (index != -1)
                {
                    comp.UpdatedDate = DateTime.Now;
                    _mockComponents[index] = comp;
                }
                return true;
            }

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"UPDATE ComponentsMaster SET 
                            Revision = @Revision,
                            Section = @Section,
                            SubSection = @SubSection,
                            QuotationDate = @QuotationDate,
                            EffectiveDate = @EffectiveDate,
                            Customer = @Customer,
                            CustomerPN = @CustomerPN,
                            InternalPN = @InternalPN,
                            GIL_PN_Ref = @GIL_PN_Ref,
                            Spec = @Spec,
                            Manufacturer = @Manufacturer,
                            LeadTime = @LeadTime,
                            TargetPrice = @TargetPrice,
                            PercentPricing = @PercentPricing,
                            CostBOM = @CostBOM,
                            Vendor = @Vendor,
                            POPrice = @POPrice,
                            POQty = @POQty,
                            PIC_Section = @PIC_Section,
                            Status = @Status,
                            UpdatedDate = GETDATE()
                            WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Revision", comp.Revision ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Section", comp.Section ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@SubSection", comp.SubSection ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@QuotationDate", comp.QuotationDate ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@EffectiveDate", comp.EffectiveDate ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Customer", comp.Customer ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@CustomerPN", comp.CustomerPN ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@InternalPN", comp.InternalPN ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@GIL_PN_Ref", comp.GIL_PN_Ref ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Spec", comp.Spec ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Manufacturer", comp.Manufacturer ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@LeadTime", comp.LeadTime);
                            cmd.Parameters.AddWithValue("@TargetPrice", comp.TargetPrice);
                            cmd.Parameters.AddWithValue("@PercentPricing", comp.PercentPricing);
                            cmd.Parameters.AddWithValue("@CostBOM", comp.CostBOM);
                            cmd.Parameters.AddWithValue("@Vendor", comp.Vendor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@POPrice", comp.POPrice);
                            cmd.Parameters.AddWithValue("@POQty", comp.POQty);
                            cmd.Parameters.AddWithValue("@PIC_Section", comp.PIC_Section ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Status", comp.Status ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Id", comp.Id);

                            cmd.ExecuteNonQuery();
                        }

                        // Write to HistoryChanges table
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "Revision", old.Revision, comp.Revision, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "Section", old.Section, comp.Section, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "SubSection", old.SubSection, comp.SubSection, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "QuotationDate", old.QuotationDate?.ToString("yyyy-MM-dd"), comp.QuotationDate?.ToString("yyyy-MM-dd"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "Customer", old.Customer, comp.Customer, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "InternalPN", old.InternalPN, comp.InternalPN, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "GIL_PN_Ref", old.GIL_PN_Ref, comp.GIL_PN_Ref, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "Manufacturer", old.Manufacturer, comp.Manufacturer, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "LeadTime", old.LeadTime.ToString("F2"), comp.LeadTime.ToString("F2"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "TargetPrice", old.TargetPrice.ToString("F4"), comp.TargetPrice.ToString("F4"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "CostBOM", old.CostBOM.ToString("F4"), comp.CostBOM.ToString("F4"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "Vendor", old.Vendor, comp.Vendor, currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "POPrice", old.POPrice.ToString("F4"), comp.POPrice.ToString("F4"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "POQty", old.POQty.ToString("F2"), comp.POQty.ToString("F2"), currentUser);
                        LogDbChangeIfDifferent(conn, trans, comp.Id, comp.InternalPN, "PIC_Section", old.PIC_Section, comp.PIC_Section, currentUser);

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void LogDbChangeIfDifferent(SqlConnection conn, SqlTransaction trans, int compId, string internalPn, string field, string oldVal, string newVal, string user)
        {
            if (oldVal == newVal || (string.IsNullOrEmpty(oldVal) && string.IsNullOrEmpty(newVal))) return;

            string query = @"INSERT INTO HistoryChanges (ComponentId, InternalPN, FieldName, OldValue, NewValue, ChangedBy, ChangedDate) 
                            VALUES (@ComponentId, @InternalPN, @FieldName, @OldValue, @NewValue, @ChangedBy, GETDATE())";
            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@ComponentId", compId);
                cmd.Parameters.AddWithValue("@InternalPN", internalPn ?? "");
                cmd.Parameters.AddWithValue("@FieldName", field);
                cmd.Parameters.AddWithValue("@OldValue", oldVal ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NewValue", newVal ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ChangedBy", user);
                cmd.ExecuteNonQuery();
            }
        }

        private static void LogMockChangeIfDifferent(int compId, string internalPn, string field, string oldVal, string newVal, string user)
        {
            if (oldVal == newVal || (string.IsNullOrEmpty(oldVal) && string.IsNullOrEmpty(newVal))) return;

            _mockHistory.Insert(0, new HistoryChange
            {
                Id = _mockHistory.Count + 1,
                ComponentId = compId,
                InternalPN = internalPn,
                FieldName = field,
                OldValue = oldVal,
                NewValue = newVal,
                ChangedBy = user,
                ChangedDate = DateTime.Now
            });
        }

        // --- Bulk Update PIC for a specific Section ---

        public static bool AssignPICForSection(string section, string picName, string currentUser)
        {
            if (UseInMemoryMock)
            {
                var matching = _mockComponents.Where(x => x.Section.Equals(section, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var item in matching)
                {
                    string oldPic = item.PIC_Section;
                    item.PIC_Section = picName;
                    LogMockChangeIfDifferent(item.Id, item.InternalPN, "PIC_Section", oldPic, picName, currentUser);
                }
                return true;
            }

            string query = "UPDATE ComponentsMaster SET PIC_Section = @PIC WHERE Section = @Section";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Fetch ids to log
                        var idsToUpdate = new List<Tuple<int, string, string>>();
                        string selectQuery = "SELECT Id, InternalPN, PIC_Section FROM ComponentsMaster WHERE Section = @Section";
                        using (SqlCommand selCmd = new SqlCommand(selectQuery, conn, trans))
                        {
                            selCmd.Parameters.AddWithValue("@Section", section);
                            using (SqlDataReader r = selCmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    idsToUpdate.Add(Tuple.Create(Convert.ToInt32(r["Id"]), r["InternalPN"].ToString(), r["PIC_Section"].ToString()));
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@PIC", picName ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Section", section);
                            cmd.ExecuteNonQuery();
                        }

                        // Audit log
                        foreach (var item in idsToUpdate)
                        {
                            LogDbChangeIfDifferent(conn, trans, item.Item1, item.Item2, "PIC_Section", item.Item3, picName, currentUser);
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // --- Permissions Logic ---

        public static List<UserPermission> GetUserPermissions()
        {
            if (UseInMemoryMock)
            {
                return _mockPermissions.ToList();
            }

            var list = new List<UserPermission>();
            string query = "SELECT * FROM UserPermissions ORDER BY Username, Section";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new UserPermission
                            {
                                Id = Convert.ToInt32(r["Id"]),
                                Username = r["Username"].ToString(),
                                Section = r["Section"].ToString(),
                                HasRead = Convert.ToBoolean(r["HasRead"]),
                                HasWrite = Convert.ToBoolean(r["HasWrite"]),
                                AssignedBy = r["AssignedBy"].ToString(),
                                AssignedDate = Convert.ToDateTime(r["AssignedDate"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static bool SaveUserPermission(string username, string section, bool hasRead, bool hasWrite, string currentUser)
        {
            username = username.Trim().ToLower();
            if (UseInMemoryMock)
            {
                var existing = _mockPermissions.FirstOrDefault(x => x.Username == username && x.Section == section);
                if (existing != null)
                {
                    existing.HasRead = hasRead;
                    existing.HasWrite = hasWrite;
                    existing.AssignedBy = currentUser;
                    existing.AssignedDate = DateTime.Now;
                }
                else
                {
                    _mockPermissions.Add(new UserPermission
                    {
                        Id = _mockPermissions.Count + 1,
                        Username = username,
                        Section = section,
                        HasRead = hasRead,
                        HasWrite = hasWrite,
                        AssignedBy = currentUser,
                        AssignedDate = DateTime.Now
                    });
                }
                return true;
            }

            string checkQuery = "SELECT COUNT(1) FROM UserPermissions WHERE Username = @Username AND Section = @Section";
            string insertQuery = @"INSERT INTO UserPermissions (Username, Section, HasRead, HasWrite, AssignedBy, AssignedDate) 
                                   VALUES (@Username, @Section, @HasRead, @HasWrite, @AssignedBy, GETDATE())";
            string updateQuery = @"UPDATE UserPermissions SET HasRead = @HasRead, HasWrite = @HasWrite, 
                                   AssignedBy = @AssignedBy, AssignedDate = GETDATE() 
                                   WHERE Username = @Username AND Section = @Section";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                bool exists = false;
                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Section", section);
                    exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }

                string query = exists ? updateQuery : insertQuery;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@HasRead", hasRead);
                    cmd.Parameters.AddWithValue("@HasWrite", hasWrite);
                    cmd.Parameters.AddWithValue("@AssignedBy", currentUser);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // --- Audit Log Retrieval ---

        public static List<HistoryChange> GetHistoryChanges()
        {
            if (UseInMemoryMock)
            {
                return _mockHistory.ToList();
            }

            var list = new List<HistoryChange>();
            string query = "SELECT * FROM HistoryChanges ORDER BY ChangedDate DESC";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new HistoryChange
                            {
                                Id = Convert.ToInt32(r["Id"]),
                                ComponentId = Convert.ToInt32(r["ComponentId"]),
                                InternalPN = r["InternalPN"].ToString(),
                                FieldName = r["FieldName"].ToString(),
                                OldValue = r["OldValue"] == DBNull.Value ? null : r["OldValue"].ToString(),
                                NewValue = r["NewValue"] == DBNull.Value ? null : r["NewValue"].ToString(),
                                ChangedBy = r["ChangedBy"].ToString(),
                                ChangedDate = Convert.ToDateTime(r["ChangedDate"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // --- Utility Fetching ---

        public static List<string> GetAllSections()
        {
            if (UseInMemoryMock)
            {
                return _mockComponents.Select(x => x.Section).Distinct().OrderBy(x => x).ToList();
            }

            var list = new List<string>();
            string query = "SELECT DISTINCT Section FROM ComponentsMaster ORDER BY Section";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(r["Section"].ToString());
                        }
                    }
                }
            }
            return list;
        }
    }
}
