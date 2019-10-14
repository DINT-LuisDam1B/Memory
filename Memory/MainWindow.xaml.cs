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

            for (int i = 0; i < NUMCOLUMNAS; i++)
            {
                for (int j = 0; j < numFilas; j++)
                {
                    TextBlock textBlock = new TextBlock();
                    Grid_Imagenes.Children.Add(textBlock);
                  
                    textBlock.
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Iniciar(object sender, RoutedEventArgs e)
        {
            int numFilas = (int)((RadioButton)sender).Tag;
            CrarTabla(numFilas);

        }
    }
}
