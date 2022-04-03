using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace HWFiliesAndSerilization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region FilesHW
            string[] dirs = Directory.GetDirectories(@"C:\Drivers", "*.*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < 10; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                Console.WriteLine(dir.Name);
            }
            Folderdetails(@"C:\Files");
            #endregion
            Car c1 = new Car("AutoCars", "Mazda", 2012, "Blue", 1234, 5);
            Car c2 = new Car("AutoCars", "Mazda", 2012, "Blue", 125, 5);
            Car c3 = new Car("Auto", "BMW", 2022, "Red", 1234, 5);
            //XmlSerializer serializer = new XmlSerializer(typeof(Car));
            //using( FileStream fileStream = new FileStream(@"C:\Files\fileXs.txt",FileMode.Create))
            //{
            //    serializer.Serialize(fileStream, c1);
            //}
            c1.Brand = "Kia";
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            using (FileStream fileStream = new FileStream(@"C:\Files\fileXs.txt", FileMode.Create))
            {
                serializer.Serialize(fileStream, c1);
            }
            Car c4 = new Car();
            using (Stream fileStrem2 = new FileStream(@"C:\Files\fileXs.txt", FileMode.Open))
            {
                XmlSerializer DeXml = new XmlSerializer(typeof(Car));
                 c4 = (Car)DeXml.Deserialize(fileStrem2);
            }
            Car[] cars = new Car[3];
            cars[0] = c1;
            cars[1] = c2;
            cars[2] = c3;
            XmlSerializer carsArray = new XmlSerializer(typeof(Car[]));
           using(FileStream fileStream1 = new FileStream(@"C:\Files\fileXmlArray.txt", FileMode.Create))
            {
                carsArray.Serialize(fileStream1, cars);
            }
            using (FileStream fileStream1 = new FileStream(@"C:\Files\fileXmlArray.txt", FileMode.Create))
            {
                XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(Car[]));
                Car [] newArrayCar = (Car [])xmlSerializer2.Deserialize(fileStream1); 
            }


        }
        public static void Folderdetails(string nameFolder)
        {
            DirectoryInfo folder = new DirectoryInfo(nameFolder);
            List<FileInfo> myFiles = folder.GetFiles().ToList();
            List<FileInfo> myListFiles2 = myFiles.OrderBy(FileInfo => FileInfo.Length).Reverse().ToList();
            Console.WriteLine($"Name: {myListFiles2[0].Name}\nLenght: { myListFiles2[0].Length}\n { myListFiles2[0].LastWriteTime}");
            Console.WriteLine($"Name: { myListFiles2[1].Name}\nLenght: { myListFiles2[1].Length}\n { myListFiles2[1].LastWriteTime}");
            Console.WriteLine($"Name: { myListFiles2[2].Name}\nLenght: { myListFiles2[2].Length}\n { myListFiles2[2].LastWriteTime}");



        }
    }
}
