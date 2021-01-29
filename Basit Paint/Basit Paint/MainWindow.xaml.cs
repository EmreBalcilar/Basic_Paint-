using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Basit_Paint
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
        Point dot;
        bool durum;
        Brush brush = Brushes.Black; //starting color is black
        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //draw as long as the button left click is pressed
        {
            durum = true;
            dot = e.GetPosition(canvas1);
            canvas1.CaptureMouse();
        }
        private void canvas1_MouseRightButtonDown(object sender, MouseButtonEventArgs e) //draw as long as the button left click is pressed
        {
            durum = false;
            canvas1.ReleaseMouseCapture();
        }

        private void canvas1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) //stop drawing when left click is not pressed

        {
            durum = false;
            canvas1.ReleaseMouseCapture();
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e) //to follow the mouse movement

        {
            if (durum == true)
            {
                Line satır = new Line();
                satır.X1 = dot.X;
                satır.Y1 = dot.Y;
                dot = e.GetPosition(canvas1);
                satır.X2 = dot.X;
                satır.Y2 = dot.Y;
                satır.Stroke = brush;
                satır.StrokeThickness = 5;
                canvas1.Children.Add(satır);
            }
            else
            {
                durum = false;
                canvas1.ReleaseMouseCapture();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var kare = e.Source as Rectangle;
            if (kare != null)
            {
               
                brush = kare.Fill;
                
            }
            else
            {
                durum = true;
                dot = e.GetPosition(canvas1);
                canvas1.CaptureMouse();      
            }
        }
       
    }
}
