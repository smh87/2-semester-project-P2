namespace Project 
{
    public class Texts: Program
    {
        public string PathToText { get; set; }
        public string PathToTextBinary { get; set; }
        public string PathToTextLemmon { get; set; }
        public double PercentPlagerism1 { get; private set; }
        public double PercentPlagerism2 { get; private set; }
        public double PercentPlagerism3 { get; private set; }
        public int MethodsUsed { get; private set; }
        public int MySpot { get; set; }

        public void CheckThePlagerism(string binary, string lemmatized, string text)
        {
            comparer.Comparer_Binary compareMethod1 = new comparer.Comparer_Binary();
            comparer.Comparer_Generic compareMethod2 = new comparer.Comparer_Generic();
            MethodsUsed = 0;

            if (MySpot >= TextToAlwaysCheck)
            {
                PercentPlagerism1 = compareMethod1.Function_Binary(PathToTextBinary, binary);
                MethodsUsed++;
                if (PercentPlagerism1 > MaxPercent1)
                {
                    PercentPlagerism2 = compareMethod2.Function_Generic(PathToText, text);
                    MethodsUsed++;
                    if (PercentPlagerism2 > MaxPercent2)
                    {
                        PercentPlagerism3 = compareMethod2.Function_Generic(PathToTextLemmon, lemmatized);
                        MethodsUsed++;
                    }
                }
            }
            else
            {
                PercentPlagerism3 = compareMethod2.Function_Generic(PathToTextLemmon, lemmatized);
                MethodsUsed++;
            }
        }
    }
}
