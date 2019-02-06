using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CsharpWebService
{
    class WebService
    {
        #region Atributos
        private string url;
        #endregion

        #region Constructor
        public WebService()
        {
            url = "https://jsonplaceholder.typicode.com/";
        }
        #endregion

        #region Metodos
        public void Menu()
        {
            Console.WriteLine("************************");
            Console.WriteLine("*** MENU DEL SISTEMA ***");
            Console.WriteLine("************************");
            Console.WriteLine("(0): Salir");
            Console.WriteLine("(1): Listar");
            Console.WriteLine("(2): Crear");
            Console.WriteLine("(3): Actualizar");
            Console.WriteLine("(4): Eliminar");
            Console.WriteLine("Seleccione una opcion: ");
        }

        public void ListAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // List all Post.    
                HttpResponseMessage response = client.GetAsync("posts").Result;

                if (response.IsSuccessStatusCode)
                {
                    var products = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(products);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public async void Create()
        {
            using (var client = new HttpClient())
            {
                Post postnew = new Post { userId = 1, title = "jonmid", body = "jonmid" };
                string content = JsonConvert.SerializeObject(postnew);

                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync("posts", byteContent).ConfigureAwait(false);
                //var response = client.PostAsync("posts", byteContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success Create");
                }
                else {
                    Console.WriteLine("Error Create");
                }
            }
        }

        public void Update()
        {
            using (var client = new HttpClient())
            {
                Post postupdate = new Post { userId = 1, title = "mideros", body = "mideros" };
                string content = JsonConvert.SerializeObject(postupdate);

                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var response = await client.PutAsync("posts/1", byteContent).ConfigureAwait(false);
                var response = client.PutAsync("posts/100", byteContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success Update");
                }
                else
                {
                    Console.WriteLine("Error Update");
                }
            }
        }

        public void Delete()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var response = client.DeleteAsync("posts/9999").Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success Delete");
                }
                else
                {
                    Console.WriteLine("Error Delete");
                }
            }
        }
        #endregion
    }
}
