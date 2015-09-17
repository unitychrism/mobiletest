#!/bin/bash

EXPORTDIR=$1
OUTPUTDIR=$2
PLATFORM=$3

# supported here: ios, android
# supported by hockeyapp: ios (.ipa), android (.apk), osx (.app.zip)
case $PLATFORM in
  ios) # ipa = build.ipa, dsym = build.dSYM.zip
    IPA_ARG="-F 'ipa=@$OUTPUTDIR/build.ipa'"
    DSYM_ARG="-F 'dsym=@$OUTPUTDIR/build.dSYM.zip'"
    ;;
  android) # ipa = ExecutableName.apk, dsym = mapping.txt (not available)
    APK_FILENAME=$(basename "$(find $OUTPUTDIR -name '*.apk')")
    IPA_ARG="-F 'ipa=@$OUTPUTDIR/$APK_FILENAME'"
    DSYM_ARG=""
    ;;
  *) # unsupported platform for hockeyapp
    echo "HOCKEYAPP: Publish is unsupported for platform $PLATFORM, exiting."
    exit 1
    ;;
esac

echo "HOCKEYAPP: Publishing build artifacts for target $PLATFORM."

CMD="curl"
COMMON_ARGS="-F 'status=2'
-F 'notify=0'
-F 'mandatory=0'
-H 'X-HockeyAppToken: 0377483fd3294309a5219ab48c2d3f95'
https://rink.hockeyapp.net/api/2/apps/upload"

eval ${CMD} ${IPA_ARG} ${DSYM_ARG} ${COMMON_ARGS}
