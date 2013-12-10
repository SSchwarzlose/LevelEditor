// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Xml;

namespace LevelEditor.Controle
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media.Imaging;

    using LevelEditor.Model;
    using LevelEditor.View;

    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private AboutWindow aboutWindow;

        private NewMapWindow newMapWindow;

        private MainWindow mainWindow;

        private Dictionary<string, MapTileType> tileTypes;

        private Dictionary<string, BitmapImage> tileImages; 

        private Map map;

        private MapTileType currentBrush;
        private string MapFileExtension = ".map";
        private string MapFileFilter = "Map files (.map) | *.map";
        private string XmlelementWidth = "Width";

        private string XmlElementHeight = "Height";
        private string XmlElementTiles = "Tiles";
        private string XmlElementPositionX = "X";
        private string XmlElementPositionY = "Y";
        private string XmlElementType = "Type";

        public void CloseAboutWindow()
        {
            this.aboutWindow.Close();
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

            this.tileImages = new Dictionary<string, BitmapImage>();

            foreach (var tileType in this.tileTypes.Values)
            {
                var imageUri = "pack://application:,,,/Resources/MapTiles/" + tileType.Name + ".png";

                BitmapImage tileImage = new BitmapImage();
                tileImage.BeginInit();
                tileImage.UriSource = new Uri(imageUri);
                tileImage.EndInit();

                this.tileImages.Add(tileType.Name, tileImage);
            }
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

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    this.map[x, y] = new MapTile(x, y, defaultMapTile);
                }
            }

            this.UpdateCanvas();

            this.newMapWindow.Close();
        }

        private void UpdateCanvas()
        {
            this.mainWindow.UpdateMapCanvas(this.map);
        }

        private void ShowErrorMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Cancel);
        }

        public void ExecutedNew()
        {
            if (this.newMapWindow == null || !this.newMapWindow.IsLoaded)
            {
                this.newMapWindow = new NewMapWindow();
                this.newMapWindow.SetMapTileTypes(this.tileTypes.Keys);
            }

            this.newMapWindow.Show();
            this.newMapWindow.Focus();
        }

        public void ExecutedHelp()
        {
            
        }

        public void ExecutedClose()
        {
            this.Shutdown();
        }

        public bool CanExecuteNew()
        {
            return true;
        }

        public bool CanExcecuteHelp()
        {
            return true;
        }

        public bool CanExecuteClose()
        {
            return true;
        }

        public void OnTileClicked(Vector2I position)
        {
            if (this.currentBrush == null)
            {
                return;
            }

            this.map[position].Type = this.currentBrush.Name;

             this.mainWindow.UpdateMapCanvas(position, this.tileImages[this.currentBrush.Name]);
        }

        public BitmapImage GetTileImage(string type)
        {
            return this.tileImages[type];
        }

        private void OnActivated(object sender, EventArgs e)
        {
            this.mainWindow = (MainWindow)this.MainWindow;
            this.mainWindow.SetMapTileTypes(this.tileTypes.Keys);
        }

        public void OnBrushSelected(string brush)
        {
            this.currentBrush = this.tileTypes[brush];
        }

        public void ExecuteSaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
                                                {
                                                    AddExtension = true,
                                                    CheckPathExists = true,
                                                    DefaultExt = MapFileExtension,
                                                    FileName = "New Map",
                                                    Filter = MapFileFilter,
                                                    ValidateNames = true
                                                };

            var result = saveFileDialog.ShowDialog();

            if (result != true)
            {
                return;
            }

            using (var stream = saveFileDialog.OpenFile())
            {
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

                using (var writer = XmlWriter.Create(stream, settings))
                {
                    writer.WriteStartElement("Map");

                    writer.WriteAttributeString("xmlns", "map", null, "http://www.npruehs.de/teaching/tool-developement/");

                    writer.WriteElementString(XmlelementWidth, this.map.Width.ToString(CultureInfo.InvariantCulture));
                    writer.WriteElementString(XmlElementHeight, this.map.Height.ToString(CultureInfo.InvariantCulture));

                    writer.WriteStartElement(XmlElementTiles);
                    foreach (var mapTile in this.map.Tiles)
                    {
                        writer.WriteStartElement("MapTile");
                        writer.WriteElementString(XmlElementPositionX, mapTile.Position.X.ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString(XmlElementPositionY, mapTile.Position.Y.ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString(XmlElementType, mapTile.Type);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
            }
        }

        public bool CanExecuteSaveAs()
        {
            if (this.map != null)
            {
                return true;
            }

            return false;
        }

        public void ExecuteAbout()
        {
            if (this.aboutWindow == null || !this.aboutWindow.IsLoaded)
            {
                this.aboutWindow = new AboutWindow();
            }

            this.aboutWindow.Show();
            this.aboutWindow.Focus();
        }

        public bool CanExecuteAbout()
        {
            return true;
        }
    }
}
