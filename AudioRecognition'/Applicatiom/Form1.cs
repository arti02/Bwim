using AudioRecognition_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applicatiom
{
	public partial class Form1 : Form
	{

		[DllImport("winmm.dll")]
		private static extern long mciSendString(string command, StringBuilder retstring, int Returnlenth, IntPtr callback);

		public Form1()
		{
			InitializeComponent();
			mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
			button1.Click += new EventHandler(this.button1_Click);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mciSendString("record recsound", null, 0, IntPtr.Zero);
			button2.Click += new EventHandler(this.button2_Click);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			mciSendString("save recsound C:\\Users\\Artem\\Desktop\\Nagrania\\test1.wav", null, 0, IntPtr.Zero);
			mciSendString("close recsound", null, 0, IntPtr.Zero);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = button1.Text;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		
	}
}
