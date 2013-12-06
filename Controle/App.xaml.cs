namespace LevelEditor.Controle
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using LevelEditor.Model;
    using LevelEditor.View;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AboutWindow aboutWindow;

        private NewMapWindow newMapWindow;

        private Dictionary<string, MapTileType> tileTypes;

        private Map map;

        public void Quit()
        {
            this.Shutdown();
        }

        public void CloseAboutWindow()
        {
            this.aboutWindow.Close();
        }

        public void NewMap()
        {
            newMapWindow = new NewMapWindow();
            newMapWindow.Show();
        }

        public void ShowHelpWindow()
        {
            this.aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            this.tileTypes = new Dictionary<string, MapTileType>();

            var grass = new MapTileType(1, "Grass");
            var desert = new MapTileType(3, "Desert");
            var water = new MapTileType(5, "Water");

            this.tileTypes.Add(grass.Name, grass);
            this.tileTypes.Add(desert.Name, desert);
            this.tileTypes.Add(water.Name, water);
        }

        public void CreateNewMap()
        {
            int width;
            int height;

            try
            {
                width = int.Parse(this.newMapWindow.MapWidthTextBox.Text);
            }
            catch (FormatException)
            {
                this.ShowErrorMessage("Incorect Width", "Please enter a valid Map width.");
                return;
            }

            try
            {
                height = int.Parse((this.newMapWindow.MapHeighTextBox.Text));
            }
            catch (FormatException)
            {
                this.ShowErrorMessage("Incorect Height", "Pleaser enter a valid Map height.");
                return;
            }

            try
            {
                this.map = new Map(width, height);
            }
            catch (ArgumentOutOfRangeException e)
            {
                this.ShowErrorMessage("Incorrect Map size", e.Message);
                return;
            }

            var defaultMapTile = this.newMapWindow.SelectedMapTileType;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    this.map[x, y] = new MapTile(x,y,defaultMapTile);
                }
            }

            this.newMapWindow.Close();
        }

        private void ShowErrorMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Cancel);
        }
    }
}
