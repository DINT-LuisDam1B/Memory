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

        //Eventos

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
            CrearTabla(numFilas);

        }

        private void MouseDown_TextBlock(object sender,RoutedEventArgs e)
        {
            TextBlock auxTextBlock = ((TextBlock)sender);

            auxTextBlock.Text = GenerarCaracter();
            auxTextBlock.Background = Brushes.White;
        } 

        //Metodos

        //Metodo devuelve caracter

        public string GenerarCaracter()
        {
            Random generador = new Random();
            List<string> lista = new List<string>();
            lista.Add("f");
            lista.Add("h");
            lista.Add("k");
            lista.Add("ñ");
            lista.Add(",");
            lista.Add("d");
            lista.Add("b");
            lista.Add("2");
            lista.Add("8");
            lista.Add("m");
            return lista[generador.Next(0,9)];
        }

        public void CrearTabla(int numFilas)
        {
            Grid_Imagenes.RowDefinitions.Clear();

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
                    //border.Padding = new Thickness(5);
                    border.CornerRadius = new CornerRadius(4);
                    border.Margin = new Thickness(2);
                    textBlock.Background = new LinearGradientBrush(Colors.White, Colors.SteelBlue, new Point(0.5, 0), new Point(0.5,1));

                    textBlock.Text = "s";
                    textBlock.MouseDown += new MouseButtonEventHandler(MouseDown_TextBlock);
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

        
    }
}
