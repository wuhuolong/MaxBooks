#import "GADManager.h"
#import "UnityAppController.h"
#import "xSdkInterface.h"
//#import <GoogleMobileAdsMediationTestSuite/GoogleMobileAdsMediationTestSuite.h>//
//#import <GoogleMobileAdsMediationTestSuite/GMTSMediationTestSuite.h>

@interface GADManager()

@property (copy, nonatomic) RewardVideoCloseCallback rewardVideoCloseCallback;
@property bool isShowed;

@end

@implementation GADManager
static GADManager* _instance = nil;


+ (GADManager*) sharedInstance
{
    if (_instance == nil)
    {
        _instance = [[GADManager alloc] init];
    }
    return _instance;
}

- (void)setupWithVC:(UIViewController *)vc
{
    //admod
    [[GADMobileAds sharedInstance] startWithCompletionHandler:nil];
    //[GADMobileAds sharedInstance].delegate = self;
    self.isShowed = false;

    _viewController = vc;
}

- (bool)isRewardVideoReady
{
    return self.rewardedAd.isReady;
}
- (void)initAd
{
    [[GADMobileAds sharedInstance]startWithCompletionHandler:nil];

    UIViewController *unityrootvc = UnityGetGLViewController();
    [_instance setupWithVC:unityrootvc];
    [[GADManager sharedInstance] requestLoadRewardVideo];
    NSLog(@"max ==> initAd\n");
}

//*******Reward ad*******
- (void)showRewardVideo
{
    [self doSomething:0];
}
- (void)requestLoadRewardVideo {
    NSLog(@"max ==> viewDidLoad\n");
  self.rewardedAd = [self createAndLoadRewardedAd];
}

- (GADRewardedAd *)createAndLoadRewardedAd {
    NSLog(@"max ==> createAndLoadRewardedAd\n");
  GADRewardedAd *rewardedAd = [[GADRewardedAd alloc]
      initWithAdUnitID:@"ca-app-pub-3940256099942544/1712485313"];
  GADRequest *request = [GADRequest request];
  [rewardedAd loadRequest:request completionHandler:^(GADRequestError * _Nullable error) {
    if (error) {
      // Handle ad failed to load case.
      NSLog(@"max ==> Handle ad failed to load case !!!\n");
    } else {
      // Ad successfully loaded.
        NSLog(@"max ==> Ad successfully loaded !!!\n");
    }
  }];
  return rewardedAd;
}

- (IBAction)doSomething:(id)sender {
    NSLog(@"max ==> Ad doSomething");
  if (self.rewardedAd.isReady) {
    [self.rewardedAd presentFromRootViewController:self.viewController delegate:self];
      self.isShowed = true;
  } else {
      if (!self.isShowed) {
          self.rewardedAd = [self createAndLoadRewardedAd];
          NSLog(@"max ==> Reload ad");
      }
    NSLog(@"max ==> Ad wasn't ready");
  }
}
//*******end Reward ad********
//********* old Interstitial ***********
- (void) requestLoadInterstitial
{
    self.interstitial = [[GADInterstitial alloc] initWithAdUnitID: @"ca-app-pub-5198453589012868/1013017089"];
    self.interstitial.delegate = self;
    [self.interstitial loadRequest:[GADRequest request]];
}

- (bool) isInterstitialReady
{
    return self.interstitial == nil ? false : [self.interstitial isReady];
}

- (void) showInterstitial
{
    if ([self isInterstitialReady])
    {
        [self.interstitial presentFromRootViewController:self.viewController];
    }
    [self requestLoadInterstitial];
}
//********* end old Interstitial ***********

#pragma mark impletement GADReward
/// Tells the delegate that the user earned a reward.//玩家完成播放，需要获得奖励
- (void)rewardedAd:(GADRewardedAd *)rewardedAd userDidEarnReward:(GADAdReward *)reward {
  // TODO: Reward the user.
  NSDictionary *dic= [NSDictionary dictionaryWithObjectsAndKeys:
                        @1,@"Type",
                        @1,@"Ret",nil];
    NSString *json = [self Dic2Json:dic];
    if (json.length != 0) {
        [xSdkInterface SendMsg2Unity:json];
    }else{
        NSLog(@"json parse error");
    }

  NSLog(@"max callback ==> rewardedAd:userDidEarnReward:%@",json);
}

/// Tells the delegate that the rewarded ad was presented.//开始展示
- (void)rewardedAdDidPresent:(GADRewardedAd *)rewardedAd {
  NSLog(@"max callback ==> rewardedAdDidPresent:");
}

/// Tells the delegate that the rewarded ad failed to present.
- (void)rewardedAd:(GADRewardedAd *)rewardedAd didFailToPresentWithError:(NSError *)error {
    NSDictionary *dic= [NSDictionary dictionaryWithObjectsAndKeys:
                          @"Type",@"1",
                          @"Ret",@"0",nil];
    NSString *json = [self Dic2Json:dic];
    [xSdkInterface SendMsg2Unity:json];
  NSLog(@"max callback ==> rewardedAd:didFailToPresentWithError");
}

/// Tells the delegate that the rewarded ad was dismissed.//关闭，无论有没有播放完
- (void)rewardedAdDidDismiss:(GADRewardedAd *)rewardedAd {
  self.rewardedAd = [self createAndLoadRewardedAd];
  NSLog(@"max callback ==> rewardedAdDidDismiss:");
}


#pragma mark implement GADInterstitial


- (void)interstitialDidReceiveAd:(GADInterstitial *)ad
{
    NSLog(@"interstitialDidReceiveAd");
}

- (void)interstitial:(GADInterstitial *)ad didFailToReceiveAdWithError:(GADRequestError *)error
{
    NSLog(@"didFailToReceiveAdWithError");
    [self performSelector:@selector(requestLoadInterstitial) withObject:nil afterDelay:10.f];
    
}

- (void)interstitialWillPresentScreen:(GADInterstitial *)ad
{
    NSLog(@"interstitialWillPresentScreen");
    
}

- (void)interstitialDidFailToPresentScreen:(GADInterstitial *)ad
{
    NSLog(@"interstitialDidFailToPresentScreen");
    
}

- (void)interstitialWillDismissScreen:(GADInterstitial *)ad
{
    NSLog(@"interstitialWillDismissScreen");
    
    
}

- (void)interstitialDidDismissScreen:(GADInterstitial *)ad
{
    NSLog(@"interstitialDidDismissScreen");
    
    [self requestLoadInterstitial];
}

- (void)interstitialWillLeaveApplication:(GADInterstitial *)ad
{
    NSLog(@"interstitialWillLeaveApplication");
    
}
//*********** tools ******************
-(NSString *)Dic2Json:(NSDictionary *)dic{
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
-(NSDictionary *)Json2Dic:(NSString *)json{
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



extern "C"{
    void test(){
        //[[GADManager sharedInstance] initAd];
        //[[GADManager sharedInstance]showInterstitial];
        printf("==> test \n");
    }

    bool _isRewardVideoReady(){
        printf("==> _isRewardVideoReady \n");
        return false;//return [[GADManager sharedInstance] isRewardVideoReady];
    }
    
    void _showRewardVideo(){
        printf("==> _showRewardVideo \n");
        [[GADManager sharedInstance] showRewardVideo];
    }
    void _SendMsg(const char *json){
        printf("==> _SendMsg \n");
        NSString *str = [NSString stringWithUTF8String:json];
        [[GADManager sharedInstance] receivedMsg:str];
    }
}
