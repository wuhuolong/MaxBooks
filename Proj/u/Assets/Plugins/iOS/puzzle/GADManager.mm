#import "GADManager.h"
#import "UnityAppController.h"
#import "xSdkInterface.h"
#import "IAPManager.h"
#import "UMMgr.h"
//#import <GoogleMobileAdsMediationTestSuite/GoogleMobileAdsMediationTestSuite.h>//
//#import <GoogleMobileAdsMediationTestSuite/GMTSMediationTestSuite.h>


static int OnRewardAdShowOver = 1;// 结算广告展示成功
static int OnRewardAdShow = 2;// 结算广告展示
static int OnLevelEnter = 3;// 关卡进入
static int OnLevelClear = 4;// 关卡通过
static int OnClickADPuzzle = 5;// 广告方块广告展示
static int OnUnlockAdPuzzle = 6;// 广告方块解锁成功
static int OnPay2RemoveAd = 7;// 去广告功能触发
static int OnPay2RemoveAdSucc = 8;// 去广告付费成功
static int OnScreenshots = 9;// 结算截图使用次数
static int CallEvaluation = 10;//调起应用商店评价

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
    //[[GADManager sharedInstance] requestLoadInterstitial];
    
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
      //Track 5
      //NSDictionary *dic = [NSDictionary dictionaryWithObjectsAndKeys:@"showRewardAD",@"Action",@"5",@"Type", nil];
      [[UMMgr sharedInstance] Track:@"5"];
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
        //Track 1
        NSDictionary *dic = [NSDictionary dictionaryWithObjectsAndKeys:@"showInterstitial",@"Action",@"1",@"Type", nil];
        [[UMMgr sharedInstance] Track:@"1" Dic:dic];
        [self.interstitial presentFromRootViewController:self.viewController];
    }else{
        [self requestLoadInterstitial];
    }
}
//********* end old Interstitial ***********

#pragma mark impletement GADReward
/// Tells the delegate that the user earned a reward.//玩家完成播放，需要获得奖励
- (void)rewardedAd:(GADRewardedAd *)rewardedAd userDidEarnReward:(GADAdReward *)reward {
    // TODO: Reward the user.
    //Track 6
    //NSDictionary *dic2 = [NSDictionary dictionaryWithObjectsAndKeys:@"showRewardAD cb",@"Action",@"6",@"Type", nil];
    [[UMMgr sharedInstance] Track:@"6"];
    NSDictionary *dic= [NSDictionary dictionaryWithObjectsAndKeys:
                        @6,@"Type",
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
                          @6,@"Type",
                          @0,@"Ret",nil];
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
    //track 2
    NSDictionary *dic2 = [NSDictionary dictionaryWithObjectsAndKeys:@"showInterstitial cb",@"Action",@"2",@"Type", nil];
    [[UMMgr sharedInstance] Track:@"2" Dic:dic2];
    NSLog(@"interstitialDidReceiveAd");
}

- (void)interstitial:(GADInterstitial *)ad didFailToReceiveAdWithError:(GADRequestError *)error
{
    NSLog(@"didFailToReceiveAdWithError");
    [self performSelector:@selector(requestLoadInterstitial) withObject:nil afterDelay:10.f];
    
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
- (void)receivedMsg:(NSString *)str{
    NSDictionary *dic = [[GADManager sharedInstance] Json2Dic:str];
    if(dic != nil){
        int type = [[dic objectForKey:@"Type"]intValue];
        NSString *strTemp;
        NSDictionary *dic2;
        switch (type) {
                case 1://on show intersitial
                break;
            case 2://on show intersitial over callback
                break;
            case 3://level enter
                strTemp =[NSString stringWithFormat:@"%d_Level", [[dic objectForKey:@"LevelID"]intValue]];
                dic2 = [NSDictionary dictionaryWithObjectsAndKeys:[dic objectForKey:@"Type"],@"Type",strTemp,@"LevelID", nil];
                strTemp = [NSString stringWithFormat:@"%d",type];
                [[UMMgr sharedInstance] Track:strTemp Dic:dic2];
                break;
            case 4://level clear
                strTemp =[NSString stringWithFormat:@"%d_Level", [[dic objectForKey:@"LevelID"]intValue]];
                dic2 = [NSDictionary dictionaryWithObjectsAndKeys:[dic objectForKey:@"Type"],@"Type",strTemp,@"LevelID", nil];
                strTemp = [NSString stringWithFormat:@"%d",type];
                [[UMMgr sharedInstance] Track:strTemp Dic:dic2];
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                 break;
             case 9:
                 break;
             case 10:
                 [[IAPManager getInstance] CallEvaluation];
                 break;
            default:
                break;
        }
    }
}


- ( void ) imageSaved: ( UIImage *) image didFinishSavingWithError:( NSError *)error
    contextInfo: ( void *) contextInfo
{
    NSLog(@"保存结束");
    if (error != nil) {
        NSLog(@"有错误");
    }
}

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
    void _showInterstitialAD(){
        printf("==> _showInterstitialAD \n");
        [[GADManager sharedInstance] showInterstitial];
    }
    void _SendMsg(const char *json){
        printf("==> _SendMsg \n");
        NSString *str = [NSString stringWithUTF8String:json];
        [[GADManager sharedInstance] receivedMsg:str];
    }
    void _SavePhoto(const char *json){
        printf("==> _SavePhoto \n");
        NSString *url = [NSString stringWithUTF8String:json];
        UIImage *img = [UIImage imageWithContentsOfFile:url];
        GADManager *ins = [GADManager sharedInstance];

        //Track 9
        //NSDictionary *dic2 = [NSDictionary dictionaryWithObjectsAndKeys:@"showRewardAD cb",@"Action",@"9",@"Type", nil];
        [[UMMgr sharedInstance] Track:@"9"];
        UIImageWriteToSavedPhotosAlbum(img, ins, @selector(imageSaved:didFinishSavingWithError:contextInfo:), nil);
    }
}
