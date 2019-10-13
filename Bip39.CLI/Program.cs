using System.IO;

namespace CAPSLOCKGANG.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] wordList = File.ReadAllLines("english.txt");

            Bip39 bip39 = new Bip39(wordList);

            var seedAndEntropy = bip39.GenerateSeedAndEntropy("ozone drill grab fiber curtain grace pudding thank cruise elder eight picnic");

            var seedAndPhrase = bip39.GenerateSeedAndPhrase("0x9e885d952ad362caeb4efe34a8e91bd2");

            bool isOk = bip39.Verify(seedAndPhrase.MnemonicPhrase, seedAndPhrase.Seed);
        }
    }
}
