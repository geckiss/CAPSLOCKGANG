using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPSLOCKGANG
{
    /// <summary>
    /// Bip39 mnemonic phrase generator and verifier
    /// <para>
    ///     <see href="https://github.com/geckiss/PA193_mnemonic_CAPSLOCKGANG"/>
    /// </para>
    /// </summary>
    public class Bip39
    {
        private readonly IList<string> wordList;

        private readonly Encoding encoding;

        public Bip39(IList<string> wordList) : this(wordList, Encoding.UTF8)
        {
        }

        public Bip39(IList<string> wordList, Encoding encoding)
        {
            if (wordList == null)
            {
                throw new ArgumentNullException(nameof(wordList));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            // fix wordlist
            wordList = wordList.Select(line => line.Trim())
                               .Where(line => line.Length > 0) 
                               //.OrderBy(line => line)
                               .ToList();

            if (wordList.Count != 2048)
            {
                // TODO: throw exception or?
            }

            this.wordList = wordList;
            this.encoding = encoding;
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
