using System;
namespace xc
{
    public class Singleton<T> where T : new()
    {
        protected static T sInstance = default(T);

        protected Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                return GetInstance();
            }
        }

        public static T instance
        {
            get
            {
                return GetInstance();
            }
        }

        public static T GetInstance()
        {
            if (Singleton<T>.sInstance == null)
                Singleton<T>.sInstance = Activator.CreateInstance<T>();
            return Singleton<T>.sInstance;
        }
    }
}