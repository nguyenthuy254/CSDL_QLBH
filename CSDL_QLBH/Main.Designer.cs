namespace CSDL_QLBH
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DMChatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.DMNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.DMHanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMucToolStripMenuItem,
            this.ThoatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMucToolStripMenuItem
            // 
            this.danhMucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMChatlieu,
            this.DMNhanvien,
            this.DMHanghoa});
            this.danhMucToolStripMenuItem.Name = "danhMucToolStripMenuItem";
            this.danhMucToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.danhMucToolStripMenuItem.Text = "Danh mục";
            // 
            // DMChatlieu
            // 
            this.DMChatlieu.Name = "DMChatlieu";
            this.DMChatlieu.Size = new System.Drawing.Size(270, 34);
            this.DMChatlieu.Text = "DM Chất Liệu";
            this.DMChatlieu.Click += new System.EventHandler(this.DMChatlieu_Click);
            // 
            // DMNhanvien
            // 
            this.DMNhanvien.Name = "DMNhanvien";
            this.DMNhanvien.Size = new System.Drawing.Size(270, 34);
            this.DMNhanvien.Text = "DM Nhân Viên";
            this.DMNhanvien.Click += new System.EventHandler(this.DMNhanvien_Click);
            // 
            // DMHanghoa
            // 
            this.DMHanghoa.Name = "DMHanghoa";
            this.DMHanghoa.Size = new System.Drawing.Size(270, 34);
            this.DMHanghoa.Text = "DM Hàng Hóa";
            this.DMHanghoa.Click += new System.EventHandler(this.DMHanghoa_Click);
            // 
            // ThoatToolStripMenuItem
            // 
            this.ThoatToolStripMenuItem.Name = "ThoatToolStripMenuItem";
            this.ThoatToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.ThoatToolStripMenuItem.Text = "Thoát";
            this.ThoatToolStripMenuItem.Click += new System.EventHandler(this.ThoatToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MAIN";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DMChatlieu;
        private System.Windows.Forms.ToolStripMenuItem DMNhanvien;
        private System.Windows.Forms.ToolStripMenuItem DMHanghoa;
        private System.Windows.Forms.ToolStripMenuItem ThoatToolStripMenuItem;
    }
}

