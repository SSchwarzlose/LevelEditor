namespace LevelEditor.Controle
{
    using System.Windows;

    using LevelEditor.View;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AboutWindow aboutWindow;

        public void Quit()
        {
            this.Shutdown();
        }

        public void CloseAboutWindow()
        {
            this.aboutWindow.Close();
        }

        public void ExecuteAbout()
        {
            this.aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
