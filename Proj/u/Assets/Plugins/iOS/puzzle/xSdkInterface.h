//
//  xSdkInterface.h
//  Unity-iPhone
//
//  Created by UYOFUN_MAC_PRO on 2019/10/30.
//


#import <Foundation/Foundation.h>
NS_ASSUME_NONNULL_BEGIN


@interface xSdkInterface : NSObject



+ (void)OnwillFinishLaunchingWithOptions;
+ (void)OnApplicationDidBecomeActive;
+ (void)OnApplicationDidEnterBackground;
+ (void)OnApplicationWillEnterForeground;
+ (void)SendMsg2Unity:(NSString *)json;
+(NSString *)Dic2Json:(NSDictionary *)dic;
+(NSDictionary *)Json2Dic:(NSString *)json;
@end

NS_ASSUME_NONNULL_END
