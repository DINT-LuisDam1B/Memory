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
        Random generador = new Random();
        List<string> listaCartas = new List<string>();


        //Eventos

        private void Button_Click_Iniciar(object sender, RoutedEventArgs e)
        {
            listaCartas.Clear();
            ProgressBar_Progreso.Value = 0;

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

        private void MouseDown_Border(object sender,RoutedEventArgs e)
        {
            
            Border auxBorder = ((Border)sender);
            Viewbox auxViewbox = (Viewbox)auxBorder.Child;
            TextBlock auxTextBlock = (TextBlock)auxViewbox.Child;

            string[] elementos = (auxBorder.Tag).ToString().Split(',');

            auxTextBlock.Text = elementos[2];
            auxBorder.Background = Brushes.White;
        } 

        //Metodos

        //Metodo devuelve caracter

        public string GenerarCaracter()
        {
            List<string> lista = new List<string>();

            lista.Add("f");
            lista.Add("h");
            lista.Add("k");
            lista.Add("o");
            lista.Add("Y");
            lista.Add("d");
            lista.Add("b");
            lista.Add("2");
            lista.Add("8");
            lista.Add("m");
            lista.Add("B");
            lista.Add("u");
            return lista[generador.Next(0,11)];
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
                
                    border.CornerRadius = new CornerRadius(4);
                    border.Margin = new Thickness(2);
                    border.Background = new LinearGradientBrush(Colors.White, Colors.SteelBlue, new Point(0.5, 0), new Point(0.5,1));

                    textBlock.Text = "s";
                    border.MouseDown += new MouseButtonEventHandler(MouseDown_Border);
                    textBlock.FontFamily = new FontFamily("Webdings");

                    string caracter = EstaPareja();
                    border.Tag = i + "," + j + "," + caracter;
                    textBlock.Tag = caracter;
                    viewbox.Child = textBlock;
                    border.Child = viewbox;
                    
                    
                    Grid.SetColumn(border,j);
                    Grid.SetRow(border,i);

                    listaCartas.Add("" + i +","+ j +"," +caracter);
                    Grid_Imagenes.Children.Add(border);
                }
            }
        }

        public string EstaPareja()
        {

            int veces = 0;
            string caracter = "";
            bool salir = false;

            caracter = GenerarCaracter();

            if (listaCartas.Count == 0 || listaCartas.Count == 1)
            {
                
                listaCartas.Add(caracter);
            }
            else
            {
                while (!salir)
                {
                    
                    if (!listaCartas.Contains(caracter))
                    {
                        listaCartas.Add(caracter);
                        salir = true;
                    }
                    else
                    {
                        for (int i = 0; i < listaCartas.Count; i++)
                        {
                            if (listaCartas[i] == caracter)
                            {
                                veces++;
                            }
                        }
                        if (veces < 2)
                        {
                            listaCartas.Add(caracter);
                            salir = true;
                        }
                        else
                        {
                            caracter = GenerarCaracter();
                            veces = 0;
                        }
                    }
                }
            }
            return caracter;
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Mostrar_Click(object sender, RoutedEventArgs e)
        {
            if (Grid_Imagenes.Children.Count != 0)
            {
                ProgressBar_Progreso.Value = 100;
            }
            

            foreach (Border item in Grid_Imagenes.Children)
            {
                Viewbox auxViewbox = (Viewbox)item.Child;
                TextBlock auxTextBlock = (TextBlock)auxViewbox.Child;
                auxTextBlock.Text = (string)auxTextBlock.Tag;
                item.Background = Brushes.White;
            }

            
           
        }
    }
}
