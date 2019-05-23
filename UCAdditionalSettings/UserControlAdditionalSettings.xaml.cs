using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UCAdditionalSettings
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlAdditionalSettings : UserControl
    {
        public IEnumerable<DFVersion> ListDFVersion { get; set; }
        public UserControlAdditionalSettings()
        {
            InitializeComponent();
            ListDFVersion = Enum.GetValues(typeof(DFVersion)).Cast<DFVersion>();
            this.DataContext = this;
        }

        #region DependencyPropertys
        public AdditionalSettingsInfo CurrentAdditionalSettingsInfo
        {
            get { return (AdditionalSettingsInfo)GetValue(CurrentAdditionalSettingsInfoProperty); }
            set { SetValue(CurrentAdditionalSettingsInfoProperty, value); }
        }
        public static readonly DependencyProperty CurrentAdditionalSettingsInfoProperty =
            DependencyProperty.Register("CurrentAdditionalSettingsInfo", typeof(AdditionalSettingsInfo), typeof(UserControlAdditionalSettings), new UIPropertyMetadata(new AdditionalSettingsInfo()));

#endregion
    }
}
