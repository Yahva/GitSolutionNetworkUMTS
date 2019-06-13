using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UCBasicSettings
{
    public class BasicSettingsInfo : INotifyPropertyChanged, ICloneable
    {
        #region Оператор
        private uint _mcc;
        private uint _mnc;

        public uint MCC { get { return _mcc; } set { _mcc = value; OnPropertyChanged(); } }
        public uint MNC { get { return _mnc; } set { _mnc = value; OnPropertyChanged(); } }
        #endregion

        #region Идентификаторы
        private int _lac;
        private bool _isAutoSelectionLAC;
        private int _cid;
        private bool _isAutoSelectionCID;

        public int LAC { get { return _lac; } set { _lac = value; OnPropertyChanged(); } }
        public bool IsAutoSelectionLAC { get { return _isAutoSelectionLAC; } set { _isAutoSelectionLAC = value; OnPropertyChanged(); } }
        public int CID { get { return _cid; } set { _cid = value; OnPropertyChanged(); } }
        public bool IsAutoSelectionCID { get { return _isAutoSelectionCID; } set { _isAutoSelectionCID = value; OnPropertyChanged(); } }
        #endregion

        #region Передатчик
        private TypeMode _mode;
        private byte _attenuation;
        private int _msPower;
        private bool _isAutoRegulateMSPower;

        public TypeMode Mode { get { return _mode; } set { _mode = value; OnPropertyChanged(); } }
        public byte Attenuation { get { return _attenuation; } set { _attenuation = value; OnPropertyChanged(); } }
        public int MSPower { get { return _msPower; } set { _msPower = value; OnPropertyChanged(); } }
        public bool IsAutoRegulateMSPower { get { return _isAutoRegulateMSPower; } set { _isAutoRegulateMSPower = value; OnPropertyChanged(); } }
        #endregion

        #region Корректировка
        private int _startSearchArea;
        private int _distanceСorrection;
        

        public int StartSearchArea { get { return _startSearchArea; } set { _startSearchArea = value; OnPropertyChanged(); } }
        public int DistanceСorrection { get { return _distanceСorrection; } set { _distanceСorrection = value; OnPropertyChanged(); } }
        #endregion

        private bool _useGPRS;
        public bool UseGPRS { get { return _useGPRS; } set { _useGPRS = value; OnPropertyChanged(); } }

        #region Частотные каналы
        private bool _isEnabledFrequencyChangeModel;
        private bool _isEnabledFrequencyChannelAutoselect;
        private int _directChannel;
        private int _reverseChannel;
        private int _psc;
        private DateTime _operatingTimeFrequency;
        public ObservableCollection<ItemChannelNumberAndPSC> _collectionItemChannelNumberAndPSC;

        public bool IsEnabledFrequencyChangeModel { get { return _isEnabledFrequencyChangeModel; } set { _isEnabledFrequencyChangeModel = value; OnPropertyChanged(); } }
        public bool IsEnabledFrequencyChannelAutoselect { get { return _isEnabledFrequencyChannelAutoselect; } set { _isEnabledFrequencyChannelAutoselect = value; OnPropertyChanged(); } }      
        public int DirectChannel { get { return _directChannel; } set { _directChannel = value; OnPropertyChanged(); } }
        public int ReverseChannel { get { return _reverseChannel; } set { _reverseChannel = value; OnPropertyChanged(); } }
        public int PSC { get { return _psc; } set { _psc = value; OnPropertyChanged(); } }

        public DateTime OperatingTimeFrequency { get { return _operatingTimeFrequency; } set { _operatingTimeFrequency = value; OnPropertyChanged(); } }
        public ObservableCollection<ItemChannelNumberAndPSC> CollectionItemChannelNumberAndPSC { get { return _collectionItemChannelNumberAndPSC; } set { _collectionItemChannelNumberAndPSC = value; OnPropertyChanged(); } }
        #endregion

        #region Перенаправление на GSM
        private bool _isEnabledFrequencyChannelRedirection;
        private TypeRedirection _redirection;
        private int _frequensyChannel;
        private bool _isSetSpecifyFrequencyChannel;

        public bool IsEnabledFrequencyChannelRedirection { get { return _isEnabledFrequencyChannelRedirection; } set { _isEnabledFrequencyChannelRedirection = value; OnPropertyChanged(); } }
        public TypeRedirection Redirection { get { return _redirection; } set { _redirection = value; OnPropertyChanged(); } }
        public int FrequensyChannel { get { return _frequensyChannel; } set { _frequensyChannel = value; OnPropertyChanged(); } }
        public bool IsSetSpecifyFrequencyChannel { get { return _isSetSpecifyFrequencyChannel; } set { _isSetSpecifyFrequencyChannel = value; OnPropertyChanged(); } }
        #endregion

        public object Clone()
        {
            BasicSettingsInfo CloneBasicSettingsInfo = this.MemberwiseClone() as BasicSettingsInfo;

            CloneBasicSettingsInfo.CollectionItemChannelNumberAndPSC = new ObservableCollection<ItemChannelNumberAndPSC>();
            this.CollectionItemChannelNumberAndPSC?.ForEach((item) => CloneBasicSettingsInfo.CollectionItemChannelNumberAndPSC.Add(item.Clone() as ItemChannelNumberAndPSC));

            return CloneBasicSettingsInfo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       
    }

    public class ItemChannelNumberAndPSC : INotifyPropertyChanged, ICloneable
    {
        public int _directChannelNumber;
        private int _psc;

        public int DirectChannelNumber { get { return _directChannelNumber; } set { _directChannelNumber = value; OnPropertyChanged(); } }
        public int PSC { get { return _psc; } set { _psc = value; OnPropertyChanged(); } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public enum TypeMode
    {
        Standard,
        Suppression
    }

    public enum TypeRedirection
    {
        TurnedOff,
        WithoutObtainingIDs,
        OnReceiptIdentifiers_always,
        OnReceeiptIdentifiers_availability
    }
}
