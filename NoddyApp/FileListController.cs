using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace NoddyApp
{
	partial class FileListController : UITableViewController
	{
		private readonly string _fileListCellId = new NSString ("FileListCell");

		public FileListController (IntPtr handle) : base (handle)
		{
			Files = new List<string> {
				"Wash your face",
				"Go to bed",
				"Clean your teeth",
				"I said NO"
			};
		}

		public List<string> Files { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.RegisterClassForCellReuse (typeof(UITableViewCell), _fileListCellId);
			TableView.DataSource = new FileListDataSource (Files, _fileListCellId);
		}

		public class FileListDataSource : UITableViewDataSource
		{
			private readonly List<string> _files;
			private readonly string _cellId;

			public FileListDataSource (List<string> files, string cellId)
			{
				_files = files;
				_cellId = cellId;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (_cellId);

				cell.TextLabel.Text = _files [indexPath.Row];
				return cell;
			}

			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return _files.Count ();
			}
		}
	}
}
