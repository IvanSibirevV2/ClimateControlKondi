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
using ClimateControlKondi;

namespace Wpf_Manager
{
    /// <summary>
    /// Логика взаимодействия для Window_Authentication.xaml
    /// </summary>
    public partial class Window_Authentication : Window
    {
        public Window_Authentication()
        {
            InitializeComponent();
        }
        private void QWE() 
        {
            ("select Count(Manager.login) from Manager"
                + " where Manager.login = '" + this.TextBox_Login.Text
            + "' and Manager.password ='" + this.TextBox_PasWord.Text
            + "' GROUP BY Manager.login ;"
            ).Execute_SQLite()
            // 'login1', 'pass1'
            .SetIf(_fBool: a => a.Count == 1
                , _f1: a => {
                    this.GridMain.Background = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xaa, 0x00));
                }
                , _f0: a => {
                    this.GridMain.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xaa, 0x00, 0x00));
                })
            ;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e){QWE();}
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e){QWE(); }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
