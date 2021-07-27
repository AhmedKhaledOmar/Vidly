using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class API
    {
		public static async Task<string> GetAsync(string url)
		{
			HttpClient client = new HttpClient();
			var response = await client.GetAsync(url);
			var jsonString = await response.Content.ReadAsStringAsync();
			return jsonString;
		}

		public static async Task<string> PostAsync<T>(string Url, T Obj)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			var response = await client.PostAsJsonAsync(Url, Obj);
			var jsonstring = await response.Content.ReadAsStringAsync();
			return jsonstring;
		}

		public static async Task<string> PutAsync<T>(string Url, T Obj)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			var response = await client.PostAsJsonAsync(Url, Obj);
			var jsonstring = await response.Content.ReadAsStringAsync();
			return jsonstring;
		}
	}
}