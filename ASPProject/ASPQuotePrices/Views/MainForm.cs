using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormApp.Helpers;
using WinFormApp.Models;

namespace WinFormApp.Views
{
    public partial class MainForm : Form
    {
        private List<Component> _allComponents = new List<Component>();
        private Component _selectedComponent = null;

        public MainForm()
        {
            InitializeComponent();
            SetupEditorControls();
            StyleGrids();
            
            this.Load += MainForm_Load;
            
            // Grid Component event
            dgvComponents.SelectionChanged += DgvComponents_SelectionChanged;

            // Search events
            txtSearchPN.Enter += TxtSearchPN_Enter;
            txtSearchPN.Leave += TxtSearchPN_Leave;
            txtSearchPN.TextChanged += TxtSearchPN_TextChanged;
            cmbFilterSection.SelectedIndexChanged += CmbFilterSection_SelectedIndexChanged;
            btnClearFilters.Click += BtnClearFilters_Click;

            // Action events
            btnAddNew.Click += BtnAddNew_Click;
            btnSaveComponent.Click += BtnSaveComponent_Click;
            btnCheckGaps.Click += BtnCheckGaps_Click;

            // PIC events
            txtPICName.Enter += TxtPICName_Enter;
            txtPICName.Leave += TxtPICName_Leave;
            btnSavePIC.Click += BtnSavePIC_Click;

            // Permission events
            txtPermUser.Enter += TxtPermUser_Enter;
            txtPermUser.Leave += TxtPermUser_Leave;
            btnSavePerm.Click += BtnSavePerm_Click;

            // History search event
            txtSearchHistory.Enter += TxtSearchHistory_Enter;
            txtSearchHistory.Leave += TxtSearchHistory_Leave;
            txtSearchHistory.TextChanged += TxtSearchHistory_TextChanged;

            txtCurrentUser.TextChanged += TxtCurrentUser_TextChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshData();

            // Load sections filter
            var sections = DbHelper.GetAllSections();
            cmbFilterSection.Items.Clear();
            cmbFilterSection.Items.Add("All Sections");
            foreach (var s in sections) cmbFilterSection.Items.Add(s);
            cmbFilterSection.SelectedIndex = 0;

            cmbPICSection.Items.Clear();
            cmbPermSection.Items.Clear();
            foreach (var s in sections)
            {
                cmbPICSection.Items.Add(s);
                cmbPermSection.Items.Add(s);
            }
            if (cmbPICSection.Items.Count > 0) cmbPICSection.SelectedIndex = 0;
            if (cmbPermSection.Items.Count > 0) cmbPermSection.SelectedIndex = 0;

            // 2. Automatically Pop up to team the GAP LT, pricing, % pricing, sources with PO and Cost BOM on load!
            ShowGapAnalysisPopup();
        }

        private void RefreshData()
        {
            try
            {
                _allComponents = DbHelper.GetAllComponents();
                ApplyComponentFilters();

                // PIC list
                var picGroup = _allComponents
                    .Where(x => !string.IsNullOrEmpty(x.Section))
                    .GroupBy(x => x.Section)
                    .Select(g => new { Section = g.Key, PIC = g.FirstOrDefault()?.PIC_Section ?? "N/A", ComponentCount = g.Count() })
                    .ToList();
                dgvPICList.DataSource = picGroup;

                // Permissions list
                dgvPermissions.DataSource = DbHelper.GetUserPermissions();

                // History logs
                dgvHistory.DataSource = DbHelper.GetHistoryChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection issue. Running in in-memory Mock Mode.\nDetails: {ex.Message}", "Database Offline", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DbHelper.UseInMemoryMock = true;
                RefreshData();
            }
        }

