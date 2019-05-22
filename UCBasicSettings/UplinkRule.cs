using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UCBasicSettings
{
    public class UplinkRule : ValidationRule
    {
        public int Downlink { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal Uplink = (decimal)value;

            if(Uplink != UserControlBasicSettings.DownlinkToUplinkConveter(Downlink)) return new ValidationResult(false, "Не соответствует Downlink");
            return new ValidationResult(true, "");
        }

    }
}
