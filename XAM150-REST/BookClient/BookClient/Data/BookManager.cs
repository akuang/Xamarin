using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public class BookManager
    {
        const string Url = "http://xam150.azurewebsites.net/api/books";
        private string authorizationKey = string.Empty;

        public async Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
            List<Book> books = new List<Book>();

            using (var httpClient = await GetHttpClient())
            {
                string json = await httpClient.GetStringAsync(Url);
                if (!string.IsNullOrEmpty(json))
                {
                    books = JsonConvert.DeserializeObject<List<Book>>(json);
                }
            }

            return books;
        }

        public async Task<Book> Add(string title, string author, string genre)
        {
            // TODO: use POST to add a book
            Book book = new Book
            {
                Title = title,
                ISBN = string.Empty,
                Authors = new List<string> { author },
                Genre = genre,
                PublishDate = DateTime.Today
            };

            using (var httpClient = await GetHttpClient())
            {
                string json = JsonConvert.SerializeObject(book);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(Url, content);
                var result = await response.Content.ReadAsStringAsync();
                Book bookAdded = JsonConvert.DeserializeObject<Book>(result);

                return bookAdded;
            }
        }

        public async Task Update(Book book)
        {
            // TODO: use PUT to update a book
            string json = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using(var httpClient = await GetHttpClient())
            {
                var result = await httpClient.PutAsync($"{Url}/{book.ISBN}", content);
            }
        }

        public async Task Delete(string isbn)
        {
            // TODO: use DELETE to delete a book
            using (var httpClient = await GetHttpClient())
            {
                var result = await httpClient.DeleteAsync($"{Url}/{isbn}");
            }
        }

        private async Task<HttpClient> GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await httpClient.GetStringAsync($"{Url}/login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey ?? string.Empty);
            }

            if (!string.IsNullOrEmpty(authorizationKey))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                return httpClient;
            }

            throw new Exception($"Unable to get authentication key from {Url}/login");
        }
    }
}

