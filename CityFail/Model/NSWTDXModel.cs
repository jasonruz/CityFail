using System;
using System.Net;
using System.Xml;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Ink;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;

namespace CityFail.Model
{
    /// <summary>
    /// A parser for files from the NSW public transport data exchange 
    /// program.
    /// </summary>
    public class NSWTDXModel
    {
        // The XML file to read
        private static string xmlFile = "Data/112_20090828.xml";

        // The XmlReader that will exist for the lifetime of the object.
        private XmlReader reader;

        /// <summary>
        /// Class constructor, create the XmlReader.
        /// </summary>
        public NSWTDXModel()
        {
            // Instantiate the XmlReader
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            reader = XmlReader.Create(xmlFile, settings);

            // Skip over the XML declaration
            reader.MoveToContent();

            // Skip to StopPoints
            reader.ReadToDescendant("StopPoints");

        }

        /// <summary>
        /// Gets the next descriptor from the XML file.
        /// Precondition: Reader is inside StopPoints tags.
        /// </summary>
        /// <returns>The next Descriptor.</returns>
        public Descriptor ReadDescriptor()
        {
            reader.ReadToDescendant("Descriptor");
            reader.ReadStartElement("Descriptor");
            reader.ReadStartElement("CommonName");

            Descriptor newDescriptor = new Descriptor();
            newDescriptor.CommonName = reader.ReadContentAsString();

            return newDescriptor;
        }
    }
}
