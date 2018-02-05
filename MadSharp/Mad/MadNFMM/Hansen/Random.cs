namespace Cum
{
    internal class Random
    {
        private System.Random _rand;

        public Random(long l)
        {
            _rand = new System.Random((int) l);
        }

        public double NextDouble()
        {
            return _rand.NextDouble();
        }
    }
}