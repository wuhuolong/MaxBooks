//
//  BuglyMgr.m
//  layabox
//
//  Created by admin on 2019/7/23.
//  Copyright © 2019年 layabox. All rights reserved.
//

#import "BuglyMgr.h"

@implementation BuglyMgr

static BuglyMgr* _instance = nil;
static NSString * _appid = @"8a2d92c667";
//static NSString * _appkey = @"9eafa1d1-49cd-4d1c-9964-3952c70426ef";
+ (BuglyMgr*) sharedInstance
{
    if (_instance == nil)
    {
        _instance = [[BuglyMgr alloc] init];
    }
    return _instance;
}

+ (void) SetUserId:(NSString *) userId
{
    NSLog(@"BuglyMgr SetUserId");
    [Bugly setUserIdentifier:userId];
}

+ (void) SetTag:(NSNumber *) tag
{
    NSLog(@"BuglyMgr SetTag");
    [Bugly setTag:[tag integerValue]];
}

+ (void) PostException:(NSString *) logStr
{
    NSLog(@"BuglyMgr Post logic error");
    NSError *error = [NSError errorWithDomain:@"ErrorDomain" code:10000 userInfo:@{NSLocalizedDescriptionKey:logStr}];
    [Bugly reportError:error];
}

- (void) setup
{
//    BuglyConfig * config = [[BuglyConfig alloc] init];
//    config.delegate = self;
//    [Bugly startWithAppId:@"b5eca119c9" config:config];
    
    [Bugly startWithAppId:_appid config:^{
        BuglyConfig *config = [[BuglyConfig alloc] init];
        config.blockMonitorEnable = YES;
        config.blockMonitorTimeout = 2;
        config.consolelogEnable = YES;
        config.delegate = self;
        return config;
    }()];
}

- (NSString *)attachmentForException:(NSException *)exception {
    NSLog(@"(%@:%d) %s %@",[[NSString stringWithUTF8String:__FILE__] lastPathComponent], __LINE__, __PRETTY_FUNCTION__,exception);
    return @"This is an attachment";
}

@end
