using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UCAdditionalSettingsUMTS;
using UCBasicSettingsUMTS;

namespace UCMainSettingsUMTS
{
    /// <summary>
    /// Interaction logic for UserControlMainSettingsUMTS.xaml
    /// </summary>
    public partial class UserControlMainSettingsUMTS : UserControl
    {
        public UserControlMainSettingsUMTS()
        {
            InitializeComponent();
            ComboBox_SwitchLocalization.DataContext = new VMUCMainForBasicandAdditionalSettings();

            SetUserControlsInfo();           
        }

        private void SetUserControlsInfo()
        {
            #region Set UserControlSettingsRAN
            CurrentOptionsUMTSInfo.CurrentBasicSettingsInfo = new BasicSettingsUMTSInfo()
            {
                #region Оператор
                MCC = 255,
                MNC = 55,
                #endregion

                #region Идентификаторы
                IsAutoSelectionLAC = true,
                LAC = 5559,
                IsAutoSelectionCID = true,
                CID = 6669,
                #endregion

                #region Передатчик
                Mode = TypeMode.Standard,
                Attenuation = 100,
                MSPower = 25,
                IsAutoRegulateMSPower = true,
                #endregion

                #region Корректировка
                StartSearchArea = 156,
                DistanceСorrection = 178,
                #endregion
                UseGPRS = true,

                #region Частотные каналы
                DirectChannel = 0,
                ReverseChannel = 0,
                PSC = 0,
                CollectionItemChannelNumberAndPSC = new ObservableCollection<ItemChannelNumberAndPSC>()
                {
                    new ItemChannelNumberAndPSC() { DirectChannelNumber = 900, PSC = 144},
                    new ItemChannelNumberAndPSC() { DirectChannelNumber = 885, PSC = 144}
                }
                #endregion
            };
            this.ListLegitimateOperators = new List<LegitimateOperator>()
            {
                new LegitimateOperator() { MCC = 259, MNC = 01, Сountry = "Moldova", MobileOperator="Orange" },
                new LegitimateOperator() { MCC = 259, MNC = 02, Сountry = "Moldova", MobileOperator="Moldcell" },
            };
            #endregion

            #region Set UserControlAdditionalSettings
            CurrentOptionsUMTSInfo.CurrentAdditionalSettingsInfo = new AdditionalSettingsUMTSInfo()
            {
                #region ПАМ
                #endregion

                #region Радиоканалы
                IsEnabledRadioChannels = true,
                ListRadioChannels = new List<RadioChannel>()
                {
                    new RadioChannel()
                    {
                        ChannelNumber = 0, ListUseCasesChannel = new List<UseCasesChannel>()
                                                                 {
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.Registrations },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.OutgoingCalls },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.IncomingCalls }
                                                                  }
                    },
                    new RadioChannel()
                    {
                        ChannelNumber = 1, ListUseCasesChannel = new List<UseCasesChannel>()
                                                                 {
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.Registrations },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.OutgoingCalls },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.IncomingCalls }
                                                                  }
                    },
                    new RadioChannel()
                    {
                        ChannelNumber = 2, ListUseCasesChannel = new List<UseCasesChannel>()
                                                                 {
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.Registrations },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.OutgoingCalls },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.IncomingCalls }
                                                                  }
                    },
                    new RadioChannel()
                    {
                        ChannelNumber = 3, ListUseCasesChannel = new List<UseCasesChannel>()
                                                                 {
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.Registrations },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.OutgoingCalls },
                                                                    new UseCasesChannel() { IsUse = true, TypeUseCase = TypeUseCase.IncomingCalls }
                                                                  }
                    },

                }
                #endregion
            };
            #endregion
        }

        #region DependencyPropertys
        public OptionsUMTSInfo CurrentOptionsUMTSInfo
        {
            get { return (OptionsUMTSInfo)GetValue(CurrentOptionsUMTSInfoProperty); }
            set { SetValue(CurrentOptionsUMTSInfoProperty, value); }
        }
        public static readonly DependencyProperty CurrentOptionsUMTSInfoProperty =
            DependencyProperty.Register("CurrentOptionsUMTSInfo", typeof(OptionsUMTSInfo), typeof(UserControlMainSettingsUMTS), new UIPropertyMetadata(new OptionsUMTSInfo()));

        public List<LegitimateOperator> ListLegitimateOperators
        {
            get { return (List<LegitimateOperator>)GetValue(ListLegitimateOperatorsProperty); }
            set { SetValue(ListLegitimateOperatorsProperty, value); }
        }
        public static readonly DependencyProperty ListLegitimateOperatorsProperty =
            DependencyProperty.Register("ListLegitimateOperators", typeof(List<LegitimateOperator>), typeof(UserControlMainSettingsUMTS), new UIPropertyMetadata(new List<LegitimateOperator>()));
        #endregion   
    }
}
