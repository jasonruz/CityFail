using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

// Directive for the data model.
using CityFail.Model;

/* "The view model in the MVVM pattern encapsulates the presentation logic and
 * data for the view. It has no direct reference to the view or any knowledge
 * about the view's specific implementation or type. The view model implements
 * properties and commands to which the view can data bind and notifies the 
 * view of any state changes through change notification events. The 
 * properties and commands that the view model provides define the 
 * functionality to be offered by the UI, but the view determines how that 
 * functionality is to be rendered."
 * -- from "Chapter 5: Implementing the MVVM Pattern":
 * http://msdn.microsoft.com/en-us/library/gg405484(v=pandp.40).aspx#sec3
 */

// I'm going to put business logic in here as well. Not sure if that's bad,
// but it's probably not good. :/
namespace CityFail.ViewModel
{
    public class CityFailViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private CityFailContext cityFailDB;

        // Class constructor, create the data context object
        public CityFailViewModel(string cityFailConnectionString)
        {
            cityFailDB = new CityFailContext(cityFailConnectionString);
        }

        // Status text
        private string _statusText;
        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                NotifyPropertyChanged("StatusText");
            }
        }


        // 20130326 - This is kept here as an example
        //
        //// Add a descriptor to the database and collections.
        //public void AddDescriptor(Descriptor newDescriptor)
        //{
        //    // Add a descriptor to the data context.
        //    cityFailDB.Descriptors.InsertOnSubmit(newDescriptor);

        //    // Save changes to the database.
        //    cityFailDB.SubmitChanges();

        //    // Update the ViewModel.
        //    StatusText += ".";
        //}

        /// <summary>
        /// Do the initial import of Descriptors.
        /// </summary>
        public void ImportDescriptors()
        {
            NSWTDXModel tdx = new NSWTDXModel();
            Descriptor newDescriptor = new Descriptor();

            // Read a new descriptor.
            while ((newDescriptor = tdx.ReadDescriptor()) != null)
            {
                // Add a descriptor to the data context.
                cityFailDB.Descriptors.InsertOnSubmit(newDescriptor);

                // Save changes to the database.
                cityFailDB.SubmitChanges();

                // Update the ViewModel.
                if (StatusText == null)
                {
                    StatusText = (0).ToString();
                }
                StatusText = (int.Parse(StatusText)+1).ToString();
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
