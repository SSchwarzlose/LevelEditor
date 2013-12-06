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

        private void CommandExecutedNew(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.NewMap();
        }

        private void CommandExecutedHelp(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ShowHelpWindow();
        }

        private void CommandExecutedClose(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.Quit();
        }

        private void CommandCanExecuteNew(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandCanExecuteHelp(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandCanExecuteClose(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
