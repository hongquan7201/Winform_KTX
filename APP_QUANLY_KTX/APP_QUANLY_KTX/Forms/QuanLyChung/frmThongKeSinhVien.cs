
using DevExpress.XtraCharts;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;

namespace ProjectQLKTX
{
    public partial class frmThongKeSinhVien : DevExpress.XtraEditors.XtraForm
    {
        private readonly IThongKeHelper _thongKeHelper;
        public frmThongKeSinhVien(IThongKeHelper thongKeHelper)
        {
            InitializeComponent();
            _thongKeHelper = thongKeHelper;
        }

        private async void frmThongKeSinhVien_Load(object sender, EventArgs e)
        {
            var result = await _thongKeHelper.GetThongKe("api/thongke/sinhvien", DateTime.Now.Year, Constant.Token);
            if (result.status == 200)
            {
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series("Tổng Số Sinh Viên Năm " + DateTime.Now.Year, DevExpress.XtraCharts.ViewType.Bar);
                // Đổ dữ liệu vào loạt dữ liệu
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 1", result.data.Data.month_1));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 2", result.data.Data.month_2));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 3", result.data.Data.month_3));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 4", result.data.Data.month_4));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 5", result.data.Data.month_5));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 6", result.data.Data.month_6));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 7", result.data.Data.month_7));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 8", result.data.Data.month_8));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 9", result.data.Data.month_9));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 10", result.data.Data.month_10));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 11", result.data.Data.month_11));
                series1.Points.Add(new DevExpress.XtraCharts.SeriesPoint("Tháng 12", result.data.Data.month_12));

                foreach (SeriesPoint point in series1.Points)
                {
                    decimal number1 = (result.data.Max * 50 / 100);
                    decimal number2 = (result.data.Max * 70 / 100);
                    if ((decimal)Convert.ToDouble(point.Values[0]) < number1)
                    {
                        // Nếu giá trị của cột nhỏ hơn 50, thiết lập màu đỏ
                        point.Color = Color.Red;
                    }
                    else if ((decimal)Convert.ToDouble(point.Values[0]) >= number1 && (decimal)Convert.ToDouble(point.Values[0]) < number2)
                    {
                        // Nếu giá trị của cột từ 50 đến 70, thiết lập màu vàng
                        point.Color = Color.Yellow;
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
                ((XYDiagram)chartDoanhThu.Diagram).AxisY.WholeRange.SetMinMaxValues(result.data.Min, result.data.Max);
                // Hiển thị biểu đồ
                chartDoanhThu.Dock = DockStyle.Fill;
                this.Controls.Add(chartDoanhThu);
            }
        }
    }
}