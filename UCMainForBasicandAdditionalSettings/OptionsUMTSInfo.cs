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
        public OptionsUMTSInfo()
        {
            CurrentBasicSettingsUMTSInfo = new BasicSettingsUMTSInfo();
            CurrentAdditionalSettingsUMTSInfo = new AdditionalSettingsUMTSInfo();
        }

        BasicSettingsUMTSInfo _currentBasicSettingsUMTSInfo;
        AdditionalSettingsUMTSInfo _currentAdditionalSettingsUMTSInfo;

        public BasicSettingsUMTSInfo CurrentBasicSettingsUMTSInfo { get { return _currentBasicSettingsUMTSInfo; } set { _currentBasicSettingsUMTSInfo = value; OnPropertyChanged(); } }
        public AdditionalSettingsUMTSInfo CurrentAdditionalSettingsUMTSInfo { get { return _currentAdditionalSettingsUMTSInfo; } set { _currentAdditionalSettingsUMTSInfo = value; OnPropertyChanged(); } }

        public object Clone()
        {
            return new OptionsUMTSInfo()
            {
                CurrentBasicSettingsUMTSInfo = this.CurrentBasicSettingsUMTSInfo.Clone() as BasicSettingsUMTSInfo,
                CurrentAdditionalSettingsUMTSInfo = this.CurrentAdditionalSettingsUMTSInfo.Clone() as AdditionalSettingsUMTSInfo
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       
    }
}
