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

namespace AnaliticOptimumVector
{
    public partial class Form1 : Form
    {

        List<double> vecA;
        List<double> vecB;
        List<double> vecC;
        
        public Form1()
        {
            InitializeComponent();

            vecA = new List<double>();
            vecB = new List<double>();
            vecC = new List<double>();

        }


        public List<Double> Normalize(List<Double> src)
        {
            double sr = src.Average();
            //для 0 среднего
            for (int i = 0; i < src.Count; i++)
            {
                src[i] = src[i] - sr;
            }


            double A = new double();
            A = 0.0;
            //для нахождения энергии начального
            for (int i = 0; i < src.Count; i++)
            {
                A = A + src[i] * src[i];
            }


            //для нормализации каждого
            for (int i = 0; i < src.Count; i++)
            {
                src[i] = src[i] / ((double)Math.Sqrt(A));
            }


            return src;
        }



        private double PrintNorma(List<double> src)
        {
            //для контрольной проверки
            double A = 0;
            for (int i = 0; i < src.Count; i++)
            {
                A = A + src[i] * src[i];
            }

            return Math.Sqrt(A);
        }



        /// <summary>
        /// Открыть вектора А
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line = "123";
                while (line!=null)
                {
                    line = sr.ReadLine();

                    if (line!=null)
                    {
                     //   MessageBox.Show(vecA.Count.ToString());
                        vecA.Add(Double.Parse(line));
                    }
                }
                sr.Close();


