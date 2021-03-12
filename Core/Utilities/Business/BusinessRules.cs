using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;  // HANGİ İŞ KURALINDA HATA ALIYORSAK ONU DÖNDÜRÜYORUZ
                }
            }
            return null;  //HİÇBİR İŞ KURALINDA HATA ALMIYORSAK NULL DÖNDÜRÜYORUZ
        }
    }
}
