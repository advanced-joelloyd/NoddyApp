using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NoddyApp
{
	partial class FileListController : UITableViewController
	{
		private readonly string _fileListCellId = new NSString ("FileListCell");

		public FileListController (IntPtr handle) : base (handle)
		{
			Files = new List<string> ();
		}

		public List<string> Files { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var documents = new FileStore(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			documents.AddFile ("Clean your teeth");
	
			TableView.RegisterClassForCellReuse (typeof(UITableViewCell), _fileListCellId);
			TableView.Source = new FileListDataSource (documents, _fileListCellId);
		}

		public class FileListDataSource : UITableViewSource
		{
			private readonly FileStore _files;
			private List<string> _fileCache;
			private readonly string _cellId;

			public FileListDataSource (FileStore files, string cellId)
			{
				_files = files;
				_cellId = cellId;
				_fileCache = _files.GetFiles().ToList();
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (_cellId);

				cell.TextLabel.Text = _fileCache [indexPath.Row];
				return cell;
			}

			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return _fileCache.Count ();
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var fileName = _fileCache [indexPath.Row];
				new UIAlertView (fileName, _files.GetContent(fileName), null, "OK").Show();
				tableView.DeselectRow (indexPath, true);
			}
		}
	}
}
