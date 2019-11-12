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

//*********** tools ******************
+(NSString *)Dic2Json:(NSDictionary *)dic{
    NSError *err;
    NSData *data = [NSJSONSerialization dataWithJSONObject:dic options:kNilOptions error:&err];
    if (err) {
        NSLog(@"dic parse to json error code ==>%ld",(long)err.code);
        return @"";
    }
    NSString *str = [[NSString alloc]initWithData:data encoding:NSUTF8StringEncoding];
    NSLog(@"dic parse to json ==> %@",str);
    return str;
}
+(NSDictionary *)Json2Dic:(NSString *)json{
    NSLog(@"json parse to dic");
    NSData *data = [json dataUsingEncoding:NSUTF8StringEncoding];
    NSError *err;
    NSDictionary *dic = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingMutableContainers error:&err];
    if (err) {
        NSLog(@"json parse to dic error code ==>%ld",(long)err.code);
        return nil;
    }
    return dic;
}
//*********** tools ******************
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



