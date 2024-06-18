using EShopAdminApplication.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace EShopAdminApplication.Controllers
{
    public class UserController : Controller
    {
        //public UserManager<EShopApplicationUser> usermanager;
        //public UserController(UserManager<EShopApplicationUser> usermanager)
        //{
        //    this.usermanager = usermanager;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportProducts(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<Product> users = getAllProductsFromFile(file.FileName);
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44369/api/Admin/ImportAllProducts";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");

        }

        private List<Product> getAllProductsFromFile(string fileName)
        {
            List<Product> products = new List<Product>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using(var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        products.Add(new Models.Product
                        {
                            ProductName = reader.GetValue(0).ToString(),
                            ProductDescription = reader.GetValue(1).ToString(),
                            ProductImage = reader.GetValue(2).ToString(),
                            Price = (int)reader.GetValue(3)
                        });
                    }

                }
            }
            return products;

        }
    }
}
