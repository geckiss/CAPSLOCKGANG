namespace CAPSLOCKGANG
{
    public struct SeedPhraseResult
    {
        public string MnemonicPhrase { get; }
        public string Seed { get; }

        internal SeedPhraseResult(string mnemonicPhrase, string seed)
        {
            MnemonicPhrase = mnemonicPhrase;
            Seed = seed;
        }
    }
}
