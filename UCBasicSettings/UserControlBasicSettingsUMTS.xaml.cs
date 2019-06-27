
using CommonClassLibraryForSolutionNetwork;
using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UCBasicSettingsUMTS
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlBasicSettingsUMTS : UserControl
    {
        public IEnumerable<TypeMode> ListMode { get; set; }
        public IEnumerable<TypeRedirection> ListRedirection { get; set; }
        public UserControlBasicSettingsUMTS()
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

        private void ClearInvalidSpinEdit_ReverseChannel(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindingExpression bex = (sender as SpinEdit).GetBindingExpression(SpinEdit.ValueProperty);
            if (bex != null)
                if ((bool)e.NewValue)
                {
                    (sender as SpinEdit).Text = "0";
                    bex.UpdateTarget();
                    bex.UpdateSource();
                }
                else if ((bool)e.OldValue)
                {
                    (sender as SpinEdit).Text = null;
                    Validation.ClearInvalid(bex);
                }
        }     
        
        private void ClearInvalidValue(bool NewValue, bool OldValue, BindingExpression bex)
        {
            if (bex != null)
                if (NewValue)  bex.UpdateSource();
                else if (OldValue) Validation.ClearInvalid(bex);
        }
        #endregion

        #region DependencyPropertys
        public BasicSettingsUMTSInfo CurrentBasicSettingsUMTSInfo
        {
            get { return (BasicSettingsUMTSInfo)GetValue(CurrentBasicSettingsUMTSInfoProperty); }
            set { SetValue(CurrentBasicSettingsUMTSInfoProperty, value); }
        }
        public static readonly DependencyProperty CurrentBasicSettingsUMTSInfoProperty =
            DependencyProperty.Register("CurrentBasicSettingsUMTSInfo", typeof(BasicSettingsUMTSInfo), typeof(UserControlBasicSettingsUMTS), new UIPropertyMetadata(new BasicSettingsUMTSInfo()));

        public IEnumerable<LegitimateOperator> ListLegitimateOperators
        {
            get { return (IEnumerable<LegitimateOperator>)GetValue(ListLegitimateOperatorsProperty); }
            set { SetValue(ListLegitimateOperatorsProperty, value); }
        }
        public static readonly DependencyProperty ListLegitimateOperatorsProperty =
            DependencyProperty.Register("ListLegitimateOperators", typeof(IEnumerable<LegitimateOperator>), typeof(UserControlBasicSettingsUMTS), new UIPropertyMetadata(new List<LegitimateOperator>()));


        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(UserControlBasicSettingsUMTS), new UIPropertyMetadata(false));
        #endregion

        #region Validation
        private bool IsValid(DependencyObject obj)
        {
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }
        private void UserControl_HasError(object sender, ValidationErrorEventArgs e)
        {
            HasError = !IsValid(this);
        }
        #endregion

        private void Button_Click_UpdateSourceDownlink(object sender, RoutedEventArgs e)
        {
            MultiBindingExpression mbex = BindingOperations.GetMultiBindingExpression(SpinEdit_DirectChannel, SpinEdit.TextProperty);
            if (mbex != null)
                mbex.UpdateSource();
        }

        public static int DownlinkToUplinkConveter(int valueDownlink)
        {
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

            return result;
        }
        public static string GetCommonNmaeByDownlink(int valueDownlink)
        {
            string result = "UMTS Operating Band";
            if (((valueDownlink >= 10562) && (valueDownlink <= 10838)))
            {
                result += " I"+" (IMT)";
            }
            else if (((valueDownlink >= 9662) && (valueDownlink <= 9938)))
            {
                result += " II" + " (U.S. PCS)";
            }
            else if (((valueDownlink >= 1162) && (valueDownlink <= 1513)))
            {
                result += " III" + " (DCS)";
            }
            else if (((valueDownlink >= 1537) && (valueDownlink <= 1738)))
            {
                result += " IV" + " (AWS)";
            }
            else if (((valueDownlink >= 4357) && (valueDownlink <= 4458)))
            {
                result += " V" + " (CLR)";
            }
            else if (((valueDownlink >= 4387) && (valueDownlink <= 4413)))
            {
                result += " V" + " (CLR)";
            }
            else if (((valueDownlink >= 2237) && (valueDownlink <= 2563)))
            {
                result += " VII" + " (IMT-E)";
            }
            else if (((valueDownlink >= 2937) && (valueDownlink <= 3088)))
            {
                result += " VIII" + " (GSM)";
            }
            else if (((valueDownlink >= 9237) && (valueDownlink <= 9387)))
            {
                result += " IX";
            }
            else if (((valueDownlink >= 3112) && (valueDownlink <= 3388)))
            {
                result += " X";
            }
            else if (((valueDownlink >= 3712) && (valueDownlink <= 3787)))
            {
                result += " XI";
            }
            else if (((valueDownlink >= 3842) && (valueDownlink <= 3903)))
            {
                result += " XII" + " (SMH)";
            }
            else if (((valueDownlink >= 4017) && (valueDownlink <= 4043)))
            {
                result += " XIII" + " (SMH)";
            }
            else if (((valueDownlink >= 4117) && (valueDownlink <= 4143)))
            {
                result += " XIV" + " (SMH)";
            }
            else if (((valueDownlink >= 712) && (valueDownlink <= 763)))
            {
                result += " XIX";
            }
            else if (((valueDownlink >= 4512) && (valueDownlink <= 4638)))
            {
                result += " XX";
            }
            else if (((valueDownlink >= 862) && (valueDownlink <= 912)))
            {
                result += " XXI";
            }
            else if (((valueDownlink >= 4662) && (valueDownlink <= 5038)))
            {
                result += " XXI";
            }
            else if (((valueDownlink >= 5112) && (valueDownlink <= 5413)))
            {
                result += " XXV";
            }
            else if (((valueDownlink >= 5762) && (valueDownlink <= 5913)))
            {
                result += " XXVI" + " (ECLR)";
            }
            else
            {
                result = "Unknown";
            }

            return result;
        }
       
        private void Add_ItemChannelNumberAndPSC(object sender, RoutedEventArgs e)
        {
            AddDirectChannelWindow addDirectChannelWindow = new AddDirectChannelWindow(new ItemChannelNumberAndPSC());
            if (addDirectChannelWindow.ShowDialog() == true)
            {
                ItemChannelNumberAndPSC itemChannelNumberAndPSC = addDirectChannelWindow.ItemChannelNumberAndPSC;
                CurrentBasicSettingsUMTSInfo.CollectionItemChannelNumberAndPSC.Add(itemChannelNumberAndPSC);
            }
        }
        private void Delete_ItemChannelNumberAndPSC(object sender, RoutedEventArgs e)
        {
            if (GridControl_CollectionItemChannelNumberAndPSC.SelectedItem == null) return;
            ItemChannelNumberAndPSC item = GridControl_CollectionItemChannelNumberAndPSC.SelectedItem as ItemChannelNumberAndPSC;
            CurrentBasicSettingsUMTSInfo.CollectionItemChannelNumberAndPSC.Remove(item);
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

    public class DownlinkToCommonNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value != DependencyProperty.UnsetValue)
            {
                int valueDownlink = (int)value;
                return UserControlBasicSettingsUMTS.GetCommonNmaeByDownlink(valueDownlink);
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class DownlinkToUplinkConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            int valueDownlink = 0;
            Int32.TryParse((string)value, out valueDownlink);           
            return new object[2] { valueDownlink, UserControlBasicSettingsUMTS.DownlinkToUplinkConveter(valueDownlink) };
        }
    }

    public class CorrectWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value != DependencyProperty.UnsetValue)
            {
                double valueWidth = (double)value;
                return (valueWidth > 1) ? (valueWidth - 1) : valueWidth;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }  
}
