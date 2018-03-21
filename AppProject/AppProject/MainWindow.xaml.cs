﻿using System;
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

namespace AppProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Bill> bills;
        int numDinners = 0;

        public MainWindow()
        {
            InitializeComponent();
            List<string> imageFileNames = HelperMethods481.
            AssemblyManager.GetAllEmbeddedResourceFilesEndingWith(".png", ".jpg");

            foreach (string fileName in imageFileNames)
            {
                Image image = HelperMethods481.AssemblyManager.GetImageFromEmbeddedResources(fileName);
                string itemName = fileName.Replace(".jpg", "").Split('.').Last();
                MoreInfoControl moreInfo = new MoreInfoControl(image, itemName);
                this.DisplayMoreInfoGrid.Children.Add(moreInfo);
                moreInfo.Visibility = Visibility.Hidden;
            }
            W_StartButton.Opacity = 0.25;
            W_StartButton.IsEnabled = false;
        }

        private void W_numberOfPeopleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (W_numberOfPeopleSlider.Value > 0)
            {
                W_StartButton.Opacity = 1;
                W_StartButton.IsEnabled = true;
            }
            else
            {
                W_StartButton.Opacity = 0.25;
                W_StartButton.IsEnabled = false;
            }
        }

        private void W_StartButton_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Visible;
            WelcomeScreen.Visibility = Visibility.Hidden;
            Console.WriteLine(W_numberOfPeopleSlider.Value);
            numDinners = (int) W_numberOfPeopleSlider.Value;

            //Need to actually get the number of people in this loop
            for (int i=0; i<numDinners; i++)
            {
                this.R_BillUnicormGrid.Children.Add(new Bill(i+1));
            }

        }

        private void R_ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Visible;
            ReviewGrid.Visibility = Visibility.Hidden;
        }

        private void M_ReviewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Hidden;
            ReviewGrid.Visibility = Visibility.Visible;
        }

        private void R_MoveButton_Click(object sender, RoutedEventArgs e)
        {
            //ReviewGrid.Visibility = Visibility.Hidden;
           // ReviewGrid_Move1.Visibility = Visibility.Visible;
        }

        private void W_StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.WelcomeScreen.Visibility = Visibility.Hidden;
        }
    }
}
