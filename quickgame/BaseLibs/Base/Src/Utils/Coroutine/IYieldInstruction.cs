
namespace SafeCoroutine
{
    public interface IYieldInstruction
    {
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="delta_time">Delta_time.</param>
        /// <returns>指令完成了返回true，还没完成返回false</returns> 
        bool Update(float delta_time);
    }
}
