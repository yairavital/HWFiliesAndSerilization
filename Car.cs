using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
namespace HWFiliesAndSerilization
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        private int numberOfSeats { get; set; }

        public Car(string model, string brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }

        public Car()
        { }
        public Car(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                Car car = (Car)xml.Deserialize(myStream);
                this.Model = car.Model;
                this.Year = car.Year;
                this.Color = car.Color;
                this.codan = car.codan;
                this.Brand = car.Brand;
                this.numberOfSeats = car.numberOfSeats;
            }

        }
            public int GetCodan()
        { return codan; }
        public int GetNumberOfSeats()
        { return numberOfSeats; }
        public void ChangeNumberOfSeats(int newNumSeats)
        { numberOfSeats = newNumSeats;}
   
        public static void SerilizeACar(string fileName, Car car)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(myStream, car);
            }
        }

        public static void SerilizeCarArray(string fileName, Car[] car)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car[]));
                xml.Serialize(myStream, car);
            }
        }

        public static Car DeSerilizeACar(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer Dxml = new XmlSerializer(typeof(Car));
                Car xmlImporteredCar = (Car)Dxml.Deserialize(myStream);
                return xmlImporteredCar;
            }

        }

        public static Car[] DeSerilizeCarArray(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer DxmlArray = new XmlSerializer(typeof(Car[]));

                Car[] xmlImporteredCarArray = (Car[])DxmlArray.Deserialize(myStream);
                return xmlImporteredCarArray;
            }

        }

        public bool CarCompare(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer Dxml = new XmlSerializer(typeof(Car));
                Car xmlImporteredCar = (Car)Dxml.Deserialize(myStream);
                if (JsonSerializer.Serialize(xmlImporteredCar) == JsonSerializer.Serialize(this))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return true;
        }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
