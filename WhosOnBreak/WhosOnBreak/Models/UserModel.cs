using System;
using SQLite;
namespace WhosOnBreak
{
	[Table("UsersModel")]
	public class UserModel
	{

		/// <summary>
		/// Model associoted with the one user
		/// </summary>

		[PrimaryKey]
		public int Id { get; set; }
		public string Name { get; set; }

		public UserModel()
		{
		}
	}
}
