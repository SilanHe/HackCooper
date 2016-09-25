using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WhosOnBreak
{
	public class FriendsRepository
	{
		private readonly SQLiteAsyncConnection conn;

		public FriendsRepository(string dbpath)
		{
			conn = new SQLiteAsyncConnection(dbpath);
			conn.CreateTableAsync<FriendModel>().Wait();
		}

		public async Task AddNewFriendAsync(string friendsName, int friendsId)
		{
			await conn.InsertAsync(new FriendModel
			{
				FriendName = friendsName,
				FriendId = friendsId
			});
		}

		public async Task<List<FriendModel>> GetFriendsAsync()
		{
			return await conn.Table<FriendModel>().ToListAsync();
		}

		public async Task ClearFriendsAsync()
		{
			await conn.RunInTransactionAsync(connection =>
			{
				connection.Execute($"DELETE FROM [FriendModel]");
			});
		}
	}
}
