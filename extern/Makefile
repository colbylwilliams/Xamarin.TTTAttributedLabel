IOS_RELEASE=1.13.4

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT=TTTAttributedLabel.xcodeproj
TARGET=TTTAttributedLabel

all : clean Release-iphonesimulator/TTTAttributedLabel.framework

TTTAttributedLabel/README.md :
	git clone git@github.com:TTTAttributedLabel/TTTAttributedLabel.git
	cd TTTAttributedLabel && git checkout $(IOS_RELEASE)

Release-iphoneos/TTTAttributedLabel.framework : TTTAttributedLabel/README.md
	cd TTTAttributedLabel/Carthage && $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration Release clean build
	-mv TTTAttributedLabel/Carthage/build/Release-iphoneos ./

Release-iphonesimulator/TTTAttributedLabel.framework : Release-iphoneos/TTTAttributedLabel.framework
	cd TTTAttributedLabel/Carthage && $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv TTTAttributedLabel/Carthage/build/Release-iphonesimulator ./
	rm -rf TTTAttributedLabel

clean :
	rm -rf TTTAttributedLabel
	rm -rf Release-iphoneos
	rm -rf Release-iphonesimulator