using LocalizationBasicAndAdditionalSettings.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UCBasicSettings;

namespace UCMainForBasicandAdditionalSettings
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UCMainForBasicandAdditionalSettings : UserControl
    {
        private readonly Dictionary<EnumUC, UserControl> _listUC;
        public UCMainForBasicandAdditionalSettings()
        {
            LocalizationManager.Instance.LocalizationProvider = new ResxLocalizationProvider();
            InitializeComponent();
            ComboBox_SwitchLocalization.DataContext = new VMUCMainForBasicandAdditionalSettings();

            _listUC = new Dictionary<EnumUC, UserControl>()
            {
                { EnumUC.UCAdditionalSettings, new UCAdditionalSettings.UCAdditionalSettings() },
                { EnumUC.UCBasicSettings, new UserControlBasicSettings() }
            };

            #region Set UserControlSettingsRAN
            ((UserControlBasicSettings)_listUC[EnumUC.UCBasicSettings]).CurrentBasicSettingsInfo = new BasicSettingsInfo()
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
                PSC = 0
                #endregion
            };
            ((UserControlBasicSettings)_listUC[EnumUC.UCBasicSettings]).ListLegitimateOperators = new List<LegitimateOperator>()
            {
                new LegitimateOperator() { MCC = 259, MNC = 01, Сountry = "Moldova", MobileOperator="Orange" },
                new LegitimateOperator() { MCC = 259, MNC = 02, Сountry = "Moldova", MobileOperator="Moldcell" },
            };
            #endregion

        }

        private enum EnumUC
        {
            UCAdditionalSettings,
            UCBasicSettings
        }

        private void Button_SetInPanelUCAdditionalSettingsCommand_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PanelOptions.Child = _listUC[EnumUC.UCAdditionalSettings];
        }

        private void Button_SetInPanelUCBasicSettings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PanelOptions.Child = _listUC[EnumUC.UCBasicSettings];
        }
    }
}
