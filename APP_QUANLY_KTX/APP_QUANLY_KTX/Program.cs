﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Logins;
using Serilog;

namespace ProjectQLKTX
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static readonly IHost _host = CreateHostBuilder();
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("LOGSAPP/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                _host.Start();
                Log.Information("Application start");
                //Đoạn này mặc định của winform
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Lấy ra cái Form1 đã được khai báo trong services
                //var form1 = _host.Services.GetRequiredService<frmAuto>();
                try
                {
                    var form1 = _host.Services.GetRequiredService<frmDangNhap>();
                    //Lệnh chạy gốc là: Application.Run(new Form1);
                    //Đã được thay thế bằng lệnh sử dụng service khai báo trong host
                    Application.Run(form1);
                }
                catch (Exception ex)
                {

                    Log.Error(ex.Message);
                    Log.Error(ex.ToString());
                    if (ex.InnerException != null)
                    {
                        Log.Error(ex.ToString());
                        Log.Error(ex.InnerException.Message);
                    }
                }

                //Khi form chính (form1) bị đóng <==> chương trình kết thúc
                //thì dừng host
                _host.StopAsync().GetAwaiter().GetResult();
                //và giải phóng tài nguyên host đã sử dụng.
                _host.Dispose();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                if (ex.InnerException != null)
                {
                    Log.Error(ex.ToString());
                    Log.Error(ex.InnerException.Message);
                }
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static IHost CreateHostBuilder()
        {

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<frmDangNhap>();
                    services.AddSingleton<Home>();
                    services.AddTransient<ILoginHelper, LoginHelper>();
                    services.AddTransient<IBienLaiHelper, BienLaiHelper>();
                    services.AddTransient<INhanVienHelper, NhanVienHelper>();
                }).Build();
        }
    }
}