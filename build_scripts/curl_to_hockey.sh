curl \
-F "ipa=@$2/build.ipa" \
-F "dsym=@$2/build.dSYM.zip" \
-F "status=2" \
-F "notify=0" \
-F "mandatory=0" \
-H "X-HockeyAppToken: 0377483fd3294309a5219ab48c2d3f95" \
https://rink.hockeyapp.net/api/2/apps/upload
