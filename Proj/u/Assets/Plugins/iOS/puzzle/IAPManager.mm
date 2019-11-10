#import "IAPManager.h"

@interface IAPManager ()
@property (nonatomic, copy) NSString* rechargeProduct;
@end

@implementation IAPManager

+ (IAPManager*) getInstance{
    static IAPManager* iap = nil;
    if (iap == nil){
        iap = [IAPManager alloc];
        //[iap initIAP:nil];
    }
    return iap;
}

- (void)initIAP:(NSString*)products
{
    NSLog(@"[IAP] initIAP");
    [[SKPaymentQueue defaultQueue] addTransactionObserver:self];
    
    NSArray* arr = [products componentsSeparatedByString:@"||"];
    NSSet * set = [NSSet setWithArray:arr];
    [self requestProducts:set];
}

- (void)dealloc
{
    [[SKPaymentQueue defaultQueue] removeTransactionObserver:self];
}

- (void)requestProducts:(NSSet*)products
{
    NSLog(@"[IAP] requestProducts");
    if ([SKPaymentQueue canMakePayments])
    {
        SKProductsRequest *request = [[SKProductsRequest alloc] initWithProductIdentifiers:products];
        request.delegate = self;
        [request start];
    }
    else
    {
        NSLog(@"[IAP] requestProducts fail, canMakePayments fail");
    }
}

-(NSString*)formatPrice:(SKProduct*)product
{
    NSNumberFormatter* numberFormatter = [[NSNumberFormatter alloc] init];
    [numberFormatter setFormatterBehavior:NSNumberFormatterBehavior10_4];
    [numberFormatter setNumberStyle:NSNumberFormatterCurrencyStyle];
    [numberFormatter setLocale:product.priceLocale];
    return [numberFormatter stringFromNumber:product.price];
}

- (void)updateProductPrice:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response
{
    NSArray *product = response.products;
    
    //如果服务器没有产品
    if([product count] == 0){
        NSLog(@"[IAP] updateProductPrice, nothing");
        return;
    }
    
    NSError* error = nil;
    NSMutableArray* values = [[NSMutableArray alloc] init];
    NSMutableArray* keys = [[NSMutableArray alloc] init];
    for (SKProduct *pro in product) {
        
        NSLog(@"[IAP] updateProductPrice %@", [pro description]);
        NSLog(@"[IAP] updateProductPrice %@", [pro localizedTitle]);
        NSLog(@"[IAP] updateProductPrice %@", [pro localizedDescription]);
        NSLog(@"[IAP] updateProductPrice %@", [pro price]);
        NSLog(@"[IAP] updateProductPrice %@", [pro productIdentifier]);
        
        [keys addObject:[pro productIdentifier]];
        [values addObject:[self formatPrice:pro]];
    }
    NSDictionary* dic = [NSDictionary dictionaryWithObjects:values forKeys:keys];
    NSData* jsonData = [NSJSONSerialization dataWithJSONObject:dic options:NSJSONWritingPrettyPrinted error:&error];
    NSString* jsonStr = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    NSString* cb = [NSString stringWithFormat:@"js_on_product_price_update('%@')", jsonStr];
}

-(NSString *)strOneLine:(NSString * )str
{
    str= [str stringByReplacingOccurrencesOfString:@"\r\n" withString:@""];
    str = [str stringByReplacingOccurrencesOfString:@"\n" withString:@""];
    return [str stringByReplacingOccurrencesOfString:@"\t" withString:@""];
}

- (void)productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response {
    NSLog(@"[IAP] productsRequest");
    
    [self updateProductPrice:request didReceiveResponse:response];
    
    if(self.rechargeProduct != NULL) {
        
        NSArray *product = response.products;
        
        //如果服务器没有产品
        if([product count] == 0){
            return;
        }
        
        SKProduct *requestProduct = nil;
        for (SKProduct *pro in product) {
            // 11.如果后台消费条目的ID与我这里需要请求的一样（用于确保订单的正确性）
            if([pro.productIdentifier isEqualToString:self.rechargeProduct]){
                requestProduct = pro;
            }
        }
        
        // 12.发送购买请求
        NSLog(@"[IAP] addPayment, %@", self.rechargeProduct);
        SKPayment *payment = [SKPayment paymentWithProduct:requestProduct];
        [[SKPaymentQueue defaultQueue] addPayment:payment];
        
        // 错误的产品 ID 回馈
        NSMutableString *resOutput = [[NSMutableString alloc] init];
        for( NSString *invalidProductId in response.invalidProductIdentifiers )
        {
            [resOutput appendFormat:@"[IAP] Invalid product id: %@\n",invalidProductId];
        }
        NSLog(@"%@",resOutput);
    }
    
    self.rechargeProduct = NULL;
}

