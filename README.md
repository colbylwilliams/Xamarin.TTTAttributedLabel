# Xamarin.TTTAttributedLabel

A Xamarin.iOS binding for [TTTAttributedLabel][0]


## Installation
Either add the [Xamarin.TTTAttributedLabel NuGet package][2] to your Xamarin.iOS project (recommended), or clone this repo, build using the steps below, and reference the TTTAttributedLabel project from your Xamarin.iOS project.


## Usage
Examples ported from [TTTAttributedLabel Usage][1] section.

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


## Building

To build, run `make` in the `extern` directory. Then open `bindings/TTTAttributedLabel/TTTAttributedLabel.sln` in Xamarin Studio and build.

### Requirements

* Xamarin Studio 6.0+ (`XBuild`)
* `xcodebuild`


## Todo

* Sample project
* Xamarin Component


## License

`Xamarin.TTTAttributedLabel` is available under the MIT license. See the LICENSE file for more info.

[0]:https://github.com/TTTAttributedLabel/TTTAttributedLabel
[1]:https://github.com/TTTAttributedLabel/TTTAttributedLabel#usage
[2]:https://www.nuget.org/packages/Xamarin.TTTAttributedLabel