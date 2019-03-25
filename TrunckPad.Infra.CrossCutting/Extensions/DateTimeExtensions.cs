using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TrunckPad.Infra.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Formatado(this DateTime strIn, string masc)
        {
            var retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            return retorno;
        }

        public static string Formatado(this DateTime? strIn, string masc)
        {
            string retorno = "";
            if (strIn != null)
            {
                return retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            }
            return retorno;
        }
    }
}
