using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This Code was written by Valentin Springer &  Alexander Dengler, 
 * 10.10.2016
 * 
 * The Idea and concept code was written by : James McCaffrey
 * and it can be found : https://visualstudiomagazine.com/articles/2013/03/01/pattern-recognition-with-perceptrons.aspx
 * 
 *
 * This is a Perceptron, after Training it can decide 
 * if an input is the same as for which it was trained
 * 
 * Thanks to people like James McCaffrey who make such code easy understandable and free accessible
 */
namespace Perceptron
{

    public class Perceptron
    {

        //Copied from Example
        public static int[][] trainingData = new int[5][];



        static void Main()
        {
            trainingData[0] = new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 };  // 'A'
            trainingData[1] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1 };  // last bit: 0 = is-B false, 1 = is-B true
            trainingData[2] = new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0 };  // 'C'
            trainingData[3] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 };  // 'D'
            trainingData[4] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 };  // 'E'

            Console.ReadKey();
            Console.Clear();

            //Copied From Example
            #region
            ShowData(trainingData[0]);
            ShowData(trainingData[1]);
            ShowData(trainingData[2]);
            ShowData(trainingData[3]);
            ShowData(trainingData[4]);
            #endregion
            Console.WriteLine();
            Console.WriteLine("This Perceptron trys to determine if it is a B or not");
            Console.WriteLine("It was Trained with the above examples");
            Console.ReadKey();

            int[] unknown = new int[] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0 };  // damaged 'B' in 2 positions
            Console.WriteLine("\nPredicting is a 'B' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown);
            Console.ReadKey();


            int[] unknown2 = new int[] { 0, 1, 1, 0,
                                         1, 0, 0, 1,
                                         1, 1, 1, 1,
                                         1, 0, 0, 1,
                                         1, 0, 0, 1 };  //not a B its A
            Console.WriteLine("\nPredicting is a 'B' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown2);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown2);
            Console.ReadKey();



            int[] unknown3 = new int[] { 1, 1, 1, 0,
                                         1, 1, 1, 1,
                                         1, 1, 1, 1,
                                         1, 0, 0, 1,
                                         1, 0, 1, 1 };  //not a B 
            Console.WriteLine("\nPredicting is a 'B' (yes = 1, no = 0) for the following pattern:\n");
            ShowData(unknown3);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The Prediction is:");
            Perceptron.First.Prediction(unknown3);
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

        //Deklaration of Perceptrons
        #region
        public static Perceptron First = new Perceptron("First",
            new int[][] {   //Trainingsdata
            trainingData[0] = new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0 },  // 'A'
            trainingData[1] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1 },  // last bit: 0 = is-B false, 1 = is-B true
            trainingData[2] = new int[] { 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0 },  // 'C'
            trainingData[3] = new int[] { 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },  // 'D'
            trainingData[4] = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }} // 'E'
            );
        #endregion

        public string Name;
        public float OutPut;
        public float[] weights;

        //Object Perceptron
        public Perceptron(string name, int[][] training)
        {
            Name = name;
            if (weights == null)
            {
                weights = TrainPerceptron(training, maxEpochs, alpha, targetError);
            }





        }


        public void Prediction(int[] Input)
        {
            float Dp = DotProdukt(Input, First.weights, BestBias);
            if (BestBias < Dp)
            {
                Console.WriteLine("Yes, it is a B");
            }
            else
            {
                Console.WriteLine("No, it is no B");
            }
            Console.WriteLine("The Dotpoint is " + Dp + " it Aktivates at: " + BestBias);
            //return (float) DotProdukt(Input, First.weights);
        }


        //Computes DotProdukt
        public float DotProdukt(int[] input, float[] weights, float bias)
        {

            float DP;
            float DPSum = 0f;
            for (int x = 0; x < input.Length || x < weights.Length - 1; x++)
            {
                DP = weights[x] * input[x];
                DPSum += DP;

            }
            DPSum += bias;
            return DPSum;
        }



        //Dekleration for the Weight learning function
        public int maxEpochs = 100000;
        public double alpha = 0.075;
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
                    int desired = Trainingsdata[i][Trainingsdata[i].Length - 1];

                    float Output = DotProdukt(Trainingsdata[i], Wheights, Bias);
                    float delta = desired - Output;

                    for (int x = 0; x < Wheights.Length; x++)
                    {
                        Wheights[x] += (float)alpha * delta * Trainingsdata[i][x];
                    }
                    Bias += (float)(alpha * delta);
                }
                epoch++;
                Console.WriteLine("This current Round is: \t" + epoch);
                Error = TotalError(Trainingsdata, Wheights, Bias);
                Console.WriteLine("The current Error is: \t" + Error);

            }
            BestBias = Bias;

            if (Wheights == null)
            {
                Console.WriteLine("Wheigt returns null");
                Console.ReadKey();
            }
            Console.WriteLine("");
            Console.WriteLine("The Wheights are:");
            Console.WriteLine("");
            for (int x = 0; x < Wheights.Length; x++)
            {
                Console.WriteLine("Wheight " + x + "\t is \t" + Wheights[x]);
            }
            return Wheights;

        }

        //Training Loop exit criterion
        public double TotalError(int[][] trainingsdata, float[] wheights, float bias)
        {
            double sum = 0.0;
            for (int i = 0; i < trainingsdata.Length; i++)
            {
                int desired = trainingsdata[i][trainingsdata[i].Length - 1];
                float Output = DotProdukt(trainingsdata[i], wheights, bias);
                sum += Math.Abs(desired - Output);
            }

            return 0.5 * sum;
        }





    }
}
