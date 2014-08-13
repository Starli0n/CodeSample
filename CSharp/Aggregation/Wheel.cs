using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Aggregation
{
    class Wheel : IDisposable
    {
        protected string m_sName;
        protected int m_iID = 0;
        // Flag: Has Dispose already been called?
        bool m_disposed = false;

        public Wheel(string a_sName)
        {
            m_sName = a_sName;
            Debug.WriteLine("{0} - Wheel::Wheel()", m_sName, null);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Debug.WriteLine("{0} - Wheel::Dispose()", m_sName, null);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("{0} - Wheel::Dispose({1})", m_sName, disposing, null);
            if (m_disposed)
            {
                Debug.WriteLine("{0} - Wheel({1}) already disposed", m_sName, disposing, null);
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            m_disposed = true;
        }

        ~Wheel()
        {
            Debug.WriteLine("{0} - Wheel::~Wheel()", m_sName, null);
            Dispose(false);
        }

        public string Name
        {
            get { return m_sName; }
        }

        public int ID
        {
            get { return m_iID; }
            set { m_iID = value; }
        }
    }
}
