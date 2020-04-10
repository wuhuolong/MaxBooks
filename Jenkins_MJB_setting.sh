#!/bin/sh +x
. /etc/profile

BASH_PROFILE="$HOME/.bash_profile"

if [ -f "$BASH_PROFILE" ]; then
. $BASH_PROFILE
fi

set -e

echo ${WORKSPACE}/${ProjectRoot}
echo ${WORKSPACE}/data/导表工具
echo ${WORKSPACE}/data/$CFG_DATA_VERSION/$CFG_DATA_TYPE/配置表

security unlock-keychain -p "zjxf_raorui321" ~/Library/Keychains/login.keychain

export NOTIFY_USERS="wuhuolong|liuzhihua"
export RES_VERSION_STR=${BUILD_NUMBER}-svn${SVN_REVISION_1}-${SVN_REVISION_2}-${SVN_REVISION_3}

sh ${WORKSPACE}/trunk/IOS/auto_ios_build.sh ${WORKSPACE}/${ProjectRoot} ${WORKSPACE}/data/$CFG_DATA_VERSION/$CFG_DATA_TYPE/配置表 ${WORKSPACE}/data/导表工具
