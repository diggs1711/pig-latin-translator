using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PigLatinTranslator
{

    public class PigLatinTranslator
    {
        public char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public string translateWord(string s)
        {
            if(s == "" || s == null) {
                return "";
            }

            string stringWithRemovedPunc = Regex.Replace(s,"[?!,.]", "");
            Char firstLetter = s[0];
            Match punc = Regex.Match(s, "[?!,.]");

            if (isVowel(firstLetter)) {
                return stringWithRemovedPunc + "yay" + punc.Value;
            } else {
                int idx = getIndexOfFirstVowel(stringWithRemovedPunc);
                bool isCapital = isCapitalLetter(firstLetter);

                string upToFirstVowel = stringWithRemovedPunc.Substring(0, idx);
                string after = stringWithRemovedPunc.Substring(idx);

                if(isCapital) {
                    Char newFirstLetter = Char.ToUpper(after[0]);
                    return newFirstLetter + after.Substring(1) + upToFirstVowel.ToLower() + "ay" + punc.Value;
                } else {
                    return after + upToFirstVowel + "ay" + punc.Value;
                }
            }
        }

        private bool isVowel(Char c) {
            return vowels.Contains(Char.ToLower(c));
        }

        public string TranslateSentence(string sentence) {
            string[] splitString = sentence.Split(' ');

            List<string> res = new List<string>();

            foreach (var word in splitString)
            {
               res.Add(translateWord(word));
            }

            return string.Join(" ", res.ToArray());
        }

        private bool isCapitalLetter(Char c) {
            return Char.IsUpper(c);
        }

        private int getIndexOfFirstVowel(string s)
        {
            int index = 0;

            while (index < s.Length && !vowels.Contains(s[index]))
            {
                index++;
            }

            return index;
        }
    }
}
