using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UCBasicSettings
{
   public class FrequencyRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo ci)
        {
            decimal frequencyChannel = (decimal)value;

            if ( (1 <= frequencyChannel && frequencyChannel <= 124) ||
                 (128 <= frequencyChannel && frequencyChannel <= 251) ||
                 (512 <= frequencyChannel && frequencyChannel <= 885) ||
                 (955 <= frequencyChannel && frequencyChannel <= 1023) ) return new ValidationResult(true, "");

                return new ValidationResult(false,
                  "Не верно задан частотный канал. Автоподбор частотного канала отключен.\n"+
                  "Диапазон: P-GSM-900 (1-124), GSM-850 (128-251),\n" +
                  "DCS-1800 (512-885), R-GSM-900 (955-1023)");           
        }
    }
}
