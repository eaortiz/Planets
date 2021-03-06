﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;


namespace Planets
{
    class Graphics
    {
        
        public static void drawWorld(GamePlay page, World w)
        {
            List<Planet> planets = w.getPlanets();
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets[i].image != null) page.ContentPanel1.Children.Add(planets[i].image);
                else page.ContentPanel1.Children.Add(planets[i].ellipse);
                
            }
            page.ContentPanel1.Children.Add(w.getSpaceship().image);
        }
        public static void update(GamePlay page, World w)   
        {
            Spaceship ship = w.getSpaceship();
            ship.image.RenderTransform = new RotateTransform() { CenterX = ship.image.ActualWidth / 2, CenterY = ship.image.ActualHeight / 2, Angle = 180 * (Math.Atan2(ship.velocity.x, -ship.velocity.y)) / Math.PI };
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Margin = new Thickness(ship.getPosition().x, ship.getPosition().y, 0, 0);
            ellipse.StrokeThickness = 10.0;
            ellipse.Stroke = new SolidColorBrush(Colors.OrangeRed);
            page.ContentPanel1.Children.Add(ellipse);
            Vector mult = ship.velocity.times((float)ship.image.ActualHeight / (ship.velocity.getMagnitude()));
            ship.image.Margin = new Thickness(ship.getPosition().x + mult.x, ship.getPosition().y + mult.y, 0, 0);
           
        }
    }
}
