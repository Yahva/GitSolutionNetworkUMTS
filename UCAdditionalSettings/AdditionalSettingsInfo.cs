using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UCAdditionalSettings
{
    public class AdditionalSettingsInfo : INotifyPropertyChanged, ICloneable
    {
        #region ПАМ
        private DFVersion _dfVersion;
        private int _channelDirectionFinding;
        public DFVersion DFVersion { get { return _dfVersion; } set { _dfVersion = value; OnPropertyChanged(); } }
        public int ChannelDirectionFinding { get { return _channelDirectionFinding; } set { _channelDirectionFinding = value; OnPropertyChanged(); } }
        #endregion

        #region Радио каналы
        private bool _isEnabledRadioChannels;
        private IList<RadioChannel> _listRadioChannels;

        public bool IsEnabledRadioChannels { get { return _isEnabledRadioChannels; } set { _isEnabledRadioChannels = value; OnPropertyChanged(); } }
        public IList<RadioChannel> ListRadioChannels { get { return _listRadioChannels; } set { _listRadioChannels = value; OnPropertyChanged(); } }
        #endregion

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
    }

    public class RadioChannel:INotifyPropertyChanged
    {
        private int _channelNumber;
        public IList<UseCasesChannel> _listUseCasesChannel;

        public int ChannelNumber { get { return _channelNumber; } set { _channelNumber = value; OnPropertyChanged(); } }
        public IList<UseCasesChannel> ListUseCasesChannel { get { return _listUseCasesChannel; }set { _listUseCasesChannel = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class UseCasesChannel : INotifyPropertyChanged
    {
        private TypeUseCase _typeUseCase;
        private bool _isUse;

        public bool IsUse { get { return _isUse; } set { _isUse = value; OnPropertyChanged(); } }
        public TypeUseCase TypeUseCase { get { return _typeUseCase; } set { _typeUseCase = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public enum DFVersion
    {
        NotUsed,
        Version1,
        Version2
    }

    public enum TypeUseCase
    {
        Registrations,
        OutgoingCalls,
        IncomingCalls
    }
}
