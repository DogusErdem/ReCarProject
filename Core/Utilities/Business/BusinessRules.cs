using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params istediğimiz kadar IResult göndermemizi sağlar
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                    //iş kurallarından(logicsten) hatalı olanı döndürüyoruz
                }
            }
            return null;
        }
    }
}
