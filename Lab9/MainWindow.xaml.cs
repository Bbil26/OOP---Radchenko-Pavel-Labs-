using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        float Get_Eq(int n, int k, float x, float y)
        {
            float result = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    result += ((float)Math.Pow(Math.Abs(x), i) + (float)Math.Cos(y) * (float)Math.Pow(y, i)) / (i * j);
                } 
            }
            return result;
        }

        void Out_Result()
        {
            float result = Get_Eq(Convert.ToInt32(CB_n.Text), Convert.ToInt32(CB_k.Text), Convert.ToSingle(TB_x.Text), Convert.ToSingle(TB_y.Text));
            res_0.Text = Convert.ToString((int)result, 2);
            res_1.Text = Convert.ToString((int)result, 8);
            res_2.Text = Convert.ToString(result);
            res_3.Text = Convert.ToString((int)result, 16);

        }
        
        /// /////////////////////////////////////////////
        private void TB_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_x.Text != "" && TB_y.Text != "" && float.TryParse(TB_x.Text, out _) && float.TryParse(TB_y.Text, out _))
                Out_Result();
        }
        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TB_x != null && TB_y != null)
                if (TB_x.Text != "" && TB_y.Text != "" && float.TryParse(TB_x.Text, out _) && float.TryParse(TB_y.Text, out _))
                    Out_Result();
        }
        /// /////////////////////////////////////////////
        private void Regex_1(object sender, TextCompositionEventArgs e)
        {
            string regexPattern = @"^-?[\d\,]*$";
            string input = (sender as TextBox).Text + e.Text;

            //убирает возможность дублировать точку
            if ((sender as TextBox).Text.Contains(",") && (e.Text == "," || e.Text == "."))
            {
                e.Handled = true;
                return;
            }

            //согласуется с регулярным выражением и заменяет точку на запятую
            if (!Regex.IsMatch(input, regexPattern))
            {
                e.Handled = true;
                if (e.Text == "." && !(sender as TextBox).Text.Contains(","))
                {
                    (sender as TextBox).Text += ",";
                    (sender as TextBox).Select((sender as TextBox).Text.Length, 0);
                }
            }

        }

        //Убирает возможность ставить пробелы в Text_Box'ы, какого-то черта их пропускает Regex WTF??!?
        private void TB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


    }
}
