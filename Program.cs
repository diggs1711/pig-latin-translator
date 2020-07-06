using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            PigLatinTranslator pigLatinTranslator = new PigLatinTranslator();

            pigLatinTranslator.translateWord("Hello");
        }
    }
}
