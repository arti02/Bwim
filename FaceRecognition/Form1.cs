using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceRecognition
{
	public partial class Form1 : Form
	{
		private static CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
		public Form1()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult res = openFileDialog1.ShowDialog();
				if (res.Equals(DialogResult.OK))
				{
					string path = openFileDialog1.FileName;
					pictureBox1.Image = Image.FromFile(path);

					Bitmap bitmap = new Bitmap(pictureBox1.Image);
					Image<Bgr,byte> grayImage = new Image<Bgr, byte>(bitmap);

					Rectangle[] faces = classifier.DetectMultiScale(grayImage,1.01,2);
					Console.WriteLine(faces.Length);
					foreach(Rectangle face in faces)
					{
						Console.WriteLine(face.Width);
						Console.WriteLine(face.Height);
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							using(Pen pen=new Pen(Color.Aquamarine, 2))
							{
								graphics.DrawRectangle(pen, face);
							}
						}
					}
					pictureBox1.Image = bitmap;
				}
				else
				{
					MessageBox.Show("No image selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}
	}
}
