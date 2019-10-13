namespace CAPSLOCKGANG
{
    public struct SeedEntropyResult
    {
        public string Seed { get; }
        public string Entropy { get; }

        internal SeedEntropyResult(string seed, string entropy)
        {
            Seed = seed;
            Entropy = entropy;
        }
    }
}
