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

namespace Memory
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public const int NUMCOLUMNAS = 4;

        public void CrarTabla(int numFilas)
        {

            for (int i = 0; i < numFilas; i++)
            {
                Grid_Imagenes.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < numFilas; i++)
            {
                for (int j = 0; j < NUMCOLUMNAS; j++)
                {
                    Viewbox viewbox = new Viewbox();
                    TextBlock textBlock = new TextBlock();
                    Border border = new Border();

                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(2);
                    border.Padding = new Thickness(5);
                    border.CornerRadius = new CornerRadius(4);
                    border.Margin = new Thickness(2);
                    border.Background = Brushes.Aquamarine;
                    border.Background = new GradientBrush

                    textBlock.Text = "h";
                    textBlock.FontFamily = new FontFamily("Webdings");

                    viewbox.Child = textBlock;
                    border.Child = viewbox;
                    
                    
                    Grid.SetColumn(border,j);
                    Grid.SetRow(border,i);

                    Grid_Imagenes.Children.Add(border);


                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Iniciar(object sender, RoutedEventArgs e)
        {
            int numFilas = 0;

            if (Button_DifBaja.IsChecked == true)
            {
                numFilas = Convert.ToInt32(Button_DifBaja.Tag);
            }
            else if (Button_DifMedia.IsChecked == true)
            {
                numFilas = Convert.ToInt32(Button_DifMedia.Tag);
            }
            else
            {
                numFilas = Convert.ToInt32(Button_DifAlta.Tag);
            }


            CrarTabla(numFilas);

        }
    }
}
