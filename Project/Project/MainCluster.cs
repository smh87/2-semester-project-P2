using System;

namespace ClusterClass
{
    public class MainCluster
    {
        public int maxTagesUsed = 9; //10 because 0 also counts it is 9
        public static Boolean debuggerMode = true;

        public string[] MainClusterCode(string[] tagsToCheck, string folderPath)
        {
            int[] textsThatMatchInt;
            string[] tagMatchArray = new string[tagsToCheck.Length];

            int i = 0;
            while (i < tagsToCheck.Length)
            {
                tagsToCheck[i] = tagsToCheck[i] + ":";
                i++;
            }

                TagSorter tagRef = new TagSorter();
            Categorizer tagRefCat = new Categorizer();

            textsThatMatchInt = tagRef.FindReleventTexts(tagsToCheck, folderPath);

            string[] finalArrayOfTexts = tagRefCat.CategorizeTexts(tagRef.ReleventTextsArrayPasser, textsThatMatchInt);
            return finalArrayOfTexts;
        }
    }
}
