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

namespace SliderWeakening
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControlSlider : UserControl
    {
        public UserControlSlider()
        {
            InitializeComponent();
            this.Loaded += (o, e) => { ChangeSizeSlider(); };
            this.SizeChanged += (o,e) => { ChangeSizeSlider();};
        }


        //Property
        public readonly static DependencyProperty MaximumProperty;
        public readonly static DependencyProperty MinimumProperty;
        public readonly static DependencyProperty ValueProperty;
        public readonly static DependencyProperty ValueBackProperty;

        public readonly static DependencyProperty PointAngleLeftBottomProperty;
        public readonly static DependencyProperty PointAngleRightTopProperty;
        public readonly static DependencyProperty PointAngleRightBottomProperty;

        static UserControlSlider()
        {
            // Регистрация свойств зависимости       
            MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(UserControlSlider), new UIPropertyMetadata(100));
            MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(UserControlSlider), new UIPropertyMetadata(0));
            ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(UserControlSlider), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnSetDelValueChanged)));
            ValueBackProperty = DependencyProperty.Register("ValueBack", typeof(int), typeof(UserControlSlider), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnSetDelValueBackChanged)));

            PointAngleLeftBottomProperty = DependencyProperty.Register("PointAngleLeftBottom", typeof(Point), typeof(UserControlSlider), new FrameworkPropertyMetadata(new Point(0, 22)));
            PointAngleRightTopProperty = DependencyProperty.Register("PointAngleRightTop", typeof(Point), typeof(UserControlSlider), new FrameworkPropertyMetadata(new Point(200,0)));
            PointAngleRightBottomProperty = DependencyProperty.Register("PointAngleRightBottom", typeof(Point), typeof(UserControlSlider), new FrameworkPropertyMetadata(new Point(200,22)));
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetCurrentValue(ValueProperty, value);}
        }
        private static void OnSetDelValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserControlSlider userControlGrid = (UserControlSlider)sender;
            userControlGrid.ValueBack = userControlGrid.Maximum - userControlGrid.Value;
        }

        public int ValueBack
        {
            get { return (int)GetValue(ValueBackProperty); }
            set { SetCurrentValue(ValueBackProperty, value); }
        }
        private static void OnSetDelValueBackChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserControlSlider userControlGrid = (UserControlSlider)sender;
            userControlGrid.Value = userControlGrid.Maximum - userControlGrid.ValueBack;
        }

        public Point PointAngleLeftBottom
        {
            get { return (Point)GetValue(PointAngleLeftBottomProperty); }
            set { SetCurrentValue(PointAngleLeftBottomProperty, value); }
        }

        public Point PointAngleRightTop
        {
            get { return (Point)GetValue(PointAngleRightTopProperty); }
            set { SetCurrentValue(PointAngleRightTopProperty, value); }
        }

        public Point PointAngleRightBottom
        {
            get { return (Point)GetValue(PointAngleRightBottomProperty); }
            set { SetCurrentValue(PointAngleRightBottomProperty, value); }
        }

        void ChangeSizeSlider()
        {
            PointAngleRightTop = new Point(ActualWidth,0);
            PointAngleRightBottom = new Point(ActualWidth, 22);
        }

    }
}
