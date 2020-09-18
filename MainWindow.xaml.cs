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
using System.Windows.Threading;
using Pelit;

namespace Polttopallo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer dispatcherTimer;
        private int i;
        private double[] PaikkaX;
        private double[] PaikkaY;
        private Pelit.Peli peli = new Pelit.Peli();
        private Pelialusta pelialusta = new Pelialusta();
        private int pisteet = 0;
        private int hutit = 0;
        private bool? osuiko = null;
        private int ruutu;


        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 2500);
            dispatcherTimer.Start();
            Init();

            Siirto(i);
        }

        private void Init()
        {
            PaikkaX = new double[] { 0, 350, 750 };
            PaikkaY = new double[] { 0, 160, 320 };

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Siirto(i++);
            CommandManager.InvalidateRequerySuggested();
        }

        private void Siirto(int i)
        {
            if (osuiko == false)
            {
                peli.hutit++;
            }
            Hudit.Text = "Hutit: " + peli.hutit;
            osuiko = false;
            // TrueTaiFalse.Text = peli.OnkoOsuma(ruutu).ToString();
            //peli.OnkoOsuma(ruutu);
            //Pisteet.Text = "Pisteet: " + peli.pisteet;
            //Hudit.Text = "Hutit: " + peli.hutit.ToString();
            //pelialusta.osuiko = false;
            //TrueTaiFalse.Text = peli.OnkoOsuma(ruutu).ToString();


            ruutu = random.Next(1,10);
            switch (ruutu)
            {
                case 1:
                    Canvas.SetLeft(Kuva, PaikkaX[0]);
                    Canvas.SetTop(Kuva, PaikkaY[0]);

                    break;
                case 2:
                    Canvas.SetLeft(Kuva, PaikkaX[1]);
                    Canvas.SetTop(Kuva, PaikkaY[0]);


                    break;
                case 3:
                    Canvas.SetLeft(Kuva, PaikkaX[2]);
                    Canvas.SetTop(Kuva, PaikkaY[0]);


                    break;
                case 4:
                    Canvas.SetLeft(Kuva, PaikkaX[0]);
                    Canvas.SetTop(Kuva, PaikkaY[1]);


                    break;
                case 5:
                    Canvas.SetLeft(Kuva, PaikkaX[1]);
                    Canvas.SetTop(Kuva, PaikkaY[1]);


                    break;
                case 6:
                    Canvas.SetLeft(Kuva, PaikkaX[2]);
                    Canvas.SetTop(Kuva, PaikkaY[1]);

                      
                    break;
                case 7:
                    Canvas.SetLeft(Kuva, PaikkaX[0]);
                    Canvas.SetTop(Kuva, PaikkaY[2]);

                    break;
                case 8:
                    Canvas.SetLeft(Kuva, PaikkaX[1]);
                    Canvas.SetTop(Kuva, PaikkaY[2]);


                    break;
                case 9:
                    Canvas.SetLeft(Kuva, PaikkaX[2]);
                    Canvas.SetTop(Kuva, PaikkaY[2]);
                    break;
                default:
                    break;
            }
            Kuva.Visibility = Visibility.Visible;

            if (peli.OnkoValmis() == true)
            {
                Kuva.Visibility = Visibility.Hidden;
                dispatcherTimer.Stop();
                MessageBox.Show("Peli loppui");
            }
            //if (hutit == 3)
            //{
            //        dispatcherTimer.Stop();
            //    Kuva.Visibility = Visibility.Hidden;
            //    MessageBox.Show("Peli loppui");

            //}
  

        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Kuva.Visibility = Visibility.Hidden;
           // pelialusta.osuiko = true;
          //  peli.OnkoOsuma(ruutu);
        osuiko = true;
           // bool tulos = peli.OnkoOsuma(1);
           if (osuiko == true)
            {
                peli.pisteet++;
//
            }

            //TrueTaiFalse.Text = peli.OnkoOsuma(ruutu).ToString();

             Pisteet.Text = "Pisteet: " + peli.pisteet;



        }





    }
}
