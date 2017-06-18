using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This Code was written by Valentin Springer & Alexander Dengler, 
 * 10.10.2016
 * 
 * The Idea and concept code was written by : James McCaffrey
 * and it can be found : https://visualstudiomagazine.com/articles/2013/03/01/pattern-recognition-with-perceptrons.aspx
 * 
 * * This is a Perceptron, after Training it can decide 
 * if an input is the same as for which it was trained
 * 
 * Thanks to people like James McCaffrey who make such code easy understandable and free accessible
 */
namespace Perceptron
{

    public class Perceptron
    {

        //Copied from Example
        public static int[][] trainingData = new int[26][];



        static void Main()
        {
            trainingData[0] = new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0};  // 'A'
            trainingData[1] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0 }; // last bit: 0 = is-B false, 1 = is-B true
            trainingData[2] = new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0 }; // 'C'
            trainingData[3] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 }; // 'D'
            trainingData[4] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }; // 'E'
            trainingData[5] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 }; // 'F'
            trainingData[6] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0 }; // 'G'
            trainingData[7] = new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 }; // 'H'
            trainingData[8] = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }; // 'I'
            trainingData[9] = new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }; // 'J'
            trainingData[10]= new int[] { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }; // 'K'
            trainingData[11]= new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }; // 'L'
            trainingData[12]= new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 }; // 'N'
            trainingData[13]= new int[] { 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0 }; // 'N'
            trainingData[14]= new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }; // 'O'
            trainingData[15]= new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 }; // 'P'
            trainingData[16]= new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }; // 'Q'
            trainingData[17]= new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }; // 'R'
            trainingData[18]= new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0 }; // 'S'
            trainingData[19]= new int[] { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 }; // 'T'
            trainingData[20]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }; // 'U'
            trainingData[21]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 }; // 'V'
            trainingData[22]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0 }; // 'W'
            trainingData[23]= new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }; // 'X'
            trainingData[24]= new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 }; // 'Y'
            trainingData[25]= new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0 }; // 'Z'

            Console.ReadKey();
            Console.Clear();

            //Copied From Example
            #region
            ShowData(trainingData[0]);
            ShowData(trainingData[1]);
            ShowData(trainingData[2]);
            ShowData(trainingData[3]);
            ShowData(trainingData[4]);
            ShowData(trainingData[5]);
            ShowData(trainingData[6]);
            ShowData(trainingData[7]);
            ShowData(trainingData[8]);
            ShowData(trainingData[9]);
            ShowData(trainingData[10]);
            ShowData(trainingData[11]);
            ShowData(trainingData[12]);
            ShowData(trainingData[13]);
            ShowData(trainingData[14]);
            ShowData(trainingData[15]);
            ShowData(trainingData[16]);
            ShowData(trainingData[17]);
            ShowData(trainingData[18]);
            ShowData(trainingData[19]);
            ShowData(trainingData[20]);
            ShowData(trainingData[21]);
            ShowData(trainingData[22]);
            ShowData(trainingData[23]);
            ShowData(trainingData[24]);
            ShowData(trainingData[25]);
            #endregion
            Console.WriteLine();
            Console.WriteLine("This Perceptron trys to determine if it is a '" + Letter + "' or not");
            Console.WriteLine("It was Trained with the above examples");
            Console.ReadKey();

            Console.Clear();
            int[] unknown = new int[] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0 };  // damaged 'B' in 2 positions
            Console.WriteLine("\nPredicting is a '"+ Letter +"' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown);
            Console.ReadKey();


            Console.Clear();
            int[] unknown2 = new int[] { 0, 1, 1, 0,
                                         1, 0, 0, 1,
                                         1, 1, 1, 1,
                                         1, 0, 0, 1,
                                         1, 0, 0, 1 };  //not a B its A
            Console.WriteLine("\nPredicting is a '" + Letter + "' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown2);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown2);
            Console.ReadKey();


            Console.Clear();
            int[] unknown3 = new int[] { 1, 1, 1, 0,
                                         1, 1, 1, 1,
                                         1, 1, 1, 1,
                                         1, 0, 0, 1,
                                         1, 0, 1, 1 };  //not a B 
            Console.WriteLine("\nPredicting is a '" + Letter + "' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown3);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown3);
            Console.ReadKey();


            Console.Clear();
            int[] unknown4 = trainingData[4] = new int[] { 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }; // 'F'
            Console.WriteLine("\nPredicting is a '" + Letter + "' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown4);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown4);
            Console.ReadKey();

        }
        //Copied from Example
        public static void ShowData(int[] data)
        {
            for (int i = 0; i < 20; ++i)  // hard-coded to indicate custom routine
            {
                if (i % 4 == 0) { Console.WriteLine(""); Console.Write(" "); }  // finished a row
                if (data[i] == 0) Console.Write(" ");
                else Console.Write("1");
            }
            Console.WriteLine("");
        }

        public static string Letter = "F";

        //Deklaration of Perceptrons
        #region
        public static Perceptron First = new Perceptron("First",
            new int[][] {   //Trainingsdata (last bit: 0 = is-letter false, 1 = is-letter true)
            trainingData[0] = new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 }, // 'A'
            trainingData[1] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0 }, // 'B'
            trainingData[2] = new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0 }, // 'C'
            trainingData[3] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 }, // 'D'
            trainingData[4] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, // 'E'
            trainingData[5] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 }, // 'F'
            trainingData[6] = new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0 }, // 'G'
            trainingData[7] = new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 }, // 'H'
            trainingData[8] = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }, // 'I'
            trainingData[9] = new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }, // 'J'
            trainingData[10]= new int[] { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }, // 'K'
            trainingData[11]= new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, // 'L'
            trainingData[12]= new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 }, // 'M'
            trainingData[13]= new int[] { 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0 }, // 'N'
            trainingData[14]= new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }, // 'O'
            trainingData[15]= new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 }, // 'P'
            trainingData[16]= new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }, // 'Q'
            trainingData[17]= new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }, // 'R'
            trainingData[18]= new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0 }, // 'S'
            trainingData[19]= new int[] { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 }, // 'T'
            trainingData[20]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 }, // 'U'
            trainingData[21]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 }, // 'V'
            trainingData[22]= new int[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0 }, // 'W'
            trainingData[23]= new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 }, // 'X'
            trainingData[24]= new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 }, // 'Y'
            trainingData[25]= new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0 }  // 'Z'
            });   
        #endregion

        public string Name;
        public float OutPut;
        public float[] weights;
        
        //Object Perceptron
        public Perceptron(string name, int[][] training)
        {
            Name = name;
            if(weights == null)
            {
                weights = TrainPerceptron(training, maxEpochs, alpha, targetError);
            }
        }


        public void Prediction(int[] Input)
        {
            float Dp = DotProdukt(Input, First.weights,BestBias);
            if (BestBias < Dp)
            {
                Console.WriteLine("Yes, it is a "+ Letter);
            }
            else {
                Console.WriteLine("No, it is no "+ Letter);
            }
            Console.WriteLine("The Dotpoint is " + Dp + " it Aktivates at: " + BestBias);
            //return (float) DotProdukt(Input, First.weights);
        }


        //Computes DotProdukt
        public float DotProdukt(int[] input , float[] weights ,float bias)
        {
            
            float DP;
            float DPSum = 0f;
            for (int x = 0; x < input.Length || x < weights.Length-1; x++)
            {
                DP = weights[x] * input[x];
                DPSum += DP;
                
            }
            DPSum += bias;
            return DPSum;
        }



        //Dekleration for the Weight learning function
        public int maxEpochs = 1000000;
        public double alpha = 0.00075;
        public double targetError = 0.0;
        public float Bias = 0.050f;
        public float BestBias;
        double Error = double.MaxValue;
        int epoch = 0;

        //Weight Learning function/ Training Loop
        public float[] TrainPerceptron(int[][] Trainingsdata, int maxEpochs, double alpha, double TargetError)
       {
            Console.WriteLine("Started Training:");
            int dim = trainingData[0].Length;
            float[] Wheights = new float[dim];

            Console.WriteLine("Epoch: " + (epoch < maxEpochs));
            Console.WriteLine("Error: " + (Error > TargetError));
            Console.WriteLine("Trainingsloop is about to Start");
            Console.WriteLine("Press any Key to continue...");
            Console.ReadKey();
            Console.WriteLine("Execute Trainingsloop");
            while (epoch < maxEpochs && Error > TargetError)
            {
                for (int i = 0; i < Trainingsdata.Length; i++)
                {
                    int desired = Trainingsdata[i][Trainingsdata[i].Length-1];

                    float Output = DotProdukt(Trainingsdata[i] , Wheights, Bias);
                    float delta = desired - Output;

                    for(int x = 0; x < Wheights.Length; x++)
                    {
                        Wheights[x] += (float) alpha * delta * Trainingsdata[i][x];
                    }
                    Bias +=(float) (alpha * delta);
                }
                epoch++;
                //Console.WriteLine("\r");
                //Console.WriteLine("This current Round is: \t"+epoch);
                Error = TotalError(Trainingsdata,Wheights,Bias);
                Console.WriteLine("The current Error is: \t"+ Error + "\tRounds to Go: \t" + (maxEpochs - epoch));
            }
            BestBias = Bias;
          
            if(Wheights == null)
            {
                Console.WriteLine("Wheigt returns null");
                Console.ReadKey();
            }
            Console.WriteLine("");
            Console.WriteLine("\aThe Wheights are:");
            Console.WriteLine("");
            for(int x = 0; x < Wheights.Length; x++)
            {
                Console.WriteLine("Wheight "+ x +"\t is \t"+ Wheights[x]);
            }
            return Wheights;
            
        }

        //Training Loop exit criterion
        public double TotalError(int[][] trainingsdata,float[] wheights ,float bias)
        {
            double sum = 0.0;
            for(int i = 0; i < trainingsdata.Length; i++)
            {
                int desired = trainingsdata[i][trainingsdata[i].Length-1];
                float Output = DotProdukt(trainingsdata[i], wheights , bias);
                sum += Math.Abs(desired - Output);
            }

            return 0.5 * sum;
        }



        
      
    }
}
