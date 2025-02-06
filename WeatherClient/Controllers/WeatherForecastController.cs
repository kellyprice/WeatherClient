using Microsoft.AspNetCore.Mvc;

namespace WeatherClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string apiUrl = "https://serverapp-hegecdf0gzgteea4.canadacentral-01.azurewebsites.net/weatherforecast";

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseData = await response.Content.ReadAsStringAsync();

                        return Ok(responseData);
                    }
                    else
                    {
                        // Output the status code if the request was not successful
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors that occurred during the request
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }

            return Ok();
        }
    }
}
