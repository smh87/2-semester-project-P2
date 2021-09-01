using System.IO;

namespace comparer
{
    class Comparer_Binary
    {
        private const int Words = 5;
        public double Function_Binary(string Texttocheck, string text)
        {
            string data = string.Empty;
            double plag_perc = 0;
            int length = 0,
                length_text = 0,
                length_data = 0;

            //Her tjekker vi skal tjekke imod den tekst vi har fået eller om den kan springes over
            if (string.Compare(Texttocheck, "null") == 0)
            {
                return plag_perc;
            }

            //Her læses filen fra data basen ind i data string
            data = File.ReadAllText(Texttocheck);
            length_data = data.Length;
            length_text = text.Length;

            //Her finder vi den korteste tekst
            //Dette bruges senere i comparer funktionen
            if (length_data < length_text || length_data == length_text)
            {
                length = length_data;
            }
            else
            {
                length = length_text;
            }

            //Her tjekker vi Words antal af bits fra hver tekst op mod hindanen
            //Her comparer vi direkte
            for (int a = 0; a < (length - Words); a += Words)
            {
                string temp_data = data.Substring(a, Words);
                string temp_text = text.Substring(a, Words);
                if (string.Compare(temp_data, temp_text) == 0)
                {
                    plag_perc += Words;
                }
            }
            
            //Her har vi hvor mange procent(givet i decimaler) der er matched
            plag_perc = plag_perc / length_text;
            return plag_perc;
        }
    }
}