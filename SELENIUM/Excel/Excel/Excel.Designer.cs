namespace Excel
{
    partial class Excel
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertBreakPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllBreakPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(607, 366);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Open";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(758, 339);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FileName";
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(74, 400);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(166, 21);
            this.cboSheet.TabIndex = 3;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(74, 366);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(510, 20);
            this.txtFileName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sheet";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(688, 400);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 6;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Restart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Continue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.continue_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(422, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Step";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.step_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertBreakPointToolStripMenuItem,
            this.removeAllBreakPointsToolStripMenuItem,
            this.insertLineToolStripMenuItem,
            this.removeLineToolStripMenuItem,
            this.appendLineToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 136);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // insertBreakPointToolStripMenuItem
            // 
            this.insertBreakPointToolStripMenuItem.Name = "insertBreakPointToolStripMenuItem";
            this.insertBreakPointToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.insertBreakPointToolStripMenuItem.Text = "Insert Break Point";
            this.insertBreakPointToolStripMenuItem.Click += new System.EventHandler(this.insertBreakPointToolStripMenuItem_Click);
            // 
            // removeAllBreakPointsToolStripMenuItem
            // 
            this.removeAllBreakPointsToolStripMenuItem.Name = "removeAllBreakPointsToolStripMenuItem";
            this.removeAllBreakPointsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.removeAllBreakPointsToolStripMenuItem.Text = "Remove All Break Points";
            this.removeAllBreakPointsToolStripMenuItem.Click += new System.EventHandler(this.removeBreakPointToolStripMenuItem_Click);
            // 
            // insertLineToolStripMenuItem
            // 
            this.insertLineToolStripMenuItem.Name = "insertLineToolStripMenuItem";
            this.insertLineToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.insertLineToolStripMenuItem.Text = "Insert Line";
            this.insertLineToolStripMenuItem.Click += new System.EventHandler(this.insertLineToolStripMenuItem_Click);
            // 
            // removeLineToolStripMenuItem
            // 
            this.removeLineToolStripMenuItem.Name = "removeLineToolStripMenuItem";
            this.removeLineToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.removeLineToolStripMenuItem.Text = "Remove Line";
            this.removeLineToolStripMenuItem.Click += new System.EventHandler(this.removeLineToolStripMenuItem_Click);
            // 
            // appendLineToolStripMenuItem
            // 
            this.appendLineToolStripMenuItem.Name = "appendLineToolStripMenuItem";
            this.appendLineToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.appendLineToolStripMenuItem.Text = "AppendLine";
            this.appendLineToolStripMenuItem.Click += new System.EventHandler(this.appendLineToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(688, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Save_Click);
            // 
            // Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Excel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selenium Tests Defined using Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertBreakPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllBreakPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendLineToolStripMenuItem;
        private System.Windows.Forms.Button button4;
    }
}

