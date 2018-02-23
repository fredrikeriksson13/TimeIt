namespace TimeItCustomer
{
    partial class PriceWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceWindow));
            this.treeViewHourlyRate = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkProjectActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewOvertime1 = new System.Windows.Forms.TextBox();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.txtNewOvertime2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSelectDefault = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblSaved = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewHourlyRate
            // 
            this.treeViewHourlyRate.CheckBoxes = true;
            this.treeViewHourlyRate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.treeViewHourlyRate.ImageIndex = 0;
            this.treeViewHourlyRate.ImageList = this.imageList1;
            this.treeViewHourlyRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeViewHourlyRate.Location = new System.Drawing.Point(15, 60);
            this.treeViewHourlyRate.Name = "treeViewHourlyRate";
            this.treeViewHourlyRate.SelectedImageIndex = 0;
            this.treeViewHourlyRate.Size = new System.Drawing.Size(237, 503);
            this.treeViewHourlyRate.TabIndex = 0;
            this.treeViewHourlyRate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewHourlyRate_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Documents-Blue-1.png");
            this.imageList1.Images.SetKeyName(1, "Documents-green-1.png");
            this.imageList1.Images.SetKeyName(2, "Document-Red.png");
            this.imageList1.Images.SetKeyName(3, "Documents-Gray.png");
            this.imageList1.Images.SetKeyName(4, "Document-Gray.png");
            // 
            // chkProjectActive
            // 
            this.chkProjectActive.AutoSize = true;
            this.chkProjectActive.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.chkProjectActive.Location = new System.Drawing.Point(15, 33);
            this.chkProjectActive.Name = "chkProjectActive";
            this.chkProjectActive.Size = new System.Drawing.Size(118, 22);
            this.chkProjectActive.TabIndex = 1;
            this.chkProjectActive.Text = "Visa inaktiva";
            this.chkProjectActive.UseVisualStyleBackColor = true;
            this.chkProjectActive.CheckedChanged += new System.EventHandler(this.chkProjectActive_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(394, 577);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(475, 577);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Stäng";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(71, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Övertid 2 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(71, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Övertid 1 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(85, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Timpris :";
            // 
            // txtNewOvertime1
            // 
            this.txtNewOvertime1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtNewOvertime1.Location = new System.Drawing.Point(158, 70);
            this.txtNewOvertime1.Name = "txtNewOvertime1";
            this.txtNewOvertime1.Size = new System.Drawing.Size(100, 23);
            this.txtNewOvertime1.TabIndex = 19;
            this.txtNewOvertime1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewOvertime1_KeyUp);
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtNewPrice.Location = new System.Drawing.Point(158, 29);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(100, 23);
            this.txtNewPrice.TabIndex = 18;
            this.txtNewPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewPrice_KeyUp);
            // 
            // txtNewOvertime2
            // 
            this.txtNewOvertime2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtNewOvertime2.Location = new System.Drawing.Point(158, 113);
            this.txtNewOvertime2.Name = "txtNewOvertime2";
            this.txtNewOvertime2.Size = new System.Drawing.Size(100, 23);
            this.txtNewOvertime2.TabIndex = 17;
            this.txtNewOvertime2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewOvertime2_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.txtNewOvertime1);
            this.groupBox2.Controls.Add(this.txtNewOvertime2);
            this.groupBox2.Controls.Add(this.txtNewPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.groupBox2.Location = new System.Drawing.Point(258, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 156);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prissättning ";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblCounter.Location = new System.Drawing.Point(234, 585);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(119, 18);
            this.lblCounter.TabIndex = 32;
            this.lblCounter.Text = "Antal ibockade :";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.lblSaved);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnUnselectAll);
            this.groupBox4.Controls.Add(this.btnSelectDefault);
            this.groupBox4.Controls.Add(this.btnSelectAll);
            this.groupBox4.Controls.Add(this.treeViewHourlyRate);
            this.groupBox4.Controls.Add(this.chkProjectActive);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(-3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(553, 568);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Priser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(291, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Avmarkera alla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(291, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Markera alla med standard pris";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(291, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Markera alla";
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUnselectAll.Location = new System.Drawing.Point(258, 102);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(27, 23);
            this.btnUnselectAll.TabIndex = 33;
            this.btnUnselectAll.UseVisualStyleBackColor = false;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectDefault
            // 
            this.btnSelectDefault.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectDefault.Location = new System.Drawing.Point(258, 144);
            this.btnSelectDefault.Name = "btnSelectDefault";
            this.btnSelectDefault.Size = new System.Drawing.Size(27, 23);
            this.btnSelectDefault.TabIndex = 32;
            this.btnSelectDefault.UseVisualStyleBackColor = false;
            this.btnSelectDefault.Click += new System.EventHandler(this.btnSelectDefault_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectAll.Location = new System.Drawing.Point(258, 60);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(27, 23);
            this.btnSelectAll.TabIndex = 31;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSaved.Location = new System.Drawing.Point(432, 539);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(72, 24);
            this.lblSaved.TabIndex = 37;
            this.lblSaved.Text = "Sparat";
            this.lblSaved.Visible = false;
            // 
            // PriceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(563, 624);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Name = "PriceWindow";
            this.Text = "PriceWindow";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewHourlyRate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkProjectActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewOvertime1;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.TextBox txtNewOvertime2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSelectDefault;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label lblSaved;
    }
}