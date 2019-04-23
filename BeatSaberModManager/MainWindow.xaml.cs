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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BeatSaberModManager.Core;
using MahApps.Metro.Controls;
using BeatSaberModManager.Objects;

namespace BeatSaberModManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainDataGrid.ItemsSource = loadDummyDataList();
            var buildInfo = BuildInfo.GetBuildInfo();
            Console.WriteLine(buildInfo.FullName);
        }

        private List<Plugin> loadDummyDataList()
        {
            List<Plugin> plugins = new List<Plugin>();
            plugins.Add(new Plugin()
            {
                Id = "100",
                Name = "test",
                Description = "test plugin",
                Author = "Luna Delrey",
                Enabled = true
            });

            return plugins;
        }
    }
}
