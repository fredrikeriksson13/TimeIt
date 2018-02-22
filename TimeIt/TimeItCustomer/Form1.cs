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
    public partial class Form1 : Form
    {
        private customersTableAdapter CustomerAdapter;
        private contactsTableAdapter ContactsAdapter;
        private activitiesTableAdapter ActivitiesAdapter;
        private usersTableAdapter UsersAdapter;
        private tasksTableAdapter taskAdapter;
        private TreeNode Activities;
        private TaskWindow taskwindow;
        private PriceWindow priceWindow;
        private int UserId;
        private int activityID;
        private int ProjectsContactID;
        private int ProjectAttestID;
        private int ProjectManagerID;
        private bool Edit;
        private bool CreatingNewActivity;
        private int maxID;

        private enum activityStatus
        {
            aktivt = 1,
            okToAttest = 2,
            okToTidredovisa = 4,
            avslutat = 64,
            projectPlanning = 128,
            activityDone = 256
        }
        private enum activityPriceStatus
        {

            [Description("Löpande timpris")]
            lopandeTimpris = 1,
            [Description("Fastpris")]
            fastPris = 2,
            [Description("Avtalsfakturering")]
            avtalsfakturering = 4,
            [Description("Timbank")]
            timbank = 8,
            [Description("Ej debiterad")]
            ejDeb = 16,
            [Description("Interntprojekt")]
            interntProj = 32,
            //[Description("Arv")]  arv = 128
            [Description("Frånvaro")]
            absence = 1024,
        }
        private enum projectType
        {
            [Description("Projekt")]
            projekt = 1,
            [Description("Uppdrag")]
            uppdrag = 2,
            [Description("Aktivitet")]
            aktivitet = 3
        }
        private enum timeClassification
        {
            [Description("Administration/Möten")]
            admin = 1,
            [Description("Konsultation")]
            Konsultation = 2,
            [Description("Systemutveckling")]
            Servicedesk = 3,
            [Description("Servicedesk")]
            Systemutveckling = 4,
            [Description("Utbildning")]
            Utbildning = 5,
            [Description("Support")]
            Support = 6,
            [Description("Sälj")]
            Sales = 7,

            [Description("Utlägg")]
            Outlays = 8,
            [Description("Produkt")]
            Produkt = 9
        }
        private enum typeSwitch
        {
            aktivitet = 1,
            projektAndUppdrag = 2,
            projekt = 3
        }

        public Form1()
        {
            CheckProgramAcces();
            InitializeComponent();
            MinimumSize = new Size(1300, 700);
            EnableDisableCustomerControls(false);
            EnableDisableProjectControls(false);
            EnableDisableContactControls(false);
            PopulateCustomer();
        }

        #region Main

        private void CheckProgramAcces()
        {
            try
            {
                UsersAdapter = new usersTableAdapter();
                usersDataTable utable = UsersAdapter.GetAuthorizedUsers();
                UsersAdapter.Dispose();

                string[] useArr = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');
                string username = useArr[1];

                foreach (usersRow ur in utable.Rows)
                {
                    if (ur.username == username)
                    {
                        UserId = ur.ID;
                        return;
                    }
                }
                MessageBox.Show("Access denied.");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listboxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displays all data for the selected Customer
            gbTaskCounter.Visible = false;
            ClearProjectData();
            ClearCustomerData();

            if (listboxCustomers.SelectedItem != null)
            {
                PopulateCustomerTextBoxes();
                PopulateContactListBox();
                EnableDisableContactControls(true);
                GetCustomerProjectData();
            }
            EnableDisableCustomerControls(false);
            EnableDisableProjectControls(false);
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            ClearCustomerData();
            ClearProjectData();
            string SearchString;
            //Search and populate listbox on the matching customer name
            if (!string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
            {
                lblSearch.Visible = false;
                listboxCustomers.SelectionMode = SelectionMode.None;

                if (txtCustomerSearch.Text.Length == 1)
                    SearchString = txtCustomerSearch.Text + "%";
                else
                    SearchString = "%" + txtCustomerSearch.Text + "%";

                CustomerAdapter = new customersTableAdapter();
                customersDataTable CustomerTable = CustomerAdapter.GetCustomerByName(SearchString);

                listboxCustomers.ValueMember = "ID";
                listboxCustomers.DisplayMember = "CustomerName";
                listboxCustomers.DataSource = CustomerTable;
                CustomerAdapter.Dispose();
                listboxCustomers.SelectionMode = SelectionMode.One;
            }
            else
            {
                PopulateCustomer();
            }
            treeViewProjects.Nodes.Clear();
            EnableDisableCustomerControls(false);
            EnableDisableContactControls(false);
            EnableDisableProjectControls(false);
        }

        private void txtCustomerSearch_MouseClick(object sender, MouseEventArgs e)
        {
            lblSearch.Visible = false;
        }

        private void lblSearch_MouseClick(object sender, MouseEventArgs e)
        {
            lblSearch.Visible = false;
            txtCustomerSearch.Focus();
        }

        private void txtCustomerSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
            {
                lblSearch.Visible = true;
                txtCustomerSearch.TabStop = false;
            }
        }

        #endregion

        #region CustomerEvents

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            ClearCustomerData();
            ClearProjectData();
            treeViewProjects.Nodes.Clear();
            listboxCustomers.ClearSelected();
            EnableDisableProjectControls(false);
            EnableDisableCustomerControls(true);
            EnableDisableContactControls(false);
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            EnableDisableCustomerControls(true);
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            CreateOrEditCustomer();

        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            if (listboxCustomers.SelectedItem != null)
            {
                PopulateCustomerTextBoxes();
            }
            else
            {
                ClearCustomerData();
            }
            EnableDisableCustomerControls(false);
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            EnableDisableCustomerControls(true);
        }

        #endregion

        #region ContactsEvent

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            listBoxContacts.ClearSelected();
            ShowContactDialog(string.Empty, string.Empty);
        }

        private void btnContactEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ContactsAdapter = new contactsTableAdapter();
                contactsDataTable cTable = ContactsAdapter.GetContactByContactID((int)listBoxContacts.SelectedValue);
                contactsRow cRow = (contactsRow)cTable.Rows[0];
                ShowContactDialog(cRow.firstName, cRow.lastName);
                ContactsAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableContactControls(true);
        }

        #endregion

        #region ProjectEvent

        private void chkProjectInActive_CheckedChanged(object sender, EventArgs e)
        {
            GetCustomerProjectData();
        }

        private void btnProjectNew_Click(object sender, EventArgs e)
        {
            Edit = false;
            ClearProjectData();
            
            SetNewProjectDefaultPrice();
            PopulateProjectPriceStatusComboBox();
            PopulateTimeClassificationComboBox();
            PopulateProjectTypeComboBox(typeSwitch.projektAndUppdrag);

            PopulateCmdContactRef();
            PopulateAttestComboBox();
            PopulateProjectManagerCombobox();
            cbAttest.SelectedValue = UserId;
            chkProjecktActive.Checked = true;
            treeViewProjects.SelectedNode = null;
           
            gbTaskCounter.Visible = false;
            EnableDisableProjectControls(true);
            comboBoxProjectPriceStatus.SelectedIndex = 0;comboBoxKlassificiering.SelectedIndex = 0;
            txtProjectDescription.Focus();
        }

        private void btnProjectEdit_Click(object sender, EventArgs e)
        {
            Edit = true;
            EnableDisableProjectControls(true);

            if (ProjectAttestID.Equals(null) || ProjectAttestID.Equals(0))
            {
                ProjectAttestID = UserId;
                cbAttest.SelectedValue = ProjectAttestID;
            }
        }

        private void btnProjectSave_Click(object sender, EventArgs e)
        {
            int IdOnNodeThatIsEdit = 0;
            if (treeViewProjects.SelectedNode == null)
            {
                CreateProjectActivity(0);
            }
            else
            {
                IdOnNodeThatIsEdit = (int)treeViewProjects.SelectedNode.Tag;
                CreateProjectActivity((int)treeViewProjects.SelectedNode.Tag);
            }
            GetCustomerProjectData();
            if (!Edit)
            {
                NewTreeNodeAutoSelect(maxID, true);
            }
            else
            {
                NewTreeNodeAutoSelect(IdOnNodeThatIsEdit, false);
            }
            PopulateProjectInfo();
           
            EnableDisableProjectControls(false);
        }

        private void btnProjectCancel_Click(object sender, EventArgs e)
        {
           

            if (treeViewProjects.SelectedNode == null)
            {
                ClearProjectData();
                EnableDisableProjectControls(false);
            }
            else
            {
                try
                {
                    BeginInvoke(new Action(() => PopulateProjectInfo()));
                    EnableDisableProjectControls(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtProjectDescription_TextChanged(object sender, EventArgs e)
        {
            EnableDisableProjectControls(true);
        }

        private void treeViewProjects_MouseClick(object sender, MouseEventArgs e)
        {
            gbTaskCounter.Visible = false;
            gbTaskCounter.Text = "Tasks : 0";
            treeViewProjects.SelectedNode = treeViewProjects.GetNodeAt(e.X, e.Y);
            

            try
            {
                BeginInvoke(new Action(() => PopulateProjectInfo()));

                ActivitiesAdapter = new activitiesTableAdapter();
                activitiesDataTable ActivitiesTable = ActivitiesAdapter.GetParentIDProjectAndActivityByID((int)treeViewProjects.SelectedNode.Tag);
                activitiesRow projectRow = (activitiesRow)ActivitiesTable.Rows[0];
                ActivitiesTable.Dispose();


                if (treeViewProjects.SelectedNode != null && !projectRow.parentID.Equals(0) && projectRow.type.Equals((int)projectType.aktivitet))
                {
                    gbTaskCounter.Visible = true;
                    taskAdapter = new tasksTableAdapter();
                    tasksDataTable tTable = taskAdapter.GetIDOnActivityID((int)treeViewProjects.SelectedNode.Tag);
                    taskAdapter.Dispose();

                    gbTaskCounter.Text = "Tasks : " + tTable.Rows.Count.ToString();
                    activityID = projectRow.ID;
                }

                if (e.Button == MouseButtons.Right) // Gets the right mouse clicked selected node, adds a context menu 
                {
                    if (treeViewProjects.SelectedNode != null && projectRow.parentID.Equals(0) && projectRow.type.Equals((int)projectType.projekt))
                    {
                        ContextMenu cm = new ContextMenu();
                        cm.MenuItems.Add("Lägg till ny aktivitet", AddNewActivityToSelectedProject);
                        cm.MenuItems.Add("Avmarkera valt projekt", UnselectProject);
                        treeViewProjects.SelectedNode.ContextMenu = cm;
                    }
                    else
                    {
                        ContextMenu cm = new ContextMenu();
                        cm.MenuItems.Add("Avmarkera valt projekt", UnselectProject);
                        treeViewProjects.SelectedNode.ContextMenu = cm;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UnselectProject(object sender, EventArgs e)
        {
            ClearProjectData();
            treeViewProjects.SelectedNode = null;
            EnableDisableProjectControls(false);
        }

        private void AddNewActivityToSelectedProject(object sender, EventArgs e)
        {
            Edit = false;
            CreatingNewActivity = true;
            AddNewActivity();
            EnableDisableProjectControls(true);
        }

        private void btnClearStartDate_Click(object sender, EventArgs e)
        {
            //Resets DateTimePicker to deafult time
            dtpProjectStartDate.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtpProjectStartDate.Format = DateTimePickerFormat.Custom;
            dtpProjectStartDate.CustomFormat = " ";
        }

        private void btnClearStopDate_Click(object sender, EventArgs e)
        {
            //Resets DateTimePicker to deafult time
            dtpProjectStopDate.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtpProjectStopDate.Format = DateTimePickerFormat.Custom;
            dtpProjectStopDate.CustomFormat = " ";
        }

        private void dtpProjectStartDate_MouseDown(object sender, MouseEventArgs e)
        {
            //Sets DateTimePicker to DatetimeNow when user interact
            dtpProjectStartDate.Value = DateTime.Now;
            dtpProjectStartDate.Format = DateTimePickerFormat.Long;
        }

        private void dtpProjectStopDate_MouseDown(object sender, MouseEventArgs e)
        {
            //Sets DateTimePicker to DatetimeNow when user interact
            dtpProjectStopDate.Value = DateTime.Now;
            dtpProjectStopDate.Format = DateTimePickerFormat.Long;
        }

        private void btnAddNewActivity_Click(object sender, EventArgs e)
        {
            Edit = false;
            CreatingNewActivity = true;
            AddNewActivity();
            EnableDisableProjectControls(true);
        }

        private void comboBoxProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCbTypColor();
            EnableDisableProjectControls(true);
        }

        #endregion

        #region TaskEvent

        private void ms_CustomEvent()
        {
            try
            {
                taskAdapter = new tasksTableAdapter();
                tasksDataTable tTable = taskAdapter.GetIDOnActivityID(activityID);
                taskAdapter.Dispose();
                gbTaskCounter.Text = "Tasks : " + tTable.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            try
            {
                btnTaskOpenClose.Text = "Stäng Tasks";
                taskwindow = new TaskWindow(activityID);
                taskwindow.FormClosed += new FormClosedEventHandler(TaskWIndowClosedEvent);
                taskwindow.CustomEvent += new TaskWindow.CustomDelegate(ms_CustomEvent);
                taskwindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TaskWIndowClosedEvent(object sender, EventArgs e)
        {
            try
            {
                ((TaskWindow)sender).FormClosed -= TaskWIndowClosedEvent;
                btnTaskOpenClose.Text = "Öppna Tasks";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region CustomerMethods
        /// <summary>
        /// Gets the Customer information, and populate Customer Information 
        /// </summary>
        private void PopulateCustomer()
        {
            try
            {
                listboxCustomers.SelectionMode = SelectionMode.None;
                CustomerAdapter = new customersTableAdapter();
                customersDataTable CustomerTable = CustomerAdapter.GetCustomerInfo();

                listboxCustomers.ValueMember = "ID";
                listboxCustomers.DisplayMember = "CustomerName";
                listboxCustomers.DataSource = CustomerTable;

                CustomerAdapter.Dispose();
                listboxCustomers.SelectionMode = SelectionMode.One;

                dtpProjectStartDate.Format = DateTimePickerFormat.Custom;
                dtpProjectStartDate.CustomFormat = " ";
                dtpProjectStopDate.Format = DateTimePickerFormat.Custom;
                dtpProjectStopDate.CustomFormat = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Creates or Edit a Customer 
        /// </summary>
        private void CreateOrEditCustomer()
        {
            try
            {
                CustomerAdapter = new customersTableAdapter();
                customersDataTable cTable;
                customersRow cRow;

                if (listboxCustomers.SelectedItem == null)
                {
                    cTable = CustomerAdapter.GetCustomerDataByID(0);
                    cRow = cTable.NewcustomersRow();
                    SetCustomersData(cRow);
                    cTable.Rows.Add(cRow);
                    CustomerAdapter.Update(cTable);
                    CustomerAdapter.Dispose();

                    PopulateCustomer();
                    cTable = CustomerAdapter.GetMaxCustomerID();
                    cRow = (customersRow)cTable.Rows[0];
                    CustomerAdapter.Dispose();
                    EnableDisableCustomerControls(false);
                    listboxCustomers.SelectedValue = cRow.ID;
                }
                else
                {
                    cTable = CustomerAdapter.GetCustomerDataByID((int)listboxCustomers.SelectedValue);
                    cRow = (customersRow)cTable.Rows[0];
                    SetCustomersData(cRow);
                    CustomerAdapter.Update(cTable);
                    int CustomerEdit = (int)listboxCustomers.SelectedValue;
                    PopulateCustomer();
                    
                    CustomerAdapter.Dispose();
                    listboxCustomers.SelectedValue = CustomerEdit;
                }
                EnableDisableCustomerControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        private void SetCustomersData(customersRow cRow)
        {
            int a;
            cRow.customerName = txtCustomerName.Text;
            cRow.address = txtCustomerAdress.Text;
            cRow.orgNumber = txtCustomerOrgNummer.Text;

            int.TryParse(txtCustomerStdHourlyPrice.Text, out a);
            cRow.stdHourlyPrice = a;

            int.TryParse(txtCustomerStdOvetTime1.Text, out a);
            cRow.stdOvertime1 = a;

            int.TryParse(txtCustomerStdOvetTime2.Text, out a);
            cRow.stdOvertime2 = a;
        }

        private void EnableDisableCustomerControls(bool state)
        {
            if (listboxCustomers.SelectedItem != null)
                btnCustomerEdit.Visible = !state;
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) != true && state == true)
                btnCustomerSave.Visible = state;
            else
                btnCustomerSave.Visible = false;

            btnCustomerCancel.Visible = state;
            btnCustomerAdd.Visible = !state;
            txtCustomerSearch.Enabled = !state;
            lblSearch.Enabled = !state;

            txtCustomerName.ReadOnly = !state;
            txtCustomerOrgNummer.ReadOnly = !state;
            txtCustomerAdress.ReadOnly = !state;
            txtCustomerStdHourlyPrice.ReadOnly = !state;
            txtCustomerStdOvetTime1.ReadOnly = !state;
            txtCustomerStdOvetTime2.ReadOnly = !state;

            Color backColor;
            if (!state)
                backColor = SystemColors.ControlLight;
            else
                backColor = SystemColors.Window;

            txtCustomerName.BackColor = backColor;
            txtCustomerOrgNummer.BackColor = backColor;
            txtCustomerAdress.BackColor = backColor;
            txtCustomerStdHourlyPrice.BackColor = backColor;
            txtCustomerStdOvetTime1.BackColor = backColor;
            txtCustomerStdOvetTime2.BackColor = backColor;
        }

        private void ClearCustomerData()
        {
            txtCustomerName.Clear();
            txtCustomerOrgNummer.Clear();
            txtCustomerAdress.Clear();
            txtCustomerStdHourlyPrice.Clear();
            txtCustomerStdOvetTime1.Clear();
            txtCustomerStdOvetTime2.Clear();
            listBoxContacts.DataSource = null;
        }

        private void PopulateCustomerTextBoxes()
        {
            try
            {
                CustomerAdapter = new customersTableAdapter();
                customersDataTable cTable = CustomerAdapter.GetCustomerDataByID((int)listboxCustomers.SelectedValue);
                customersRow cRow = (customersRow)cTable.Rows[0];
                CustomerAdapter.Dispose();
                txtCustomerName.Text = cRow.customerName;
                txtCustomerOrgNummer.Text = cRow.orgNumber.ToString();
                txtCustomerAdress.Text = cRow.address;
                txtCustomerStdHourlyPrice.Text = cRow.stdHourlyPrice.ToString();
                txtCustomerStdOvetTime1.Text = cRow.stdOvertime1.ToString();
                txtCustomerStdOvetTime2.Text = cRow.stdOvertime2.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region ContactsMethods

        private void ShowContactDialog(string firstName, string lastName)
        {
            try
            {
                //Opens upp the contact dialog for edit and sets the propertys in ContactDialog
               using (ContactDialog cd = new ContactDialog(firstName, lastName))
                {
                    cd.ShowDialog();
                    if (cd.SaveContact == true)
                    {
                        ContactsAdapter = new contactsTableAdapter();
                        contactsDataTable cTable;
                        contactsRow conRow;

                        if (listBoxContacts.SelectedItem == null)
                        {
                            cTable = ContactsAdapter.GetContactByContactID(0);
                            conRow = cTable.NewcontactsRow();
                            conRow.firstName = cd.FirstName;
                            conRow.lastName = cd.LastName;
                            conRow.customerID = (int)listboxCustomers.SelectedValue;
                            cTable.Rows.Add(conRow);
                        }
                        else
                        {
                            cTable = ContactsAdapter.GetContactByContactID((int)listBoxContacts.SelectedValue);
                            conRow = (contactsRow)cTable.Rows[0];
                            conRow.firstName = cd.FirstName;
                            conRow.lastName = cd.LastName;
                            conRow.customerID = (int)listboxCustomers.SelectedValue;
                        }
                        ContactsAdapter.Update(cTable);
                        ContactsAdapter.Dispose();
                        PopulateContactListBox();
                        PopulateCmdContactRef();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PopulateContactListBox()
        {
            try
            {
                listBoxContacts.SelectionMode = SelectionMode.None;
                ContactsAdapter = new contactsTableAdapter();
                contactsDataTable _contTable = ContactsAdapter.GetContactsNamesASName((int)listboxCustomers.SelectedValue);
                ContactsAdapter.Dispose();
                listBoxContacts.ValueMember = "ID";
                listBoxContacts.DisplayMember = "Name";
                listBoxContacts.DataSource = _contTable;
                listBoxContacts.SelectionMode = SelectionMode.One;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EnableDisableContactControls(bool state)
        {
            btnContactAdd.Visible = state;

            if (listBoxContacts.SelectedItem != null)
                btnContactEdit.Visible = true;
            else
                btnContactEdit.Visible = false;
        }

        #endregion

        #region ProjectMethods

        private void PopulateProjectTypeComboBox(typeSwitch Type)
        {
            comboBoxProjectType.DisplayMember = "Description";
            comboBoxProjectType.ValueMember = "Value";

            switch (Type)
            {
                case typeSwitch.aktivitet:
                    comboBoxProjectType.DataSource = Enum.GetValues(typeof(projectType)).Cast<projectType>()
                   .Where(value => (projectType)value == projectType.aktivitet)
                   .Select(value => new
                   {
                       (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                       value
                   })
                    .ToList();
                    break;

                case typeSwitch.projektAndUppdrag:
                    comboBoxProjectType.DataSource = Enum.GetValues(typeof(projectType)).Cast<projectType>()
                   .Where(value => (projectType)value == projectType.projekt || (projectType)value == projectType.uppdrag)
                   .Select(value => new
                   {
                       (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                       value
                   })
                    .ToList();
                    break;

                case typeSwitch.projekt:
                    comboBoxProjectType.DataSource = Enum.GetValues(typeof(projectType)).Cast<projectType>()
                   .Where(value => (projectType)value == projectType.projekt)
                   .Select(value => new
                   {
                       (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                       value
                   })
                    .ToList();
                    break;
            }
        }

        private void PopulateProjectPriceStatusComboBox()
        {
            comboBoxProjectPriceStatus.DisplayMember = "Description";
            comboBoxProjectPriceStatus.ValueMember = "Value";
            comboBoxProjectPriceStatus.DataSource = Enum.GetValues(typeof(activityPriceStatus))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }
        private void PopulateTimeClassificationComboBox()
        {
            comboBoxKlassificiering.DisplayMember = "Description";
            comboBoxKlassificiering.ValueMember = "Value";
            comboBoxKlassificiering.DataSource = Enum.GetValues(typeof(timeClassification))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }
        private void SetNewProjectDefaultPrice()
        {
            txtProjectPrice.Text = txtCustomerStdHourlyPrice.Text;
            txtProjectOverTime1.Text = txtCustomerStdOvetTime1.Text;
            txtProjectOverTime2.Text = txtCustomerStdOvetTime2.Text;
        }

        private void ClearProjectData()
        {
            txtProjectDescription.Clear();
            txtProjectRemark.Clear();
            txtProjectBudgetHours.Clear();
            txtProjectOverTime1.Clear();
            txtProjectOverTime2.Clear();
            txtProjectPrice.Clear();
            txtProjectPriceFixed.Clear();
            txtProjectCalculatedHours.Clear();
            chkProjecktActive.Checked = false;
            chkProjecktOkToAttest.Checked = false;
            chkProjecktOkToTidredovisa.Checked = false;
            chkProjectAvslutat.Checked = false;
            chkProjectProjectPlanning.Checked = false;
            chkProjectActivityDone.Checked = false;
            comboBoxProjectPriceStatus.DataSource = null;
            comboBoxKlassificiering.DataSource = null;
            comboBoxProjectType.DataSource = null;
            dtpProjectStartDate.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtpProjectStartDate.Format = DateTimePickerFormat.Custom;
            dtpProjectStartDate.CustomFormat = " ";
            dtpProjectStopDate.Value = DateTime.Parse("1900-01-01 00:00:00");
            dtpProjectStopDate.Format = DateTimePickerFormat.Custom;
            dtpProjectStopDate.CustomFormat = " ";
            lblChangeDate.Text = "-";
            lblChangeByName.Text = "-";
            cbCustomerContactRef.DataSource = null;
            cbAttest.DataSource = null;
            cbProjectManager.DataSource = null;
            lblHideProjektType.Text = string.Empty;
            lblHideProjectManage.Text = string.Empty;
            lblHideAttest.Text = string.Empty;
            lblHideRef.Text = string.Empty;
            lblHidePriceStatus.Text = string.Empty;
            labelKlassificering.Text = "";
            lblShowID.Text = "";
            lbUsers.DataSource = null;
            cbUsers.DataSource = null;
        }

        private void EnableDisableProjectControls(bool state)
        {
            if (listboxCustomers.SelectedItem != null)
            {
                btnProjectNew.Visible = !state;
                chkProjectInActive.Visible = !state;
            }
            else
            {
                btnProjectNew.Visible = false;
                chkProjectInActive.Visible = false;
            }

            if (treeViewProjects.SelectedNode != null)
                btnProjectEdit.Visible = !state;
            
            if (treeViewProjects.SelectedNode == null)
            {
                btnAddNewActivity.Visible = false;
                btnProjectEdit.Visible = false;
            }

            txtCustomerSearch.Enabled = !state;
            lblSearch.Enabled = !state;

            txtProjectDescription.ReadOnly = !state;
            txtProjectRemark.ReadOnly = !state;
            txtProjectPrice.ReadOnly = !state;
            txtProjectPriceFixed.ReadOnly = !state;
            txtProjectOverTime1.ReadOnly = !state;
            txtProjectOverTime2.ReadOnly = !state;
            txtProjectBudgetHours.ReadOnly = !state;
            txtProjectCalculatedHours.ReadOnly = !state;

            lblHideProjektType.Visible = !state;
            lblHidePriceStatus.Visible = !state;
            lblHideStartDate.Visible = !state;
            dtpProjectStartDate.Visible = state;
            lblHideStopdate.Visible = !state;
            dtpProjectStopDate.Visible = state;
            btnClearStartDate.Visible = state;
            btnClearStopDate.Visible = state;

            chkProjecktActive.Enabled = state;
            chkProjectAvslutat.Enabled = state;
            chkProjectActivityDone.Enabled = state;
            chkProjectProjectPlanning.Enabled = state;
            chkProjecktOkToAttest.Enabled = state;
            chkProjecktOkToTidredovisa.Enabled = state;

            if (comboBoxProjectType.SelectedItem != null)
            {
                if (comboBoxProjectType.SelectedValue.Equals(projectType.projekt))
                {
                    chkProjecktOkToTidredovisa.Enabled = false;
                    btnAddNewActivity.Visible = !state;
                }
                else
                {
                    btnAddNewActivity.Visible = false;
                }
            }
         
            comboBoxProjectType.Visible = state;
            cbProjectManager.Visible = state;
            comboBoxKlassificiering.Visible = state;
            cbAttest.Visible = state;
            cbCustomerContactRef.Visible = state;
            comboBoxProjectPriceStatus.Visible = state;
            comboBoxKlassificiering.Visible = state;
            btnAddUser.Visible = state;
            cbUsers.Visible = state;

            Color backcolor;
            if (!state)
                backcolor = SystemColors.ControlLight;
            else
                backcolor = SystemColors.Window;

            txtProjectDescription.BackColor = backcolor;
            txtProjectRemark.BackColor = backcolor;
            txtProjectPrice.BackColor = backcolor;
            txtProjectPriceFixed.BackColor = backcolor;
            txtProjectOverTime1.BackColor = backcolor;
            txtProjectOverTime2.BackColor = backcolor;
            txtProjectBudgetHours.BackColor = backcolor;
            txtProjectCalculatedHours.BackColor = backcolor;
            lbUsers.BackColor = backcolor;
            btnProjectCancel.Visible = state;

            if (string.IsNullOrWhiteSpace(txtProjectDescription.Text) != true && state == true)
                btnProjectSave.Visible = state;
            else
                btnProjectSave.Visible = false;
        }
        /// <summary>
        /// Gets the Projects associated to the selected customer
        /// </summary>
        private void GetCustomerProjectData()
        {
            try
            {
                if (listboxCustomers.SelectedItem != null)
                {
                    treeViewProjects.Nodes.Clear();
                    ActivitiesAdapter = new activitiesTableAdapter();
                    activitiesDataTable ActivitiesTable;

                    if (chkProjectInActive.Checked)
                    {
                        ActivitiesTable = ActivitiesAdapter.GetAllProjectsOnCustomerID((int)listboxCustomers.SelectedValue);
                    }
                    else
                    {
                        ActivitiesTable = ActivitiesAdapter.GetAllActiveProjectsOnCustomerID((int)listboxCustomers.SelectedValue);
                    }

                    ActivitiesAdapter.Dispose();

                    foreach (activitiesRow Proj in ActivitiesTable.Rows)
                    {
                        if (Proj.parentID == 0)
                        {
                            Activities = new TreeNode();
                            Activities.Text = Proj.description;
                            Activities.Tag = Proj.ID;
                            treeViewProjects.Nodes.Add(Activities);
                            if ((Proj.status % 2) == 0)
                            {
                                Activities.ImageIndex = 3;
                                Activities.SelectedImageIndex = 3;
                            }
                            else if (Proj.type.Equals((int)projectType.projekt))
                            {
                                Activities.ImageIndex = 0;
                                Activities.SelectedImageIndex = 0;
                            }
                            else if (Proj.type.Equals((int)projectType.uppdrag))
                            {
                                Activities.ImageIndex = 1;
                                Activities.SelectedImageIndex = 1;
                            }
                        }
                    }

                    int index = 0;
                    foreach (TreeNode tn in treeViewProjects.Nodes)
                    {
                        foreach (activitiesRow act in ActivitiesTable.Rows)
                        {
                            if (act.parentID == (int)tn.Tag)
                            {
                                TreeNode activity = new TreeNode();
                                activity.Text = act.description;
                                activity.Tag = act.ID;
                                treeViewProjects.Nodes[index].Nodes.Add(activity);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Creates a new row for a new project if edit is false, else it will make a edit
        /// </summary>
        /// <param name="ID"></param>
        private void CreateProjectActivity(int ID)
        {
            try
            {
                ActivitiesAdapter = new activitiesTableAdapter();
                activitiesDataTable aTables = ActivitiesAdapter.GetProjectInfoByID(ID);
                activitiesRow aRow;

                if (!Edit)
                {
                    aRow = aTables.NewactivitiesRow();
                }
                else
                {
                    aRow = (activitiesRow)aTables.Rows[0];
                }

                aRow.projectManagerID = (int)cbProjectManager.SelectedValue;
                aRow.invoiceUserID = (int)cbAttest.SelectedValue;
                aRow.contactID = (int)cbCustomerContactRef.SelectedValue;
               

                int budget;
                double over1, over2, price, pricefix;
                DateTime start, stop;
                aRow.description = txtProjectDescription.Text;
                aRow.remark = txtProjectRemark.Text;
                int.TryParse(txtProjectBudgetHours.Text, out budget);
                aRow.budgetHours = budget;
                double.TryParse(txtProjectOverTime1.Text, out over1);
                aRow.overtime1 = over1;
                double.TryParse(txtProjectOverTime2.Text, out over2);
                aRow.overtime2 = over2;
                double.TryParse(txtProjectPrice.Text, out price);
                aRow.price = price;
                double.TryParse(txtProjectPriceFixed.Text, out pricefix);
                aRow.price_fixed = pricefix;
                aRow.changeDate = DateTime.Now;
                aRow.changedBy = UserId;
                dtpProjectStartDate.Value.Equals(DateTime.Parse("1900-01-01 00:00:00"));
                if (dtpProjectStartDate.Value.Equals(DateTime.Parse("1900-01-01 00:00:00")))
                {
                    aRow.startDate = DateTime.Parse("1900-01-01 00:00:00");
                }
                else
                {
                    DateTime.TryParse(dtpProjectStartDate.Value.ToString(), out start);
                    aRow.startDate = start;
                }
                dtpProjectStopDate.Value.Equals(DateTime.Parse("1900-01-01 00:00:00"));
                if (dtpProjectStopDate.Value.Equals(DateTime.Parse("1900-01-01 00:00:00")))
                {
                    aRow.stopDate = DateTime.Parse("1900-01-01 00:00:00");
                }
                else
                {
                    DateTime.TryParse(dtpProjectStopDate.Value.ToString(), out stop);
                    aRow.stopDate = stop;
                }
                //Sets project Status
                aRow.status = 0;
                if (chkProjecktActive.Checked)
                {
                    aRow.status = (int)activityStatus.aktivt;
                }
                if (chkProjecktOkToAttest.Checked)
                {
                    aRow.status = aRow.status | (int)activityStatus.okToAttest;
                }
                if (chkProjecktOkToTidredovisa.Checked)
                {
                    aRow.status = aRow.status | (int)activityStatus.okToTidredovisa;
                }
                if (chkProjectAvslutat.Checked)
                {
                    aRow.status = aRow.status | (int)activityStatus.avslutat;
                }
                if (chkProjectProjectPlanning.Checked)
                {
                    aRow.status = aRow.status | (int)activityStatus.projectPlanning;
                }
                if (chkProjectActivityDone.Checked)
                {
                    aRow.status = aRow.status | (int)activityStatus.activityDone;
                }

                aRow.priceStatus = (int)comboBoxProjectPriceStatus.SelectedValue;
                aRow.timeClassificationID = (int)comboBoxKlassificiering.SelectedValue;
                aRow.type = (int)comboBoxProjectType.SelectedValue; ;


                aRow.customerID = (int)listboxCustomers.SelectedValue;
                if (!Edit)
                {
                    activitiesDataTable _maxTable = ActivitiesAdapter.GetMaxActivitiesID();
                    activitiesRow maxRow = (activitiesRow)_maxTable.Rows[0];
                    maxID = maxRow.ID;
                }
                if(ID == 0)
                {
                  aRow.rootID = maxID+1;
                  aTables.Rows.Add(aRow);
                }
                if (CreatingNewActivity)
                {
                    aRow.parentID = ID;
                    aRow.rootID = ID;
                    aTables.Rows.Add(aRow);
                    CreatingNewActivity = false;
                }

                ActivitiesAdapter.Update(aTables);
                ActivitiesAdapter.Dispose();
                treeViewProjects.Nodes.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Gets the customers project data
        /// </summary>
        private void PopulateProjectInfo()
        {
            try
            {
                if (treeViewProjects.SelectedNode != null)
                {
                    PopulateProjectPriceStatusComboBox();
                    PopulateTimeClassificationComboBox();
                    PopulateUsersComboBox();
                    PopulateAssociatedUserToList((int)treeViewProjects.SelectedNode.Tag);

                    ActivitiesAdapter = new activitiesTableAdapter();
                    activitiesDataTable ActivitiesTables = ActivitiesAdapter.GetProjectInfoByID((int)treeViewProjects.SelectedNode.Tag);
                    activitiesRow projectRow = (activitiesRow)ActivitiesTables.Rows[0];
                    ActivitiesTables.Dispose();
                    
                    ProjectManagerID = projectRow.projectManagerID;
                    ProjectsContactID = projectRow.contactID;
                    ProjectAttestID = projectRow.invoiceUserID;

                    lblChangeByName.Text = GetUserNameByID(projectRow.changedBy);
                    txtProjectDescription.Text = projectRow.description;
                    txtProjectRemark.Text = projectRow.remark;
                    txtProjectOverTime1.Text = projectRow.overtime1.ToString();
                    txtProjectOverTime2.Text = projectRow.overtime2.ToString();
                    txtProjectPrice.Text = projectRow.price.ToString();
                    txtProjectPriceFixed.Text = projectRow.price_fixed.ToString();
                    txtProjectBudgetHours.Text = projectRow.budgetHours.ToString();
                    txtProjectCalculatedHours.Text = projectRow.calculatedHours.ToString();
                    cbAttest.SelectedValue = projectRow.invoiceUserID;
                    lblShowID.Text = treeViewProjects.SelectedNode.Tag.ToString();

                    if (projectRow.IschangeDateNull())
                    {
                        lblChangeDate.Text = "-";
                    }
                    else
                    {
                        lblChangeDate.Text = projectRow.changeDate.ToString();
                    }

                    if (projectRow.IsstartDateNull() || projectRow.startDate.Equals(DateTime.Parse("1900-01-01 00:00:00")))
                    {
                        dtpProjectStartDate.Value = DateTime.Parse("1900-01-01 00:00:00");
                        dtpProjectStartDate.Format = DateTimePickerFormat.Custom;
                        dtpProjectStartDate.CustomFormat = " ";
                    }
                    else
                    {
                        dtpProjectStartDate.Value = projectRow.startDate;
                        dtpProjectStartDate.Format = DateTimePickerFormat.Long;
                    }
                    if (projectRow.IsstopDateNull() || projectRow.stopDate.Equals(DateTime.Parse("1900-01-01 00:00:00")))
                    {
                        dtpProjectStopDate.Value = DateTime.Parse("1900-01-01 00:00:00");
                        dtpProjectStopDate.Format = DateTimePickerFormat.Custom;
                        dtpProjectStopDate.CustomFormat = " ";
                    }
                    else
                    {
                        dtpProjectStopDate.Value = projectRow.stopDate;
                        dtpProjectStopDate.Format = DateTimePickerFormat.Long;
                    }

                    //Checks the activity status-------------------------------------------------
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.aktivt))
                    {
                        chkProjecktActive.Checked = true;
                    }
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.okToAttest))
                    {
                        chkProjecktOkToAttest.Checked = true;
                    }
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.okToTidredovisa))
                    {
                        chkProjecktOkToTidredovisa.Checked = true;
                    }
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.avslutat))
                    {
                        chkProjectAvslutat.Checked = true;
                    }
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.projectPlanning))
                    {
                        chkProjectProjectPlanning.Checked = true;
                    }
                    if (projectRow.status.Equals(projectRow.status | (int)activityStatus.activityDone))
                    {
                        chkProjectActivityDone.Checked = true;
                    }
                    //Checks the activity price status ---------------------------------------------------

                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.lopandeTimpris))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.lopandeTimpris;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.fastPris))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.fastPris;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.avtalsfakturering))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.avtalsfakturering;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.timbank))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.timbank;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.ejDeb))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.ejDeb;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.interntProj))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.interntProj;
                    }
                    if (projectRow.priceStatus.Equals(projectRow.priceStatus | (int)activityPriceStatus.absence))
                    {
                        comboBoxProjectPriceStatus.SelectedValue = activityPriceStatus.absence;
                    }
                    comboBoxKlassificiering.SelectedIndex = projectRow.timeClassificationID-1;

                    //Checks the project type --------------------------------------------------------------
                    if (projectRow.parentID.Equals(0) && treeViewProjects.SelectedNode.Nodes.Count <= 0)
                    {
                        PopulateProjectTypeComboBox(typeSwitch.projektAndUppdrag);
                    }
                    else if (projectRow.parentID.Equals(0) && treeViewProjects.SelectedNode.Nodes.Count > 0)
                    {
                        PopulateProjectTypeComboBox(typeSwitch.projekt);
                    }
                    else if (!projectRow.parentID.Equals(0))
                    {
                        PopulateProjectTypeComboBox(typeSwitch.aktivitet);
                    }

                    
                    if (projectRow.type.Equals(projectRow.type | (int)projectType.projekt))
                    {
                        comboBoxProjectType.SelectedValue = projectType.projekt;
                    }
                    if (projectRow.type.Equals(projectRow.type | (int)projectType.uppdrag))
                    {
                        comboBoxProjectType.SelectedValue = projectType.uppdrag;
                    }
                    if (projectRow.type.Equals(projectRow.type | (int)projectType.aktivitet))
                    {
                        comboBoxProjectType.SelectedValue = projectType.aktivitet;
                    }
                    PopulateProjectManagerCombobox();
                    PopulateAttestComboBox();
                    PopulateCmdContactRef();
                    PopulateHideLabels();
                }
                EnableDisableProjectControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Gets the user who made last change to the project
        /// </summary>
        /// <param name="ChangeByID"></param>
        /// <returns></returns>
        private string GetUserNameByID(int ChangeByID)
        {
            try
            {
             
                if (ChangeByID != 0)
                {
                    UsersAdapter = new usersTableAdapter();
                    usersDataTable ud = UsersAdapter.GetUserNameByChangeByID(ChangeByID);
                    usersRow ur = (usersRow)ud.Rows[0];
                    UsersAdapter.Dispose();
                    return ur.firstName;
                }
                else
                {
                    return "-";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "-";
            }
        }
        /// <summary>
        /// Populates the AttestCombobox with Users
        /// </summary>
        private void PopulateAttestComboBox()
        {
            try
            {
                UsersAdapter = new usersTableAdapter();
                usersDataTable ud = UsersAdapter.GetAttestUsers();
                UsersAdapter.Dispose();
                cbAttest.ValueMember = "ID";
                cbAttest.DisplayMember = "fullName";
                cbAttest.DataSource = ud;
                cbAttest.SelectedValue = ProjectAttestID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Get all contacts, Creates a anonymous type and fills the list with objects of contacts.
        /// And creates one object with empty data for a blank contact.
        /// then fills combobox with objects of contacts.
        /// Sets the ProjectsContactID
        /// </summary>
        private void PopulateCmdContactRef()
        {
            try
            {
                List<object> reflist = new List<object>();

                int _refID;
                string _refName = string.Empty;

                foreach (DataRowView refItem in listBoxContacts.Items)
                {
                    _refID = int.Parse(refItem.Row[listBoxContacts.ValueMember].ToString());
                    _refName = refItem.Row[listBoxContacts.DisplayMember].ToString();
                    var anonymousData = new { ID = _refID, fullName = _refName };
                    reflist.Add(anonymousData);
                }
                var anonymousEmptyData = new { ID = 0, fullName = "-" };
                reflist.Insert(0, anonymousEmptyData);

                cbCustomerContactRef.ValueMember = "ID";
                cbCustomerContactRef.DisplayMember = "fullName";
                cbCustomerContactRef.DataSource = reflist;
                cbCustomerContactRef.SelectedValue = ProjectsContactID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Get all Users, Creates a anonymous type and fills the list with objects of Users.
        /// And creates one object with empty data for a blank User.
        /// then fills combobox with objects of User.
        /// Sets the ProjectManagerID
        /// </summary>
        private void PopulateProjectManagerCombobox()
        {
            try
            {
                UsersAdapter = new usersTableAdapter();
                usersDataTable ud = UsersAdapter.GetAllUsers();
                UsersAdapter.Dispose();

                List<object> userlist = new List<object>();
                foreach (usersRow ur in ud.Rows)
                {
                    var anonymousData = new { ID = ur.ID, fullName = ur.fullName };
                    userlist.Add(anonymousData);
                }
                var anonymousEmptyData = new { ID = 0, fullName = "-" };
                userlist.Insert(0, anonymousEmptyData);

                cbProjectManager.ValueMember = "ID";
                cbProjectManager.DisplayMember = "fullName";
                cbProjectManager.DataSource = userlist;
                cbProjectManager.SelectedValue = ProjectManagerID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PopulateHideLabels()
        {
            lblHideProjektType.Text = comboBoxProjectType.Text;
            lblHidePriceStatus.Text = comboBoxProjectPriceStatus.Text;
            labelKlassificering.Text = comboBoxKlassificiering.Text;
            lblHideStartDate.Text = dtpProjectStartDate.Text;
            lblHideStopdate.Text = dtpProjectStopDate.Text;
            lblHideProjectManage.Text = cbProjectManager.Text;
            lblHideAttest.Text = cbAttest.Text;
            lblHideRef.Text = cbCustomerContactRef.Text;
        }
        /// <summary>
        /// Changes ProjectTypeComboBox color, depending on whats selected 
        /// </summary>
        private void ChangeCbTypColor()
        {
            try
            {
                if (comboBoxProjectType.SelectedValue != null)
                {
                    if (comboBoxProjectType.SelectedValue.Equals(projectType.projekt))
                    {
                        comboBoxProjectType.BackColor = Color.LightBlue;
                        lblHideProjektType.ForeColor = Color.Blue;
                    }
                    else if (comboBoxProjectType.SelectedValue.Equals(projectType.uppdrag))
                    {
                        comboBoxProjectType.BackColor = Color.Green;
                        lblHideProjektType.ForeColor = Color.Green;
                    }
                    else if (comboBoxProjectType.SelectedValue.Equals(projectType.aktivitet))
                    {
                        comboBoxProjectType.BackColor = Color.Red;
                        lblHideProjektType.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        /// <summary>
        /// Finds and select the newest or the latest edited project or activity
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Create"></param>
        private void NewTreeNodeAutoSelect(int Id , bool Create)
        {
            try
            {
                bool found = false;
                foreach (TreeNode node in treeViewProjects.Nodes)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode childnode in node.Nodes)
                        {
                            if (((int)childnode.Tag == Id+1 && Create == true) || ((int)childnode.Tag == Id && Create == false))
                            {
                                activityID = Id;
                                treeViewProjects.SelectedNode = childnode;
                                gbTaskCounter.Visible = true;
                                found = true;
                                break;
                            }
                        }
                    }
                    else if ((int)node.Tag == Id && found == false)
                    {
                        treeViewProjects.SelectedNode = node;
                        activityID = Id;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddNewActivity()
        {
            PopulateProjectTypeComboBox(typeSwitch.aktivitet);
            chkProjecktActive.Checked = true;
            chkProjecktOkToAttest.Checked = true;
            chkProjecktOkToTidredovisa.Checked = true;
            txtProjectDescription.Text = string.Empty;
            txtProjectDescription.Focus();
        }

        #endregion

        #region UserEvents
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(treeViewProjects.SelectedNode != null)
            {
                AddSelectedUserToAktivitet();
                PopulateAssociatedUserToList((int)treeViewProjects.SelectedNode.Tag);
                cbUsers.DataSource = null;
                PopulateUsersComboBox();
            }
            else
            {
                MessageBox.Show("Projektet måste vara sparat innan man lägger till en användre");
            }
        }


        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbUsers.SelectedIndex = -1;
        }

        #endregion

        #region UserMethods
        /// <summary>
        /// Populate userComboBox with non associated users to the project / activity
        /// </summary>
        private void PopulateUsersComboBox()
        {
            try
            {
                usersTableAdapter userAdapter = new usersTableAdapter();
                usersDataTable usr = userAdapter.GetAllNotAddedUsers((int)treeViewProjects.SelectedNode.Tag);
                cbUsers.DisplayMember = "Name";
                cbUsers.ValueMember = "ID";
                cbUsers.DataSource = usr;
                cbUsers.SelectedIndex = -1;
                userAdapter.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Populate userListbox with the associated user to the project / activity
        /// </summary>
        /// <param name="activityID"></param>
        private void PopulateAssociatedUserToList(int activityID)
        {
            try
            {
                usersTableAdapter userAdapter = new usersTableAdapter();
                usersDataTable usrs = userAdapter.GetDataByJunktion(activityID);

                lbUsers.DisplayMember = "Name";
                lbUsers.ValueMember = "ID";
                lbUsers.DataSource = usrs;
                lbUsers.SelectedIndex = -1;
                userAdapter.Dispose();
            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Adds the selected user to the project / activity
        /// </summary>
        private void AddSelectedUserToAktivitet()
        {
            try
            {
                if(cbUsers.SelectedItem != null)
                {
                    activityUsersTableAdapter ActivityUserAdapter = new activityUsersTableAdapter();
                    activityUsersDataTable activityUserTable = ActivityUserAdapter.AddActivityUser();
                    activityUsersRow activityUserRow = activityUserTable.NewactivityUsersRow();

                    activityUserRow.userID = (int)cbUsers.SelectedValue;
                    activityUserRow.activityID = (int)treeViewProjects.SelectedNode.Tag;
                    activityUserRow.status = 0;
                    activityUserRow.priority = 0;
                    activityUserRow.resourcePercentage = 0;

                    activityUserTable.Rows.Add(activityUserRow);
                    ActivityUserAdapter.Update(activityUserTable);
                    ActivityUserAdapter.Dispose();
                    lbUsers.DataSource = null;
                }
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        #endregion

        private void btnPriceOpen_Click(object sender, EventArgs e)
        {
            if(listboxCustomers.SelectedItem != null)
            {
                priceWindow = new PriceWindow((int)listboxCustomers.SelectedValue, (int)projectType.projekt, (int)projectType.uppdrag, Convert.ToInt32(txtCustomerStdHourlyPrice.Text), Convert.ToInt32(txtCustomerStdOvetTime1.Text) , Convert.ToInt32(txtCustomerStdOvetTime2.Text));
                priceWindow.ShowDialog();
            }
           

        }

       
    }
}
