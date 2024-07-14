﻿namespace MornSingleton
{
    public abstract class MornSingleton<T> where T : MornSingleton<T>, new()
    {
        private static T s_instance;

        public static T Instance
        {
            get
            {
                if (s_instance != null) return s_instance;

                s_instance = new T();
                s_instance.Instanced();
                return s_instance;
            }
        }

        protected abstract void Instanced();
    }

    public abstract class MornSingleton<TClass, TInterface>
        where TClass : MornSingleton<TClass, TInterface>, TInterface, IMornSingleton, new()
    {
        private static TInterface s_instance;

        public static TInterface Instance
        {
            get
            {
                if (s_instance != null) return s_instance;

                var cla = new TClass();
                cla.Instanced();
                s_instance = cla;
                return s_instance;
            }
        }
    }
}