using System;

namespace Utils
{
    public static class ValueConverter
    {
        private const int Thousand = 1000;
        private const int Million = 1000000;
        private const int Billion = 1000000000;
        private const long Trillion = 1000000000000L;
        private const char ThousandSymbol = 'K';
        private const char MillionSymbol = 'M';
        private const char BillionSymbol = 'B';
        private const char TrillionSymbol = 'T';
        
        public static string ConvertValueToString(long cost)
        {
            double roundedCost;

            switch (cost)
            {
                case > Trillion:
                    roundedCost = Round(Trillion);
                    return $"{roundedCost}{TrillionSymbol}";
                case > Billion:
                    roundedCost = Round(Billion);
                    return $"{roundedCost}{BillionSymbol}";
                case > Million:
                    roundedCost = Round(Million);
                    return $"{roundedCost}{MillionSymbol}";
                case > Thousand:
                    roundedCost = Round(Thousand);
                    return $"{roundedCost}{ThousandSymbol}";
                default:
                    return cost.ToString();
            }
            
            double Round(long denominator) => Math.Round((double)cost / denominator, 1, MidpointRounding.AwayFromZero);
        }
    }
}