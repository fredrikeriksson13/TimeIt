using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeItCustomer.DsCustomerTableAdapters;
using static TimeItCustomer.DsCustomer;

namespace TimeItCustomer
{
    public partial class PriceWindow : Form
    {
        private activitiesTableAdapter ActivitiesAdapter;
        
        private TreeNode Activities;
        private int CustomerID;
        private int project;
        private int uppdrag;
        private int deafalultPrice;
        private int defaultOvertime1;
        private int defaultOvertime2;

        public PriceWindow(int _customerID, int _project, int _uppdrag, int _deafultPrice,int _deafaultOvertime1, int _defaultOvertime2)
             
        {
            InitializeComponent();
            deafalultPrice = _deafultPrice;
            defaultOvertime1 = _deafaultOvertime1;
            defaultOvertime2 = _defaultOvertime2;
            txtDefaultTimpris.Text = deafalultPrice.ToString();
            txtDefaultOvertime1.Text = defaultOvertime1.ToString();
            txtDefaultovertime2.Text = defaultOvertime2.ToString();
            project = _project;
            uppdrag = _uppdrag; 
            CustomerID = _customerID;
           
            this.CenterToScreen();
            treeViewHourlyRate.SelectedNode = null;
            GetCustomerProjectData();
        }
        
        private void SavePriceChanges()
        {
            ActivitiesAdapter = new activitiesTableAdapter();
            activitiesDataTable ActivitiesTable; /*= ActivitiesAdapter.GetActivityPriceDataByCustomerID(CustomerID);*/
            activitiesRow row;


            foreach (TreeNode Parent in treeViewHourlyRate.Nodes)
            {
                if(Parent.Checked == true)
                {
                    ActivitiesTable = ActivitiesAdapter.GetActivityPriceDataByID((int)Parent.Tag);

                    row = (activitiesRow)ActivitiesTable.Rows[0];
                    ActivitiesTable.AcceptChanges();
                    //row = ActivitiesTable.FirstOrDefault(x => x.ID.Equals(Parent.Tag));
                    row.price = float.Parse(txtNewPrice.Text);
                    row.overtime1 = float.Parse(txtNewOvertime1.Text);
                    row.overtime2 = float.Parse(txtNewOvertime2.Text);
                    //ActivitiesTable.AcceptChanges();
                    ActivitiesTable.AcceptChanges();
                    row.SetModified();
                }
            }
            ActivitiesAdapter.Dispose();
                //foreach (TreeNode child in Parent.no)
                //{
                //    if(child.Checked == true)
                //    {
                //        //row = ActivitiesTable.FirstOrDefault(x => x.ID.Equals(Parent.Tag));
                //        //row.price = float.Parse(txtNewPrice.Text);
                //        //row.overtime1 = float.Parse(txtNewOvertime1.Text);
                //        //row.overtime2 = float.Parse(txtNewOvertime2.Text);

            //    }
            //}
        }

            //ActivitiesTable.AcceptChanges();
            //ActivitiesAdapter.Update(ActivitiesTable);
            

        

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
                        Activities.Text = Proj.description;
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
                            activity.Text = act.description;
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

        private void chkProjectActive_CheckedChanged(object sender, EventArgs e)
        {
            GetCustomerProjectData();
        }

        private void rdbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SetNodeValues(true);
        }

        private void rdbUnselectAll_CheckedChanged(object sender, EventArgs e)
        {
            SetNodeValues(false);
        }

        private void rdbSelectDefault_CheckedChanged(object sender, EventArgs e)
        {
            SetNodesToDefault();
        }

        private void treeViewHourlyRate_MouseClick(object sender, MouseEventArgs e)
        {

            ActivitiesAdapter = new activitiesTableAdapter();
            activitiesDataTable ActivitiesTables = ActivitiesAdapter.GetActivityPriceDataByID((int)treeViewHourlyRate.SelectedNode.Tag);
            activitiesRow projectRow = (activitiesRow)ActivitiesTables.Rows[0];
            ActivitiesAdapter.Dispose();

            txtHourlyPrice.Text = projectRow.price.ToString();
            txtOvertime1.Text = projectRow.overtime1.ToString();
            txtOvertime2.Text = projectRow.overtime2.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePriceChanges();
        }
    } 
}
