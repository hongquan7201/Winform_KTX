using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System.IO;

namespace ProjectQLKTX.Files
{
    public class Export
    {
        public static void ExportPDF (GridControl gridControl, string nameFile)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = nameFile+".pdf"; // Đặt tên file mặc định là "TaiSan.pdf"
            save.Filter = "PDF Files|*.pdf"; // Chỉ cho phép lưu file có đuôi .pdf
            if (save.ShowDialog() == DialogResult.OK)
            {
                gridControl.ExportToPdf(save.FileName);
                MessageBox.Show("Xuất File Thành Công!");
            }
        }
        public static void ExportExcel(GridControl gridControl, string nameFile)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = nameFile + ".xlsx"; // Đặt tên file mặc định là "TaiSan.pdf"
            save.Filter = "PDF Files|*.xlsx"; // Chỉ cho phép lưu file có đuôi .pdf
            if (save.ShowDialog() == DialogResult.OK)
            {
                gridControl.ExportToXlsx(save.FileName);
                MessageBox.Show("Xuất File Thành Công!");
            }
        }
    }
}
