using System;

namespace ClusterClass
{
    class TagSorter : MainCluster
    {
        private string[] releventTextsArrayLocation;//used to define what text match the tags search
        //private string indexLocation = @"E:\my programes\Visual programs\Cluster\Cluster\Data\Index.txt";
        public string[] ReleventTextsArrayPasser { get { return releventTextsArrayLocation; } }//Makes sure that the right array is returned and not altered from another class
        //this part finds the right
        public int[] FindReleventTexts(string[] tagsToCheck, string rootLocation)
        {
            int tagsLeft = maxTagesUsed;//Program default is to always cheack for 10 tags therfore 9 since we count 0;
            string indexLocation = rootLocation + @"Data\Index.txt";
            int lineNumber = 0;
            int[] amountOfTextsToTag = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int totalTexts = 0;
            string lineWithCorrectTag = "";
            string compilledLines = "";
            while (tagsLeft >= 0) {
                int i = 0;
                int j = 0;
                foreach (var textLine in System.IO.File.ReadAllLines(indexLocation))
                {
                    lineNumber++;
                    if (textLine.Contains(tagsToCheck[tagsLeft]))
                    {
                        lineWithCorrectTag = textLine;
                    }
                }
                if (lineWithCorrectTag != "")
                {
                    lineWithCorrectTag = lineWithCorrectTag.Substring(lineWithCorrectTag.IndexOf(":") + 1);//this line makes a new string after the first ":"

                    if (compilledLines == "")
                    {
                        compilledLines = lineWithCorrectTag;
                    }
                    else
                    {
                        compilledLines = compilledLines + "," + lineWithCorrectTag;
                    }

                    for (i = 0; i < lineWithCorrectTag.Length; i++)
                    {
                        if (lineWithCorrectTag[i] == ',')
                        {
                            j++;
                        }
                    }
                    amountOfTextsToTag[tagsLeft] = j + 1;
                    totalTexts += amountOfTextsToTag[tagsLeft];
                }


                
                tagsLeft--;
            }
            releventTextsArrayLocation = compilledLines.Split(',');//This line saparates the string into smaller bits. Seperating them at every ","
            return amountOfTextsToTag;
        }
    }
}