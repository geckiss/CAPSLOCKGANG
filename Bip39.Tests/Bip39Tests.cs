using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace CAPSLOCKGANG.Tests
{
    public class Tests
    {
        // some wordlists are here: https://github.com/trezor/python-mnemonic/tree/master/mnemonic/wordlist

        private IList<string> wordList;

        [SetUp]
        public void Setup()
        {
            wordList = File.ReadAllLines(@"..\..\..\english.txt");
        }

        [Test]
        public void Constructor_ThrowsException_When_WordListIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Bip39(new string[0]);
            });
        }

        [Test]
        public void Constructor_ThrowsException_When_WordListContainsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Bip39(new string[1]);
            });
        }

        [Test]
        public void Constructor_ThrowsException_When_WordListIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Bip39(null, null);
            });
        }

        // TODO: maybe more constructor tests?

        [Test]
        public void GenerateSeedAndPhrase_ThrowsException_When_EntropyIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Bip39(wordList).GenerateSeedAndPhrase(null);
            });
        }

        //[TestCase("00000000000000000000000000000000", ExpectedResult = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about")]
        //[TestCase("9e885d952ad362caeb4efe34a8e91bd2", ExpectedResult = "ozone drill grab fiber curtain grace pudding thank cruise elder eight picnic")]
        //[TestCase("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", ExpectedResult = "zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo vote")]
        //// TODO: maybe add more cases
        //public string GetSeedAndPhrase_ReturnsValidMnemonicPhase_When_EntropyIsValid(string entropy)
        //{
        //    var result = new Bip39(wordList).GenerateSeedAndPhrase(entropy);
        //    return result.MnemonicPhrase;
        //}

        //[TestCase("00000000000000000000000000000000", ExpectedResult = "c55257c360c07c72029aebc1b53c05ed0362ada38ead3e3e9efa3708e53495531f09a6987599d18264c1e1c92f2cf141630c7a3c4ab7c81b2f001698e7463b04")]
        //[TestCase("9e885d952ad362caeb4efe34a8e91bd2", ExpectedResult = "274ddc525802f7c828d8ef7ddbcdc5304e87ac3535913611fbbfa986d0c9e5476c91689f9c8a54fd55bd38606aa6a8595ad213d4c9c9f9aca3fb217069a41028e")]
        //[TestCase("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", ExpectedResult = "dd48c104698c30cfe2b6142103248622fb7bb0ff692eebb00089b32d22484e1613912f0a5b694407be899ffd31ed3992c456cdf60f5d4564b8ba3f05a69890ad")]
        //public string GetSeedAndPhrase_ReturnsValidSeed_When_EntropyIsValid(string entropy)
        //{
        //    var result = new Bip39(wordList).GenerateSeedAndPhrase(entropy);
        //    return result.Seed;
        //}

        // etc ...
    }
}