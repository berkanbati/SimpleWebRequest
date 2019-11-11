using System;
using System.Text;
using System.Net;
using System.IO;

namespace Web_Request
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                StringBuilder sb = new StringBuilder();

                byte[] buf = new byte[8192];

                // Prepare the web page
                HttpWebRequest request = (HttpWebRequest)
                    WebRequest.Create("http://www.example.com");

                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();

                string tempString = null;
                int count = 0;

                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);

                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?

                // print out page source
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
