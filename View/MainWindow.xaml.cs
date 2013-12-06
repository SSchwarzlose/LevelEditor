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
            this.controler.ExecutedNew();
        }

        private void CommandExecutedHelp(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ExecutedHelp();
        }

        private void CommandExecutedClose(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ExecutedClose();
        }

        private void CommandCanExecuteNew(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.controler.CanExecuteNew();
        }

        private void CommandCanExecuteHelp(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.controler.CanExcecuteHelp();
        }

        private void CommandCanExecuteClose(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.controler.CanExecuteClose();
        }
    }
}
