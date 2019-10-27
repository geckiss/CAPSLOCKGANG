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
            wordList = wordList.Where(line => line != null)
                               .Select(line => line.Trim())
                               .Where(line => line.Length > 0)
                               .ToList();

            if (wordList.Count != 2048)
            {
                throw new ArgumentException("Line count != 2048", nameof(wordList));
            }

            this.wordList = wordList;
            this.encoding = encoding;
        }

        public SeedPhraseResult GenerateSeedAndPhrase(string entropy)
        {
            if (entropy == null)
            {
                throw new ArgumentNullException(nameof(entropy));
            }

            // https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki#generating-the-mnemonic
            int ENT = entropy.Length;
            int CS = ENT / 32;
            int MS = (ENT + CS) / 11;

            var bytes = encoding.GetBytes(entropy);
            var bitArray = new BitArray(bytes);
            var words = new List<string>();
            for (int i = 0; i < bitArray.Count; i += 7)
            {
                int index = GetInt(bitArray[i], bitArray[i + 1], bitArray[i + 2], bitArray[i + 3], bitArray[i + 4], bitArray[i + 5], bitArray[i + 6]);
                words.Add(wordList[index]);
            }
            var mnemonicPhrase = string.Join(" ", words);

            if (mnemonicPhrase.Length != MS)
            {
                throw new Exception("Invalid result");
            }

            var seed = "";
            // TODO https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki#from-mnemonic-to-seed

            return new SeedPhraseResult(mnemonicPhrase, seed);
        }

        private static int GetInt(params bool[] bits)
        {
            if (bits.Length != 7)
            {
                throw new ArgumentException("Array does not contain 7 bites.", nameof(bits));
            }

            int GetInt(bool value) => value ? 1 : 0;

            return GetInt(bits[0]) << 6 +
                   GetInt(bits[1]) << 5 +
                   GetInt(bits[2]) << 4 +
                   GetInt(bits[3]) << 3 +
                   GetInt(bits[4]) << 2 +
                   GetInt(bits[5]) << 1 +
                   GetInt(bits[6]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mnemonicPhrase">Mnemonic phrase</param>
        /// <exception cref="NotImplementedException">Not implemented</exception>
        /// <returns>SeedEntropyResult</returns>
        public SeedEntropyResult GenerateSeedAndEntropy(string mnemonicPhrase)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string mnemonicPhrase, string seed)
        {
            return GenerateSeedAndEntropy(mnemonicPhrase).Seed == seed;
        }
    }
}
