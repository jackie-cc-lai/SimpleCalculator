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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string numDisp = "";
        string numHidden = "";
        double finalnum1 = 0;
        double finalnum2 = 0;
        double finalResult = 0;
        string oper = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_Er(object sender, RoutedEventArgs e)
        {
            numDisp = "";
            numHidden = "";
            oper = "";
        }
        private void Button_Click_Num(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.Source;
            numDisp = numDisp + btn.Content.ToString();
            textBoxInput.Text = numDisp;      
        }
        private void Button_Click_Op(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.Source;
            oper = btn.Content.ToString();
            textBoxDebug.Text = oper;
            if(oper != "")
            {
                textBoxOp.Text = "Route 2";
                finalnum2 = Convert.ToDouble(numDisp);
                finalResult = getResult(finalnum1, finalnum2);
                numHidden = finalResult.ToString();
                finalnum1 = finalResult;
 
            }
            else
            {
                textBoxOp.Text = "Route 1";
                finalnum1 = Convert.ToDouble(numDisp);
                numHidden = numDisp;
            }
            textBoxNum1.Text = numHidden;
            numDisp = "";
            textBoxInput.Text = numDisp;
        }

        private void Button_Click_Res(object sender, RoutedEventArgs e)
        {
            textBoxOp.Text = "Res triggered";
            Button btn = (Button)e.Source;
            if (btn.Content.ToString() == "=")
            {
                finalnum2 = Convert.ToDouble(numDisp);
                finalResult = getResult(finalnum1, finalnum2);                
            } else if (btn.Content.ToString() == "sin")
            {
                finalnum1 = Convert.ToDouble(numDisp);
                 finalResult = Math.Sin(finalnum1);
             } else if (btn.Content.ToString() == "cos")
            {
                finalnum1 = Convert.ToDouble(numDisp);
                 finalResult = Math.Cos(finalnum1);
            }else if (btn.Content.ToString() == "tan")
            {
                finalnum1 = Convert.ToDouble(numDisp);
                 finalResult = Math.Tan(finalnum1);
            }
            numDisp = finalResult.ToString();
            textBoxInput.Text = numDisp;
        }
        public double getResult(double numDisp, double numHidden)
        {
            if (oper == "+")
            {
                return numDisp + numHidden;
            }
            else if (oper == "/")
            {
                return numDisp / numHidden;
            }
            else if (oper == "*")
            {
                return numDisp * numHidden;
            }
            else
            {
                return numDisp - numHidden;
            }
        }
    }
}
