using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WhosOnBreak
{
	public class RestService : IRestService
	{
		const string RestUrl = "http://54.173.202.54/api/";

		HttpClient client;

		public List<NotifModelJson> Notifs { get; private set; }
		public UserModelJson User { get; private set; }

		public RestService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<List<NotifModelJson>> RefreshNotifsAsync(string ownId)
		{
			Notifs = new List<NotifModelJson>();

			var uri = new Uri(RestUrl + "notifs?notifTo=" + ownId);

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Notifs = JsonConvert.DeserializeObject<List<NotifModelJson>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

			return Notifs;
		}

		public async Task<UserModelJson> GetUserAsync(string id)
		{
			User = new UserModelJson();

			var uri = new Uri(RestUrl + "users/" + id);

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					User = JsonConvert.DeserializeObject<UserModelJson>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

			return User;
		}

		public async Task SaveNotifAsync(NotifModelJson notifItem)
		{
			var uri = new Uri(RestUrl + "notifs");

			try
			{
				var json = JsonConvert.SerializeObject(notifItem);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				Debug.WriteLine(await content.ReadAsStringAsync());

				HttpResponseMessage response = null;
				response = await client.PostAsync(uri, content);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully saved.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

		public async Task SaveUserAsync(UserModelJson userItem, bool isNewItem = false)
		{
			var uri = new Uri(RestUrl + "users");

			try
			{
				var json = JsonConvert.SerializeObject(userItem);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				Debug.WriteLine(await content.ReadAsStringAsync());

				HttpResponseMessage response = null;
				if (isNewItem)
				{
					response = await client.PostAsync(uri, content);
				}
				else
				{
					response = await client.PutAsync(new Uri(RestUrl + "deuces/" + userItem.Id), content);
				}

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully saved.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteNotifsAsync(string id)
		{
			var uri = new Uri(RestUrl + "notifs/" + id);

			try
			{
				var response = await client.DeleteAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully deleted.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}
	}
}
