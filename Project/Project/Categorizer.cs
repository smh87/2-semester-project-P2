namespace ClusterClass
{
    class Categorizer
    {
        public string[] finalArray;
        public int removeCounter = 0;

        public string[] CategorizeTexts(string[] strArray, int[] numArray)
        {
            finalArray = strArray;
            int[] pointsPrTxt = new int[finalArray.Length];

            pointsPrTxt = GivePointsToArray(pointsPrTxt, strArray, numArray);
            pointsPrTxt = RemoveDupes(pointsPrTxt, strArray, numArray);

            finalArray = SetCorrectOrder(pointsPrTxt, finalArray, numArray);

            return finalArray;
        }

        private int[] GivePointsToArray(int[] pointArray, string[] strArray, int[] numArray)
        {
            /*
            *this function gives points to all texts.
            *Text that match the first tag are given max points since this is the most valued tag
            *Afterwords every tag gives one less point until it is only 1 point
            */

            int i = 0;
            int j = 0;
            int count = 0;
            int count2 = 0;
            while (i < pointArray.Length)
            {
                if (count == 0)
                {
                    j++;
                    count = numArray[count2];
                    count2++;
                }

                pointArray[i] = j;
                i++;
                count--;
            }

            return pointArray;
        }

        private int[] RemoveDupes(int[] pointArray, string[] strArray, int[] numArray)
        {
            /*
            *This loop removes duplicates and add their points together 
            */
            int j = 0;
            int i = 0;
            while (i < finalArray.Length)
            {
                j = i + 1;
                while (j < finalArray.Length)
                {
                    if (strArray[i].Equals(strArray[j]))
                    {
                        pointArray[i] += pointArray[j];

                        if (pointArray[j] != 0)
                        {
                            removeCounter++;
                        }

                        pointArray[j] = 0;
                        finalArray[j] = "null";
                    }
                    j++;
                }
                i++;
            }
            return pointArray;
        }

        private string[] SetCorrectOrder(int[] pointArray, string[] strArray, int[] numArray)
        {
            int arraySize = strArray.Length - removeCounter;
            string[] finalString = new string[arraySize];
            int i = 0;
            int finalJ = 0;
            int j = 0;

            int maxNum = 0;
            while (i < arraySize)
            {
                maxNum = pointArray[i];
                finalString[i] = strArray[i];
                j = 0;
                finalJ = i;
                while (j < strArray.Length)
                {
                    if (maxNum < pointArray[j])
                    {
                        maxNum = pointArray[j];
                        finalJ = j;
                    }
                    j++;
                }
                finalString[i] = strArray[finalJ];
                pointArray[finalJ] = 0;
                i++;
            }
            return finalString;
        }
    }
}