#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

@interface IAPManager : NSObject<SKProductsRequestDelegate,SKPaymentTransactionObserver>
+ (IAPManager*) getInstance;
-(void)recharge:(NSString*) productID;
- (void)initIAP:(NSString*) oneProduct;
- (void)jsFinishTransaction:(NSString*) transactionID;
- (void)CallEvaluation;
@end


