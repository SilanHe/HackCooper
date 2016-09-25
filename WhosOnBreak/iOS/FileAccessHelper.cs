using System;
namespace WhosOnBreak.iOS
{
	public class FileAcessHelper
	{
		public FileAcessHelper()
		{
		}

		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

			if (!System.IO.Directory.Exists(libFolder))
			{
				System.IO.Directory.CreateDirectory(libFolder);
			}

			return System.IO.Path.Combine(libFolder, filename);
		}
	}
}
