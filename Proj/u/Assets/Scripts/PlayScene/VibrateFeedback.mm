#import <Foundation/Foundation.h>
#import <UIKit/UIFeedbackGenerator.h>

extern "C" void VibrateFeedback ()
{
   UIImpactFeedbackGenerator *feedBackGenertor = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleMedium];
   [feedBackGenertor prepare];
   [feedBackGenertor impactOccurred];
}