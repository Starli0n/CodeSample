using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    public sealed class MySingleton : Singleton<MySingleton>
    {
        private MySingleton() : base()
        {
            Debug.WriteLine("MySingleton::MySingleton");
        }

        protected override void Release(bool releasing)
        {
            Debug.WriteLine("MySingleton::Release({1})", releasing, null);
            if (Released)
                return;

            if (releasing)
            {
                // Free any other managed objects here.
                //
            }

            base.Release(releasing);

            // Free any unmanaged objects here.
            //
        }
    }
}
