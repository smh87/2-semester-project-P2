using System;
using java.util;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCoreNlp
{
    public class Kwindex
    {
        public List<string> KwMain(string text, string wantedPath)
        {
            //get path to UI folder
            var modelsDirectory = @wantedPath + @"Data/models/models";
            var model = modelsDirectory + @"/pos-tagger/english-left3words/english-left3words-distsim.tagger";

            if (!System.IO.File.Exists(model))
                throw new Exception($"Check path to the model file '{model}'");

            // Loading POS Tagger
            var tagger = new MaxentTagger(model);

            var sentences = MaxentTagger.tokenizeText(new java.io.StringReader(text)).toArray();
            //Ny Keyword
            KeyWord NewKeyword = new KeyWord();
            //liste af string til at gemme taggedsaetninger
            List<string> NounList = new List<string>();

            foreach (List sentence in sentences)
            {
                var TaggedSentenceList = (tagger.tagSentence(sentence));
                //Lav tagged sætninger om til string
                string MyTaggedSentences = SentenceUtils.listToString(TaggedSentenceList, false);
                //gem til MyList
                NounList.AddRange(NewKeyword.NounFilter(MyTaggedSentences));

                //udskriver tagged saetninger
                
            }
            //Frekvenstable med emneord / noegleord
            
            List<string> FrekvensTable = NewKeyword.FreqvensTable(NounList);
            
            return FrekvensTable;
        }

    }

    class KeyWord
    {
        /// <summary>
        /// Funktion til at filtrer navneord ental og fleretal fra tekster
        /// </summary>
        /// <param name="TaggedWord"></param>
        /// <returns>Liste af ord NounTaggedList</returns>
        public List<String> NounFilter(string TaggedWord)
        {
            List<string> NounTaggedList = TaggedWord.Split(' ')
            //med nogle tilaegs ord /JJ saa skriv det her 
            //.Where(p => p.EndsWith("/NN") || p.EndsWith("/NNS") || p.EndsWith("/JJ")).ToList();
            .Where(p => p.EndsWith("/NN") || p.EndsWith("/NNS")).ToList();

            return NounTaggedList;
        }
        public List<string> FreqvensTable(List<string> MyList)
        {
            //liste til frekvenstable
            List<string> NounList = new List<string>();
            SortedList<string, int> SortNounList = new SortedList<string, int>();
            //frekvens beregning
            var n = from x in MyList
                    group x by x into y
                    select y;
            //top 10
            foreach (var arrNo in n)
            {
                //tilfoej til table
                SortNounList.Add(arrNo.Key, arrNo.Count());
            }
            IEnumerable<KeyValuePair<string, int>> SortNounList2 = (from entry in SortNounList orderby entry.Value descending select entry).Take(10);
            //fjern endelser /nn osv 
            foreach (KeyValuePair<string, int> x in SortNounList2)
            {
                char[] MyChar = { '/', 'N', 'J', 'S' };
                NounList.Add(x.Key.TrimEnd(MyChar));
            }
            return NounList;
        }
    }
}
