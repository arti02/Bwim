
using AudioRecognition_ML.ConsoleApp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
	public partial class Form1 : Form
	{
		/*[DllImport("winmm.dll")]
		private static extern long mciSendString(string command, StringBuilder retstring, int Returnlenth, IntPtr callback);*/
		static WaveFileWriter waveFile;
		WaveInEvent waveSource;
		//D:\Soft\C#VisualStudio\BWIM_Face_Recognition\Bwim\AudioRecognition'\App\Audio
		public static string tempFile;
		//string tempFile;
		public Form1()
		{
			InitializeComponent();
			/*	mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
				button1.Click += new EventHandler(this.button1_Click);*/
			
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			tempFile = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Audio/test1.wav");
			waveSource = new WaveInEvent();
			waveSource.WaveFormat = new WaveFormat(48000, 2);

			waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);

			
			waveFile = new WaveFileWriter(tempFile, waveSource.WaveFormat);
			waveSource.StartRecording();
			label1.Text = "Recording now...";

			/*mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
			mciSendString("record recsound", null, 0, IntPtr.Zero);*/
			button2.Click += new EventHandler(this.button2_Click);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			try
			{
				this.waveSource.StopRecording();
				waveFile.Dispose();
				label1.Text = "Stop recording";
				byte[] forwardsWavFileStreamByteArray = PopulateForwardsWavFileByteArray(tempFile);
				MessageBox.Show("Audio file succesfully saved");
			}
			catch
			{
				MessageBox.Show("Niestety blad");
			}

			/*mciSendString("save recsound C:\\Users\\Artem\\Desktop\\Nagrania\\test1.wav", null, 0, IntPtr.Zero);
			mciSendString("close recsound", null, 0, IntPtr.Zero);*/
		}

	

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			label1.Text = "Recognition in progress...";
			Thread.Sleep(700);
			if ( ModelManager.EvaluateAudio().ToString().Equals("1"))
			{
				textBox1.Text = "Male";
			}
			else
			{
				textBox1.Text = "Female";
			}
			label1.Text = "Recognition complete";
		}
		private static byte[] PopulateForwardsWavFileByteArray(string forwardsWavFilePath)
		{
			byte[] forwardsWavFileStreamByteArray;
			using (FileStream forwardsWavFileStream = new FileStream(forwardsWavFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				forwardsWavFileStreamByteArray = new byte[forwardsWavFileStream.Length];
				forwardsWavFileStream.Read(forwardsWavFileStreamByteArray, 0, (int)forwardsWavFileStream.Length);
			}
			return forwardsWavFileStreamByteArray;
		}

		static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
		{
			waveFile.WriteData(e.Buffer, 0, e.BytesRecorded);
		}


		

		private void button2_Click_1(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{

		}



		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