                vecA = Normalize(vecA);
            }

        }

        private void открытьBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line = "123";
                while (line != null)
                {
                    line = sr.ReadLine();

                    if (line != null)
                    {
                        vecB.Add(Double.Parse(line));
                    }
                }
                sr.Close();

                vecB = Normalize(vecB);
            }
        }


        private double skalyar(List<double> a, List<double> b)
        {
        
            double sum = 0.0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i] * b[i];
            }

            return sum;
        }

        private double kriterii(List<double> a, List<double> b, List<double> c)
        {
            return Math.Abs(skalyar(a,c)-skalyar(b,c));
        }


        private void найтиСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //начнем считать свертку как в основной программе
            double sum = new float();
            double xx = new float();
            double hh = new float();


            for (int k = 0; k < vecA.Count; k++) //пробежимся по длине всего сигнала
            {
                sum = 0;
                for (int l = 0; l < vecB.Count; l++) //по длине всего фильтра
                {
                    if (k + l < vecA.Count)
                    {
                        xx = vecA[k + l];
                        hh = vecB[l];
                    }
                    else { xx = 0; hh = 0; }
                    sum = sum + xx * hh;
                }
                vecC.Add(sum);
            } //for k  



            double F1F2 = 0.0;
            double F1F1 = 0.0;
            double F2F2 = 0.0;


            if (vecA.Count==vecB.Count)
            {
                for (int i = 0; i < vecA.Count; i++)
                {
                    F1F2 += vecA[i] * vecB[i];
                    F1F1 += vecA[i] * vecA[i];
                    F2F2 += vecB[i] * vecB[i]; 
                }
            }


            //найдем B1 и B2 согласно формудам Борзунову

            double B1 = 1 / Math.Sqrt(F1F1-2*F1F2+F2F2);
            double B2 = -1 / Math.Sqrt(F1F1 - 2 * F1F2 + F2F2);

            //найдем A1,A2

            double A1= (-B1*F1F2 + Math.Sqrt((B1*B1)*((F1F2*F1F2)-(F1F1*F2F2))+F1F1))/F1F1;

            double A2 = (-B1 * F1F2 - Math.Sqrt((B1 * B1) * ((F1F2 * F1F2) - (F1F1 * F2F2)) + F1F1)) / F1F1;

            double A3 = (-B2 * F1F2 + Math.Sqrt((B2 * B2) * ((F1F2 * F1F2) - (F1F1 * F2F2)) + F1F1)) / F1F1;

            double A4 = (-B2 * F1F2 - Math.Sqrt((B2 * B2) * ((F1F2 * F1F2) - (F1F1 * F2F2)) + F1F1)) / F1F1;
            
            //Таким образом, у нас имееться 8 комбинаций и лишь одна из них максималльная

            //Найдем ее путем перебора

            List<Double>[] F3 = new List<double>[8];


            List<Double> F3_kiselev = new List<double>(); //Поместим сюда лучший по формуле киселева для деления


            for (int i = 0; i < F3.Length; i++)
            {
                F3[i] = new List<double>();
            }

            


            //C=A-(A,B)B/|B|^{2}

            //сформируем 8 разнообразных векторов- кандидатов
            for (int i = 0; i < vecA.Count; i++)
            {
                F3[0].Add(A1 * vecA[i] + B1 * vecB[i]);
                F3[1].Add(A2 * vecA[i] + B1 * vecB[i]);
                F3[2].Add(A3* vecA[i] + B1 * vecB[i]);
                F3[3].Add(A4 * vecA[i] + B1 * vecB[i]);

                F3[4].Add(A1 * vecA[i] + B2 * vecB[i]);
                F3[5].Add(A2 * vecA[i] + B2 * vecB[i]);
                F3[6].Add(A3 * vecA[i] + B2 * vecB[i]);
                F3[7].Add(A4 * vecA[i] + B2 * vecB[i]);  


                F3_kiselev.Add(vecA[i]-F1F2*vecB[i]/F2F2);

            }


            //Итак вектора сформированы

            //найдем максимум самый лучший из них

            int maxIndex = -1; //предположим максимум самый первый вектор
            double Max = -1;
            //kriterii(vecA,vecB,F3[0]);



            for (int i = 0; i < 8; i++)
            {
                if ((kriterii(vecA,vecB,F3[i])>Max) && (Math.Abs(Math.Sqrt(skalyar(F3[i],F3[i]))-1)<0.01))
                {
                    Max = kriterii(vecA, vecB, F3[i]);
                    maxIndex = i;
                }
            }




        
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName + ".csv");

                sw.WriteLine("signal F1;signal F2; OPTIMUM F3 (F1F3-F2F3=MAX) ; |F1F3-F2F3|= ;a=;b=;NORMA F1;NORMA F2;NORMA F3; alpha^2+2alpha*beta*(f1,f2) +beta^2 = 1 ???;|F1F3/F2F3|= MAX ;");

                int length;
                length = Math.Max(vecA.Count, vecB.Count);
                length = Math.Max(length, F3[maxIndex].Count);


                for (int i = 0; i < length; i++)
                {


                    //сигнал F1
                    if (i<vecA.Count)
                    {
                        sw.Write(vecA[i]+";");
                    }
                    else sw.Write(";");


                    //сигнал F2
                    if (i < vecB.Count)
                    {
                        sw.Write(vecB[i] + ";");
                    }
                    else sw.Write(";");

                    //оптимум F3
                    if (i < F3[maxIndex].Count)
                    {
                        sw.Write(F3[maxIndex][i] + ";");
                    }
                    else sw.Write(";");


                  //  sw.WriteLine("signal F1;signal F2; OPTIMUM F3; |F1F3-F2F3|=;a=;b=");
 

                    //тут выведем |F1F3-F2F3|=
                    if (i == 0)
                    {
                        sw.Write(kriterii(vecA, vecB, F3[maxIndex]) + ";");
                    }
                    else sw.Write(";");



                    //тут выведем a и b оптимального фильтра
                    if (i == 0)
                    {
                        switch (maxIndex)
                        {
                //F3[0].Add(A1 * vecA[i] + B1 * vecB[i]);
                //F3[1].Add(A2 * vecA[i] + B1 * vecB[i]);
                //F3[2].Add(A3* vecA[i] + B1 * vecB[i]);
                //F3[3].Add(A4 * vecA[i] + B1 * vecB[i]);

                //F3[4].Add(A1 * vecA[i] + B2 * vecB[i]);
                //F3[5].Add(A2 * vecA[i] + B2 * vecB[i]);
                //F3[6].Add(A3 * vecA[i] + B2 * vecB[i]);
                //F3[7].Add(A4 * vecA[i] + B2 * vecB[i]);


                            case 0:
                                 sw.Write("{0};{1};",A1,B1);
                                break;
                            case 1:
                                sw.Write("{0};{1};", A2, B1);
                                break;
                            case 2:
                                sw.Write("{0};{1};", A3, B1);
                                break;
                            case 3:
                                sw.Write("{0};{1};", A4, B1);
                                break;
                            case 4:
                                sw.Write("{0};{1};", A1, B2);
                                break;
                            case 5:
                                sw.Write("{0};{1};", A2, B2);
                                break;
                            case 6:
                                sw.Write("{0};{1};", A3, B2);
                                break;
                            case 7:
                                sw.Write("{0};{1};", A4, B2);
                                break;

                            default:
                                break;
                        }
                    }
                    else sw.Write(";;");

                    //тут выведем нормы
                    if (i == 0)
                    {
                        sw.Write("{0};{1};{2};", PrintNorma(vecA), PrintNorma(vecB), PrintNorma(F3[maxIndex]));
                    }
                    else sw.Write(";;;");


                    //Выведем дополнительныю проверку из Борзуновского письма
                    if (i == 0)
                    {
                        switch (maxIndex)
                        {
                            //F3[0].Add(A1 * vecA[i] + B1 * vecB[i]);
                            //F3[1].Add(A2 * vecA[i] + B1 * vecB[i]);
                            //F3[2].Add(A3* vecA[i] + B1 * vecB[i]);
                            //F3[3].Add(A4 * vecA[i] + B1 * vecB[i]);

                            //F3[4].Add(A1 * vecA[i] + B2 * vecB[i]);
                            //F3[5].Add(A2 * vecA[i] + B2 * vecB[i]);
                            //F3[6].Add(A3 * vecA[i] + B2 * vecB[i]);
                            //F3[7].Add(A4 * vecA[i] + B2 * vecB[i]);

//alpha^2+2alpha*beta*(f1,f2) +beta^2
                            case 0:
                                sw.Write("{0};", Math.Sqrt(A1*A1+2*A1*B1*F1F2+B1*B1));
                                break;
                            case 1:
                                sw.Write("{0};", Math.Sqrt(A2 * A2 + 2 * A2 * B1 * F1F2 + B1 * B1));
                                break;
                            case 2:
                                sw.Write("{0};", Math.Sqrt(A3 * A3 + 2 * A3 * B1 * F1F2 + B1 * B1));
                                break;
                            case 3:
                                sw.Write("{0};", Math.Sqrt(A4 * A4 + 2 * A4 * B1 * F1F2 + B1 * B1));
                                break;
                            case 4:
                                sw.Write("{0};", Math.Sqrt(A1 * A1 + 2 * A1 * B2 * F1F2 + B2 * B2));
                                break;
                            case 5:
                                sw.Write("{0};", Math.Sqrt(A2 * A2 + 2 * A2 * B2 * F1F2 + B2 * B2));
                                break;
                            case 6:
                                sw.Write("{0};", Math.Sqrt(A3 * A3 + 2 * A3 * B2 * F1F2 + B2 * B2));
                                break;
                            case 7:
                                sw.Write("{0};", Math.Sqrt(A4 * A4 + 2 * A4 * B2 * F1F2 + B2 * B2));
                                break;

                            default:
                                break;
                        }
                    }
                    else sw.Write(";");


                    if (i < F3_kiselev.Count)
                    {
                        sw.Write("{0};", F3_kiselev[i]);
                    }
                    else sw.Write(";");



                    sw.WriteLine();
                }
                   sw.Close();


            }

        }
    }
}
