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
            // "Ideally, the code-behind of a view contains only a constructor
            // that calls the InitializeComponent method."
            // -- from "Chapter 5: Implementing the MVVM Pattern":
            // http://msdn.microsoft.com/en-us/library/gg405484(v=pandp.40).aspx#sec2

            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        // TODO: Reduce coupling by binding to command interfaces,
        // instead of using this code-behind.
        // e.g. http://codingsolutions.blogspot.com.au/2010/03/windows-phone-7-tdd-kata-using-mvvm-and.html
        private void startImportButton_Click(object sender, RoutedEventArgs e)
        {
            // 20130326 - This is kept here as an example
            //
            //// Let's start by importing the descriptors!
            //
            //// Create a new descriptor.
            //Descriptor newDescriptor = new Descriptor
            //{
            //    CommonName = "This is my new descriptor."
            //};
            //
            //// Add the item to the ViewModel.
            //App.ViewModel.AddDescriptor(newDescriptor);

            // Tell the ViewModel do its work.
            App.ViewModel.ImportDescriptors();
        }
    }
}