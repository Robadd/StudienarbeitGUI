using System.Windows;
using System.Windows.Controls;

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für ScrollProp.xaml
    /// 
    /// Eigenschaften für ScrollProp:
    /// ActualValue, MaxVal, MinVal. Alle selbsterklärend
    /// </summary>
    public partial class ScrollProp : UserControl
    {
        private int maxVal;
        public int MaxVal
        {
            get { return maxVal; }
            set { maxVal = value; }
        }

        private int minVal;
        public int MinVal
        {
            get { return minVal; }
            set { minVal = value; }
        }

        private int actualValue;
        public int ActualValue
        {
            get
            {
                return actualValue;
            }
            set
            {
                if (actualValue != value)
                {
                    int newVal;
                    if (value > MaxVal) newVal = MaxVal;
                    else if (value < MinVal) newVal = MinVal;
                    else newVal = value;

                    actualValue = newVal;
                    TextVal.Text = newVal.ToString();
                    Scroll.Value = -(double)newVal;
                }
            }
        }

        public ScrollProp()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Scroll.Minimum = -(int)MaxVal;
            Scroll.Maximum = -(int)MinVal;
            //Scroll.Value = -ActualValue;
            //TextVal.Text = ActualValue.ToString();
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Scroll.Value != ActualValue)
            {
                ActualValue = -(int)Scroll.Value;
                //TextVal.Text = ((int)Math.Round(-Scroll.Value)).ToString();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextVal.Text != ActualValue.ToString())
            {
                int newVal;
                if (int.TryParse(TextVal.Text, out newVal))
                {
                    ActualValue = newVal;
                }
            }
        }
    }
}
