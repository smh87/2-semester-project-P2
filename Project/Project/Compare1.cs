using System;
using java.util;
using edu.stanford.nlp.tagger.maxent;
using System.Collections.Generic;
using System.Linq;

namespace comparer
{
    public class MainCheck1Class
    {
        public string MainCheck1(string text)
        {
            string binary = string.Empty;
            List<string> tagged = new List<string>();

            //Her kalder vi main for at få en path så vi kan få vores modeller
            Project.Program path = new Project.Program();
            var modelsDirectory = path.wantedPath + @"Data/models/models";
            var model = modelsDirectory + @"/pos-tagger/english-left3words/english-left3words-distsim.tagger";

            //Hvis vores modeller ikke bliver fundet bliver der sendt en ERROR
            if (!System.IO.File.Exists(model))
            {
                throw new Exception($"Check path to the model file '{model}'");
            }

            //Her kalder vi taggeren og ordene bliver opdelt
            var tagger = new MaxentTagger(model);
            var sentences = MaxentTagger.tokenizeText(new java.io.StringReader(text)).toArray();

            foreach (ArrayList sentence in sentences)
            {
                //Her bliver ordene først tagget, ord for ord
                //Efter de bliver tagget bliver de overført til tagged
                //Men inden de bliver overført fjerner vi ordet og beholder kun tagget for nu er ordet ligegyldigt
                List taggedSentence = tagger.tagSentence(sentence);
                tagged.AddRange(taggedSentence
                               .toArray()
                               .Select(e => e.ToString())
                               .Select(s => s.Substring(s.LastIndexOf('/')))
                               .ToList());
            }

            foreach (string tempstring in tagged)
            {
                //Nu skal vi bare se om tagget er et navneord (nn = ental, nns = flertal)
                if (string.Compare(tempstring, "/NN") == 0 || string.Compare(tempstring, "/NNS") == 0)
                {
                    binary += "1";
                }
                else
                {
                    binary += "0";
                }
            }

            //Så bliver det hele returneret til Master funktionen
            return binary;
        }
    }
}