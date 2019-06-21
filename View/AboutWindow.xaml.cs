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

namespace LevelEditor.View
{
    using LevelEditor.Controller;

    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        private App controler;

        public AboutWindow()
        {
            this.controler = (App)Application.Current;
            InitializeComponent();
        }

        private void OnCLickButtonCloseAbout(object sender, RoutedEventArgs e)
        {
            this.controler.CloseAboutWindow();
        }
    }
}
