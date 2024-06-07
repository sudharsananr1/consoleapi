using System.IO;
using System.Net;
using System.Text;

namespace clientGET
{
    class Program
    {
        static void Main(string[] args) 
        {
            string result = "";
            try
            {

                { 
                    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://localhost:7161/api/login");
                    Request.Method = "POST";
                    Request.ContentType = "application/json";
                    string jsonData = "{\"username\":\"sudharsanan\",\"password\":\"sudharsanan_admin\" }";

                    byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);
                    Request.ContentLength = dataBytes.Length;

                    using (Stream requestStream = Request.GetRequestStream())
                    {
                        requestStream.Write(dataBytes, 0, dataBytes.Length);
                    }


                    WebResponse Response = Request.GetResponse();
                    result = new StreamReader(Response.GetResponseStream()).ReadToEnd();

                
            }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:7161/api/Student/GetAllstudents");
                request.Method = "GET";
                request.ContentType= "application/json";

                WebResponse response = request.GetResponse();
                result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}