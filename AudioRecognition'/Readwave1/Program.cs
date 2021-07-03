using Accord.Audio;
using CsvHelper;

using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Readwave1
{
	class Program
	{
		static void Main(string[] args)
		{
			int y = 1;
			int x = 4000;

			String[] arr = new string[580];

			//fields;
			using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Artem\Desktop\Biometria\DataSet\BVC_Voice_Bio_Public.csv"))
			{
				parser.TextFieldType = FieldType.Delimited;
				parser.SetDelimiters(",");
				int i = 0;
				while (!parser.EndOfData)
				{
					//Processing row
					string[] fields = parser.ReadFields();
					foreach (string field in fields)
					{

						arr[i] = field;
						i++;
						//Console.WriteLine(arr[i]);
					}
				}
			}

			while (true)
			{

				Console.WriteLine(x);
				try
				{




					//double[] readWave = ReadAudioFile(@"C:\Users\Artem\Desktop\Biometria\DataSet\multiple_sentences\multiple_sentences\S_01_" + x + "_VE" + y + ".wav");
					double[] readWave = prepare(@"C:\Users\Artem\Desktop\Biometria\DataSet\multiple_sentences\multiple_sentences\S_01_" + x + "_VE"+y+".wav");
					//double[] readWave = prepare(@"C:\Users\Artem\Desktop\Biometria\DataSet\one_sentence\one_sentence\S_01_" + x + "_VE.wav");

					var csv = new StringBuilder();
					// var w = new StreamWriter(@"C:\Users\Artem\Desktop\Train1.csv");
					Mfcc mfcc = new Mfcc();

					double[] d = mfcc.MFCC_20_calculation(readWave);
/*
					if (d[0].GetHashCode() > 2046959360)
					{
						x++;
						continue;
					}*/
					String Col0 = string.Format(((float)d[0]).ToString().Replace(',', '.'));
					/*
										if (Col0.Contains('-'))
										{
											x++;
											continue;
										}*/
					String Col1 = string.Format(((float)d[1]).ToString().Replace(',', '.'));
					String Col2 = string.Format(((float)d[2]).ToString().Replace(',', '.'));
					String Col3 = string.Format(((float)d[3]).ToString().Replace(',', '.'));
					String Col4 = string.Format(((float)d[4]).ToString().Replace(',', '.'));
					String Col5 = string.Format(((float)d[5]).ToString().Replace(',', '.'));
					String Col6 = string.Format(((float)d[6]).ToString().Replace(',', '.'));
					String Col7 = string.Format(((float)d[7]).ToString().Replace(',', '.'));
					String Col8 = string.Format(((float)d[8]).ToString().Replace(',', '.'));
					String Col9 = string.Format(((float)d[9]).ToString().Replace(',', '.'));
					String Col10 = string.Format(((float)d[10]).ToString().Replace(',', '.'));
					String Col11 = string.Format(((float)d[11]).ToString().Replace(',', '.'));
					String Col12 = string.Format(((float)d[12]).ToString().Replace(',', '.'));
					String Col13 = string.Format(((float)d[13]).ToString().Replace(',', '.'));
					String Col14 = string.Format(((float)d[14]).ToString().Replace(',', '.'));
					String Col15 = string.Format(((float)d[15]).ToString().Replace(',', '.'));
					String Col16 = string.Format(((float)d[16]).ToString().Replace(',', '.'));
					String Col17 = string.Format(((float)d[17]).ToString().Replace(',', '.'));
					String Col18 = string.Format(((float)d[18]).ToString().Replace(',', '.'));
					String Col19 = string.Format(((float)d[19]).ToString().Replace(',', '.'));


					//Suggestion made by KyleMit
					String Col20 = "";
					for (int i = 0; i < 565; i++)
					{
						try
						{
							String[] tab = arr[i].Split(';');


							if (x.ToString().Equals(tab[0]))
							{
								//Console.WriteLine(tab[1]);
								if (tab[1].Equals("'Female'"))
								{
									Col20 = (0.0).ToString();
									break;
								}
								else
								{
									Col20 = (1.0).ToString();
									break;
								}

							}
						}
						catch
						{

						}
					}
					//	var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{20}", Col0, Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col20);
					var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}", Col0, Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10, Col11,
						Col12, Col13, Col14, Col15, Col16, Col17, Col18, Col19, Col20);
					csv.AppendLine(newLine);
					// i += 2;


					File.AppendAllText(@"C:\Users\Artem\Desktop\Train1.csv", csv.ToString());
					x++;
					if (x == 5000)
					{
						y++;
						x = 4000;
					}
				}


				catch
				{
					x++;
					if (x == 5000)
					{
						y++;
						x = 4000;
					}
				}
			}
		}




		public static Double[] prepare(String wavePath)

		{
			Double[] data;

			//byte[] buffer;

			/*System.IO.FileStream WaveFile = System.IO.File.OpenRead(wavePath);
			wave = new byte[WaveFile.Length];
			data = new Double[(wave.Length - 44) / 4];//shifting the headers out of the PCM data;
			WaveFile.Read(wave, 0, Convert.ToInt32(WaveFile.Length));//read the wave file into the wave variable
			*//***********Converting and PCM accounting***************//*
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = (BitConverter.ToInt32(wave, 44 + i * 4));/// 4294967296.0;

			}

			return data;*/
			//-----------------------------------------/
			/*using (WaveFileReader reader = new WaveFileReader(wavePath))
			{
				Assert.AreEqual(16, reader.WaveFormat.BitsPerSample, "Only works with 16 bit audio");
				buffer = new byte[reader.Length];
				int read = reader.Read(buffer, 0, buffer.Length);
				short[] sampleBuffer = new short[read / 2];
				Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
				data = new Double[(buffer.Length - 44) / 4];
			}

			for (int i = 0; i < data.Length; i++)
			{

				double del = 1 / 4294967296.0;
				data[i] = (BitConverter.ToInt32(buffer, 44 + i * 4));// / 4294967296.0;
																	 //4294967296.0

			}

			return data;
*/
			//---------------------------------------------
			/*AudioFileReader readertest = new AudioFileReader(wavePath);
			int bytesnumber = (int)readertest.Length;
			var buffer = new byte[bytesnumber];
			readertest.Read(buffer, 0, bytesnumber);
			data = new double[buffer.Length];
			for (int i = 0; i < buffer.Length; i++)
			{
				data[i] = buffer[i];
				//Console.WriteLine(data[i]);
			}
			
			return data;*/
			//-----------------------------------------------------------
			/*double multiplier = 16_000;
			var afr = new AudioFileReader(wavePath);
			int sampleRate = afr.WaveFormat.SampleRate;
			int sampleCount = (int)(afr.Length / afr.WaveFormat.BitsPerSample / 8);
			int channelCount = afr.WaveFormat.Channels;
			var audio = new List<double>(sampleCount);
			var buffer = new float[sampleRate * channelCount];
			int samplesRead = 0;
			while ((samplesRead = afr.Read(buffer, 0, buffer.Length)) > 0)
				audio.AddRange(buffer.Take(samplesRead).Select(x => x * multiplier));
			return audio.ToArray();*/
			//----------------------------------
			//data = WavFile.ReadStereo(wavePath).L;
			data = WavFile.ReadStereo(wavePath).L;
			return data;
			//-----------------------------

		}
		/*public static double[] ReadAudioFile(string source)
		{
			float[] block = new float[1024];
			var result = new List<double>();

			using (var reader = new AudioFileReader(source))
			{
				int nread = 0;

				do
				{
					

						nread = reader.Read(block, 0, block.Length);

						for (int i = 0; i < nread; i++)
							result.Add(block[i]);
				

				} while (nread > 0);
			}

			return result.ToArray();
		}*/






	}
}
	

