namespace LevelEditor.View
{
    using System.Windows;
    using System.Windows.Input;

    using LevelEditor.Controle;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App controler;

        public MainWindow()
        {
            InitializeComponent();

            this.controler = (App)Application.Current;
        }

        private void OnClickButtonQuit(object sender, RoutedEventArgs e)
        {
            this.controler.Quit();
        }

        private void OnClickButtonAbout(object sender, RoutedEventArgs e)
        {
            this.controler.ExecuteAbout();
        }
    }
}
