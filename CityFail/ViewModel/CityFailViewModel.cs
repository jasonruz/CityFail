using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

// Directive for the data model.
using CityFail.Model;

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


        // Add a descriptor to the database and collections.
        public void AddDescriptor(Descriptor newDescriptor)
        {
            // Add a descriptor to the data context.
            cityFailDB.Descriptors.InsertOnSubmit(newDescriptor);

            // Save changes to the database.
            cityFailDB.SubmitChanges();

            // Update the view.
            // TODO NEXT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
