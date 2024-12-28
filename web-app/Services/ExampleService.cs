using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using web_app.Models;

namespace web_app.Services;

public interface IExampleService
{
    Task<List<UserPost>> GetPosts();
}

public class ExampleService : IExampleService
{
    public ExampleService()
    {

    }


    public async Task<List<UserPost>> GetPosts()
    {
        var posts = new List<UserPost>();

        using var client = new HttpClient();
        try
        {
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                posts = JsonSerializer.Deserialize<List<UserPost>>(responseData);
            }
            else
            {
                Console.WriteLine($"Request failed. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return posts;
    }
}
