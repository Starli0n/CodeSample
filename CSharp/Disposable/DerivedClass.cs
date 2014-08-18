using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    class DerivedClass : BaseClass
    {
        public DerivedClass(string a_sName) : base(a_sName)
        {
            Debug.WriteLine("{0} - DerivedClass::DerivedClass()", m_sName, null);
        }

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("{0} - DerivedClass::Dispose({1})", m_sName, disposing, null);
            if (Disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            base.Dispose(disposing);

            // Free any unmanaged objects here.
            //
        }

    }
}
