using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für ScrollProp.xaml
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
                if (value > MaxVal) 
                    actualValue = MaxVal;
                else if (value < MinVal) 
                    actualValue = MinVal;
                else 
                    actualValue = value;
            } 
        }


        public ScrollProp()
        {
            InitializeComponent();
        }

        private void ScrollBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Scroll.Value != ActualValue)
            {
                ActualValue = (int)Scroll.Value;
                TextVal.Text = ActualValue.ToString();
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (TextVal.Text != ActualValue.ToString())
            {
                int newVal;
                int.TryParse(TextVal.Text, out newVal);
                Scroll.Value = newVal;
                actualValue = newVal;
            }
        }
    }
}
