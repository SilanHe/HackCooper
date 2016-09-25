using SQLite;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace WhosOnBreak
{
	public class UserRepository
	{
		private readonly SQLiteConnection conn;

		public string StatusMessage { get; set; }


		public UserRepository(string dbPath)
		{
			conn = new SQLiteConnection(dbPath);
			conn.CreateTable<UserModel>();
		}

		public void AddNewUser(string name, int apiId)
		{
			if (conn.Table<UserModel>().Count() == 0)
			{
				conn.Insert(new UserModel
				{
					Id = 1,
					Name = name,
					ApiId = apiId
				});
			}

		}

		public UserModel GetUser()
		{
			if (conn.Table<UserModel>().Count() != 0)
			{
				return conn.Table<UserModel>().First();
			}
			else
			{
				return new UserModel() { Id = 99999999, Name = null };
			}

		}

		public void UpdateUser(string name)
		{
			conn.Execute("UPDATE UsersModel Set FirstName = ? Where ID = 1", name);
		}


		public void ClearUsers()
		{
			conn.Execute($"DELETE FROM [UsersModel]");
		}
	}
}
