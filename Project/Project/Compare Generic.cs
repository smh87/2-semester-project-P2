using System;
using System.IO;

namespace comparer
{
    class Comparer_Generic
    {
        private const int Words = 15;
        public double Function_Generic(string Texttocheck, string text)
        {
            string data = string.Empty,
                   temp_data = string.Empty,
                   temp_text = string.Empty;
            double plag_perc = 0;
            int length_data = 0,
                length_text = 0;

            //Her tjekker vi om vi skal tjekke filen eller om vi kan springe den over
            if (string.Compare(Texttocheck, "null") == 0)
            {
                return plag_perc;
            }

            //Her læser vi en filen som er givet af Caller
            data = File.ReadAllText(Texttocheck);
            length_data = data.Length;
            length_text = text.Length;

            //Her comparer vi de to text strings ved at tage Words ord ad gangen fra den uploaded text
            //Derefter sammenligner vi det med hele den text der kommer fra databasen
            //Derefter tager vi de næste Words ord ind fra uploaded text og gør det igen
            for (int a = 0; a < (length_text - Words); a += Words)
            {
                temp_text = text.Substring(a, Words);
                for (int b = 0; b < (length_data - Words); b++)
                {
                    temp_data = data.Substring(b, Words);
                    if (string.Compare(temp_data, temp_text) == 0)
                    {
                        plag_perc += Words;
                    }
                }
            }

            //Her har vi hvor mange procent(givet i decimaler) der er matched
            plag_perc = plag_perc / length_text;
            return plag_perc;
        }
    }
}