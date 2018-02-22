using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeItCustomer.DsCustomerTableAdapters;
using static TimeItCustomer.DsCustomer;

namespace TimeItCustomer
{
    public partial class TaskWindow : Form
    {
        public delegate void CustomDelegate();
        public event CustomDelegate CustomEvent;
        private tasksTableAdapter taskAdapter;
        private tasksDataTable tTable;
        private Font headFont = new Font("Areal", 8f, FontStyle.Regular);
        private int MouseOverCurrentRow;
        public int _passingActivityID { get; set; }

        public TaskWindow(int PassingActivityID)
        {
            InitializeComponent();
            this.CenterToScreen();
            _passingActivityID = PassingActivityID;
            populateTaskListbox();
            dgvTask.Font = headFont;
        }

        #region TaskEvents

        private void dgvTask_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    MouseOverCurrentRow = dgvTask.HitTest(e.X, e.Y).RowIndex;
                    if (dgvTask.Rows.Count - 1 > 0 && MouseOverCurrentRow < dgvTask.Rows.Count - 1)
                    {
                        ContextMenu cm = new ContextMenu();
                        cm.MenuItems.Add("Lägg till ny task", AddNewRowToLwTask);
                        dgvTask.ClearSelection();
                        dgvTask.Rows[MouseOverCurrentRow].Selected = true;
                        cm.Show(dgvTask, new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTaskSave_Click_1(object sender, EventArgs e)
        {
            SaveTask();
            populateTaskListbox();
            RaiseAnEvent();
        }

        private void dgvTask_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvTask.Columns[e.ColumnIndex].Name == "chkCol" && e.RowIndex != dgvTask.Rows.Count - 1)
                {
                    bool IsChecked = Convert.ToBoolean(dgvTask[e.ColumnIndex, e.RowIndex].Value);

                    if (dgvTask.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                    {
                        dgvTask.Rows[e.RowIndex].Cells[1].Value = string.Empty;
                    }

                    if (IsChecked.Equals(false))
                    {
                        dgvTask.Rows[e.RowIndex].Cells[5].Value = true;
                        dgvTask.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Areal", 8f, FontStyle.Bold);
                        dgvTask.Rows[e.RowIndex].Cells[1].Style.Padding = new Padding(0, 0, 0, 0);
                        gbTaskwindow.Focus();
                    }
                    if (IsChecked.Equals(true))
                    {
                        dgvTask.Rows[e.RowIndex].Cells[5].Value = false;
                        dgvTask.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Areal", 8f, FontStyle.Regular);
                        dgvTask.Rows[e.RowIndex].Cells[1].Style.Padding = new Padding(20, 0, 0, 0);
                        gbTaskwindow.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddNewRowToLwTask(object sender, EventArgs e)
        {
            try
            {
                tasksRow newRow = tTable.NewtasksRow();

                string newInvoiceCode = (string)dgvTask.Rows[MouseOverCurrentRow].Cells[0].Value;

                string value = Regex.Replace(newInvoiceCode, "[A-Za-z ]", "");
                int parsedValue;
                if (string.IsNullOrWhiteSpace(value))
                {
                    parsedValue = 0;
                }
                else
                {
                    parsedValue = int.Parse(value);
                }

                newRow.invoiceCode = (parsedValue + 1).ToString();
                newRow.status = 0;
                newRow.activityID = _passingActivityID;
                tTable.Rows.Add(newRow);
                this.dgvTask.Sort(this.dgvTask.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTaskCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnRevert_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgvTask.DataSource = null;
                populateTaskListbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvTask_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = _passingActivityID;
            e.Row.Cells[5].Value = 0;
            e.Row.DefaultCellStyle.Font = new Font("Areal", 8f, FontStyle.Regular);
        }

        #endregion

        #region TaskMethods

        private void populateTaskListbox()  
        {
            try
            {
                taskAdapter = new tasksTableAdapter();
                tTable = taskAdapter.GetTaskOnActivityIDOrderByInvoiceCode(_passingActivityID);
                taskAdapter.Dispose();

                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font(headFont, FontStyle.Bold);

                dgvTask.RowHeadersVisible = false;
                dgvTask.AutoGenerateColumns = false;

                dgvTask.ColumnCount = 5;

                dgvTask.Columns[0].HeaderText = "Fakturakod";
                dgvTask.Columns[0].DataPropertyName = "invoiceCode";
                dgvTask.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTask.Columns[0].HeaderCell.Style = headerStyle;
                dgvTask.Columns[0].Name = "InvoiceCode";

                dgvTask.Columns[1].HeaderText = "Beskrivning";
                dgvTask.Columns[1].DataPropertyName = "description";
                dgvTask.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTask.Columns[1].HeaderCell.Style = headerStyle;

                dgvTask.Columns[2].HeaderText = "Budgettimmar";
                dgvTask.Columns[2].DataPropertyName = "budgethours";
                dgvTask.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTask.Columns[2].HeaderCell.Style = headerStyle;

                dgvTask.Columns[3].HeaderText = "Beräknade_timmar";
                dgvTask.Columns[3].DataPropertyName = "estimatedHours";
                dgvTask.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTask.Columns[3].HeaderCell.Style = headerStyle;

                dgvTask.Columns[4].HeaderText = "ActivityID";
                dgvTask.Columns[4].DataPropertyName = "activityID";
                dgvTask.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTask.Columns[4].HeaderCell.Style = headerStyle;
                dgvTask.Columns[4].Visible = false;

                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                chkCol.HeaderText = "Rubrik";
                chkCol.TrueValue = 1;
                chkCol.FalseValue = 0;
                chkCol.Name = "chkCol";
                chkCol.DataPropertyName = "status";
                chkCol.HeaderCell.Style = headerStyle;
                dgvTask.Columns.Add(chkCol);

                dgvTask.DataSource = tTable;

                if (dgvTask.Rows.Count - 1 >= 0)
                {
                    BeginInvoke((Action)(() => { LoopDgvAndSetStyle(); }));
                }
                this.dgvTask.Sort(this.dgvTask.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveTask()
        {
            try
            {
                foreach (DataGridViewRow row in dgvTask.Rows)
                {
                    bool IsChecked = Convert.ToBoolean(row.Cells[5].Value);

                    if (row.Cells[1].Value == DBNull.Value)
                    {
                        row.Cells[1].Value = string.Empty;
                    }
                }
                taskAdapter = new tasksTableAdapter();
                taskAdapter.Update((tasksDataTable)dgvTask.DataSource);
                taskAdapter.Dispose();
                dgvTask.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoopDgvAndSetStyle()
        {
            try
            {
                foreach (DataGridViewRow row in dgvTask.Rows)
                {
                    bool IsChecked = Convert.ToBoolean(row.Cells[5].Value);

                    if (IsChecked.Equals(false))
                    {
                        row.DefaultCellStyle.Font = new Font("Areal", 8f, FontStyle.Regular);
                        row.Cells[1].Style.Padding = new Padding(20, 0, 0, 0);
                    }
                    else if (IsChecked.Equals(true))
                    {
                        row.DefaultCellStyle.Font = new Font("Areal", 8f, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        #endregion
        
        public void RaiseAnEvent()
        {
            CustomEvent();
        }
    }
}
