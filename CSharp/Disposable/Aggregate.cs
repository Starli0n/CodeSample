using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Disposable
{
    class Aggregate : IDisposable
    {
        protected BaseClass m_class;
        // Flag: Has Dispose already been called?
        bool m_disposed = false;

        public Aggregate(BaseClass a_class)
        {
            m_class = a_class;
            Debug.WriteLine("{0} - Aggregate::Aggregate()", m_class.Name, null);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Debug.WriteLine("{0} - Aggregate::Dispose()", m_class.Name, null);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("{0} - Aggregate::Dispose({1})", m_class.Name, disposing, null);
            if (m_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
                m_class.Dispose();
            }

            // Free any unmanaged objects here.
            //
            m_disposed = true;
        }

        ~Aggregate()
        {
            Debug.WriteLine("{0} - Aggregate::~Aggregate()", m_class.Name, null);
            Dispose(false);
        }
    }
}
