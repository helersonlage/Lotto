using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotto.ViewModel
{
    public class LotoViewModel
    {
        public LotoViewModel(List<int> result, int? powerball)
        {
            Numbers = result.OrderBy(p => p).ToList();            
            PowerBall = powerball;
        }
        public List<int> Numbers = new List<int>(); 
        public int? PowerBall{ get; set; }
    }
}
