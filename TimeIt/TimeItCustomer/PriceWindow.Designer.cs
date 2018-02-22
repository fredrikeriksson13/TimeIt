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
            this.rdbSelectAll = new System.Windows.Forms.RadioButton();
            this.rdbSelectDefault = new System.Windows.Forms.RadioButton();
            this.rdbUnselectAll = new System.Windows.Forms.RadioButton();
            this.txtOvertime2 = new System.Windows.Forms.TextBox();
            this.txtHourlyPrice = new System.Windows.Forms.TextBox();
            this.txtOvertime1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewOvertime1 = new System.Windows.Forms.TextBox();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.txtNewOvertime2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDefaultOvertime1 = new System.Windows.Forms.TextBox();
            this.txtDefaultTimpris = new System.Windows.Forms.TextBox();
            this.txtDefaultovertime2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewHourlyRate
            // 
            this.treeViewHourlyRate.CheckBoxes = true;
            this.treeViewHourlyRate.ImageIndex = 0;
            this.treeViewHourlyRate.ImageList = this.imageList1;
            this.treeViewHourlyRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeViewHourlyRate.Location = new System.Drawing.Point(12, 35);
            this.treeViewHourlyRate.Name = "treeViewHourlyRate";
            this.treeViewHourlyRate.SelectedImageIndex = 0;
            this.treeViewHourlyRate.Size = new System.Drawing.Size(237, 622);
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
            this.chkProjectActive.Location = new System.Drawing.Point(12, 8);
            this.chkProjectActive.Name = "chkProjectActive";
            this.chkProjectActive.Size = new System.Drawing.Size(109, 21);
            this.chkProjectActive.TabIndex = 1;
            this.chkProjectActive.Text = "Visa inaktiva";
            this.chkProjectActive.UseVisualStyleBackColor = true;
            this.chkProjectActive.CheckedChanged += new System.EventHandler(this.chkProjectActive_CheckedChanged);
            // 
            // rdbSelectAll
            // 
            this.rdbSelectAll.AutoSize = true;
            this.rdbSelectAll.Location = new System.Drawing.Point(255, 35);
            this.rdbSelectAll.Name = "rdbSelectAll";
            this.rdbSelectAll.Size = new System.Drawing.Size(107, 21);
            this.rdbSelectAll.TabIndex = 2;
            this.rdbSelectAll.TabStop = true;
            this.rdbSelectAll.Text = "Markera alla";
            this.rdbSelectAll.UseVisualStyleBackColor = true;
            this.rdbSelectAll.CheckedChanged += new System.EventHandler(this.rdbSelectAll_CheckedChanged);
            // 
            // rdbSelectDefault
            // 
            this.rdbSelectDefault.AutoSize = true;
            this.rdbSelectDefault.Location = new System.Drawing.Point(255, 89);
            this.rdbSelectDefault.Name = "rdbSelectDefault";
            this.rdbSelectDefault.Size = new System.Drawing.Size(225, 21);
            this.rdbSelectDefault.TabIndex = 3;
            this.rdbSelectDefault.TabStop = true;
            this.rdbSelectDefault.Text = "Markera alla med standard pris";
            this.rdbSelectDefault.UseVisualStyleBackColor = true;
            this.rdbSelectDefault.CheckedChanged += new System.EventHandler(this.rdbSelectDefault_CheckedChanged);
            // 
            // rdbUnselectAll
            // 
            this.rdbUnselectAll.AutoSize = true;
            this.rdbUnselectAll.Location = new System.Drawing.Point(255, 62);
            this.rdbUnselectAll.Name = "rdbUnselectAll";
            this.rdbUnselectAll.Size = new System.Drawing.Size(123, 21);
            this.rdbUnselectAll.TabIndex = 4;
            this.rdbUnselectAll.TabStop = true;
            this.rdbUnselectAll.Text = "Avmarkera alla";
            this.rdbUnselectAll.UseVisualStyleBackColor = true;
            this.rdbUnselectAll.CheckedChanged += new System.EventHandler(this.rdbUnselectAll_CheckedChanged);
            // 
            // txtOvertime2
            // 
            this.txtOvertime2.Location = new System.Drawing.Point(4, 144);
            this.txtOvertime2.Name = "txtOvertime2";
            this.txtOvertime2.ReadOnly = true;
            this.txtOvertime2.Size = new System.Drawing.Size(100, 22);
            this.txtOvertime2.TabIndex = 5;
            // 
            // txtHourlyPrice
            // 
            this.txtHourlyPrice.Location = new System.Drawing.Point(6, 54);
            this.txtHourlyPrice.Name = "txtHourlyPrice";
            this.txtHourlyPrice.ReadOnly = true;
            this.txtHourlyPrice.Size = new System.Drawing.Size(100, 22);
            this.txtHourlyPrice.TabIndex = 7;
            // 
            // txtOvertime1
            // 
            this.txtOvertime1.Location = new System.Drawing.Point(4, 99);
            this.txtOvertime1.Name = "txtOvertime1";
            this.txtOvertime1.ReadOnly = true;
            this.txtOvertime1.Size = new System.Drawing.Size(100, 22);
            this.txtOvertime1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Timpris";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Övertid 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Övertid 2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(777, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(777, 78);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 21);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(777, 105);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 21);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(823, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(904, 622);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ny Övertid 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = " Ny Övertid 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nytt Timpris";
            // 
            // txtNewOvertime1
            // 
            this.txtNewOvertime1.Location = new System.Drawing.Point(9, 93);
            this.txtNewOvertime1.Name = "txtNewOvertime1";
            this.txtNewOvertime1.Size = new System.Drawing.Size(100, 22);
            this.txtNewOvertime1.TabIndex = 19;
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(9, 48);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(100, 22);
            this.txtNewPrice.TabIndex = 18;
            // 
            // txtNewOvertime2
            // 
            this.txtNewOvertime2.Location = new System.Drawing.Point(9, 138);
            this.txtNewOvertime2.Name = "txtNewOvertime2";
            this.txtNewOvertime2.Size = new System.Drawing.Size(100, 22);
            this.txtNewOvertime2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Ny Övertid 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = " Ny Övertid 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Nytt Timpris";
            // 
            // txtDefaultOvertime1
            // 
            this.txtDefaultOvertime1.Location = new System.Drawing.Point(12, 99);
            this.txtDefaultOvertime1.Name = "txtDefaultOvertime1";
            this.txtDefaultOvertime1.Size = new System.Drawing.Size(100, 22);
            this.txtDefaultOvertime1.TabIndex = 25;
            // 
            // txtDefaultTimpris
            // 
            this.txtDefaultTimpris.Location = new System.Drawing.Point(12, 54);
            this.txtDefaultTimpris.Name = "txtDefaultTimpris";
            this.txtDefaultTimpris.Size = new System.Drawing.Size(100, 22);
            this.txtDefaultTimpris.TabIndex = 24;
            // 
            // txtDefaultovertime2
            // 
            this.txtDefaultovertime2.Location = new System.Drawing.Point(12, 144);
            this.txtDefaultovertime2.Name = "txtDefaultovertime2";
            this.txtDefaultovertime2.Size = new System.Drawing.Size(100, 22);
            this.txtDefaultovertime2.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.txtHourlyPrice);
            this.groupBox1.Controls.Add(this.txtOvertime2);
            this.groupBox1.Controls.Add(this.txtOvertime1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(445, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 179);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aktivitets priser";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Controls.Add(this.txtNewOvertime1);
            this.groupBox2.Controls.Add(this.txtNewOvertime2);
            this.groupBox2.Controls.Add(this.txtNewPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(692, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 174);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prisändring på markerade";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Controls.Add(this.txtDefaultovertime2);
            this.groupBox3.Controls.Add(this.txtDefaultTimpris);
            this.groupBox3.Controls.Add(this.txtDefaultOvertime1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(316, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 179);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Standard priser";
            // 
            // PriceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 669);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rdbUnselectAll);
            this.Controls.Add(this.rdbSelectDefault);
            this.Controls.Add(this.rdbSelectAll);
            this.Controls.Add(this.chkProjectActive);
            this.Controls.Add(this.treeViewHourlyRate);
            this.Name = "PriceWindow";
            this.Text = "PriceWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewHourlyRate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkProjectActive;
        private System.Windows.Forms.RadioButton rdbSelectAll;
        private System.Windows.Forms.RadioButton rdbSelectDefault;
        private System.Windows.Forms.RadioButton rdbUnselectAll;
        private System.Windows.Forms.TextBox txtOvertime2;
        private System.Windows.Forms.TextBox txtHourlyPrice;
        private System.Windows.Forms.TextBox txtOvertime1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewOvertime1;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.TextBox txtNewOvertime2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDefaultOvertime1;
        private System.Windows.Forms.TextBox txtDefaultTimpris;
        private System.Windows.Forms.TextBox txtDefaultovertime2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}