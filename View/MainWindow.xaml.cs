// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="BlackCore Games">
//   
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelEditor.View
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Policy;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    using LevelEditor.Controle;
    using LevelEditor.Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand About = new RoutedCommand();
        private readonly App controler;

        /// <summary>
        /// The tile size in pixels.
        /// </summary>
        private const int TileSizeInPixels = 32;

        private Image[,] canvasImages;

        private bool brushDown;

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

        public void UpdateMapCanvas(Map map)
        {
            this.MapCanvas.Children.Clear();

            this.MapCanvas.Width = map.Width * TileSizeInPixels;
            this.MapCanvas.Height = map.Height * TileSizeInPixels;

            this.canvasImages = new Image[map.Width, map.Height];

            for (var x = 0; x < map.Width; x++)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    var mapTile = map[x, y];

                    var image = new Image
                                    {
                                        Width = TileSizeInPixels,
                                        Height = TileSizeInPixels,
                                        Source = this.controler.GetTileImage(mapTile.Type),
                                        Tag = new Vector2I(x, y)
                                    };

                    this.MapCanvas.Children.Add(image);

                    this.canvasImages[x, y] = image;

                    Canvas.SetLeft(image, x * TileSizeInPixels);
                    Canvas.SetTop(image, y * TileSizeInPixels);

                    image.MouseLeftButtonDown += this.OnBrushDown;
                    image.MouseLeftButtonUp += this.OnBrushUp;
                    image.MouseMove += this.OnTileClicked;
                }
            }
        }

        private void OnTileClicked(object sender, MouseEventArgs e)
        {
            if (!this.brushDown)
            {
                return;
            }

            var tile = (Image)sender;
            var position = (Vector2I)tile.Tag;

            this.controler.OnTileClicked(position);
        }

        private void OnBrushUp(object sender, MouseButtonEventArgs e)
        {
            this.brushDown = false;
        }

        private void OnBrushDown(object sender, MouseButtonEventArgs e)
        {
            this.brushDown = true;
        }

        internal void UpdateMapCanvas(Vector2I position, BitmapImage tileImage)
        {
            this.canvasImages[position.X, position.Y].Source = tileImage;
        }

        /// <summary>
        /// The set map tile types.
        /// </summary>
        /// <param name="mapTileTypes">
        /// The map tile types.
        /// </param>
        public void SetMapTileTypes(IEnumerable<string> mapTileTypes)
        {
            foreach (var mapTileType in mapTileTypes)
            {
                var radioButton = new RadioButton();
                radioButton.Content = mapTileType;
                radioButton.GroupName = "MapTileTypes";
                radioButton.Checked += this.OnBrushSelected;

                this.BrushSelectionPanel.Children.Add(radioButton);
            }
        }

        private void OnBrushSelected(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this.controler.OnBrushSelected((string)radioButton.Content);
        }

        private void CommandExecutedSaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ExecuteSaveAs();
        }

        private void CommandCanExecuteSaveAs(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.controler.CanExecuteSaveAs();
        }

        private void CommandExecutedAbout(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ExecuteAbout();
        }

        private void CommandCanExecuteAbout(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.controler.CanExecuteAbout();
        }

        private void CommandExecutedOpen(object sender, ExecutedRoutedEventArgs e)
        {
            this.controler.ExecuteOpen();
        }

        private void CommandCanExecuteOpen(object sender, CanExecuteRoutedEventArgs e)
        {
            this.controler.CanExecuteOpen();
        }
    }
}
