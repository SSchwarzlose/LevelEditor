using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditor.View
{
    using LevelEditor.Controller;

    /// <summary>
    /// Interaction logic for NewMapWindow
    /// </summary>
    public partial class NewMapWindow : Window
    {
        /// <summary>
        /// The Controller.
        /// </summary>
        private readonly App controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewMapWindow"/> class.
        /// </summary>
        public NewMapWindow()
        {
            this.InitializeComponent();

            this.controller = (App)Application.Current;
        }

        /// <summary>
        /// Gets the selected map tile type.
        /// </summary>
        public string SelectedMapTileType { get; private set; }

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
                var radioButton = new RadioButton { Content = mapTileType, GroupName = "MapTileTypes" };
                radioButton.Checked += this.OnMapTileSelected;

                this.DefaultTilePanel.Children.Add(radioButton);
            }

            var firstRadioButton = (RadioButton)this.DefaultTilePanel.Children[0];
            firstRadioButton.IsChecked = true;
        }

        /// <summary>
        /// The on map tile selected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnMapTileSelected(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this.SelectedMapTileType = radioButton.Content.ToString();
        }

        /// <summary>
        /// The on create map clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnCreateMapClicked(object sender, RoutedEventArgs e)
        {
            this.controller.CreateNewMap();
        }
    }
}
