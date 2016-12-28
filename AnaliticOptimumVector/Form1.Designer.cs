namespace AnaliticOptimumVector
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьAToolStripMenuItem,
            this.открытьBToolStripMenuItem,
            this.найтиСToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьAToolStripMenuItem
            // 
            this.открытьAToolStripMenuItem.Name = "открытьAToolStripMenuItem";
            this.открытьAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.открытьAToolStripMenuItem.Text = "Открыть A";
            this.открытьAToolStripMenuItem.Click += new System.EventHandler(this.открытьAToolStripMenuItem_Click);
            // 
            // открытьBToolStripMenuItem
            // 
            this.открытьBToolStripMenuItem.Name = "открытьBToolStripMenuItem";
            this.открытьBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.открытьBToolStripMenuItem.Text = "Открыть B";
            this.открытьBToolStripMenuItem.Click += new System.EventHandler(this.открытьBToolStripMenuItem_Click);
            // 
            // найтиСToolStripMenuItem
            // 
            this.найтиСToolStripMenuItem.Name = "найтиСToolStripMenuItem";
            this.найтиСToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.найтиСToolStripMenuItem.Text = "Найти С";
            this.найтиСToolStripMenuItem.Click += new System.EventHandler(this.найтиСToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 354);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиСToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

