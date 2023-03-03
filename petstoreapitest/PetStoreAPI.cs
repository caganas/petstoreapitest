using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections.Generic;

namespace petstoreapitestapi
{
    internal class PetStoreAPI
    {
        string baseUrl = "https://petstore.swagger.io/v2";

        public bool petFindByStatusIsEmpty(string status)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("pet/findByStatus");
            request.AddParameter("status", status);
            var aqq = client.Get(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);
            int resCnt = 0;
            foreach(var item in json)
            {
                resCnt ++;
            }
            if (resCnt == 0)
            {
                return false;
            }
            return true;
        }
        public bool petFindByStatusHasName(string status, string name)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("pet/findByStatus");
            request.AddParameter("status", status);
            var aqq = client.Get(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);

            foreach (var item in json)
            {
                if (item["name"] == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool postPetSucceed(dynamic status, dynamic name)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("pet");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            if (status != null)
            {
                foo.status = status;
            }
            if (name != null)
            {
                foo.name = name;
            }
            string bodyjson = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
            request.AddJsonBody(bodyjson);
            var aqq = client.Post(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);
            
            try
            {
                if (json["name"] != null && json["status"] != null)
                {
                    return true;
                }
                return false;
            } catch (Exception ex)
            {
                return false;
            }

        }
        public bool putPetSucceed(dynamic status, dynamic name)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("pet");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Put;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            if (status != null)
            {
                foo.status = status;
            }
            if (name != null)
            {
                foo.name = name;
            }
            string bodyjson = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
            request.AddJsonBody(bodyjson);
            var aqq = client.Put(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);

            try
            {
                if (json["name"] != null && json["status"] != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool petById(string id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("pet/" + id);
            var aqq = client.Get(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);
            if (json["name"] != null)
            {
                return true;
            }
            
            return false;
        }
        public bool postStoreOrder(dynamic petId, dynamic status, dynamic complete)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("store/order");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            foo.petId = petId;
            foo.status = status;
            foo.complete = complete;
            
            try
            {
                string bodyjson = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
                request.AddJsonBody(bodyjson);
                var aqq = client.Post(request).Content;
                dynamic json = JsonConvert.DeserializeObject(aqq);

                if (json["id"] != null)
                {
                    return true;
                }
                return false;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool postUserCreatWithArray(dynamic userStatus)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user/createWithArray");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            foo.id = 0;
            foo.username = "tom";
            foo.firstName = "tom";
            foo.lastName = "jane";
            foo.email = "tomjane@gmail.com";
            foo.password = "tom";
            foo.phone = "1111111111";
            foo.userStatus = userStatus;
            List<dynamic> jsonArr = new List<dynamic>();
            jsonArr.Add(foo);
            try
            {
                string bodyjson = Newtonsoft.Json.JsonConvert.SerializeObject(jsonArr);
                request.AddJsonBody(bodyjson);
                var aqq = client.Post(request).Content;
                dynamic json = JsonConvert.DeserializeObject(aqq);

                if (json["code"] == 200)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool postUserCreatWithList(dynamic userStatus)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user/createWithList");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            foo.id = 0;
            foo.username = "jack";
            foo.firstName = "jack";
            foo.lastName = "lena";
            foo.email = "jacklena@gmail.com";
            foo.password = "jack";
            foo.phone = "333-333-3333";
            foo.userStatus = userStatus;
            List<dynamic> jsonArr = new List<dynamic>();
            jsonArr.Add(foo);
            foo.id = 1;
            foo.username = "tom";
            foo.firstName = "tom";
            foo.lastName = "jane";
            foo.email = "tomjane@gmail.com";
            foo.password = "tom";
            foo.phone = "1111111111";
            foo.userStatus = userStatus;
            jsonArr.Add(foo);
            try
            {
                string bodyjson = Newtonsoft.Json.JsonConvert.SerializeObject(jsonArr);
                request.AddJsonBody(bodyjson);
                var aqq = client.Post(request).Content;
                dynamic json = JsonConvert.DeserializeObject(aqq);

                if (json["code"] == 200)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool putUser(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user/" + username);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Put;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            foo.id = 0;
            foo.username = username;
            foo.firstName = firstname;
            foo.lastName = lastname;
            foo.email = email;
            foo.password = password;
            foo.phone = phone;
            foo.userStatus = userStatus;
            string bodyjson = JsonConvert.SerializeObject(foo);
            request.AddJsonBody(bodyjson);
            var aqq = client.Put(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);

            if (json["type"] == "error")
            {
                return false;
            }
            return true;
        }

        public bool getUserByUsername(string username)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user/" + username);
            var aqq = client.Get(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);
            if (json["type"] != "error")
            {
                return true;
            }

            return false;
        }

        public bool userLogin(string username, string password)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user/login");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            var aqq = client.Get(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);
            if (json["type"] != "error")
            {
                return true;
            }

            return false;
        }

        public bool postUser(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("user");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            dynamic foo = new ExpandoObject();
            foo.id = id;
            foo.username = username;
            foo.firstName = firstname;
            foo.lastName = lastname;
            foo.email = email;
            foo.password = password;
            foo.phone = phone;
            foo.userStatus = userStatus;
            try
            {
                string bodyjson = JsonConvert.SerializeObject(foo);
                request.AddJsonBody(bodyjson);
                var aqq = client.Post(request).Content;
                dynamic json = JsonConvert.DeserializeObject(aqq);

                if (json["code"] == 200)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
