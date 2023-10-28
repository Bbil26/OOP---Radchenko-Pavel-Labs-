using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Lab8
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

        float Get_factor(float x) //Факториал
        {
            float result = 1;
            for (int i = 2; i <= x; i++) result *= i;
            return result;
        }

        float Get_Eq_1(float x, float p) //Первое уравнение
        {
            float y = 0;
            int n = Math.Abs((int)Math.Round(x) - (int)Math.Round(p));

            for(int i = 0; i < n; i++)
            {
                y += i % 2 == 0 ? -(float)Math.Pow(p, i) * (float)Math.Pow(x, i + 1) / Get_factor(i + 2): 
                                   (float)Math.Pow(p, i) * (float)Math.Pow(x, i + 1) / Get_factor(i + 2);
            }

            return y;
        }

        float Get_Eq_2(int n, int r) //Второе уравнение
        {
            float y = 0;
            for (float i = 1 ; i <= n ; i++)
            {
                for (float j = 1; j <= r ; j++)
                {
                    y += (i * i + j * j) / (i * i * i + j * j * j);
                }
            }
            return y;
        }

        private void TB_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_x.Text != "" && TB_p.Text != "" && float.TryParse(TB_x.Text, out _) && float.TryParse(TB_p.Text, out _))
                res_1.Text = Get_Eq_1(Convert.ToSingle(TB_x.Text), Convert.ToSingle(TB_p.Text)).ToString();
        }

        private void TB_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_r.Text != "" && TB_n.Text != "")
                res_2.Text = Get_Eq_2(Convert.ToInt32(TB_n.Text), Convert.ToInt32(TB_r.Text)).ToString();
        }

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

        private void Regex_2(object sender, TextCompositionEventArgs e)
        {
            string regexPattern = @"^-?\d*$";
            string input = (sender as TextBox).Text + e.Text;

            if (!Regex.IsMatch(input, regexPattern))
            {
                e.Handled = true;
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
