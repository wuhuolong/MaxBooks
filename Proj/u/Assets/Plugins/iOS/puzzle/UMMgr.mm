//
//  UMMgr.m
//  Unity-iPhone
//
//  Created by UYOFUN_MAC_PRO on 2019/11/5.
//

#import <UMCommon/UMCommon.h>
#import <UMAnalytics/MobClick.h>
#import <UMCommonLog/UMCommonLogHeaders.h>
#import "UMMgr.h"
@interface UMMgr()

@end

@implementation UMMgr
static NSString *appid = @"5dc125e40cafb280ab0008cd";
static NSString *channelid = @"ly-puzzle-dev";

static UMMgr *_ins = nil;

+ (UMMgr *)sharedInstance{
    if(_ins == nil){
        _ins = [[UMMgr alloc] init];
    }
    return _ins;
}

- (void) SetUp{
    [UMCommonLogManager setUpUMCommonLogManager];
    [UMConfigure setLogEnabled:NO];//使用日志
    [MobClick setScenarioType:E_UM_NORMAL];//设置场景
    [UMConfigure initWithAppkey:appid channel:channelid];//初始化
}
- (void) Track:(NSString *)eventlabel{
    [MobClick event:eventlabel];
}

- (void) Track:(NSString *)eventlabel Dic:(NSDictionary *)params{
    [MobClick event:eventlabel attributes:params];
}
@end
