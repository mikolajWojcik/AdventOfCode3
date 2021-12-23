using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    public static class RatingHelper
    {
        public static int GetRating(int count, List<string> rating, bool countOnes)
        {
            for (int i = 0; i < count; i++)
            {
                var newRatingOnes = rating.Where(x => x[i] == '1').ToList();
                var newRatingZeros = rating.Where(x => x[i] == '0').ToList();

                if (countOnes)
                {
                    rating = newRatingOnes.Count >= newRatingZeros.Count ? newRatingOnes : newRatingZeros;
                }
                else
                {
                    rating = newRatingZeros.Count <= newRatingOnes.Count ? newRatingZeros : newRatingOnes;
                }

                if (rating.Count == 1)
                {
                    return Convert.ToInt32(rating.First(),2);
                }
            }

            return 0;
        }
    }
}