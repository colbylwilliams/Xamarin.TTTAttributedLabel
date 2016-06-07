using System;

using Foundation;
using UIKit;

namespace SimpleChat
{
	public static class AttributedStringUtil
	{
		public static UIFont DefaultFont = UIFont.SystemFontOfSize (16);


		public static UIColor MessageColor = UIColor.FromRGBA (44f / 255f, 45f / 255f, 48f / 255f, 255f / 255f);

		public static UIColor MessageLinkColor = UIColor.FromRGBA (43f / 255f, 128f / 255f, 185f / 255f, 255f / 255f);


		public static NSMutableParagraphStyle MessageParagraphStyle = new NSMutableParagraphStyle {
			LineBreakMode = UILineBreakMode.WordWrap,
			Alignment = UITextAlignment.Left
		};


		public static UIStringAttributes MessageStringAttributes = new UIStringAttributes {
			Font = DefaultFont,
			ParagraphStyle = MessageParagraphStyle,
			ForegroundColor = MessageColor
		};


		public static UIStringAttributes BoldStringAttributes = new UIStringAttributes {
			Font = UIFont.BoldSystemFontOfSize (16),
			ParagraphStyle = MessageParagraphStyle,
			ForegroundColor = MessageColor
		};


		public static UIStringAttributes LinkStringAttributes = new UIStringAttributes {
			Font = DefaultFont,
			UnderlineStyle = NSUnderlineStyle.Single,
			ParagraphStyle = MessageParagraphStyle,
			ForegroundColor = MessageLinkColor
		};


		static readonly NSUrl link = NSUrl.FromString ("https://github.com/colbylwilliams/Xamarin.TTTAttributedLabel");


		public static NSMutableAttributedString GetMessageAttributedString (this string message, string boldWord, bool mockLink = false)
		{
			var attrString = new NSMutableAttributedString (message);

			attrString.AddAttributes (MessageStringAttributes, new NSRange (0, message.Length));

			var range = new NSRange (message.IndexOf (boldWord, StringComparison.Ordinal), boldWord.Length);

			if (mockLink) {

				attrString.AddAttribute (UIStringAttributeKey.Link, link, range);

				attrString.AddAttributes (LinkStringAttributes, range);

			} else {

				attrString.AddAttributes (BoldStringAttributes, range);
			}

			return attrString;
		}
	}
}