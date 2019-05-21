
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

        private void Button_Click_UpdateSourceDownlink(object sender, RoutedEventArgs e)
        {
            BindingExpression bex = SpinEdit_DirectChannel.GetBindingExpression(SpinEdit.TextProperty);
            
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

    public class GetFirstSetSecondConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            int valueDownlink = Int32.Parse((string)value);
            int result, diff;
            if (((valueDownlink >= 10562) && (valueDownlink <= 10838)))
            {
                diff = valueDownlink - 10562;
                result = 9612 + diff;
            }
            else if (((valueDownlink >= 9662) && (valueDownlink <= 9938)))
            {
                diff = valueDownlink - 9662;
                result = 9262 + diff;
            }
            else if (((valueDownlink >= 1162) && (valueDownlink <= 1513)))
            {
                diff = valueDownlink - 1162;
                result = 937 + diff;
            }
            else if (((valueDownlink >= 1537) && (valueDownlink <= 1738)))
            {
                diff = valueDownlink - 1537;
                result = 1312 + diff;
            }
            else if (((valueDownlink >= 4357) && (valueDownlink <= 4458)))
            {
                diff = valueDownlink - 4357;
                result = 4132 + diff;
            }
            else if (((valueDownlink >= 4387) && (valueDownlink <= 4413)))
            {
                diff = valueDownlink - 4387;
                result = 4162 + diff;
            }
            else if (((valueDownlink >= 2237) && (valueDownlink <= 2563)))
            {
                diff = valueDownlink - 2237;
                result = 2012 + diff;
            }
            else if (((valueDownlink >= 2937) && (valueDownlink <= 3088)))
            {
                diff = valueDownlink - 2937;
                result = 2712 + diff;
            }
            else if (((valueDownlink >= 9237) && (valueDownlink <= 9387)))
            {
                diff = valueDownlink - 9237;
                result = 8762 + diff;
            }
            else if (((valueDownlink >= 3112) && (valueDownlink <= 3388)))
            {
                diff = valueDownlink - 3112;
                result = 2887 + diff;
            }
            else if (((valueDownlink >= 3712) && (valueDownlink <= 3787)))
            {
                diff = valueDownlink - 3712;
                result = 3487 + diff;
            }
            else if (((valueDownlink >= 3842) && (valueDownlink <= 3903)))
            {
                diff = valueDownlink - 3842;
                result = 3617 + diff;
            }
            else if (((valueDownlink >= 4017) && (valueDownlink <= 4043)))
            {
                diff = valueDownlink - 4017;
                result = 3792 + diff;
            }
            else if (((valueDownlink >= 4117) && (valueDownlink <= 4143)))
            {
                diff = valueDownlink - 4117;
                result = 3892 + diff;
            }
            else if (((valueDownlink >= 712) && (valueDownlink <= 763)))
            {
                diff = valueDownlink - 712;
                result = 312 + diff;
            }
            else if (((valueDownlink >= 4512) && (valueDownlink <= 4638)))
            {
                diff = valueDownlink - 4512;
                result = 4287 + diff;
            }
            else if (((valueDownlink >= 862) && (valueDownlink <= 912)))
            {
                diff = valueDownlink - 862;
                result = 462 + diff;
            }
            else if (((valueDownlink >= 4662) && (valueDownlink <= 5038)))
            {
                diff = valueDownlink - 4662;
                result = 4437 + diff;
            }
            else if (((valueDownlink >= 5112) && (valueDownlink <= 5413)))
            {
                diff = valueDownlink - 5112;
                result = 4887 + diff;
            }
            else if (((valueDownlink >= 5762) && (valueDownlink <= 5913)))
            {
                diff = valueDownlink - 5762;
                result = 5537 + diff;
            }
            else
            {
                diff = 0;
                result = 0;
            }

            return new object[2] { valueDownlink, result };
        }
    }
}
