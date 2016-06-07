using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace SimpleChat
{
	public partial class ChatTableViewController : UITableViewController
	{
		readonly List<NSAttributedString> Messages = new List<NSAttributedString> ();


		public ChatTableViewController (IntPtr handle) : base (handle) { }


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var messageString = "Lorem ipsum dolor sit amet";

			var wordArray = messageString.Split (' ');

			for (int i = 0; i < 20; i++) {
				for (int ii = 0; ii < wordArray.Length; ii++)
					Messages.Add (messageString.GetMessageAttributedString (wordArray [ii]));

				Messages.Add ("Xamarin.TTTAttributedLabel".GetMessageAttributedString ("Xamarin.TTTAttributedLabel", true));
			}
		}


		public override nint NumberOfSections (UITableView tableView) => 1;


		public override nint RowsInSection (UITableView tableView, nint section) => Messages.Count;


		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = TableView.DequeueReusableCell (ChatTableViewCell.ReuseId, indexPath) as ChatTableViewCell;

			var message = Messages [indexPath.Row];

			cell.SetMessage (message);

			return cell;
		}
	}
}