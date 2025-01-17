namespace Matrix
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLoad = new Button();
            dataGridView1 = new DataGridView();
            exportExcel = new Button();
            exportPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(274, 55);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Dosya Yükle";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1729, 1094);
            dataGridView1.TabIndex = 1;
            // 
            // exportExcel
            // 
            exportExcel.Location = new Point(303, 12);
            exportExcel.Name = "exportExcel";
            exportExcel.Size = new Size(274, 55);
            exportExcel.TabIndex = 2;
            exportExcel.Text = "Excel Olarak Dışa Aktar";
            exportExcel.UseVisualStyleBackColor = true;
            exportExcel.Click += exportExcel_Click;
            // 
            // exportPDF
            // 
            exportPDF.Location = new Point(595, 12);
            exportPDF.Name = "exportPDF";
            exportPDF.Size = new Size(274, 55);
            exportPDF.TabIndex = 3;
            exportPDF.Text = "PDF Olarak Dışa Aktar";
            exportPDF.UseVisualStyleBackColor = true;
            exportPDF.Click += exportPDF_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1762, 1179);
            Controls.Add(exportPDF);
            Controls.Add(exportExcel);
            Controls.Add(dataGridView1);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoad;
        private DataGridView dataGridView1;
        private Button exportExcel;
        private Button exportPDF;
    }
}
