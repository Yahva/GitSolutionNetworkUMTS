using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UCAdditionalSettingsUMTS
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlAdditionalSettingsUMTS : UserControl
    {
        public IEnumerable<DFVersion> ListDFVersion { get; set; }
        public UserControlAdditionalSettingsUMTS()
        {
            InitializeComponent();
            ListDFVersion = Enum.GetValues(typeof(DFVersion)).Cast<DFVersion>();
            this.DataContext = this;
        }

        #region DependencyPropertys
        public AdditionalSettingsUMTSInfo CurrentAdditionalSettingsUMTSInfo
        {
            get { return (AdditionalSettingsUMTSInfo)GetValue(CurrentAdditionalSettingsUMTSInfoProperty); }
            set { SetValue(CurrentAdditionalSettingsUMTSInfoProperty, value); }
        }
        public static readonly DependencyProperty CurrentAdditionalSettingsUMTSInfoProperty =
            DependencyProperty.Register("CurrentAdditionalSettingsUMTSInfo", typeof(AdditionalSettingsUMTSInfo), typeof(UserControlAdditionalSettingsUMTS), new UIPropertyMetadata(new AdditionalSettingsUMTSInfo()));

#endregion
    }
}
