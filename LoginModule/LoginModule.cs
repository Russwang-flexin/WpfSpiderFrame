using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace MySelfProject
{
    public class LoginModule
    {
        static string loginBaseUrl = "http://60.205.205.201";
        static string RestryBaseUrl = "http://60.205.205.201:8001/login";
        UserToken token;
        public LoginModule(string username, string password)
        {
            token = new UserToken();
            token.UserName = username;
            token.Password = password;
            init();
        }
        public string result = string.Empty;

        async void init()
        {
            result = await Restry();
        }

        private string Base64Encrypt(string txt)
        {
            return txt;
        }

        private string EnCryPt(string txt)
        {
            return txt;
        }

        private async Task<string> Restry()
        {
            var body = MakeJosnData();
            var res = await PostData(body);
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private async Task<WebResponse> PostData(string body)
        {
            Encoding encode = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(RestryBaseUrl);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            byte[] buffer = encode.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = await request.GetResponseAsync();
            return response;
        }

        private string MakeJosnData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["username"] = Base64Encrypt(token.UserName); ;
            dict["password"] = EnCryPt(token.Password);
            return JsonConvert.SerializeObject(dict);
        }

    }

    public class UserToken
    {
        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }


    public class RegistyBody
    {
        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    IsBad = true;
                }
                _username = value;
            }
        }

        public bool IsBad = false;

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    IsBad = true;
                }
                _password = value;
            }
        }
    }
}
