# Getting Started with TTTAttributedLabel

`TTTAttributedLabel` can display both plain and attributed text: just pass an `NSString` or `NSAttributedString` to the `SetText`. Never assign to the `AttributedText` property.

``` C#
// NSAttributedString

var attributedLabel = new TTTAttributedLabel ();

var attString = new NSAttributedString ("Tom Bombadil", new UIStringAttributes {
	ForegroundColor = UIColor.Red,
	Font = UIFont.BoldSystemFontOfSize (16),
	KerningAdjustment = null,
	BackgroundColor = UIColor.Green
});

// The attributed string is directly set, without inheriting any other text
// properties of the label.
attributedLabel.SetText(attString);
```

``` C#
// NSString

TTTAttributedLabel label = new TTTAttributedLabel ();
label.Font = UIFont.SystemFontOfSize (14);
label.TextColor = UIColor.DarkGray;
label.LineBreakMode = UILineBreakMode.WordWrap;
label.Lines = 0;

// If you're using a simple `NSString` for your text,
// assign to the `text` property last so it can inherit other label properties.
NSString text = new NSString ("Lorem ipsum dolor sit amet");

label.SetText (text, (NSMutableAttributedString mutableAttributedString) => {

	var boldText = "ipsum dolor";
	var strikeText = "sit amet";

	var boldRange = new NSRange (mutableAttributedString.ToString ().IndexOf (boldText, StringComparison.OrdinalIgnoreCase), boldText.Length);
	var strikeRange = new NSRange (mutableAttributedString.ToString ().IndexOf (strikeText, StringComparison.OrdinalIgnoreCase), strikeText.Length);

	var boldSystemFont = UIFont.BoldSystemFontOfSize (14);

	mutableAttributedString.AddAttribute (UIStringAttributeKey.Font, boldSystemFont, boldRange);
	mutableAttributedString.AddAttribute (TTTAttributeNames.StrikeOut, NSObject.FromObject (true), strikeRange);

	return mutableAttributedString;
});
```
First, we create and configure the label, the same way you would instantiate `UILabel`. Any text properties that are set on the label are inherited as the base attributes when using the `SetText` method. In this example, the substring "ipsum dolar", would appear in bold, such that the label would read "Lorem **ipsum dolar** sit amet", in size 14 Helvetica, with a dark gray color.
