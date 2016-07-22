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
using HtmlAgilityPack;

namespace HtmlParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = new Uri("http://www.ciceksepeti.com");
            var client = new WebClient {Encoding = Encoding.UTF8};
            var html = client.DownloadString(url);

            var htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.Load(new StringReader(html));
                     

            var titles = htmldoc.DocumentNode.SelectNodes("//a[@class='main-menu__link-responsive js-main-menu-link-responsive']");

            foreach (var title in titles)
            {
                listBox1.Items.Add(WebUtility.HtmlDecode(title.InnerText));
            }

        }
    }
}
