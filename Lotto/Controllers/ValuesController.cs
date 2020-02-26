using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lotto.Services;
using Lotto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Lotto.Controllers
{
    
    public class ValuesController : Controller
    {
        // GET api/values

        [Route("api/NZLottoNumberGenerator")]
        [HttpGet]
        public List<LotoViewModel> NZGenerateLottoNumbers(int NumberLines, bool powerBall)
        {

            return NumGenerator(NumberLines, powerBall, 6);

        }



        [Route("api/NZStrikeNumberGenerator")]
        [HttpGet]
        public List<LotoViewModel> NZStrikeNumberGenerator(int NumberLines)
        {
            bool powerBall = false;

            return NumGenerator(NumberLines, powerBall, 4);

        }



        private List<LotoViewModel> NumGenerator(int numberLines, bool powerBall, int numbersDrawn)
        {
            LottoNumberGenerator Lng = new LottoNumberGenerator();
            List<LotoViewModel> results = new List<LotoViewModel>();
            int? pwball = null;

            for (int i = 0; i < numberLines; i++)
            {
                if (powerBall)
                    pwball = Lng.NumbersGenerator(1, 1, 10).Select(a => a).First();

                var lottoView = new LotoViewModel(Lng.NumbersGenerator(numbersDrawn), pwball);

                while (results.AsQueryable().Contains(lottoView))
                {
                    if (powerBall)
                        pwball = Lng.NumbersGenerator(1, 1, 10).Select(a => a).First();

                    lottoView = new LotoViewModel(Lng.NumbersGenerator(6), pwball);
                }

                results.Add(lottoView);
            }

            return results;
        }
    }
}
