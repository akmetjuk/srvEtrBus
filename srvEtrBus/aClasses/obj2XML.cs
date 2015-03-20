using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Threading;
using System.IO;

namespace srvEtrBus.aClasses
{
    public class obj2XML
    {
        public string SerializeMe()
        {
            return Serialize(this);
        }

        public static string obj2String(object sender)
        {
            XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
            XmlWriterSettings xmlWS = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true };
            XmlSerializer serializer = new XmlSerializer(sender.GetType());

            using (StringWriter stream = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stream, xmlWS))
            {
                serializer.Serialize(writer, sender);
                return stream.ToString();
            }        
        }

        public override string ToString()
        {
            XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
            XmlWriterSettings xmlWS = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true };
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            using ( StringWriter stream = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stream, xmlWS))
            {
                serializer.Serialize(writer, this);
                return stream.ToString();
            }
        
            /*
         *   using (StringWriter writer = new StringWriter())
          *  {                
           *     //XmlWriterSettings k = new XmlWriterSettings() {OmitXmlDeclaration = false };               
            *    serializer.Serialize(writer, this);
             *   string res = writer.ToString();
              *  // res = String.Join("\n", res.Split('\n').Skip(1).ToArray());
               * 
                * return writer.ToString();
            * }
            */
        }

        public static string Serialize(object sender)
        {            
            XmlSerializer serializer = new XmlSerializer(sender.GetType());
            string s = "";
            XmlWriterSettings xmlWS = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true };

            using (StringWriter stream = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stream, xmlWS))
            {
                serializer.Serialize(writer, sender);
                s = stream.ToString();
            }
            return s;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            if (s.Contains("<Task xmlns=\"http://www.audatex.com/SAXIF\">")) s = s.Replace("<Task xmlns=\"http://www.audatex.com/SAXIF\">", "<Task>");
            if (s.Contains("<AttachmentBinaryList xmlns=\"http://www.audatex.com/SAXIF\">")) s = s.Replace("<AttachmentBinaryList xmlns=\"http://www.audatex.com/SAXIF\">", "<AttachmentBinaryList>");
          
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }

        public static object DeserializeMe(Stream sXML, Type iType)
        {
            object obj = null;
            TextReader reader = null;
            XmlSerializer deserializer = null;
            try
            {
                deserializer = new XmlSerializer(iType);
                reader = new StreamReader(sXML);
                obj = deserializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);      
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return obj;  
        }

        //public static object DeserializeMe(object sXMLStringData, Type iType)
        //{
        //    object obj = null;
        //    TextReader reader = null;
        //    XmlSerializer deserializer = null;

        //    try
        //    {
        //        deserializer = new XmlSerializer(iType);
        //        reader = new StringReader((String)sXMLStringData);
        //        obj = deserializer.Deserialize(reader);
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //            reader.Dispose();
        //        }
        //    }
        //    return obj;  
        //}

        public static object DeserializeMe(string sFilePath, Type iType )
        {            
            object obj = null;
            TextReader reader = null;
            XmlSerializer deserializer = null;

            try
            {
                deserializer = new XmlSerializer(iType);
                reader = new StreamReader(sFilePath);
                obj = deserializer.Deserialize(reader); 
            } 
            catch // (Exception ex)
            {
                //MessageBox.Show(ex.Message);                     
            }
            finally {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return obj;            
        }
    }
}
