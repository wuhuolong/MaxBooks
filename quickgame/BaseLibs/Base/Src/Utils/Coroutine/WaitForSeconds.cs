
namespace SafeCoroutine
{
    public class SafeWaitForSeconds : IYieldInstruction
    {
        private float mTimeDelay;

        public SafeWaitForSeconds(float delay)
        {
            mTimeDelay = delay;
        }

        public bool Update(float delta_time)
        {
            if (mTimeDelay < 0)
                return true;

            mTimeDelay -= delta_time;
            return false;
        }
    }
}
