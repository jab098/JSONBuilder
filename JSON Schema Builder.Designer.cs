namespace Json_Builder
{
    partial class JSONBuilder
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.cmbCollectedSchemas = new System.Windows.Forms.ComboBox();
            this.btnAddSchema = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstChosenSchemas = new System.Windows.Forms.ListBox();
            this.radCCACase = new System.Windows.Forms.RadioButton();
            this.radCCAAuth = new System.Windows.Forms.RadioButton();
            this.radCustomer = new System.Windows.Forms.RadioButton();
            this.radNDRVal = new System.Windows.Forms.RadioButton();
            this.radNDRList = new System.Windows.Forms.RadioButton();
            this.chkBuildComplete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(39, 283);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(155, 42);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Create!";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cmbCollectedSchemas
            // 
            this.cmbCollectedSchemas.FormattingEnabled = true;
            this.cmbCollectedSchemas.Location = new System.Drawing.Point(12, 12);
            this.cmbCollectedSchemas.Name = "cmbCollectedSchemas";
            this.cmbCollectedSchemas.Size = new System.Drawing.Size(210, 21);
            this.cmbCollectedSchemas.TabIndex = 18;
            // 
            // btnAddSchema
            // 
            this.btnAddSchema.Location = new System.Drawing.Point(12, 58);
            this.btnAddSchema.Name = "btnAddSchema";
            this.btnAddSchema.Size = new System.Drawing.Size(75, 23);
            this.btnAddSchema.TabIndex = 20;
            this.btnAddSchema.Text = "Add Schema";
            this.btnAddSchema.UseVisualStyleBackColor = true;
            this.btnAddSchema.Click += new System.EventHandler(this.btnAddSchema_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(147, 58);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstChosenSchemas
            // 
            this.lstChosenSchemas.FormattingEnabled = true;
            this.lstChosenSchemas.Location = new System.Drawing.Point(12, 87);
            this.lstChosenSchemas.Name = "lstChosenSchemas";
            this.lstChosenSchemas.Size = new System.Drawing.Size(210, 186);
            this.lstChosenSchemas.TabIndex = 22;
            // 
            // radCCACase
            // 
            this.radCCACase.AutoSize = true;
            this.radCCACase.Location = new System.Drawing.Point(228, 87);
            this.radCCACase.Name = "radCCACase";
            this.radCCACase.Size = new System.Drawing.Size(73, 17);
            this.radCCACase.TabIndex = 23;
            this.radCCACase.TabStop = true;
            this.radCCACase.Text = "CCA Case";
            this.radCCACase.UseVisualStyleBackColor = true;
            this.radCCACase.CheckedChanged += new System.EventHandler(this.radCCACase_CheckedChanged);
            // 
            // radCCAAuth
            // 
            this.radCCAAuth.AutoSize = true;
            this.radCCAAuth.Location = new System.Drawing.Point(228, 130);
            this.radCCAAuth.Name = "radCCAAuth";
            this.radCCAAuth.Size = new System.Drawing.Size(110, 17);
            this.radCCAAuth.TabIndex = 24;
            this.radCCAAuth.TabStop = true;
            this.radCCAAuth.Text = "CCA Authorization";
            this.radCCAAuth.UseVisualStyleBackColor = true;
            this.radCCAAuth.CheckedChanged += new System.EventHandler(this.radCCAAuth_CheckedChanged);
            // 
            // radCustomer
            // 
            this.radCustomer.AutoSize = true;
            this.radCustomer.Location = new System.Drawing.Point(228, 256);
            this.radCustomer.Name = "radCustomer";
            this.radCustomer.Size = new System.Drawing.Size(69, 17);
            this.radCustomer.TabIndex = 25;
            this.radCustomer.TabStop = true;
            this.radCustomer.Text = "Customer";
            this.radCustomer.UseVisualStyleBackColor = true;
            this.radCustomer.CheckedChanged += new System.EventHandler(this.radCustomer_CheckedChanged);
            // 
            // radNDRVal
            // 
            this.radNDRVal.AutoSize = true;
            this.radNDRVal.Location = new System.Drawing.Point(228, 216);
            this.radNDRVal.Name = "radNDRVal";
            this.radNDRVal.Size = new System.Drawing.Size(96, 17);
            this.radNDRVal.TabIndex = 26;
            this.radNDRVal.TabStop = true;
            this.radNDRVal.Text = "NDR Valuation";
            this.radNDRVal.UseVisualStyleBackColor = true;
            this.radNDRVal.CheckedChanged += new System.EventHandler(this.radNDRVal_CheckedChanged);
            // 
            // radNDRList
            // 
            this.radNDRList.AutoSize = true;
            this.radNDRList.Location = new System.Drawing.Point(228, 173);
            this.radNDRList.Name = "radNDRList";
            this.radNDRList.Size = new System.Drawing.Size(68, 17);
            this.radNDRList.TabIndex = 27;
            this.radNDRList.TabStop = true;
            this.radNDRList.Text = "NDR List";
            this.radNDRList.UseVisualStyleBackColor = true;
            this.radNDRList.CheckedChanged += new System.EventHandler(this.radNDRList_CheckedChanged);
            // 
            // chkBuildComplete
            // 
            this.chkBuildComplete.AutoSize = true;
            this.chkBuildComplete.Location = new System.Drawing.Point(228, 16);
            this.chkBuildComplete.Name = "chkBuildComplete";
            this.chkBuildComplete.Size = new System.Drawing.Size(96, 17);
            this.chkBuildComplete.TabIndex = 28;
            this.chkBuildComplete.Text = "Complete Build";
            this.chkBuildComplete.UseVisualStyleBackColor = true;
            // 
            // JSONBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 339);
            this.Controls.Add(this.chkBuildComplete);
            this.Controls.Add(this.radNDRList);
            this.Controls.Add(this.radNDRVal);
            this.Controls.Add(this.radCustomer);
            this.Controls.Add(this.radCCAAuth);
            this.Controls.Add(this.radCCACase);
            this.Controls.Add(this.lstChosenSchemas);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddSchema);
            this.Controls.Add(this.cmbCollectedSchemas);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "JSONBuilder";
            this.Text = "JSON Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cmbCollectedSchemas;
        private System.Windows.Forms.Button btnAddSchema;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstChosenSchemas;
        private System.Windows.Forms.RadioButton radCCACase;
        private System.Windows.Forms.RadioButton radCCAAuth;
        private System.Windows.Forms.RadioButton radCustomer;
        private System.Windows.Forms.RadioButton radNDRVal;
        private System.Windows.Forms.RadioButton radNDRList;
        private System.Windows.Forms.CheckBox chkBuildComplete;
    }
}

