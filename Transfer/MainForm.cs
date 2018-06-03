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
            if (textRadioButton.Checked && string.IsNullOrEmpty(inputTextBox.Text))
            {
                MessageBox.Show("需要传输的文字不能为空");
            }

            if (fileRadioButton.Checked && (string.IsNullOrEmpty(inputTextBox.Text) || !File.Exists(inputTextBox.Text)))
            {
                MessageBox.Show("需要传输的文件不存在");
                return;
            }

            var prefix = "http://192.168.1.100:23789/";
            var guid = Guid.NewGuid().ToString("d").Split('-')[0];

            groupBox1.Enabled = false;

            string qrText = string.Empty;
            string rawUrl = string.Empty;
            if (textRadioButton.Checked)
            {
                qrText = prefix + guid;
                rawUrl = "/" + guid;
            }
            else
            {
                var fileInfo = new FileInfo(inputTextBox.Text);
                var fileName = fileInfo.Name.Replace(fileInfo.Extension, string.Empty) + "-" + guid + fileInfo.Extension;
                qrText = prefix + fileName;
                rawUrl = "/" + fileName;
            }

            outputTextBox.Text = qrText;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            pictureBox1.Image = qrCode.GetGraphic(10);

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
                        if (!rawUrl.Equals(context.Request.RawUrl))
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
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            listener.Stop();

            groupBox1.Enabled = true;
        }

        private void inputTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            string[] items = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (items.Length != 1 || !File.Exists(items[0]))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;
        }

        private void inputTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            string[] items = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (items.Length != 1 || !File.Exists(items[0]))
            {
                return;
            }

            inputTextBox.Text = items[0];
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (listener.IsListening)
            {
                listener.Stop();
            }
        }
    }
}
