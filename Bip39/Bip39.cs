using System;
using System.Collections.Generic;

namespace CAPSLOCKGANG
{
    /// <summary>
    /// Bip39 mnemonic phrase generator and verifier
    /// </summary>
    public class Bip39
    {
        private readonly ICollection<string> wordList;

        public Bip39() : this(new List<string>()) // TODO: use some default wordlist
        {
        }

        public Bip39(ICollection<string> wordList)
        {
            if (wordList == null)
            {
                throw new ArgumentNullException(nameof(wordList));
            }
            if (wordList.Count != 2048)
            {
                // TODO: throw exception or?
            }

            this.wordList = wordList;
        }

        public SeedPhraseResult GenerateSeedAndPhrase(string entropy)
        {
            throw new NotImplementedException();
        }

        public SeedEntropyResult GenerateSeedAndEntropy(string mnemonicPhrase)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string mnemonicPhrase, string seed)
        {
            throw new NotImplementedException();

            // or just: return GenerateSeedAndEntropy(mnemonicPhrase).Seed == seed;
        }
    }
}
