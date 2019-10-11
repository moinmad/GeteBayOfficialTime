namespace GeteBayOfficialTime
{
    partial class frm_Analysis
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
            this.btn_loadEbayData = new System.Windows.Forms.Button();
            this.txtbx_userid = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtbx_dbpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_loaddata = new System.Windows.Forms.Button();
            this.datepick_ebay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbx_Active = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ActiveListing = new System.Windows.Forms.Label();
            this.txtbx_InvDBPath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EbayItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighBidder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_chkfordups = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_loadEbayData
            // 
            this.btn_loadEbayData.Location = new System.Drawing.Point(12, 12);
            this.btn_loadEbayData.Name = "btn_loadEbayData";
            this.btn_loadEbayData.Size = new System.Drawing.Size(137, 23);
            this.btn_loadEbayData.TabIndex = 0;
            this.btn_loadEbayData.Text = "Load Ebay Data";
            this.btn_loadEbayData.UseVisualStyleBackColor = true;
            this.btn_loadEbayData.Click += new System.EventHandler(this.btn_loadEbayData_Click);
            // 
            // txtbx_userid
            // 
            this.txtbx_userid.Location = new System.Drawing.Point(165, 14);
            this.txtbx_userid.Name = "txtbx_userid";
            this.txtbx_userid.Size = new System.Drawing.Size(177, 20);
            this.txtbx_userid.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(375, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(609, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(12, 41);
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(330, 20);
            this.txtResults.TabIndex = 4;
            // 
            // txtbx_dbpath
            // 
            this.txtbx_dbpath.Location = new System.Drawing.Point(375, 40);
            this.txtbx_dbpath.Name = "txtbx_dbpath";
            this.txtbx_dbpath.Size = new System.Drawing.Size(357, 20);
            this.txtbx_dbpath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // btn_loaddata
            // 
            this.btn_loaddata.Location = new System.Drawing.Point(12, 90);
            this.btn_loaddata.Name = "btn_loaddata";
            this.btn_loaddata.Size = new System.Drawing.Size(87, 23);
            this.btn_loaddata.TabIndex = 8;
            this.btn_loaddata.Text = "LoadData";
            this.btn_loaddata.UseVisualStyleBackColor = true;
            this.btn_loaddata.Click += new System.EventHandler(this.btn_loaddata_Click);
            // 
            // datepick_ebay
            // 
            this.datepick_ebay.Location = new System.Drawing.Point(532, 93);
            this.datepick_ebay.Name = "datepick_ebay";
            this.datepick_ebay.Size = new System.Drawing.Size(200, 20);
            this.datepick_ebay.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(774, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // chkbx_Active
            // 
            this.chkbx_Active.AutoSize = true;
            this.chkbx_Active.Location = new System.Drawing.Point(15, 119);
            this.chkbx_Active.Name = "chkbx_Active";
            this.chkbx_Active.Size = new System.Drawing.Size(56, 17);
            this.chkbx_Active.TabIndex = 11;
            this.chkbx_Active.Text = "Active";
            this.chkbx_Active.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Number of Active Listings";
            // 
            // lbl_ActiveListing
            // 
            this.lbl_ActiveListing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ActiveListing.AutoSize = true;
            this.lbl_ActiveListing.Location = new System.Drawing.Point(145, 488);
            this.lbl_ActiveListing.Name = "lbl_ActiveListing";
            this.lbl_ActiveListing.Size = new System.Drawing.Size(10, 13);
            this.lbl_ActiveListing.TabIndex = 13;
            this.lbl_ActiveListing.Text = " ";
            // 
            // txtbx_InvDBPath
            // 
            this.txtbx_InvDBPath.Location = new System.Drawing.Point(375, 66);
            this.txtbx_InvDBPath.Name = "txtbx_InvDBPath";
            this.txtbx_InvDBPath.Size = new System.Drawing.Size(357, 20);
            this.txtbx_InvDBPath.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomLabel,
            this.EbayItemNumber,
            this.StartDate,
            this.EndDate,
            this.HighBidder,
            this.Shipped,
            this.ShippingType,
            this.Title,
            this.SubTitle,
            this.Description});
            this.dataGridView1.Location = new System.Drawing.Point(12, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 318);
            this.dataGridView1.TabIndex = 7;
            // 
            // CustomLabel
            // 
            this.CustomLabel.HeaderText = "Custom Label";
            this.CustomLabel.Name = "CustomLabel";
            // 
            // EbayItemNumber
            // 
            this.EbayItemNumber.HeaderText = "Ebay Item #";
            this.EbayItemNumber.Name = "EbayItemNumber";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            // 
            // HighBidder
            // 
            this.HighBidder.HeaderText = "High Bidder";
            this.HighBidder.Name = "HighBidder";
            // 
            // Shipped
            // 
            this.Shipped.HeaderText = "Shipping Status";
            this.Shipped.Name = "Shipped";
            // 
            // ShippingType
            // 
            this.ShippingType.HeaderText = "Shipping Type";
            this.ShippingType.Name = "ShippingType";
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // SubTitle
            // 
            this.SubTitle.HeaderText = "Sub Title";
            this.SubTitle.Name = "SubTitle";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // btn_chkfordups
            // 
            this.btn_chkfordups.Location = new System.Drawing.Point(114, 90);
            this.btn_chkfordups.Name = "btn_chkfordups";
            this.btn_chkfordups.Size = new System.Drawing.Size(99, 23);
            this.btn_chkfordups.TabIndex = 15;
            this.btn_chkfordups.Text = "Check For Dups";
            this.btn_chkfordups.UseVisualStyleBackColor = true;
            this.btn_chkfordups.Click += new System.EventHandler(this.btn_chkfordups_Click);
            // 
            // frm_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 518);
            this.Controls.Add(this.btn_chkfordups);
            this.Controls.Add(this.txtbx_InvDBPath);
            this.Controls.Add(this.lbl_ActiveListing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkbx_Active);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datepick_ebay);
            this.Controls.Add(this.btn_loaddata);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_dbpath);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtbx_userid);
            this.Controls.Add(this.btn_loadEbayData);
            this.Name = "frm_Analysis";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_loadEbayData;
        private System.Windows.Forms.TextBox txtbx_userid;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtbx_dbpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_loaddata;
        private System.Windows.Forms.DateTimePicker datepick_ebay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbx_Active;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ActiveListing;
        private System.Windows.Forms.TextBox txtbx_InvDBPath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn EbayItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighBidder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button btn_chkfordups;
    }
}