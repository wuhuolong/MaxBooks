#import <Foundation/Foundation.h>
#import <GoogleMobileAds/GoogleMobileAds.h>
//#import "GADRewardViewCtrl.mm"
NS_ASSUME_NONNULL_BEGIN

typedef void(^RewardVideoCloseCallback)(bool reward);

@interface GADManager : NSObject <GADRewardedAdDelegate, GADInterstitialDelegate>

@property (nonatomic, retain) UIViewController* viewController;
@property (nonatomic, retain) GADInterstitial* interstitial;
@property(nonatomic, strong) GADRewardedAd *rewardedAd;

+ (GADManager*) sharedInstance;
- (void) initAd;
- (void) setupWithVC:(UIViewController*) vc;
- (void) requestLoadRewardVideo;
- (bool) isRewardVideoReady;
- (void) showRewardVideo;
- (void) showRewardVideoWithCallback: (RewardVideoCloseCallback)callback;
- (bool) isInterstitialReady;
- (void) showInterstitial;
- (void) receivedMsg:(NSString *)json;
@end

NS_ASSUME_NONNULL_END
