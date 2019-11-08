//
//  SdkInterface.m
//  Unity-iPhone
//
//  Created by UYOFUN_MAC_PRO on 2019/10/30.
//

#import <Foundation/Foundation.h>
#import "BuglyMgr.h"
#import "GADManager.h"
#import "UMMgr.h"
@interface xSdkInterface :NSObject
//@property (nonatomic, retain) UIViewController* viewController;

@end
@implementation xSdkInterface : NSObject
+ (void)OnwillFinishLaunchingWithOptions{
    NSLog(@"max ==> OnwillFinishLaunchingWithOptions");
    [[BuglyMgr sharedInstance]setup];
    [[UMMgr sharedInstance] SetUp];
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


char* MakeStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}
extern "C" 
{
    const char* _GetCurLang ()
    {
        NSUserDefaults * defaults = [NSUserDefaults standardUserDefaults];

        NSArray * allLanguages = [defaults objectForKey:@"AppleLanguages"];

        NSString * preferredLang = [allLanguages objectAtIndex:0];

        NSLog(@"当前语言:%@", preferredLang);

        const char* preferredLangConstChar= [preferredLang UTF8String];
        return MakeStringCopy(preferredLangConstChar);
    }
}



