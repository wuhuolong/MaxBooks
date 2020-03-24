/// <summary>
/// 同一个类型的不同实例设定具有独一无二的ID author by Changqing Yang
/// 使用方法：继承此类即可
/// </summary>
/// <typeparam name="T">该表示的类型</typeparam>
namespace Utils
{
    public class Identifier<T>
    {
        public Identifier()
        {
            mIdentifierId = mIdentifierLastId;
            ++mIdentifierLastId;
        }

        public int GetID()
        {
            return mIdentifierId;
        }

        public int Id
        {
            get
            {
                return mIdentifierId;
            }
        }

        private int mIdentifierId;
        private static int mIdentifierLastId = 0;
    }
}