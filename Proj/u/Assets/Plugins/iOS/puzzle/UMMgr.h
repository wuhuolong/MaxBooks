//
//  UMMgr.m
//  Unity-iPhone
//
//  Created by UYOFUN_MAC_PRO on 2019/11/5.
//

#import <Foundation/Foundation.h>
#import <UMCommon/UMCommon.h>
NS_ASSUME_NONNULL_BEGIN

@interface UMMgr : NSObject

+ (UMMgr*) sharedInstance;
- (void) SetUp;
- (void) Track:(NSString *)eventlabel;
- (void) Track:(NSString *)eventlabel Dic:(NSDictionary *)params;
@end

NS_ASSUME_NONNULL_END
