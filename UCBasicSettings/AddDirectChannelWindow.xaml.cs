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
using System.Windows.Shapes;

namespace UCBasicSettings
{
    /// <summary>
    /// Interaction logic for AddDirectChannelWindow.xaml
    /// </summary>
    public partial class AddDirectChannelWindow : Window
    {
        public AddDirectChannelWindow(ItemChannelNumberAndPSC itemChannelNumberAndPSC)
        {
            InitializeComponent();
            ItemChannelNumberAndPSC = itemChannelNumberAndPSC;
            this.DataContext = ItemChannelNumberAndPSC;
        }
        public ItemChannelNumberAndPSC ItemChannelNumberAndPSC { get; private set; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
