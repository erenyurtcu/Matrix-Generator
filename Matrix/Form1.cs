using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ClosedXML.Excel; // ClosedXML için
using iText.Kernel.Pdf; // iText7 için
using iText.Layout; // iText7 için
using iText.Layout.Element; // iText7 için
using Org.BouncyCastle.Security; // BouncyCastle için

namespace Matrix
{
    public partial class Form1 : Form
    {
        private DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void InitializeTable()
        {
            // DataTable baþlat ve DataGridView'e baðla
            dataTable = new DataTable();
            dataTable.Columns.Add("Feature"); // Ýlk sütun: Özelliklerin isimleri
            dataGridView1.DataSource = dataTable;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // OpenFileDialog ile XML dosyalarýný seçmek
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "XML Files (*.xml)|*.xml",
                Title = "Select XML Files"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    LoadXmlToColumn(file);
                }
            }
        }

        private void LoadXmlToColumn(string filePath)
        {
            XElement xml = XElement.Load(filePath);

            // TV adý olarak sütun baþlýðýný ekle (dosya adý kullanýlarak)
            string tvName = System.IO.Path.GetFileNameWithoutExtension(filePath);
            if (!dataTable.Columns.Contains(tvName))
            {
                dataTable.Columns.Add(tvName);
            }

            // XML içindeki her özelliði iþleme
            foreach (var element in xml.Descendants())
            {
                AddFeatureToTable(element.Name.LocalName, element.Value, tvName);
            }
        }

        private void AddFeatureToTable(string featureName, string value, string tvName)
        {
            // Özellik tablodaki ilk sütunda olmalý
            DataRow row = dataTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("Feature") == featureName);

            if (row == null)
            {
                // Yeni bir özellik (satýr) ekle
                row = dataTable.NewRow();
                row["Feature"] = featureName;
                dataTable.Rows.Add(row);
            }

            // Televizyon sütunundaki deðeri güncelle
            row[tvName] = value;
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Save as PDF File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;


                using (var writer = new PdfWriter(filePath))
                {
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);

                    // Tablo oluþtur
                    var table = new Table(dataTable.Columns.Count);

                    // Sütun baþlýklarýný ekle
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Satýrlarý ve hücreleri ekle
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cell?.ToString() ?? "")));
                        }
                    }

                    // PDF'e tabloyu ekle
                    document.Add(table);
                    document.Close();
                }

                MessageBox.Show("PDF dosyasý baþarýyla kaydedildi!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void exportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Save as Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("TV Data");

                    // Baþlýklarý ekle
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dataTable.Columns[col].ColumnName;
                    }

                    // Verileri ekle
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dataTable.Rows[row][col]?.ToString();
                        }
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Excel dosyasý baþarýyla kaydedildi!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
