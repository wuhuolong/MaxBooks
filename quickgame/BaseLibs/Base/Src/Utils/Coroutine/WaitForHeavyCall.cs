
namespace SafeCoroutine
{
    public class WaitForHeavyCall : IYieldInstruction
    {
        private static bool mIsHeavyCallThisFrame = false;
        public static WaitForHeavyCall Default = new WaitForHeavyCall();

        public static void HeavyCall()
        {
            mIsHeavyCallThisFrame = true;
        }

        public static void ResetHeavyCall()
        {
            mIsHeavyCallThisFrame = false;
        }

        public WaitForHeavyCall()
        {
            
        }

        public bool Update(float delta_time)
        {
            if (mIsHeavyCallThisFrame == false)
            {
                HeavyCall();
                return true;
            }

            return false;
        }
    }
}
