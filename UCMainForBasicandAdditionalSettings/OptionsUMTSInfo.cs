using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UCAdditionalSettings;
using UCBasicSettings;

namespace UCMainSettingsUMTS
{
    public class OptionsUMTSInfo : INotifyPropertyChanged, ICloneable
    {
        BasicSettingsInfo _currentBasicSettingsInfo;
        AdditionalSettingsInfo _currentAdditionalSettingsInfo;

        public BasicSettingsInfo CurrentBasicSettingsInfo { get { return _currentBasicSettingsInfo; } set { _currentBasicSettingsInfo = value; OnPropertyChanged(); } }
        public AdditionalSettingsInfo CurrentAdditionalSettingsInfo { get { return _currentAdditionalSettingsInfo; } set { _currentAdditionalSettingsInfo = value; OnPropertyChanged(); } }

        public object Clone()
        {
            return new OptionsUMTSInfo()
            {
                CurrentBasicSettingsInfo = this.CurrentBasicSettingsInfo.Clone() as BasicSettingsInfo,
                CurrentAdditionalSettingsInfo = this.CurrentAdditionalSettingsInfo.Clone() as AdditionalSettingsInfo
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       
    }
}
