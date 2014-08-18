using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    class BaseClass : IDisposable
    {
        protected string m_sName;
        // Flag: Has Dispose already been called?
        bool m_disposed = false;

        public BaseClass(string a_sName)
        {
            m_sName = a_sName;
            Debug.WriteLine("{0} - BaseClass::BaseClass()", m_sName, null);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Debug.WriteLine("{0} - BaseClass::Dispose()", m_sName, null);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("{0} - BaseClass::Dispose({1})", m_sName, disposing, null);
            if (m_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            m_disposed = true;
        }

        ~BaseClass()
        {
            Debug.WriteLine("{0} - BaseClass::~BaseClass()", m_sName, null);
            Dispose(false);
        }

        public bool Disposed { get { return m_disposed; } }

        public string Name
        {
            get { return m_sName;  }
        }
    }
}
