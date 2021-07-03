using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionNewVersion
{
	public partial class Form1 : Form
	{
		//Declare Variables to use them in all this project
		MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
		HaarCascade faceDetected;
		Image<Bgr, byte> Frame;
		Capture camera;
		Image<Gray, byte> result;
		Image<Gray, byte> TrainedFace=null;
		Image<Gray, byte> grayFace=null;
		List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
		List<string> labels = new List<string>();
		List<string> Users = new List<string>();
		int Count, NumLables, t;
		string name, names = null;

	


		public Form1()
		{
			InitializeComponent();
			//HaarCascade is for face detection----------------------------
		

			faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
			try
			{
				/*string Labelsinf = File.ReadAllText(Application.StartupPath + "/Faces/Faces.txt");
				string[] Labels = Labelsinf.Split(',');
				//The first label before, will be the number of faces saved.
				NumLables = Convert.ToInt16(Labels[0]);
				Count = NumLables;
				string FacesLoad;
				for (int i = 1; i < NumLables + 1; i++)
				{
					FacesLoad = "face" + i + ".bmp";
					trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/Faces.txt"));
					labels.Add(Labels[i]);
				}*/
			} 
			catch(Exception ex)
			{
				MessageBox.Show("Nothing int the Database");
			}

		}
			
		

		private void button1_Click(object sender, EventArgs e)
		{
			camera = new Capture();
			camera.QueryFrame();
			Application.Idle += new EventHandler(FrameProcedure);

		}
		private void saveButton_Click(object sender, EventArgs e)
		{
			Count = Count + 1;
			grayFace = camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
			MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
			foreach (MCvAvgComp f in DetectedFaces[0])
			{
				TrainedFace = Frame.Copy(f.rect).Convert<Gray, Byte>();
				break;
			}
			TrainedFace=result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
			trainingImages.Add(TrainedFace);
			labels.Add(textName.Text);
			File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingImages.ToArray().Length.ToString() + ",");
			for(int i = 1; i < trainingImages.ToArray().Length; i++)
			{
				trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
				File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", labels.ToArray()[i-1] + ",");
			}
			MessageBox.Show(textName.Text + "Added Succsefuli");
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void FrameProcedure(object sender, EventArgs e)
		{

			Users.Add("");
			Frame = camera.QueryFrame().Resize(320, 240,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
			//Frame.Draw(font.rect, new Bgr(Color.Green), 3);
			grayFace = Frame.Convert<Gray, Byte>();
			MCvAvgComp[][] facesDetectedNow = grayFace.DetectHaarCascade(faceDetected,1.2,10,Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,new Size(20,20));
			foreach(MCvAvgComp f in facesDetectedNow[0])
			{
				result=Frame.Copy(f.rect).Convert<Gray,Byte>().Resize(100,100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
				Frame.Draw(f.rect, new Bgr(Color.Blue), 1);
				if (trainingImages.ToArray().Length != 0)
				{
					MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
					EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(),labels.ToArray(),1500,ref termCriterias);
					name = recognizer.Recognize(result);
					Frame.Draw(name, ref font, new Point(f.rect.X-2 , f.rect.Y-2 ), new Bgr(Color.GreenYellow));
				}
				
				Users.Add("");
				
			}
			CameraBox.Image = Frame;
			names = "";
			Users.Clear();
		}
		private void imageBox2_Click(object sender, EventArgs e)
		{

		}

		private void textName_TextChanged(object sender, EventArgs e)
		{

		}




	}
}
