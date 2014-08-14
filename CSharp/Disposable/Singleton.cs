using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    public abstract class Singleton<T> where T : class
    {
        static private readonly Lazy<T> s_Instance = new Lazy<T>(() => CreateInstanceOfT());
        static private bool s_bInitialized = false;
        static private bool s_bReleased = false;

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        public static void Initialize()
        {
            if (s_bInitialized)
                return;

            Debug.WriteLine("Singleton::Initialize");
            T single = s_Instance.Value;
            s_bInitialized = true;
        }

        public static void Release()
        {
            if (s_bReleased || !s_bInitialized)
                return;

            Debug.WriteLine("Singleton::Release");

            Singleton<T> singleton = s_Instance.Value as Singleton<T>;
            singleton.Release(true);
            GC.SuppressFinalize(singleton);
        }

        protected Singleton()
        {
            Debug.WriteLine("Singleton::Singleton");
        }

        ~Singleton()
        {
            Debug.WriteLine("Singleton::~Singleton()");
            Release(false);
        }

        protected virtual void Release(bool releasing)
        {
            Debug.WriteLine("Singleton::Release({0})", releasing, null);
            if (s_bReleased)
                return;

            if (releasing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            s_bReleased = true;
        }

        static public bool Released { get { return s_bReleased; } }
    }
}
