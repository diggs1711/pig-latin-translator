using NUnit.Framework;
using PigLatinTranslator;

namespace PigLatinTranslator.Tests
{
    public class Tests
    {
        private PigLatinTranslator _pigLatinTranslator;

        [SetUp]
        public void Setup()
        {
            _pigLatinTranslator = new PigLatinTranslator();
        }

        [Test]
        public void Translate_Word_Begins_With_Vowel()
        {
            string res1 = _pigLatinTranslator.translateWord("apple");
            string res2 = _pigLatinTranslator.translateWord("oaken");

            Assert.AreEqual("appleyay", res1);
            Assert.AreEqual("oakenyay", res2);
        }

        [Test]
        public void Translate_Word_Begins_With_Capital_Letter_And_Preserves_Case()
        {
            string res1 = _pigLatinTranslator.translateWord("Apple");
            string res2 = _pigLatinTranslator.translateWord("Do");
            string NoCapitalLetter = _pigLatinTranslator.translateWord("button");

            Assert.AreEqual("Appleyay", res1);
            Assert.AreEqual("Oday", res2);
            Assert.AreEqual("uttonbay", NoCapitalLetter);
        }


        [Test]
        public void Translate_Word_Begins_With_Consonant()
        {
            string res1 = _pigLatinTranslator.translateWord("trebuchet");
            string res2 = _pigLatinTranslator.translateWord("shrimp");

            Assert.AreEqual("ebuchettray", res1);
            Assert.AreEqual("impshray", res2);
        }

        [Test]
        public void Translate_Word_Ends_With_Punctuation()
        {
            string res1 = _pigLatinTranslator.translateWord("waffles.");
            string res2 = _pigLatinTranslator.translateWord("today?");

            Assert.AreEqual("afflesway.", res1);
            Assert.AreEqual("odaytay?", res2);
        }

        [Test]
        public void Translate_Sentence()
        {
            string res1 = _pigLatinTranslator.TranslateSentence("I like to eat honey waffles.");
            string res2 = _pigLatinTranslator.TranslateSentence("Do you think it is going to rain today?");

            Assert.AreEqual("Iyay ikelay otay eatyay oneyhay afflesway.", res1);
            Assert.AreEqual("Oday ouyay inkthay ityay isyay oinggay otay ainray odaytay?", res2);
        }

        [Test]
        public void Translate_Word_Returns_Empty_String_When_No_Input()
        {
            string res = _pigLatinTranslator.translateWord("");
            Assert.AreEqual(res, "");
        }


    }
}