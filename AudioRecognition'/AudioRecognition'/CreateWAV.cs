using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecognition_
{
	public class CreateWAV
	{
        static WaveFileWriter waveFile;
        WaveInEvent waveSource = new WaveInEvent();
        public  void Start()
		{
            //WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(0);
            Console.WriteLine("Now recording...");
         
            //waveSource.DeviceNumber = 0;
            waveSource.WaveFormat = new WaveFormat(44100, 2);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);

            string tempFile = (@"C:\Users\Artem\Desktop\Nagrania\test1.wav");
            waveFile = new WaveFileWriter(tempFile, waveSource.WaveFormat);
            waveSource.StartRecording();
            Console.WriteLine("Press enter to stop");
            Console.ReadLine();
        }
        public  void Stop()
		{
            string tempFile = (@"C:\Users\Artem\Desktop\Nagrania\test1.wav");
           
            this.waveSource.StopRecording();
            waveFile.Dispose();
            byte[] forwardsWavFileStreamByteArray = PopulateForwardsWavFileByteArray(tempFile);

            Console.WriteLine(forwardsWavFileStreamByteArray);
            Console.WriteLine("*******");
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
    }
}
