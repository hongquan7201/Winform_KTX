
using DevExpress.XtraCharts;

namespace ProjectQLKTX
{
    public partial class frmThongKeSinhVien : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeSinhVien()
        {
            InitializeComponent();
        }

        private void frmThongKeSinhVien_Load(object sender, EventArgs e)
        {
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series("Tổng Số Sinh Viên Năm 2023", DevExpress.XtraCharts.ViewType.Bar);
            // Đổ dữ liệu vào loạt dữ liệu
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 1", 60));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 2", 20));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 3", 40));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 4", 70));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 5", 55));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 6", 80));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 7", 10));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 8", 5));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 9", 90));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 10", 25));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 11", 35));
            series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 12", 65));

            foreach (SeriesPoint point in series1.Points)
            {
                if (Convert.ToDouble(point.Values[0]) < 50)
                {
                    // Nếu giá trị của cột nhỏ hơn 50, thiết lập màu đỏ
                    point.Color = Color.Red; 
                }
                else if (Convert.ToDouble(point.Values[0]) >= 50 && Convert.ToDouble(point.Values[0]) < 70)
                {
                    // Nếu giá trị của cột từ 50 đến 70, thiết lập màu vàng
                    point.Color  = Color.Yellow;
                }
                else
                {
                    // Nếu giá trị của cột lớn hơn hoặc bằng 70, thiết lập màu xanh
                    point.Color = Color.Green;
                }
            }

            // Thêm loạt dữ liệu vào biểu đồ
            chartDoanhThu.Series.Add(series1);
            // Thiết lập trục tung (trục Y)
            ((XYDiagram)chartDoanhThu.Diagram).AxisY.WholeRange.SetMinMaxValues(10, 100);
            // Hiển thị biểu đồ
            chartDoanhThu.Dock = DockStyle.Fill;
            this.Controls.Add(chartDoanhThu);
        }
    }
}