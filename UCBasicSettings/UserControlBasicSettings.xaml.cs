
using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UCBasicSettings
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlBasicSettings : UserControl
    {
        public IEnumerable<TypeMode> ListMode { get; set; }
        public IEnumerable<TypeRedirection> ListRedirection { get; set; }
        public UserControlBasicSettings()
        {
            InitializeComponent();
            ListMode = Enum.GetValues(typeof(TypeMode)).Cast<TypeMode>();
            ListRedirection = Enum.GetValues(typeof(TypeRedirection)).Cast<TypeRedirection>();
            this.DataContext = this;
        }

        #region SetUnsetValidation
        private void ClearInvalidSpinEdit(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindingExpression bex = (sender as SpinEdit).GetBindingExpression(SpinEdit.ValueProperty);
            ClearInvalidValue((bool)e.NewValue, (bool)e.OldValue, bex);
        }
        private void ClearInvalidValue(bool NewValue, bool OldValue, BindingExpression bex)
        {
            if (bex != null)
                if (NewValue) bex.UpdateSource();
                else if (OldValue) Validation.ClearInvalid(bex);
        }
        #endregion

        #region DependencyPropertys
        public BasicSettingsInfo CurrentBasicSettingsInfo
        {
            get { return (BasicSettingsInfo)GetValue(CurrentBasicSettingsInfoProperty); }
            set { SetValue(CurrentBasicSettingsInfoProperty, value); }
        }
        public static readonly DependencyProperty CurrentBasicSettingsInfoProperty =
            DependencyProperty.Register("CurrentBasicSettingsInfo", typeof(BasicSettingsInfo), typeof(UserControlBasicSettings), new UIPropertyMetadata(new BasicSettingsInfo()));

        public IEnumerable<LegitimateOperator> ListLegitimateOperators
        {
            get { return (IEnumerable<LegitimateOperator>)GetValue(ListLegitimateOperatorsProperty); }
            set { SetValue(ListLegitimateOperatorsProperty, value); }
        }
        public static readonly DependencyProperty ListLegitimateOperatorsProperty =
            DependencyProperty.Register("ListLegitimateOperators", typeof(IEnumerable<LegitimateOperator>), typeof(UserControlBasicSettings), new UIPropertyMetadata(new List<LegitimateOperator>()));


        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(UserControlBasicSettings), new UIPropertyMetadata(false));
        #endregion

        private void ComboBox_Selected_LegitimateOperator(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            LegitimateOperator legitimateOperator = comboBox.SelectedItem as LegitimateOperator;

            if (legitimateOperator != null)
            {
                CurrentBasicSettingsInfo.MCC = legitimateOperator.MCC;
                CurrentBasicSettingsInfo.MNC = legitimateOperator.MNC;
            }
            else
            {
                CurrentBasicSettingsInfo.MCC = 0;
                CurrentBasicSettingsInfo.MNC = 0;
            }
        }
    }
    public class LegitimateOperator
    {
        public int MCC { get; set; }
        public int MNC { get; set; }

        public string Сountry { get; set; }
        public string MobileOperator { get; set; }

        public override string ToString()
        {
            return String.Format(Сountry + "-" + MobileOperator + " ({0:D3} {1:D2})", MCC, MNC);
        }
    }
    public class MSPowerIndBmConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value != DependencyProperty.UnsetValue)
            {
                int valueMSPover = (int)value;
                double result = (0.001 * Math.Pow(10, ((double)valueMSPover / 10)));
                result = Math.Round(result,4);
                return result;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