        private void StyleGrids()
        {
            var grids = new[] { dgvComponents, dgvPICList, dgvPermissions, dgvHistory };
            foreach (var grid in grids)
            {
                grid.BackgroundColor = Color.FromArgb(30, 41, 59);
                grid.ForeColor = Color.White;
                grid.GridColor = Color.FromArgb(51, 65, 85);
                grid.BorderStyle = BorderStyle.None;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                grid.RowHeadersVisible = false;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.EnableHeadersVisualStyles = false;

                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 8, 5, 8);

                grid.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
                grid.DefaultCellStyle.ForeColor = Color.White;
                grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(99, 102, 241);
                grid.DefaultCellStyle.SelectionForeColor = Color.White;
                grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                grid.DefaultCellStyle.Padding = new Padding(4);

                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void SetupEditorControls()
        {
            panelCompEditor.AutoScroll = true;

            panelCompEditor.Controls.Add(lblEditorTitle);
            int startY = 55;
            int gapY = 52;
            int labelWidth = 110;
            int inputWidth = 160;

            var fields = new[]
            {
                new { Label = "Revision", Box = txtEditRevision },
                new { Label = "Section", Box = txtEditSection },
                new { Label = "Internal PN", Box = txtEditInternalPN },
                new { Label = "GIL Ref PN", Box = txtEditGILRef },
                new { Label = "Manufacturer", Box = txtEditManufacturer },
                new { Label = "Lead Time (Wk)", Box = txtEditLeadTime },
                new { Label = "Cost BOM ($)", Box = txtEditCostBOM },
                new { Label = "Vendor", Box = txtEditVendor },
                new { Label = "PO Price ($)", Box = txtEditPOPrice },
                new { Label = "PO Qty", Box = txtEditPOQty },
                new { Label = "PIC Section", Box = txtEditPIC }
            };

            foreach (var f in fields)
            {
                Label lbl = new Label
                {
                    Text = f.Label,
                    ForeColor = Color.White,
                    Location = new Point(15, startY + 3),
                    Size = new Size(labelWidth, 20),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                f.Box.Location = new Point(135, startY);
                f.Box.Size = new Size(inputWidth, 26);
                f.Box.BackColor = Color.FromArgb(51, 65, 85);
                f.Box.ForeColor = Color.White;
                f.Box.BorderStyle = BorderStyle.FixedSingle;

                panelCompEditor.Controls.Add(lbl);
                panelCompEditor.Controls.Add(f.Box);
                startY += gapY;
            }

            btnSaveComponent.Location = new Point(15, startY + 10);
            btnSaveComponent.Size = new Size(280, 36);
            btnSaveComponent.BackColor = Color.FromArgb(16, 185, 129);
            btnSaveComponent.FlatStyle = FlatStyle.Flat;
            btnSaveComponent.FlatAppearance.BorderSize = 0;
            btnSaveComponent.ForeColor = Color.White;
            btnSaveComponent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveComponent.Text = "Save Component Details";
            panelCompEditor.Controls.Add(btnSaveComponent);
        }

        private void ApplyComponentFilters()
        {
            var filtered = _allComponents.AsEnumerable();

            string search = txtSearchPN.Text.Trim();
            if (!string.IsNullOrEmpty(search) && search != "Search Part Number...")
            {
                filtered = filtered.Where(x => 
                    (x.InternalPN != null && x.InternalPN.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (x.Vendor != null && x.Vendor.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (x.Manufacturer != null && x.Manufacturer.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }

            if (cmbFilterSection.SelectedIndex > 0)
            {
                string selectedSec = cmbFilterSection.SelectedItem.ToString();
                filtered = filtered.Where(x => x.Section == selectedSec);
            }

            dgvComponents.DataSource = filtered.ToList();
            
            // Format column names
            if (dgvComponents.Columns.Count > 0)
            {
                dgvComponents.Columns["Id"].Visible = true;
                dgvComponents.Columns["CreatedBy"].Visible = false;
                dgvComponents.Columns["CreatedDate"].Visible = false;
                dgvComponents.Columns["UpdatedDate"].Visible = false;
                dgvComponents.Columns["Status"].Visible = false;
                dgvComponents.Columns["IsPricingGapWarning"].Visible = false;
                dgvComponents.Columns["IsLeadTimeWarning"].Visible = false;

                dgvComponents.Columns["Revision"].Width = 60;
                dgvComponents.Columns["Section"].Width = 60;
                dgvComponents.Columns["InternalPN"].HeaderText = "Part Number";
                dgvComponents.Columns["GIL_PN_Ref"].HeaderText = "GIL Ref";
                dgvComponents.Columns["LeadTime"].HeaderText = "Lead Time";
                dgvComponents.Columns["CostBOM"].HeaderText = "Cost BOM";
                dgvComponents.Columns["POPrice"].HeaderText = "PO Price";
                dgvComponents.Columns["POQty"].HeaderText = "PO Qty";
                dgvComponents.Columns["PIC_Section"].HeaderText = "PIC Section";
            }
        }

        // --- Permissions Enforcement Checker ---
        private bool CheckWritePermission(string section)
        {
            string username = txtCurrentUser.Text.Trim().ToLower();
            if (username == "admin") return true; // Administrator overrides

            if (DbHelper.UseInMemoryMock)
            {
                var perm = DbHelper.GetUserPermissions().FirstOrDefault(x => x.Username == username && x.Section == section);
                return perm != null && perm.HasWrite;
            }

            // Real DB check
            var userPerms = DbHelper.GetUserPermissions();
            var matched = userPerms.FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && p.Section == section);
            return matched != null && matched.HasWrite;
        }

        private void DgvComponents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComponents.SelectedRows.Count == 0)
            {
                _selectedComponent = null;
                ClearEditorFields();
                return;
            }

            var row = dgvComponents.SelectedRows[0];
            _selectedComponent = row.DataBoundItem as Component;
            if (_selectedComponent != null)
            {
                txtEditRevision.Text = _selectedComponent.Revision;
                txtEditSection.Text = _selectedComponent.Section;
                txtEditInternalPN.Text = _selectedComponent.InternalPN;
                txtEditGILRef.Text = _selectedComponent.GIL_PN_Ref;
                txtEditManufacturer.Text = _selectedComponent.Manufacturer;
                txtEditLeadTime.Text = _selectedComponent.LeadTime.ToString("F2");
                txtEditCostBOM.Text = _selectedComponent.CostBOM.ToString("F4");
                txtEditVendor.Text = _selectedComponent.Vendor;
                txtEditPOPrice.Text = _selectedComponent.POPrice.ToString("F4");
                txtEditPOQty.Text = _selectedComponent.POQty.ToString("F2");
                txtEditPIC.Text = _selectedComponent.PIC_Section;

                // Permissions logic enforcement
                bool canWrite = CheckWritePermission(_selectedComponent.Section);
                lblEditorTitle.Text = canWrite ? "Edit Component" : "Preview (Read Only)";
                lblEditorTitle.ForeColor = canWrite ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);

                // Enable/disable textboxes based on permissions
                txtEditRevision.Enabled = canWrite;
                txtEditSection.Enabled = canWrite;
                txtEditInternalPN.Enabled = canWrite;
                txtEditGILRef.Enabled = canWrite;
                txtEditManufacturer.Enabled = canWrite;
                txtEditLeadTime.Enabled = canWrite;
                txtEditCostBOM.Enabled = canWrite;
                txtEditVendor.Enabled = canWrite;
                txtEditPOPrice.Enabled = canWrite;
                txtEditPOQty.Enabled = canWrite;
                txtEditPIC.Enabled = canWrite;
                btnSaveComponent.Enabled = canWrite;
            }
        }

        private void ClearEditorFields()
        {
            txtEditRevision.Text = "";
            txtEditSection.Text = "";
            txtEditInternalPN.Text = "";
            txtEditGILRef.Text = "";
            txtEditManufacturer.Text = "";
            txtEditLeadTime.Text = "0.00";
            txtEditCostBOM.Text = "0.0000";
            txtEditVendor.Text = "";
            txtEditPOPrice.Text = "0.0000";
            txtEditPOQty.Text = "0.00";
            txtEditPIC.Text = "";
            lblEditorTitle.Text = "No Record Selected";
            lblEditorTitle.ForeColor = Color.LightGray;
        }

        // --- Save Component Action ---

        private void BtnSaveComponent_Click(object sender, EventArgs e)
        {
            if (_selectedComponent == null)
            {
                MessageBox.Show("Please select or add a component first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string section = txtEditSection.Text.Trim();
            if (!CheckWritePermission(section))
            {
                MessageBox.Show($"Access Denied: Current user '{txtCurrentUser.Text}' does not have Write permission for Section '{section}'.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                Component updated = new Component
                {
                    Id = _selectedComponent.Id,
                    Revision = txtEditRevision.Text.Trim(),
                    Section = section,
                    SubSection = _selectedComponent.SubSection,
                    QuotationDate = _selectedComponent.QuotationDate,
                    EffectiveDate = _selectedComponent.EffectiveDate,
                    Customer = _selectedComponent.Customer,
                    CustomerPN = _selectedComponent.CustomerPN,
                    InternalPN = txtEditInternalPN.Text.Trim(),
                    GIL_PN_Ref = txtEditGILRef.Text.Trim(),
                    Spec = _selectedComponent.Spec,
                    Manufacturer = txtEditManufacturer.Text.Trim(),
                    LeadTime = Convert.ToDecimal(txtEditLeadTime.Text),
                    TargetPrice = _selectedComponent.TargetPrice,
                    CostBOM = Convert.ToDecimal(txtEditCostBOM.Text),
                    Vendor = txtEditVendor.Text.Trim(),
                    POPrice = Convert.ToDecimal(txtEditPOPrice.Text),
                    POQty = Convert.ToDecimal(txtEditPOQty.Text),
                    PIC_Section = txtEditPIC.Text.Trim(),
                    Status = "Active"
                };

                // Auto calculate percent pricing gap
                if (updated.CostBOM != 0)
                {
                    updated.PercentPricing = ((updated.POPrice - updated.CostBOM) / updated.CostBOM) * 100;
                }

                bool success = DbHelper.UpdateComponent(updated, txtCurrentUser.Text.Trim());
                if (success)
                {
                    MessageBox.Show("Component details updated successfully and change audited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save component: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            string username = txtCurrentUser.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username in the top panel first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Component newComp = new Component
                {
                    Id = 0,
                    Revision = "A01",
                    Section = "ASM1",
                    InternalPN = "NEW_PART_PN",
                    LeadTime = 12.00m,
                    CostBOM = 0.0000m,
                    POPrice = 0.0000m,
                    POQty = 1000m,
                    Status = "Active",
                    CreatedBy = username,
                    CreatedDate = DateTime.Now
                };

                if (DbHelper.UseInMemoryMock)
                {
                    newComp.Id = DbHelper.GetAllComponents().Max(x => x.Id) + 1;
                    DbHelper.GetAllComponents().Add(newComp);
                }
                else
                {
                    // Add via DbHelper Sql Query
                    using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
                    {
                        string query = @"INSERT INTO ComponentsMaster (Revision, Section, InternalPN, LeadTime, CostBOM, POPrice, POQty, Status, CreatedBy, CreatedDate) 
                                         VALUES ('A01', 'ASM1', 'NEW_PART_PN', 12.00, 0.00, 0.00, 1000.00, 'Active', @User, GETDATE())";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@User", username);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                RefreshData();
                MessageBox.Show("New template component added. Select it in the grid to edit its details.", "Component Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to insert template: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCheckGaps_Click(object sender, EventArgs e)
        {
            ShowGapAnalysisPopup();
        }

        private void ShowGapAnalysisPopup()
        {
            var list = DbHelper.GetAllComponents();
            var alertForm = new GapAlertForm(list);
            alertForm.ShowDialog(this);
        }

        // --- Assign PIC Section ---

        private void BtnSavePIC_Click(object sender, EventArgs e)
        {
            if (cmbPICSection.SelectedIndex == -1) return;
            string section = cmbPICSection.SelectedItem.ToString();
            string pic = txtPICName.Text.Trim();
            if (string.IsNullOrEmpty(pic) || pic == "Enter PIC Name...")
            {
                MessageBox.Show("Please enter a valid PIC name.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = DbHelper.AssignPICForSection(section, pic, txtCurrentUser.Text.Trim());
            if (success)
            {
                MessageBox.Show($"Assigned {pic} as PIC for Section {section}.", "PIC Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
        }

        // --- Assign Section Permissions ---

        private void BtnSavePerm_Click(object sender, EventArgs e)
        {
            string username = txtPermUser.Text.Trim();
            if (string.IsNullOrEmpty(username) || username == "Enter Username...")
            {
                MessageBox.Show("Please enter a valid username.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbPermSection.SelectedIndex == -1) return;
            string section = cmbPermSection.SelectedItem.ToString();

            bool success = DbHelper.SaveUserPermission(username, section, chkPermRead.Checked, chkPermWrite.Checked, txtCurrentUser.Text.Trim());
            if (success)
            {
                MessageBox.Show($"Permissions assigned for user '{username}' on section '{section}'.", "Permission Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
        }

        // --- Search Events and Watermark Placeholders ---

        private void TxtSearchPN_Enter(object sender, EventArgs e)
        {
            if (txtSearchPN.Text == "Search Part Number...")
            {
                txtSearchPN.Text = "";
                txtSearchPN.ForeColor = Color.White;
            }
        }

        private void TxtSearchPN_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPN.Text))
            {
                txtSearchPN.Text = "Search Part Number...";
                txtSearchPN.ForeColor = Color.Gray;
            }
        }

        private void TxtSearchPN_TextChanged(object sender, EventArgs e)
        {
            ApplyComponentFilters();
        }

        private void CmbFilterSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyComponentFilters();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearchPN.Text = "Search Part Number...";
            txtSearchPN.ForeColor = Color.Gray;
            cmbFilterSection.SelectedIndex = 0;
            ApplyComponentFilters();
        }

        private void TxtPICName_Enter(object sender, EventArgs e)
        {
            if (txtPICName.Text == "Enter PIC Name...")
            {
                txtPICName.Text = "";
                txtPICName.ForeColor = Color.White;
            }
        }

        private void TxtPICName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPICName.Text))
            {
                txtPICName.Text = "Enter PIC Name...";
                txtPICName.ForeColor = Color.Gray;
            }
        }

        private void TxtPermUser_Enter(object sender, EventArgs e)
        {
            if (txtPermUser.Text == "Enter Username...")
            {
                txtPermUser.Text = "";
                txtPermUser.ForeColor = Color.White;
            }
        }

        private void TxtPermUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPermUser.Text))
            {
                txtPermUser.Text = "Enter Username...";
                txtPermUser.ForeColor = Color.Gray;
            }
        }

        private void TxtSearchHistory_Enter(object sender, EventArgs e)
        {
            if (txtSearchHistory.Text == "Search Logs...")
            {
                txtSearchHistory.Text = "";
                txtSearchHistory.ForeColor = Color.White;
            }
        }

        private void TxtSearchHistory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchHistory.Text))
            {
                txtSearchHistory.Text = "Search Logs...";
                txtSearchHistory.ForeColor = Color.Gray;
            }
        }

        private void TxtSearchHistory_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchHistory.Text.Trim();
            var logs = DbHelper.GetHistoryChanges();
            if (!string.IsNullOrEmpty(search) && search != "Search Logs...")
            {
                logs = logs.Where(x => 
                    x.InternalPN.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    x.FieldName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    x.OldValue.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    x.NewValue.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    x.ChangedBy.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
            }
            dgvHistory.DataSource = logs;
        }

        private void TxtCurrentUser_TextChanged(object sender, EventArgs e)
        {
            // Trigger selection change to re-evaluate write permissions
            DgvComponents_SelectionChanged(this, EventArgs.Empty);
        }
    }
}
