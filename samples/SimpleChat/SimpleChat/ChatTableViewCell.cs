using System;

using Foundation;
using UIKit;

using Xamarin.TTTAttributedLabel;

namespace SimpleChat
{
	public partial class ChatTableViewCell : UITableViewCell, ITTTAttributedLabelDelegate
	{
		public static readonly NSString ReuseId = new NSString ("ChatTableViewCell");


		TTTAttributedLabel _bodyLabel;
		public TTTAttributedLabel BodyLabel {
			get {
				if (_bodyLabel == null) {
					_bodyLabel = new TTTAttributedLabel {
						TranslatesAutoresizingMaskIntoConstraints = false,
						BackgroundColor = UIColor.White,
						UserInteractionEnabled = true,
						Lines = 0,
						TextColor = AttributedStringUtil.MessageColor,
						Font = AttributedStringUtil.DefaultFont,
						LinkAttributes = AttributedStringUtil.LinkStringAttributes.Dictionary,
						EnabledTextCheckingTypes = NSTextCheckingType.Link,
						WeakDelegate = this
					};
				}
				return _bodyLabel;
			}
		}


		public ChatTableViewCell (IntPtr handle) : base (handle)
		{
			BackgroundColor = UIColor.White;
			SelectionStyle = UITableViewCellSelectionStyle.None;

			configureSubviews ();
			configureConstraints ();
		}


		public override void PrepareForReuse ()
		{
			base.PrepareForReuse ();

			SelectionStyle = UITableViewCellSelectionStyle.None;
		}


		void configureSubviews () => ContentView.AddSubview (BodyLabel);


		void configureConstraints ()
		{
			var views = new NSDictionary (
				new NSString (@"bodyLabel"), BodyLabel
			);

			var metrics = new NSDictionary (
				new NSString (@"tumbSize"), NSNumber.FromNFloat (30),
				new NSString (@"right"), NSNumber.FromNFloat (10)
			);

			ContentView.AddConstraints (NSLayoutConstraint.FromVisualFormat (@"H:|-tumbSize-[bodyLabel(>=0)]-right-|", 0, metrics, views));
			ContentView.AddConstraints (NSLayoutConstraint.FromVisualFormat (@"V:|[bodyLabel]|", 0, metrics, views));
		}


		public virtual void SetMessage (NSAttributedString message) => BodyLabel.SetText (message);


		[Export ("attributedLabel:didSelectLinkWithURL:")]
		public void DidSelectLinkWithURL (TTTAttributedLabel label, NSUrl url)
		{
			UIApplication.SharedApplication.OpenUrl (url);

			System.Diagnostics.Debug.WriteLine ($"DidSelectLinkWithURL Label = {label}, Url = {url})");
		}
	}
}