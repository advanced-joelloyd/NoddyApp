using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NoddyApp
{
	public class FileStore
	{
		private readonly string _filePath;

		public FileStore (string filePath)
		{
			_filePath = filePath;
		}

		public IEnumerable<string> GetFiles()
		{
			var files = Directory.GetFiles (_filePath).Select(f => Path.GetFileName(f));
			return files;
		}

		public void AddFile(string content)
		{
			var fileName = Path.Combine(_filePath, Guid.NewGuid() + ".txt");
			File.WriteAllText (fileName, content);
		}

		public string GetContent(string fileName)
		{
			return File.ReadAllText (Path.Combine (_filePath, fileName));	
		}
	}
}
