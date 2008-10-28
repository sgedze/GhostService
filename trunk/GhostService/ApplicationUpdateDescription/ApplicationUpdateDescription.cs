using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace GhostService.GhostServicePlugin
{
    public class ApplicationUpdateDescription
    {
        private string filename;
        public string Filename
        {
            get
            {
                return filename;
            }
            set 
            {
                filename = value;
                if (IsAvailable)
                    LoadProperties(filename);
            }
        }

        public bool IsAvailable
        {
            get
            {
                return (!string.IsNullOrEmpty(filename));
            }
        }

        private List<UpdateCheck> _checks;
        public List<UpdateCheck> Checks
        { get { return _checks; } }

        private Dictionary<string, string> _updateDetails;
        private Dictionary<string, string> UpdateDetails
        { get { return _updateDetails; } }

        private Dictionary<string, bool> _processed;

        public bool this[string key]
        {
            get
            {
                if (_processed.ContainsKey(key))
                    return _processed[key];
                else
                {
                    _processed.Add(key, false);
                    return false;
                }                
            }
            set
            {
                if (_processed.ContainsKey(key))
                    _processed[key] = value;
                else
                {
                    _processed.Add(key, value);
                }
                SaveToXML();
            }
        }        

        public string UserMessage
        {
            get
            {
                return _updateDetails["UserMessage"];
            }

            set
            {
                _updateDetails["UserMessage"] = value;
            }
        }

        public string FinalResult
        {
            get
            {
                return _updateDetails["FinalResult"];
            }

            set
            {
                _updateDetails["FinalResult"] = value;
                SaveToXML();
            }
        }

        public ApplicationUpdateDescription()
        {            
            _checks = new List<UpdateCheck>();
            _updateDetails = new Dictionary<string, string>();
            _processed = new Dictionary<string, bool>();
        }

        public ApplicationUpdateDescription(string filename):
            this()
        {
            this.filename = filename;            

            LoadProperties(filename);
        }

        public void LoadProperties(string fileName)
        {
            this.filename = fileName;

            if (!File.Exists(fileName))
                return;

            XmlDocument doc = new XmlDocument();

            using (XmlReader xr = XmlReader.Create(fileName))
                doc.Load(xr);

            foreach (XmlNode xml in doc.ChildNodes)
                foreach (XmlNode node in xml.ChildNodes)
                {
                    if (node.Name.Equals("Checks"))
                    {
                        _checks.Clear();
                        foreach (XmlNode check in node.ChildNodes)
                        {
                            if (check.HasChildNodes)
                                _checks.Add(new UpdateCheck(check["CheckDescription"].InnerText, check["Query"].InnerText, check["Result"].InnerText, (CheckType)Convert.ToInt32(check["CompareResult"].InnerText)));
                        }
                    }
                    else if (node.Name.Equals("UpdateDetails"))
                    {
                        _updateDetails.Clear();
                        foreach (XmlNode innerNode in node.ChildNodes)
                            _updateDetails.Add(innerNode.Name, node[innerNode.Name].InnerText);
                    }
                    else if (node.Name.Equals("Processed"))
                    {
                        _processed.Clear();
                        foreach (XmlNode innerNode in node.ChildNodes)
                            _processed.Add(innerNode.Name, node[innerNode.Name].InnerText.Equals("True"));
                    }
                }
        }

        public void SaveToXML()
        {
            SaveToNewXML(filename);
        }

        private XmlWriterSettings theXMLSettings
        {
            get
            {

                XmlWriterSettings settingsXML = new XmlWriterSettings();
                settingsXML.OmitXmlDeclaration = false;
                settingsXML.ConformanceLevel = ConformanceLevel.Auto;
                settingsXML.CloseOutput = false;
                settingsXML.Encoding = System.Text.Encoding.UTF8;
                settingsXML.Indent = true;

                return settingsXML;
            }
        }

        public void SaveToNewXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            filename = fileName;

            XmlWriter xmlWriter = XmlWriter.Create(fileName, theXMLSettings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ApplicationUpdateDescription");
            xmlWriter.WriteStartElement("Checks");
            foreach (UpdateCheck check in _checks)
            {
                xmlWriter.WriteStartElement("Check");
                xmlWriter.WriteElementString("CheckDescription", check.CheckDescription);
                xmlWriter.WriteElementString("Query", check.Check);
                xmlWriter.WriteElementString("Result", check.PassResult);
                xmlWriter.WriteElementString("CompareResult", ((short)check.TheCheckType).ToString());
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("UpdateDetails");

            foreach (string s in _updateDetails.Keys)
            {
                xmlWriter.WriteElementString(s, _updateDetails[s]);
            }

            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Processed");

            foreach (string s in _processed.Keys)
            {
                xmlWriter.WriteElementString(s, _processed[s].ToString());
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

        }

        internal void CreateSampleFile(string fileName)
        {
            //_checks.Add(new UpdateCheck("Select count(*) from usr_bonds where GroupCode = \"ABS\"", "0", CheckType.Equal));
            //_checks.Add(new UpdateCheck("Select count(*) from usr_firm where LicensingCode = \"LKJASD-LAKSD0-ASS\"", "0", CheckType.Less));

            _processed.Add(@"c:\gwdata\ghostconvey.exe", true);
            _updateDetails.Add("UserMessage", "This is an update for FNB clients. Includes only two documents (CoC and Bond)");

            this.SaveToNewXML(fileName);            
        }

    }
}
