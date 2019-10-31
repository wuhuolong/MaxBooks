//
//  BuglyMgr.h
//  layabox
//
//  Created by admin on 2019/7/23.
//  Copyright © 2019年 layabox. All rights reserved.
//

#import <Bugly/Bugly.h>

#ifndef BuglyMgr_h
#define BuglyMgr_h

@interface BuglyMgr : NSObject <BuglyDelegate>
+ (BuglyMgr*) sharedInstance;
- (void) setup;

@end

#endif /* BuglyMgr_h */
