IOS_RELEASE=1.13.4

CONFIGURATION=Release

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
TARGET=TTTAttributedLabel
PROJECT=TTTAttributedLabel.xcodeproj
FRAMEWORK=TTTAttributedLabel.framework

all : clean $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)

TTTAttributedLabel/README.md :
	git clone git@github.com:TTTAttributedLabel/TTTAttributedLabel.git
	cd TTTAttributedLabel && git checkout $(IOS_RELEASE)

$(CONFIGURATION)-iphoneos/$(FRAMEWORK) : TTTAttributedLabel/README.md
	cd TTTAttributedLabel/Carthage && $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration $(CONFIGURATION) clean build
	-mv TTTAttributedLabel/Carthage/build/$(CONFIGURATION)-iphoneos ./

$(CONFIGURATION)-iphonesimulator/$(FRAMEWORK) : $(CONFIGURATION)-iphoneos/$(FRAMEWORK)
	cd TTTAttributedLabel/Carthage && $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration $(CONFIGURATION) clean build
	-mv TTTAttributedLabel/Carthage/build/$(CONFIGURATION)-iphonesimulator ./

$(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK) : $(CONFIGURATION)-iphonesimulator/$(FRAMEWORK)
	mkdir -p $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)
	cp -r $(CONFIGURATION)-iphoneos/$(FRAMEWORK)/. $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)
	lipo $(CONFIGURATION)-iphonesimulator/$(FRAMEWORK)/$(TARGET) $(CONFIGURATION)-iphoneos/$(FRAMEWORK)/$(TARGET) -create -output $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)/$(TARGET)

clean :
	rm -rf TTTAttributedLabel
	rm -rf $(CONFIGURATION)-iphoneos
	rm -rf $(CONFIGURATION)-iphonesimulator
	rm -rf $(CONFIGURATION)-iphoneuniversal