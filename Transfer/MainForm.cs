using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer
{
    public partial class MainForm : Form
    {
        HttpListener listener;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listener = new HttpListener();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(inputTextBox.Text))
            {
                MessageBox.Show("文件不存在");
                return;
            }
            var fileInfo = new FileInfo(inputTextBox.Text);

            var prefix = "http://192.168.1.100:23789/";
            var guid = Guid.NewGuid().ToString("d").Split('-')[0];
            var name = fileInfo.Name.Replace(fileInfo.Extension, string.Empty) + "-" + guid + fileInfo.Extension;

            var outputText = prefix + name;

            listener.Prefixes.Clear();
            listener.Prefixes.Add(prefix);
            listener.Start();

            Task task = new Task(() =>
            {
                bool isListening = true;
                while (isListening)
                {
                    try
                    {
                        var context = listener.GetContext();
                        if (!("/" + name).Equals(context.Request.RawUrl))
                        {
                            continue;
                        }

                        if (textRadioButton.Checked)
                        {
                            context.Response.StatusCode = 200;

                            context.Response.ContentEncoding = Encoding.UTF8;

                            var writer = new StreamWriter(context.Response.OutputStream);

                            writer.Write(inputTextBox.Text);

                            writer.Close();
                        }
                        else
                        {
                            var bytes = File.ReadAllBytes(inputTextBox.Text);

                            context.Response.ContentType = "application/apk";
                            context.Response.ContentLength64 = bytes.LongLength;
                            context.Response.KeepAlive = false;
                            context.Response.Headers[HttpResponseHeader.ETag] = guid;
                            context.Response.Headers[HttpResponseHeader.LastModified] = DateTime.Now.GetDateTimeFormats('r')[0].ToString();

                            var stream = context.Response.OutputStream;

                            stream.Write(bytes, 0, bytes.Length);

                            stream.Close();
                        }
                        context.Response.Close();
                        System.Diagnostics.Debug.WriteLine("传输成功");
                    }
                    catch (HttpListenerException ex)
                    {
                        if (ex.ErrorCode == 995)
                        {
                            isListening = false;
                        }
                    }
                }
            });
            task.Start();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(outputText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            outputTextBox.Text = outputText;

            pictureBox1.Image = qrCode.GetGraphic(10);
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            listener.Stop();

        }
    }
}
