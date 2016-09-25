using System;
using SQLite;
namespace WhosOnBreak
{
	[Table("FriendModel")]
	public class FriendModel
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string FriendName { get; set; }
		public int FriendId { get; set; }
	}
}
