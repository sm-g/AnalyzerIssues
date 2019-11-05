namespace AnalyzerIssues
{
    using System;

    internal class S1854
    {
        public int FalsePositive()
        {
            var name = string.Empty;
            try
            {
                var values = GetValues();
#pragma warning disable S1854 // Dead stores should be removed
                name = values.name;
#pragma warning restore S1854 // Dead stores should be removed

                DoWork();
                return 5;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{name}: {e}");
                throw;
            }
        }

        public void ThisIsOk()
        {
            var name = string.Empty;
            try
            {
                var values = GetValues();
                name = values.name;

                DoWork();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{name}: {e}");
                throw;
            }
        }

        private (string name, int count) GetValues()
        {
            return ("foo", 1);
        }

        private void DoWork()
        {
            throw new InvalidOperationException("bang");
        }
    }
}