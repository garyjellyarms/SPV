//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Net.Http.Json;
//using System.Text;

//namespace SPVapp.Test              // Ce želimo da ti testi delajo je potebno vzpostaviti posebej HttpClient
//{
//    //https://www.youtube.com/watch?v=xs8gNQjCXw0
//    [TestClass]
//    public class ApiTests
//    {

//        private HttpClient _httpClient;

//        public ApiTests() 
//        {
//            var webAppFactory = new WebApplicationFactory<Program>();
//            _httpClient = webAppFactory.CreateDefaultClient();
//        }

//        /*
//         TESTIRANJE FOOD API - BAZE
//         */

//        [TestMethod]
//        public async Task FoodPost()
//        {
//            var payload = "{\"id\":0,\"picture\":\"www.fb.com/profileimage.png\",\"name\":\"Brokoli\"}"; //https://jsontostring.com/
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("/api/Food", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        [TestMethod]
//        public async Task FoodGetAll()
//        {
//            var response = await _httpClient.GetAsync("/api/Food");
//            //var stringResult = await response.Content.ReadAsStringAsync();
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }


//        [TestMethod]
//        public async Task FoodGetById()
//        {
//            var response = await _httpClient.GetAsync("/api/Food/1");
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        [TestMethod]
//        public async Task FoodPut()
//        {
//            var payload = "{\"id\":0,\"picture\":\"www.fb.com/profileimage.png\",\"name\":\"Brokoli2\"}"; //https://jsontostring.com/
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PutAsync("/api/Food", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            Assert.IsNotNull(stringResult);
//        }

//        [TestMethod]
//        public async Task FoodDelete()
//        {
//            var response = await _httpClient.DeleteAsync("/api/Food/1");
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        /*
//          TESTIRANJE RESTAURANT API - BAZE
//        */



//        [TestMethod]
//        public async Task RestaurantPost()
//        {
//            var payload = "{\"id\":0,\"name\":\"NOVA_RESTVARCAIJA\",\"x_coordinate\":0,\"y_coordinate\":0,\"openingTime\":0,\"closingTime\":0,\"foodList\":\"string\"}";
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("/api/Resturant", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        [TestMethod]
//        public async Task RestaurantGetAll()
//        {
//            var response = await _httpClient.GetAsync("/api/Resturant");

//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }


//        [TestMethod]
//        public async Task RestaurantGetById()
//        {
//            var response = await _httpClient.GetAsync("/api/Resturant/1");
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        [TestMethod]
//        public async Task RestaurantPut()
//        {
//            var payload = "{\"id\":0,\"name\":\"posodobljenaplikacija\",\"x_coordinate\":0,\"y_coordinate\":0,\"openingTime\":0,\"closingTime\":0,\"foodList\":\"string\"}";
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PutAsync("/api/Resturant", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            Assert.IsNotNull(stringResult);
//        }

//        [TestMethod]
//        public async Task RestaurantDelete()
//        {
//            var response = await _httpClient.DeleteAsync("/api/Resturant/1");
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }



//        /*
//        TESTIRANJE RESTAURANT API - BAZE
//      */

//        [TestMethod]
//        public async Task RegistracijaPost()
//        {
//            var payload = "{\"id\":3,\"username\":\"NOVIME\",\"password\":\"mojegedlo123\",\"name\":\"timotej\",\"surname\":\"medved\",\"email\":\"timotej.medved@student.um.si\",\"created\":\"2023-03-10T10:22:49.708Z\",\"salt\":\"string\"}";
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("/api/Auth/api/Auth/register", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }

//        [TestMethod]
//        public async Task PrijavaPost()
//        {
//            var payload = "{\"id\":0,\"username\":\"string\",\"password\":\"string\",\"name\":\"string\",\"surname\":\"string\",\"email\":\"string\",\"created\":\"2023-03-10T10:22:38.032Z\",\"salt\":\"string\"}";
//            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("/api/Auth/api/Auth/login", content);
//            var stringResult = await response.Content.ReadAsStringAsync();
//            var statusCode = response.IsSuccessStatusCode;
//            Assert.IsTrue(statusCode);
//        }



//    }
//}