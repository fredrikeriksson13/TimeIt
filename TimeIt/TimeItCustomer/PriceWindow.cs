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
    public partial class PriceWindow : Form
    {
        private activitiesTableAdapter ActivitiesAdapter;
        private customersTableAdapter CustomerAdapter;

        private TreeNode Activities;
        private int CustomerID;
        private int project;
        private int uppdrag;
        private int deafalultPrice;
        private int defaultOvertime1;
        private int defaultOvertime2;
        private float _price;
        private float _overtime1;
        private float _overtime2;
        private int _counter;

        public PriceWindow(int _customerID, int _project, int _uppdrag, int _deafultPrice, int _deafaultOvertime1, int _defaultOvertime2)

        {
            InitializeComponent();
            deafalultPrice = _deafultPrice;
            defaultOvertime1 = _deafaultOvertime1;
            defaultOvertime2 = _defaultOvertime2;
            txtNewPrice.Text = deafalultPrice.ToString();
            txtNewOvertime1.Text = defaultOvertime1.ToString();
            txtNewOvertime2.Text = defaultOvertime2.ToString();
            project = _project;
            uppdrag = _uppdrag;
            CustomerID = _customerID;

            this.CenterToScreen();
            treeViewHourlyRate.SelectedNode = null;
            GetCustomerProjectData();
        }

        private void ActivityMarkedChecker()
        {
            _counter = 0;
            foreach (TreeNode Parent in treeViewHourlyRate.Nodes)
            {
                if (Parent.Checked == true)
                {
                    _counter++;
                }
                foreach (TreeNode child in Parent.Nodes)
                {
                    if (child.Checked == true)
                    {
                        _counter++;
                    }
                }
            }

            lblCounter.Text = "Antal ibockade :" + _counter;
        }

        private void SavePriceChanges()
        {
            CustomerAdapter = new customersTableAdapter();
            customersDataTable customerDT = CustomerAdapter.GetCustomerDataByID(CustomerID);
            customersRow cRow = (customersRow)customerDT.Rows[0];

            if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
            {
                float.TryParse(txtNewPrice.Text, out _price);
                cRow.stdHourlyPrice = _price;
            }

            if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
            {
                float.TryParse(txtNewOvertime1.Text, out _overtime1);
                cRow.stdOvertime1 = _overtime1;
            }

            if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
            {
                float.TryParse(txtNewOvertime2.Text, out _overtime2);
                cRow.stdOvertime2 = _overtime2;
            }

            CustomerAdapter.Update(customerDT);
            CustomerAdapter.Dispose();

            ActivitiesAdapter = new activitiesTableAdapter();
            activitiesDataTable ActivitiesTable;
            activitiesRow row;

            foreach (TreeNode Parent in treeViewHourlyRate.Nodes)
            {
                if (Parent.Checked == true)
                {
                    ActivitiesTable = ActivitiesAdapter.GetActivityPriceDataByID((int)Parent.Tag);
                    row = (activitiesRow)ActivitiesTable.Rows[0];

                    if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
                    {
                        float.TryParse(txtNewPrice.Text, out _price);
                        row.price = _price;
                    }
                    if (!string.IsNullOrWhiteSpace(txtNewOvertime1.Text))
                    {
                        float.TryParse(txtNewOvertime1.Text, out _overtime1);
                        row.overtime1 = _overtime1;
                    }
                    if (!string.IsNullOrWhiteSpace(txtNewOvertime2.Text))
                    {
                        float.TryParse(txtNewOvertime2.Text, out _overtime2);
                        row.overtime2 = _overtime2;
                    }


                    ActivitiesAdapter.Update(ActivitiesTable);
                    ActivitiesAdapter.Dispose();
                }
                foreach (TreeNode child in Parent.Nodes)
                {
                    if (child.Checked == true)
                    {
                        ActivitiesTable = ActivitiesAdapter.GetActivityPriceDataByID((int)child.Tag);
                        row = (activitiesRow)ActivitiesTable.Rows[0];
                        if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
                        {
                            float.TryParse(txtNewPrice.Text, out _price);
                            row.price = _price;
                        }
                        if (!string.IsNullOrWhiteSpace(txtNewOvertime1.Text))
                        {
                            float.TryParse(txtNewOvertime1.Text, out _overtime1);
                            row.overtime1 = _overtime1;
                        }
                        if (!string.IsNullOrWhiteSpace(txtNewOvertime2.Text))
                        {
                            float.TryParse(txtNewOvertime2.Text, out _overtime2);
                            row.overtime2 = _overtime2;
                        }
                        ActivitiesAdapter.Update(ActivitiesTable);
                        ActivitiesAdapter.Dispose();
                    }
                }
            }
        }

        private void GetCustomerProjectData()
        {
            try
            {
                ActivitiesAdapter = new activitiesTableAdapter();
                activitiesDataTable ActivitiesTable;

                if (chkProjectActive.Checked)
                {
                    ActivitiesTable = ActivitiesAdapter.GetAllProjectsOnCustomerID(CustomerID);
                }
                else
                {
                    ActivitiesTable = ActivitiesAdapter.GetAllActiveProjectsOnCustomerID(CustomerID);
                }

                ActivitiesAdapter.Dispose();

                foreach (activitiesRow Proj in ActivitiesTable.Rows)
                {
                    if (Proj.parentID == 0)
                    {
                        Activities = new TreeNode();
                        Activities.Text = "(" + Proj.price + ") " + Proj.description;
                        Activities.Tag = Proj.ID;
                        treeViewHourlyRate.Nodes.Add(Activities);
                        if ((Proj.status % 2) == 0)
                        {
                            Activities.ImageIndex = 3;
                            Activities.SelectedImageIndex = 3;
                        }
                        else if (Proj.type.Equals(project))
                        {
                            Activities.ImageIndex = 0;
                            Activities.SelectedImageIndex = 0;
                        }
                        else if (Proj.type.Equals(uppdrag))
                        {
                            Activities.ImageIndex = 1;
                            Activities.SelectedImageIndex = 1;
                        }
                    }
                }

                int index = 0;
                foreach (TreeNode tn in treeViewHourlyRate.Nodes)
                {
                    foreach (activitiesRow act in ActivitiesTable.Rows)
                    {
                        if (act.parentID == (int)tn.Tag)
                        {
                            TreeNode activity = new TreeNode();
                            activity.Text = "(" + act.price + ") " + act.description;
                            activity.Tag = act.ID;
                            treeViewHourlyRate.Nodes[index].Nodes.Add(activity);
                            if ((act.status % 2) == 0)
                            {
                                activity.ImageIndex = 4;
                                activity.SelectedImageIndex = 4;
                            }
                            else
                            {
                                activity.ImageIndex = 2;
                                activity.SelectedImageIndex = 2;
                            }
                        }
                    }
                    index++;
                }

            }
            catch
            {

            }
            ActivitiesAdapter.Dispose();
        }

        private void SetNodesToDefault()
        {
            ActivitiesAdapter = new activitiesTableAdapter();
            activitiesDataTable ActivitiesTable = ActivitiesAdapter.GetActivityIDByCustomerIDAndPrice(deafalultPrice, CustomerID);

            foreach (TreeNode node in treeViewHourlyRate.Nodes)
            {
                if (ActivitiesTable.Any(x => x.ID.Equals(node.Tag)))
                {
                    node.Checked = true;
                }

                foreach (TreeNode children in node.Nodes)
                {
                    if (ActivitiesTable.Any(x => x.ID.Equals(children.Tag)))
                    {
                        children.Checked = true;
                    }
                }
            }
            ActivitiesAdapter.Dispose();
        }

        private void SetNodeValues(bool _value)
        {
            foreach (TreeNode node in treeViewHourlyRate.Nodes)
            {
                node.Checked = _value;
                foreach (TreeNode children in node.Nodes)
                {
                    children.Checked = _value;
                }
            }
        }

        private void allowToSaveChecker()
        {
            bool checker = false;

            foreach (TreeNode parent in treeViewHourlyRate.Nodes)
            {
                if (parent.Checked == true)
                {
                    checker = true;
                    break;
                }
                else
                {
                    checker = false;
                }
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Checked == true)
                    {
                        checker = true;
                        break;
                    }
                    else
                    {
                        checker = false;
                    }
                }

            }


            var Numeric = new Regex(@"^[0-9\,]+$");

            if (!(Numeric.IsMatch(txtNewPrice.Text)))
            {
                checker = false;
                MessageBox.Show("Pris måste vara numeriskt");
            }
            else if (!(Numeric.IsMatch(txtNewOvertime1.Text)))
            {
                checker = false;
                MessageBox.Show("Övertid 1 måste vara numeriskt");
            }
            else if (!(Numeric.IsMatch(txtNewOvertime2.Text)))
            {
                checker = false;
                MessageBox.Show("Övertid 2 måste vara numeriskt");
            }

            if (checker == true)
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }
        }

        private void chkProjectActive_CheckedChanged(object sender, EventArgs e)
        {
            treeViewHourlyRate.Nodes.Clear();
            GetCustomerProjectData();
        }

        private void treeViewHourlyRate_MouseClick(object sender, MouseEventArgs e)
        {
            ActivityMarkedChecker();
            allowToSaveChecker();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePriceChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetNodeValues(true);
            ActivityMarkedChecker();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetNodeValues(false);
            ActivityMarkedChecker();
        }

        private void btnSelectDefault_Click(object sender, EventArgs e)
        {
            SetNodesToDefault();
            ActivityMarkedChecker();
        }



        private void txtNewPrice_KeyUp(object sender, KeyEventArgs e)
        {
            float.TryParse(txtNewPrice.Text, out _overtime1);
            txtNewOvertime1.Text = (_overtime1 * 1.5f).ToString();

            float.TryParse(txtNewPrice.Text, out _overtime2);
            txtNewOvertime2.Text = (_overtime2 * 2f).ToString();
            if (!string.IsNullOrWhiteSpace(txtNewPrice.Text))
            {
                allowToSaveChecker();
            }

        }

        private void txtNewOvertime1_KeyUp(object sender, KeyEventArgs e)
        {
            allowToSaveChecker();
        }

        private void txtNewOvertime2_KeyUp(object sender, KeyEventArgs e)
        {
            allowToSaveChecker();
        }
    }
}
