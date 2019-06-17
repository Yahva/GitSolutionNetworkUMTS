using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UCAdditionalSettingsUMTS;
using UCBasicSettingsUMTS;

namespace UCMainSettingsUMTS
{
    public class OptionsUMTSInfo : INotifyPropertyChanged, ICloneable
    {
        BasicSettingsUMTSInfo _currentBasicSettingsInfo;
        AdditionalSettingsUMTSInfo _currentAdditionalSettingsInfo;

        public BasicSettingsUMTSInfo CurrentBasicSettingsInfo { get { return _currentBasicSettingsInfo; } set { _currentBasicSettingsInfo = value; OnPropertyChanged(); } }
        public AdditionalSettingsUMTSInfo CurrentAdditionalSettingsInfo { get { return _currentAdditionalSettingsInfo; } set { _currentAdditionalSettingsInfo = value; OnPropertyChanged(); } }

        public object Clone()
        {
            return new OptionsUMTSInfo()
            {
                CurrentBasicSettingsInfo = this.CurrentBasicSettingsInfo.Clone() as BasicSettingsUMTSInfo,
                CurrentAdditionalSettingsInfo = this.CurrentAdditionalSettingsInfo.Clone() as AdditionalSettingsUMTSInfo
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       
    }
}
