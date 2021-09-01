using System;
using System.Text;
using LemmaSharp;

namespace comparer
{
    public class MainCheck3Class
    {
        public string MainCheck3(string text)
        {
            Comparer_Binary compare = new Comparer_Binary();

            //Her er en string builder, fordi der kan tilføjes flere string til den modsat en string
            StringBuilder sb = new StringBuilder(string.Empty, 100);

            //Her fjerner vi diverse tegn for at lemma tingen ikke bliver forvirret
            string[] exampleWords = text.Split(
                new char[] { ' ', ',', '.', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);


            //Her kalder vi lemma tingen
            ILemmatizer lmtz = new LemmatizerPrebuiltCompact(LemmaSharp.LanguagePrebuilt.English);
            
            //Her går vi igennem hvert ord og lemmatizer det
            //Hvorefter det bliver tilføjet til stringbuilderen (sb)
            foreach (string word in exampleWords)
            {
                string temp = LemmatizeOne(lmtz, word);
                sb.Append(temp);
                sb.Append(" ");
            }

            //Her bliver det hele retuneret til Master funktionen
            return sb.ToString();
        }

        private string LemmatizeOne(ILemmatizer lmtz, string word)
        {

            //Her laver vi ordet til lower case først, hvoefter vi lemmatizer det og sender det retur
            string wordLower = word.ToLower();
            string lemma = lmtz.Lemmatize(wordLower);
            return lemma;
        }
    }
}