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

namespace PR_5_task_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double a;
            int n;

            if (double.TryParse(txtA.Text, out a) && int.TryParse(txtN.Text, out n))
            {
                double sum = 1;

                for (int i = 1; i <= n; i++)
                {
                    sum += Math.Pow(a, i);
                }

                txtResult.Text = "Сумма: " + sum.ToString("F2");
            }
            else
            {
                txtResult.Text = "Ошибка ввода!";
            }
        }
    }
}