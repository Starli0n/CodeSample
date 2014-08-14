using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    public sealed class Singleton
    {
        static private bool s_bInitialized = false;
        static private bool s_bReleased = false;

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
                Debug.WriteLine("Singleton::Nested::Nested");
            }

            internal static readonly Singleton instance = new Singleton();
        }

        public static void Initialize()
        {
            if (s_bInitialized)
                return;

            Debug.WriteLine("Singleton::Initialize");
            Singleton single = Nested.instance;
            s_bInitialized = true;
        }

        public static void Release()
        {
            if (s_bReleased || !s_bInitialized)
                return;

            Debug.WriteLine("Singleton::Release");

            Nested.instance.Release(true);
            GC.SuppressFinalize(Nested.instance);
        }

        private Singleton()
        {
            Debug.WriteLine("Singleton::Singleton");
        }

        ~Singleton()
        {
            Debug.WriteLine("Singleton::~Singleton()");
            Release(false);
        }

        private void Release(bool releasing)
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
    }
}
