using MainApp.ViewModel;
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

namespace MainApp.Components
{
    /// <summary>
    /// Логика взаимодействия для UpDownTextBox.xaml
    /// </summary>
    public partial class UpDownTextBox : UserControl
    {
        public uint MaxValue
        {
            get { return (uint)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
         DependencyProperty.Register("MaxValue", typeof(uint), typeof(UpDownTextBox), new PropertyMetadata((uint)999));
        public uint MinValue
        {
            get { return (uint)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
         DependencyProperty.Register("MinValue", typeof(uint), typeof(UpDownTextBox), new PropertyMetadata((uint)1));
        public uint Value
        {
            get { return (uint)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
         DependencyProperty.Register("Value", typeof(uint), typeof(UpDownTextBox), new PropertyMetadata((uint)1));
        
        public string MetaData
        {
            get { return (string)GetValue(MetaDataProperty); }
            set { SetValue(MetaDataProperty, value); }
        }

        public static readonly DependencyProperty MetaDataProperty =
         DependencyProperty.Register("MetaData", typeof(string), typeof(UpDownTextBox), new PropertyMetadata(String.Empty));

        public UpDownTextBoxViewModel Model;

        public UpDownTextBox()
        {
            InitializeComponent();
            this.Model = new UpDownTextBoxViewModel(MinValue, MaxValue, Value, MetaData);
            this.DataContext = this.Model;
        }
        private void updateTextBox(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = add.Foreground;
            Model.MaxValue = MaxValue;
            Model.MinValue = MinValue;
            Model.MetaData = MetaData;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            updateTextBox(sender, e);
            if (Model.Value < Model.MaxValue)
                Model.Value += 1;
            else
                Model.Value = MaxValue;
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            updateTextBox(sender, e);
            if (Model.Value > MinValue)
                Model.Value -= 1;
            else
                Model.Value = Model.MinValue;
        }
    }
}