- (void)callback_Fail:(NSString*)reason {
    NSString* cb = [NSString stringWithFormat:@"js_on_purchased_fail('%@')", reason];
}

//-------------------------------------------------------------------------------
- (void)completeTransaction:(SKPaymentTransaction *)transaction {
    NSLog(@"[IAP] SKPaymentTransactionStatePurchased");
    [self doVerifyTransaction:transaction];
}

- (void)restoreTransaction:(SKPaymentTransaction *)transaction {
    NSLog(@"[IAP] SKPaymentTransactionStateRestored");
    [self doVerifyTransaction:transaction];
}

- (void)failedTransaction:(SKPaymentTransaction *)transaction {
    NSLog(@"[IAP] SKPaymentTransactionStateFailed error: %@ %ld", transaction.error.localizedDescription,(long)transaction.error.code);
    [[SKPaymentQueue defaultQueue] finishTransaction: transaction];
    NSLog(@"[IAP] SKPaymentTransactionStateFailed");
    [self callback_Fail:@"SKPaymentTransactionStateFailed"];
}

- (void)deferredTranscation:(SKPaymentTransaction *)transaction {
    NSLog(@"[IAP] SKPaymentTransactionStateDeferred");
}

- (void)paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray *)transactions
{
    for (SKPaymentTransaction *transaction in transactions)
    {
        switch (transaction.transactionState)
        {
            case SKPaymentTransactionStatePurchased:
                [self completeTransaction:transaction];
                break;
            case SKPaymentTransactionStateFailed:
                [self failedTransaction:transaction];
                break;
            case SKPaymentTransactionStateRestored:
                [self restoreTransaction:transaction];
                break;
            case SKPaymentTransactionStateDeferred:
                [self deferredTranscation:transaction];
                break;
            default:
                break;
        }
    }
}

-(void)jsFinishTransaction:(NSString*)transactionID
{
    NSArray* transactions = [SKPaymentQueue defaultQueue].transactions;
    if (transactions.count > 0)
    {
        for (SKPaymentTransaction *transaction in transactions)
        {
            if ([transaction.transactionIdentifier isEqualToString:transactionID]) {
                [[SKPaymentQueue defaultQueue] finishTransaction: transaction];
                NSLog(@"[IAP] finishTransaction %@", transactionID);
            }
        }
    }
}

//-------------------------------------------------------------------------------
-(void)recharge:(NSString*) productID
{
    if(productID==NULL)
    {
        NSLog(@"[IAP] recharge param is nil!\n");
        [self callback_Fail:@"productID is nil"];
        return;
    }
    NSLog(@"[IAP] recharge productID=%@",productID);
    
    if([SKPaymentQueue canMakePayments] == NO)
    {
        NSLog(@"[IAP] recharge can not make payments!\n");
        [self callback_Fail:@"canMakePayments no"];
        return;
    }
    
    NSArray* transactions = [SKPaymentQueue defaultQueue].transactions;
    if (transactions.count > 0)
    {
        //检测是否有未完成的交易
        SKPaymentTransaction* transaction = [transactions firstObject];
        if (transaction.transactionState == SKPaymentTransactionStatePurchased)
        {
            NSLog(@"[IAP] process uncompleteed transaction");
            [self doVerifyTransaction:transaction];
        }
    }
    
    NSLog(@"[IAP] 开始向苹果请求产品信息");
    self.rechargeProduct = productID;
    [self requestProducts:[[NSSet alloc] initWithObjects:productID, nil]];
}

// 向验证服务器发起验证请求
- (void)doVerifyTransaction: (SKPaymentTransaction *)transaction
{
    NSLog(@"[IAP] doVerifyTransaction");
    if (transaction == nil)
        return;
    
    // 验证凭据，获取到苹果返回的交易凭据
    // appStoreReceiptURL iOS7.0增加的，购买交易完成后，会将凭据存放在该地址
    NSURL *receiptURL = [[NSBundle mainBundle] appStoreReceiptURL];
    // 从沙盒中获取到购买凭据
    NSData *receiptData = [NSData dataWithContentsOfURL:receiptURL];
    
    NSString *encodeStr = [receiptData base64EncodedStringWithOptions:NSDataBase64EncodingEndLineWithLineFeed];
    NSLog(@"[IAP] doVerifyTransaction success");
    
    NSString* cb = [NSString stringWithFormat:@"js_on_purchased_success('%@', '%@', '%@')", transaction.payment.productIdentifier, transaction.transactionIdentifier, encodeStr];
}
-(void)CallEvaluation{
    [[UIApplication sharedApplication].keyWindow endEditing:YES];
    [SKStoreReviewController requestReview];
    NSLog(@"max ==> CallEvaluation");
}
@end
