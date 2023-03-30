using MailKit.Net.Imap;
using Microsoft.VisualBasic.Logging;
using MimeKit;

namespace TestModun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> lis = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            // ReadFile();
            //string filePathEmail = "D:\\hmok.txt";
            //var mail = File.ReadAllLines(filePathEmail);
            //foreach (var line in mail)
            //{
            //    var body = line.Split(':');
            //    string Email = body[0];
            //    string Pass = body[1];
            //    string Imap = "outlook.office365.com";
            //    int Port = 993;
            //    var check = CheckLogin(Email, Pass, Imap, Port);
            //    if (check == false)
            //    {

            //        lis.Add(Email);
            //    }
            //}

            lis.Add("trà dâu");
            lis.Add("ttrà đào");
            lis.Add("trà tắc");
            Random random = new Random();
          var check =   random.Next(lis.Count);

        }
        private void ReadFile()
        {
            string filePath1 = "D:\\mail.txt";
            string filePath2 = "D:\\hmok.txt";
            var line1 = File.ReadAllLines(filePath1);
            List<string> listName = new List<string>();
            for (int i = 0; i < line1.Length; i++)
            {
                listName.Add(line1[i]);
            }
            List<string> listTMP = new List<string>();
            string fileTMP = Path.Combine(Path.GetDirectoryName(filePath2), Path.GetFileNameWithoutExtension(filePath2) + ".tmp");
            // Mở file gốc và tạo một file tạm
            using (StreamWriter writer = new StreamWriter(fileTMP))
            {
                var line = File.ReadAllLines(filePath2);
                for (int i = 0; i < line.Length; i++)
                {
                    bool isUsed = false;
                    foreach (string name in listName)
                    {
                        if (line[i].StartsWith(name))
                        {
                            isUsed = true;
                            break;
                        }
                    }
                    if (!isUsed)
                    {
                        listTMP.Add(line[i]);
                    }
                }
                foreach (string name in listTMP)
                {
                    writer.WriteLine(name);
                }
            }
            File.Delete(filePath2);
            File.Move(fileTMP, filePath2);
        }
        public static bool CheckLogin(string email, string pass, string imap, int port)
        {
            bool check = false;
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(imap) && port != null)
                {
                    using (var client = new ImapClient())
                    {
                        using (var cancel = new CancellationTokenSource())
                        {
                            client.Connect(imap, port, true, cancel.Token);
                            client.Authenticate(email, pass, cancel.Token);
                            client.Disconnect(true, cancel.Token);
                            check = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return check;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var check = lis;
        }
    }
}