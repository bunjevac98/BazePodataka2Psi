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

namespace BendAplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Bend(object sender, RoutedEventArgs e)
        {
            BendView bendView = new BendView();
            bendView.ShowDialog();
        }
        private void Button_Click_Zanr(object sender, RoutedEventArgs e)
        {
            ZanrView zanrView = new ZanrView();
            zanrView.ShowDialog();
        }
        private void Button_Click_Nagrada(object sender, RoutedEventArgs e)
        {
            NagradaView nagrada = new NagradaView();
            nagrada.ShowDialog();

        }
        private void Button_Click_IzdavacK(object sender, RoutedEventArgs e)
        {
            MuzickaKucaView muzickaKucaView = new MuzickaKucaView();
            muzickaKucaView.ShowDialog();
        }
        private void Button_Click_Muzicar(object sender, RoutedEventArgs e)
        {
            MuzicarView muzicar = new MuzicarView();
            muzicar.ShowDialog();
        }
        private void Button_Click_Menadzer(object sender, RoutedEventArgs e)
        {
            MenadzerView menadzerView = new MenadzerView();
            menadzerView.ShowDialog();
        }
        private void Button_Click_Koncert(object sender, RoutedEventArgs e)
        {
            KoncertView koncertView = new KoncertView();
            koncertView.ShowDialog();
        }
        private void Button_Click_Festival(object sender, RoutedEventArgs e)
        {
            FestivalView festivalView = new FestivalView();
            festivalView.ShowDialog();
        }
        private void Button_Click_Album(object sender, RoutedEventArgs e)
        {
            AlbumView albumView = new AlbumView();
            albumView.ShowDialog();
        }

        private void Button_Click_Ucestvuje(object sender, RoutedEventArgs e)
        {
           UcestvujeView ucestvujeView = new UcestvujeView();
            ucestvujeView.ShowDialog();
        }

        private void Button_Click_Osvaja(object sender, RoutedEventArgs e)
        {
            OsvajaView osvaja = new OsvajaView();
            osvaja.Show();

        }

        private void Button_Click_Pripada(object sender, RoutedEventArgs e)
        {
            PripadaView pripada = new PripadaView();
            pripada.Show();
        }

        private void Button_Click_Svira(object sender, RoutedEventArgs e)
        {
            SviraView svira = new SviraView();
            svira.Show();
        }

        private void Button_Click_Snima(object sender, RoutedEventArgs e)
        {
            SnimaView snima = new SnimaView();
            snima.Show();
        }

        private void Button_Click_Izdaje(object sender, RoutedEventArgs e)
        {
            IzdajeView izdaje = new IzdajeView();
            izdaje.Show();
        }

        private void Button_Click_Odrzi(object sender, RoutedEventArgs e)
        {
            OdrziView odrzi = new OdrziView();
            odrzi.Show();
        }

        private void Button_Click_Daje(object sender, RoutedEventArgs e)
        {
            Daje daje = new Daje();
            daje.Show();

        }

        private void Button_Click_Bubnjar(object sender, RoutedEventArgs e)
        {
            BubnjarView bubnjar = new BubnjarView();
            bubnjar.Show();

        }

        private void Button_Click_Klavijaturista(object sender, RoutedEventArgs e)
        {
            KlavijaturistaView klavija = new KlavijaturistaView();
            klavija.Show();

        }

        private void Button_Click_Gitarista(object sender, RoutedEventArgs e)
        {
            GitaristaView gitarista = new GitaristaView();
            gitarista.Show();
        }




    }
}
