using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ASPProject
{
    public class GridviewCheckbox
    {
        protected GridView _view;
        protected XtraForm _form;
        protected List<int> _selectedRows = new List<int>();

        public GridviewCheckbox(GridView view, XtraForm form, List<int> selectedRows)
        {
            View = view;
            _form = form;
            _selectedRows = selectedRows;
        }

        public GridView View
        {
            get { return _view; }
            set
            {
                if (_view != value && value != null)
                {
                    _view = value; // <-- ADD This Line
                    _view.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
                    _view.OptionsSelection.EnableAppearanceFocusedCell = false;
                    _view.OptionsSelection.EnableAppearanceFocusedRow = false;
                    _view.OptionsSelection.EnableAppearanceHideSelection = false;
                    _view.OptionsSelection.MultiSelect = true;
                    _view.OptionsSelection.MultiSelectMode =
                        DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                    _view.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                    _view.OptionsView.ShowAutoFilterRow = true;

                    _view.MouseDown += new MouseEventHandler(gridView1_MouseDown);
                    _view.MouseUp += new MouseEventHandler(gridView1_MouseUp);
                    _view.ColumnFilterChanged += gridView1_ColumnFilterChanged;
                }
            }
        }

        void RestoreSelection(GridView view)
        {
            _form.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < _selectedRows.Count; i++)
                    view.SelectRow(view.GetRowHandle(_selectedRows[i]));
            }));
        }
        void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            RestoreSelection(sender as GridView);
        }

        void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            RestoreSelection(view);
        }

        void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            _selectedRows = view.GetSelectedRows().ToList();
            if (hi.Column == null)
                return;
            if (hi.Column.FieldName == "DX$CheckboxSelectorColumn")
            {
                if (!hi.InRow)
                {
                    bool allSelected = view.DataController.Selection.Count == view.DataRowCount;
                    if (!allSelected)
                    {
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int sourceHandle = view.GetDataSourceRowIndex(i);
                            if (!_selectedRows.Contains(sourceHandle))
                                _selectedRows.Add(sourceHandle);
                        }
                    }
                    else _selectedRows.Clear();
                }
                else
                {
                    int sourceHandle = view.GetDataSourceRowIndex(hi.RowHandle);
                    if (!_selectedRows.Contains(sourceHandle))
                        _selectedRows.Add(sourceHandle);
                    else
                        _selectedRows.Remove(sourceHandle);
                }
            }
            RestoreSelection(view);
        }
    }
}
