using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using Microsoft.Win32;


namespace CAD_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas2D canvas2D;
        string file = "data.json";

        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Open_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Save_Executed));
            canvas2D = new Canvas2D();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Open();
        }

        private void Open()
        {
            Log.Debug("Pokus o otevření souboru");
            if (File.Exists(file))
            {
                try
                {
                    canvas2D = JsonConvert.DeserializeObject<Canvas2D>(File.ReadAllText(file));
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Chyba otevření souboru:\r\n{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show($"Soubor {file} neexistuje");
                Log.Warn($"Soubor {file} neexistuje");
            }
        }

        private void Save()
        {
            Log.Debug("Pokus o uložení souboru");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Save CAD File";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                file = saveFileDialog.FileName;
                var text = canvas2D.ToString();
                File.WriteAllText(file, JsonConvert.SerializeObject(canvas2D));
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void Konec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                canvas2D.AddPoint(e.GetPosition(canvas));
                canvas2D.Refresh(canvas);
            }
        }

    }
}
