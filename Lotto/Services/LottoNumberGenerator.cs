using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotto.Services
{
    public class LottoNumberGenerator
    {
        Random rnd = new Random();


        public List<int> NumbersGenerator(int QtyNumbersToGenerate, int minValue = 1, int MaxValue = 40)
        {
            List<int> numbers = new List<int>();
            int ranNumber;

            for (int i = 0; i < QtyNumbersToGenerate; i++)
            {
                ranNumber = RandomNumber(minValue, MaxValue);

                while (numbers.Any(n=> n == ranNumber))
                {
                    ranNumber = RandomNumber(minValue, MaxValue);
                }

                numbers.Add(ranNumber);
            }


            return numbers;
        }
       


        private int RandomNumber(int minValue = 1, int MaxValue = 40)
        {
            return rnd.Next(minValue, MaxValue + 1);
        }




    }
}
