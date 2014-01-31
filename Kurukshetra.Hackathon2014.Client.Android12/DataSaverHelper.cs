using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace Kurukshetra.Hackathon2014.Client.Android12
{
    class DataSaverHelper
    {
        public const string FILE_NAME = "data.xml";
        public readonly string FileNamePath;

        public DataSaverHelper(){
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            FileNamePath = Path.Combine(documents, "Write.txt");
        }

        public void AddNewCustomer(string userName,string secret)
        {
            if(!File.Exists(FileNamePath))
            {
                var doc = new XElement("Data");
                doc.Save(FileNamePath);
            }
            var docToSave = XElement.Load(FileNamePath);
            docToSave.Add(new XElement("Customer", 
                               new XAttribute("UserName", userName), 
                               new XElement("Secret", secret)
                            )
                        );
            docToSave.Save(FileNamePath);
        }

        public string[] GetCustomerAccouts()
        {
            if(File.Exists(FileNamePath))
            {
                var doc = XElement.Load(FileNamePath);
                var ele = doc.Descendants().Where(p => p.Name == "Customer").Select(p => p.Attribute("UserName").Value);
                return ele.ToArray();
            }
            return null;
        }

        public string GetSecretForCustomer(string userName)
        {
            if (File.Exists(FileNamePath))
            {
                var doc = XElement.Load(FileNamePath);
                var ele = doc.Descendants().
                    Where(p => p.Name == "Customer" && p.Attribute("UserName").Value == userName).
                    SingleOrDefault();
                if (ele != null)
                {
                    var secret = ele.Descendants().Where(p => p.Name == "Secret").SingleOrDefault();
                    if(secret != null)
                    {
                        return secret.Value;
                    }
                }
            }
            return "";
        }

        public string GetUrlBase()
        {
            if (File.Exists(FileNamePath))
            {
                var doc = XElement.Load(FileNamePath);
                var ele = doc.Descendants().Where(p => p.Name == "BaseUrl").FirstOrDefault();
                if(ele != null)
                {
                    return ele.Value;
                }
            }
            return "http://localhost";
        }

        public void AddUrlBase(string baseUrl)
        {
            if (File.Exists(FileNamePath))
            {
                var doc = XElement.Load(FileNamePath);
                var ele = doc.Descendants().Where(p => p.Name == "BaseUrl").FirstOrDefault();
                if (ele != null)
                {
                    ele.Value = baseUrl;
                }
                else
                {
                    doc.Add(new XElement("BaseUrl", baseUrl));
                }
                doc.Save(FileNamePath);

            }
        }
    }
}