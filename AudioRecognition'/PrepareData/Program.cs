using Accord.Audio;
using Accord.Audio.Formats;
using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareData
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
				if (y == 6)
				{
					break;
				}
				var csv = new StringBuilder();
			
					Console.WriteLine(x);
					try
					{
				




						//double[] readWave = ReadAudioFile(@"C:\Users\Artem\Desktop\Biometria\DataSet\multiple_sentences\multiple_sentences\S_01_" + x + "_VE" + y + ".wav");
						double[][] d = prepare(@"C:\Users\Artem\Desktop\Biometria\DataSet\multiple_sentences\multiple_sentences\S_01_" + x + "_VE" + y + ".wav");
					//double[][] d = prepare(@"C:\Users\Artem\Desktop\Biometria\DataSet\one_sentence\one_sentence\S_01_" + x + "_VE.wav");




					

					/*	if (d[0].GetHashCode() > 2046959360)
						{
							x++;
							continue;
						}*/
				
					
						/*		csv.Append(Col39);
							for (int z = 0; z < 13; z++)
							{
								csv.Append(string.Format("{0}",((float)d[j][z]).ToString().Replace(',', '.')));

							}
						}
						File.AppendAllText(@"C:\Users\Artem\Desktop\Train2.csv", csv.ToString());
						csv.AppendLine();*/

						/*
											if (Col0.Contains('-'))
											{
												x++;
												continue;
											}*/
						/*	*/
						String Col0 = string.Format(((float)d[1][0]).ToString().Replace(',', '.'));
						String Col1 = string.Format(((float)d[1][1]).ToString().Replace(',', '.'));
						String Col2 = string.Format(((float)d[1][2]).ToString().Replace(',', '.'));
						String Col3 = string.Format(((float)d[1][3]).ToString().Replace(',', '.'));
						String Col4 = string.Format(((float)d[1][4]).ToString().Replace(',', '.'));
						String Col5 = string.Format(((float)d[1][5]).ToString().Replace(',', '.'));
						String Col6 = string.Format(((float)d[1][6]).ToString().Replace(',', '.'));
						String Col7 = string.Format(((float)d[1][7]).ToString().Replace(',', '.'));
						String Col8 = string.Format(((float)d[1][8]).ToString().Replace(',', '.'));
						String Col9 = string.Format(((float)d[1][9]).ToString().Replace(',', '.'));
						String Col10 = string.Format(((float)d[1][10]).ToString().Replace(',', '.'));
						String Col11 = string.Format(((float)d[1][11]).ToString().Replace(',', '.'));
						String Col12 = string.Format(((float)d[1][12]).ToString().Replace(',', '.'));

						String Col13 = string.Format(((float)d[4][0]).ToString().Replace(',', '.'));
						String Col14 = string.Format(((float)d[4][1]).ToString().Replace(',', '.'));
						String Col15 = string.Format(((float)d[4][2]).ToString().Replace(',', '.'));
						String Col16 = string.Format(((float)d[4][3]).ToString().Replace(',', '.'));
						String Col17 = string.Format(((float)d[4][4]).ToString().Replace(',', '.'));
						String Col18 = string.Format(((float)d[4][5]).ToString().Replace(',', '.'));
						String Col19 = string.Format(((float)d[4][6]).ToString().Replace(',', '.'));
						String Col20 = string.Format(((float)d[4][7]).ToString().Replace(',', '.'));
						String Col21 = string.Format(((float)d[4][8]).ToString().Replace(',', '.'));
						String Col22 = string.Format(((float)d[4][9]).ToString().Replace(',', '.'));
						String Col23 = string.Format(((float)d[4][10]).ToString().Replace(',', '.'));
						String Col24 = string.Format(((float)d[4][11]).ToString().Replace(',', '.'));
						String Col25 = string.Format(((float)d[4][12]).ToString().Replace(',', '.'));

						String Col26 = string.Format(((float)d[7][0]).ToString().Replace(',', '.'));
						String Col27 = string.Format(((float)d[7][1]).ToString().Replace(',', '.'));
						String Col28 = string.Format(((float)d[7][2]).ToString().Replace(',', '.'));
						String Col29 = string.Format(((float)d[7][3]).ToString().Replace(',', '.'));
						String Col30 = string.Format(((float)d[7][4]).ToString().Replace(',', '.'));
						String Col31 = string.Format(((float)d[7][5]).ToString().Replace(',', '.'));
						String Col32 = string.Format(((float)d[7][6]).ToString().Replace(',', '.'));
						String Col33 = string.Format(((float)d[7][7]).ToString().Replace(',', '.'));
						String Col34 = string.Format(((float)d[7][8]).ToString().Replace(',', '.'));
						String Col35 = string.Format(((float)d[7][9]).ToString().Replace(',', '.'));
						String Col36 = string.Format(((float)d[7][10]).ToString().Replace(',', '.'));
						String Col37 = string.Format(((float)d[7][11]).ToString().Replace(',', '.'));
						String Col38 = string.Format(((float)d[7][12]).ToString().Replace(',', '.'));

					String Col39 = string.Format(((float)d[9][0]).ToString().Replace(',', '.'));
					String Col40 = string.Format(((float)d[9][1]).ToString().Replace(',', '.'));
					String Col41 = string.Format(((float)d[9][2]).ToString().Replace(',', '.'));
					String Col42 = string.Format(((float)d[9][3]).ToString().Replace(',', '.'));
					String Col43 = string.Format(((float)d[9][4]).ToString().Replace(',', '.'));
					String Col44 = string.Format(((float)d[9][5]).ToString().Replace(',', '.'));
					String Col45 = string.Format(((float)d[9][6]).ToString().Replace(',', '.'));
					String Col46 = string.Format(((float)d[9][7]).ToString().Replace(',', '.'));
					String Col47 = string.Format(((float)d[9][8]).ToString().Replace(',', '.'));
					String Col48 = string.Format(((float)d[9][9]).ToString().Replace(',', '.'));
					String Col49 = string.Format(((float)d[9][10]).ToString().Replace(',', '.'));
					String Col50 = string.Format(((float)d[9][11]).ToString().Replace(',', '.'));
					String Col51 = string.Format(((float)d[9][12]).ToString().Replace(',', '.'));

					String Col52 = string.Format(((float)d[11][0]).ToString().Replace(',', '.'));
					String Col53 = string.Format(((float)d[11][1]).ToString().Replace(',', '.'));
					String Col54 = string.Format(((float)d[11][2]).ToString().Replace(',', '.'));
					String Col55 = string.Format(((float)d[11][3]).ToString().Replace(',', '.'));
					String Col56 = string.Format(((float)d[11][4]).ToString().Replace(',', '.'));
					String Col57 = string.Format(((float)d[11][5]).ToString().Replace(',', '.'));
					String Col58 = string.Format(((float)d[11][6]).ToString().Replace(',', '.'));
					String Col59 = string.Format(((float)d[11][7]).ToString().Replace(',', '.'));
					String Col60 = string.Format(((float)d[11][8]).ToString().Replace(',', '.'));
					String Col61 = string.Format(((float)d[11][9]).ToString().Replace(',', '.'));
					String Col62 = string.Format(((float)d[11][10]).ToString().Replace(',', '.'));
					String Col63 = string.Format(((float)d[11][11]).ToString().Replace(',', '.'));
					String Col64 = string.Format(((float)d[11][12]).ToString().Replace(',', '.'));

					String Col65 = string.Format(((float)d[13][0]).ToString().Replace(',', '.'));
					String Col66 = string.Format(((float)d[13][1]).ToString().Replace(',', '.'));
					String Col67 = string.Format(((float)d[13][2]).ToString().Replace(',', '.'));
					String Col68 = string.Format(((float)d[13][3]).ToString().Replace(',', '.'));
					String Col69 = string.Format(((float)d[13][4]).ToString().Replace(',', '.'));
					String Col70 = string.Format(((float)d[13][5]).ToString().Replace(',', '.'));
					String Col71 = string.Format(((float)d[13][6]).ToString().Replace(',', '.'));
					String Col72 = string.Format(((float)d[13][7]).ToString().Replace(',', '.'));
					String Col73 = string.Format(((float)d[13][8]).ToString().Replace(',', '.'));
					String Col74 = string.Format(((float)d[13][9]).ToString().Replace(',', '.'));
					String Col75 = string.Format(((float)d[13][10]).ToString().Replace(',', '.'));
					String Col76 = string.Format(((float)d[13][11]).ToString().Replace(',', '.'));
					String Col77 = string.Format(((float)d[13][12]).ToString().Replace(',', '.'));



					//Suggestion made by KyleMit
					String Col78 = "";
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
										Col78 = (0.0).ToString();
										break;
									}
									else
									{
										Col78 = (1.0).ToString();
										break;
									}

								}
							}
							catch
							{

							}
						}

						var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39}," +
							"{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65},{66},{67},{68},{69},{70},{71},{72},{73},{74},{75},{76},{77},{78}",
							Col0, Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10, Col11,Col12, Col13, Col14, Col15, Col16, Col17, Col18, Col19, Col20, Col21, Col22, Col23, Col24, Col25, Col26, Col27, Col28, Col29, Col30, Col31, Col32
							, Col33, Col34, Col35, Col36, Col37, Col38, Col39, Col40, Col41, Col42, Col43, Col44, Col45, Col46, Col47, Col48, Col49, Col50, Col51, Col52, Col53, Col54, Col55, Col56, Col57, Col58, Col59, Col60, Col61, Col62, Col63, Col64, Col65, Col66, Col67, Col68, Col69, Col70, Col71, Col72
							, Col73, Col74, Col75, Col76, Col77, Col78);
						csv.AppendLine(newLine);
						// i += 2;


						File.AppendAllText(@"C:\Users\Artem\Desktop\Train2.csv", csv.ToString());

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
		public static Double[][] prepare(String wavePath)
		{
			double[][] data;
		
			WaveDecoder waveDecoder = new WaveDecoder(wavePath);
			Signal signal = waveDecoder.Decode();


			MFCC mFCC = new MFCC(40,13,133.333,6855.4976,0.97,160000,100,0.100,512);
			//MFCC mFCC = new MFCC();
			data = mFCC.ProcessSignal(signal);
			


			return data;
		}
	}
}
