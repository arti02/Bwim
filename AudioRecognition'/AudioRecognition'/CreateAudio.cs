using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio;
using NAudio.Wave;


using System;
using System.Media;
using NAudio;
using NAudio.Wave;
using System.Threading;
using System.IO;

class sound
{
    static WaveFileWriter waveFile;
    public static void Main()
    {
        //WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(0);
        Console.WriteLine("Now recording...");
        WaveInEvent waveSource = new WaveInEvent();
        //waveSource.DeviceNumber = 0;
        waveSource.WaveFormat = new WaveFormat(48000, 2);

        waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);

        string tempFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+"App/Audio/test1.wav";
        waveFile = new WaveFileWriter(tempFile, waveSource.WaveFormat);
        waveSource.StartRecording();
        Console.WriteLine("Press enter to stop");
        Console.ReadLine();
        waveSource.StopRecording();
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

