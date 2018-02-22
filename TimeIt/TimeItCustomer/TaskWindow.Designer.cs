namespace TimeItCustomer
{
    partial class TaskWindow
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
            this.gbTaskwindow = new System.Windows.Forms.GroupBox();
            this.btnRevert = new System.Windows.Forms.Button();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.btnTaskCancel = new System.Windows.Forms.Button();
            this.btnTaskSave = new System.Windows.Forms.Button();
            this.btnTaskEdit = new System.Windows.Forms.Button();
            this.gbTaskwindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTaskwindow
            // 
            this.gbTaskwindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTaskwindow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbTaskwindow.Controls.Add(this.btnRevert);
            this.gbTaskwindow.Controls.Add(this.dgvTask);
            this.gbTaskwindow.Controls.Add(this.btnTaskCancel);
            this.gbTaskwindow.Controls.Add(this.btnTaskSave);
            this.gbTaskwindow.Controls.Add(this.btnTaskEdit);
            this.gbTaskwindow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTaskwindow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbTaskwindow.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.gbTaskwindow.Location = new System.Drawing.Point(6, 5);
            this.gbTaskwindow.Name = "gbTaskwindow";
            this.gbTaskwindow.Size = new System.Drawing.Size(971, 544);
            this.gbTaskwindow.TabIndex = 10;
            this.gbTaskwindow.TabStop = false;
            this.gbTaskwindow.Text = "Task";
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnRevert.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevert.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevert.Location = new System.Drawing.Point(874, 17);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(90, 28);
            this.btnRevert.TabIndex = 15;
            this.btnRevert.Text = "Återställ";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click_1);
            // 
            // dgvTask
            // 
            this.dgvTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTask.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTask.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTask.Location = new System.Drawing.Point(6, 51);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.RowHeadersWidth = 25;
            this.dgvTask.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTask.RowTemplate.Height = 20;
            this.dgvTask.Size = new System.Drawing.Size(958, 450);
            this.dgvTask.TabIndex = 14;
            this.dgvTask.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTask_CellMouseUp);
            this.dgvTask.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTask_DefaultValuesNeeded);
            this.dgvTask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTask_MouseClick_1);
            // 
            // btnTaskCancel
            // 
            this.btnTaskCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaskCancel.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnTaskCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaskCancel.Location = new System.Drawing.Point(874, 510);
            this.btnTaskCancel.Name = "btnTaskCancel";
            this.btnTaskCancel.Size = new System.Drawing.Size(90, 28);
            this.btnTaskCancel.TabIndex = 10;
            this.btnTaskCancel.Text = "Stäng";
            this.btnTaskCancel.UseVisualStyleBackColor = false;
            this.btnTaskCancel.Click += new System.EventHandler(this.btnTaskCancel_Click);
            // 
            // btnTaskSave
            // 
            this.btnTaskSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaskSave.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnTaskSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaskSave.Location = new System.Drawing.Point(793, 510);
            this.btnTaskSave.Name = "btnTaskSave";
            this.btnTaskSave.Size = new System.Drawing.Size(75, 28);
            this.btnTaskSave.TabIndex = 9;
            this.btnTaskSave.Text = "Spara";
            this.btnTaskSave.UseVisualStyleBackColor = false;
            this.btnTaskSave.Click += new System.EventHandler(this.btnTaskSave_Click_1);
            // 
            // btnTaskEdit
            // 
            this.btnTaskEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaskEdit.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnTaskEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaskEdit.Location = new System.Drawing.Point(874, 510);
            this.btnTaskEdit.Name = "btnTaskEdit";
            this.btnTaskEdit.Size = new System.Drawing.Size(90, 28);
            this.btnTaskEdit.TabIndex = 11;
            this.btnTaskEdit.Text = "Redigera";
            this.btnTaskEdit.UseVisualStyleBackColor = false;
            // 
            // TaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.gbTaskwindow);
            this.Name = "TaskWindow";
            this.Text = "TaskWindow";
            this.gbTaskwindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTaskwindow;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Button btnTaskCancel;
        private System.Windows.Forms.Button btnTaskSave;
        private System.Windows.Forms.Button btnTaskEdit;
        private System.Windows.Forms.Button btnRevert;
    }
}