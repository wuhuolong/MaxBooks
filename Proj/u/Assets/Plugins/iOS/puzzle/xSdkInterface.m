//
//  SdkInterface.m
//  Unity-iPhone
//
//  Created by UYOFUN_MAC_PRO on 2019/10/30.
//

#import <Foundation/Foundation.h>
#import "BuglyMgr.h"
#import "GADManager.h"

@interface xSdkInterface :NSObject
//@property (nonatomic, retain) UIViewController* viewController;

@end
@implementation xSdkInterface : NSObject
+ (void)OnwillFinishLaunchingWithOptions{
    NSLog(@"max ==> OnwillFinishLaunchingWithOptions");
    [[BuglyMgr sharedInstance]setup];
    [[GADManager sharedInstance]initAd];
}

+ (void)OnApplicationDidBecomeActive{
    NSLog(@"max ==> OnApplicationDidBecomeActive");
}

+ (void)OnApplicationDidEnterBackground{
    NSLog(@"max ==> OnApplicationDidEnterBackground");
}

+ (void)OnApplicationWillEnterForeground{
    NSLog(@"max ==> OnApplicationWillEnterForeground");
}
+ (void)SendMsg2Unity:(NSString *)json{
    const char *json_str = [json UTF8String];
    NSLog(@"==> oc json back");
    UnitySendMessage("MonoSingleton", "SdkInterfaceCallback", json_str);
}

@end
