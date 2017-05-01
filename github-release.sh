#!/bin/bash


set -e

REPO=$1 && shift
RELEASE=$1 && shift
RELEASEFILES=$@

if ! TAG=`git describe --exact-match --tags 2>/dev/null`; then
  echo "This commit is not a tag so not creating a release"
  exit 0
fi

if [ "$TRAVIS" = "true" ] && [ -z "$TRAVIS_TAG" ]; then
  echo "This build is not for the tag so not creating a release"
  exit 0
fi

if [ "$TRAVIS" = "true" ] && [ "$TRAVIS_TAG" != "$RELEASE" ]; then
  echo "Error: TRAVIS_TAG ($TRAVIS_TAG) does not match the indicated release ($RELEASE)"
  exit 1
fi

if [ "$TAG" != "$RELEASE" ]; then
  echo "Error: The tag ($TAG) does not match the indicated release ($RELEASE)"
  exit 1
fi

if [[ -z "$RELEASEFILES" ]]; then
  echo "Error: No release files provided"
  exit 1
fi

SCRIPTDIR=`dirname $0`
[ -e "$SCRIPTDIR/GITHUBTOKEN" ] && . "$SCRIPTDIR/GITHUBTOKEN"
if [[ -z "$GITHUBTOKEN" ]]; then
  echo "Error: GITHUBTOKEN is not set"
  exit 1
fi

echo "Checking if GitHub release for $RELEASE exists already"
RESULT=`curl -s -w "\n%{http_code}\n"     \
  -H "Authorization: token $GITHUBTOKEN"  \
  "https://api.github.com/repos/$REPO/releases/tags/$RELEASE"`
if [ "`echo "$RESULT" | tail -1`" = "404" ]; then
  echo "Creating GitHub release for $RELEASE"
  RELEASENEW=true

  echo -n "Create draft release... "
JSON=$(cat <<EOF
{
  "tag_name":         "$TAG",
  "target_commitish": "master",
  "name":             "$TAG",
  "draft":            true,
  "prerelease":       false
}
EOF
)
  RESULT=`curl -s -w "\n%{http_code}\n"     \
    -H "Authorization: token $GITHUBTOKEN"  \
    -d "$JSON"                              \
    "https://api.github.com/repos/$REPO/releases"`
  if [ "`echo "$RESULT" | tail -1`" != "201" ]; then
    echo FAILED
    echo "$RESULT" 
    exit 1
  fi 
  RELEASEID=`echo "$RESULT" | sed -ne 's/^  "id": \(.*\),$/\1/p'`
  if [[ -z "$RELEASEID" ]]; then
    echo FAILED
    echo "$RESULT" 
    exit 1
  fi
  echo DONE
elif [ "`echo "$RESULT" | tail -1`" = "200" ]; then
  echo "GitHub release $RELEASE existing, adding assets."
  RELEASEID=`echo "$RESULT" | sed -ne 's/^  "id": \(.*\),$/\1/p'`
  echo "Release ID: \"$RELEASEID\""
else
  echo "Error: No release files provided"
  exit 1
fi

for FILE in $RELEASEFILES; do
  if [ ! -f $FILE ]; then
    echo "Warning: $FILE not a file"
    continue
  fi
  FILESIZE=`stat -c '%s' "$FILE"`
  FILENAME=`basename $FILE`
  echo -n "Uploading $FILENAME... "
  RESULT=`curl -s -w "\n%{http_code}\n"                   \
    -H "Authorization: token $GITHUBTOKEN"                \
    -H "Accept: application/vnd.github.manifold-preview"  \
    -H "Content-Type: application/octet-stream"           \
    --data-binary "@$FILE"                                \
    "https://uploads.github.com/repos/$REPO/releases/$RELEASEID/assets?name=$FILENAME"`
  if [ "`echo "$RESULT" | tail -1`" != "201" ]; then
    echo FAILED
    echo "$RESULT" 
    exit 1
  fi
  echo DONE
done 

if [ "$RELEASENEW" = true ]; then
  echo -n "Publishing release... "
JSON=$(cat <<EOF
{
  "draft": false
}
EOF
)
  RESULT=`curl -s -w "\n%{http_code}\n"     \
    -X PATCH                                \
    -H "Authorization: token $GITHUBTOKEN"  \
    -d "$JSON"                              \
    "https://api.github.com/repos/$REPO/releases/$RELEASEID"`
  if [ "`echo "$RESULT" | tail -1`" = "200" ]; then
    echo DONE
  else
    echo FAILED
    echo "$RESULT"
    exit 1
  fi
fi