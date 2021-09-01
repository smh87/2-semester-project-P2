using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Project
{ 
    public class Program
    {
        public string[] ArrayOfTextsNames { get; private set; }
        public int MaxPercent1 { get { return 10; } }
        public int MaxPercent2 { get { return 5; } }
        public int TextToAlwaysCheck { get { return 3; } }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //get path to UI folder husk at lave kontrol af path
        public string wantedPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new P2());
        }

        public double[] RunPlagiarismCheck(string text)
        {
            ConsoleAppCoreNlp.Kwindex NewIndex = new ConsoleAppCoreNlp.Kwindex();
            ClusterClass.MainCluster ClusterIndex = new ClusterClass.MainCluster();
            P2 Frontend = new P2();
            List<string> Frekvenstable = NewIndex.KwMain(text,wantedPath);
            if (Frekvenstable.Count != 10) {
                return null;
            }
            string[] tags = Frekvenstable.ToArray();
            string[] arrayOfTexts = ClusterIndex.MainClusterCode(tags, wantedPath);

            comparer.MainCheck1Class check1 = new comparer.MainCheck1Class();
            comparer.MainCheck3Class check3 = new comparer.MainCheck3Class();
            string lemmatized = check3.MainCheck3(text);
            string binary = check1.MainCheck1(text);
            double[] ArrayOfPercantages = new double[arrayOfTexts.Length];

            Texts[] textsArray = new Texts[arrayOfTexts.Length];
            int i = 0;
            while (i < arrayOfTexts.Length)
            {
                string localStr = wantedPath + @"Data\Binary\" + arrayOfTexts[i] + ".txt";
                textsArray[i] = new Texts();
                textsArray[i].PathToTextBinary = localStr;
                localStr = wantedPath + @"Data\Lemma\" + arrayOfTexts[i] + ".txt";
                textsArray[i].PathToTextLemmon = localStr;
                localStr = wantedPath + @"Data\Texts\" + arrayOfTexts[i] + ".txt";
                textsArray[i].PathToText = localStr;
                textsArray[i].MySpot = i;
                textsArray[i].CheckThePlagerism(binary, lemmatized, text);
                ArrayOfPercantages[i] = textsArray[i].PercentPlagerism3;
                i++;
            }
            ArrayOfTextsNames = arrayOfTexts;
            Console.WriteLine("Plag1:" + textsArray[0].PercentPlagerism1 +
                "Plag2:" + textsArray[0].PercentPlagerism2 +
                "Plag3:" + textsArray[0].PercentPlagerism3);

            return ArrayOfPercantages;
        }
    }
}
