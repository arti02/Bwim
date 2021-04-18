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


class sound
{
    static WaveFileWriter waveFile;
    public static void Main()
    {
        //WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(0);
        Console.WriteLine("Now recording...");
        WaveInEvent waveSource = new WaveInEvent();
        //waveSource.DeviceNumber = 0;
        waveSource.WaveFormat = new WaveFormat(44100, 1);

        waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);

        string tempFile = (@"C:\Users\Artem\Desktop\Nagrania\test1.mp4");
        waveFile = new WaveFileWriter(tempFile, waveSource.WaveFormat);
        waveSource.StartRecording();
        Console.WriteLine("Press enter to stop");
        Console.ReadLine();
        waveSource.StopRecording();
        waveFile.Dispose();
    }

    static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
    {
        waveFile.WriteData(e.Buffer, 0, e.BytesRecorded);
    }

}

