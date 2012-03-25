using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

// Directive for the data model.
using CityFail.Model;

namespace CityFail
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        private void startImportButton_Click(object sender, RoutedEventArgs e)
        {
            // Let's start by importing the descriptors!

            // Create a new descriptor.
            Descriptor newDescriptor = new Descriptor
            {
                CommonName = "This is my new descriptor."
            };

            // Add the item to the ViewModel.
            App.ViewModel.AddDescriptor(newDescriptor);

        }
    }
}