IOS_RELEASE=2.0.0

CONFIGURATION=Release

XCODEBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
TARGET=TTTAttributedLabel
PROJECT=TTTAttributedLabel.xcodeproj
FRAMEWORK=TTTAttributedLabel.framework

all : clean ../binding/TTTAttributedLabel/TTTAttributedLabel/bin/$(CONFIGURATION)/Xamarin.TTTAttributedLabel.dll

TTTAttributedLabel/README.md :
	git clone git@github.com:TTTAttributedLabel/TTTAttributedLabel.git
	cd TTTAttributedLabel && git checkout $(IOS_RELEASE)

$(CONFIGURATION)-iphoneos/$(FRAMEWORK) : TTTAttributedLabel/README.md
	cd TTTAttributedLabel/Carthage && $(XCODEBUILD) OTHER_CFLAGS="-fembed-bitcode" -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration $(CONFIGURATION) clean build
	-mv TTTAttributedLabel/Carthage/build/$(CONFIGURATION)-iphoneos ./

$(CONFIGURATION)-iphonesimulator/$(FRAMEWORK) : $(CONFIGURATION)-iphoneos/$(FRAMEWORK)
	cd TTTAttributedLabel/Carthage && $(XCODEBUILD) OTHER_CFLAGS="-fembed-bitcode" -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration $(CONFIGURATION) clean build
	-mv TTTAttributedLabel/Carthage/build/$(CONFIGURATION)-iphonesimulator ./

$(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK) : $(CONFIGURATION)-iphonesimulator/$(FRAMEWORK)
	mkdir -p $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)
	cp -r $(CONFIGURATION)-iphoneos/$(FRAMEWORK)/. $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)
	lipo $(CONFIGURATION)-iphonesimulator/$(FRAMEWORK)/$(TARGET) $(CONFIGURATION)-iphoneos/$(FRAMEWORK)/$(TARGET) -create -output $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)/$(TARGET)

$(CONFIGURATION)-binding/ApiDefinitions.cs : $(CONFIGURATION)-iphoneuniversal/$(FRAMEWORK)
	mkdir -p $(CONFIGURATION)-binding
	cp extras/ApiDefinitions.cs $(CONFIGURATION)-binding
	cp extras/StructsAndEnums.cs $(CONFIGURATION)-binding
	# sharpie bind \
	# 	-n Xamarin.TTTAttributedLabel \
	# 	-o $(CONFIGURATION)-binding \
	# 	-sdk iphoneos \
	# 	TTTAttributedLabel/TTTAttributedLabel/TTTAttributedLabel.h

../binding/TTTAttributedLabel/TTTAttributedLabel/bin/$(CONFIGURATION)/Xamarin.TTTAttributedLabel.dll : $(CONFIGURATION)-binding/ApiDefinitions.cs
	cd ../binding/TTTAttributedLabel/TTTAttributedLabel && XBuild /p:Configuration=$(CONFIGURATION)
	cd ../binding/TTTAttributedLabel/TTTAttributedLabel && nuget pack TTTAttributedLabel.nuspec

clean :
	# rm -rf TTTAttributedLabel
	rm -rf $(CONFIGURATION)-binding
	rm -rf $(CONFIGURATION)-iphoneos
	rm -rf $(CONFIGURATION)-iphonesimulator
	rm -rf $(CONFIGURATION)-iphoneuniversal