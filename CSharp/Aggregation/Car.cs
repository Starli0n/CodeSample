using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Aggregation
{
    class Car : IDisposable
    {
        protected string m_sName;
        protected Wheel m_wheelProperty = null;
        protected Wheel m_wheelMethod = null;
        // Flag: Has Dispose already been called?
        bool m_disposed = false;

        public Car(string a_sName)
        {
            m_sName = a_sName;
            Debug.WriteLine("{0} - Car::Car()", m_sName, null);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Debug.WriteLine("{0} - Car::Dispose()", m_sName, null);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("{0} - Car::Dispose({1})", m_sName, disposing, null);
            if (m_disposed)
            {
                Debug.WriteLine("{0} - Whell({1}) already disposed", m_sName, disposing, null);
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                //
                if (m_wheelProperty != null)
                {
                    m_wheelProperty.Dispose();
                    m_wheelProperty = null;
                }
                if (m_wheelMethod != null)
                {
                    m_wheelMethod.Dispose();
                    m_wheelMethod = null;
                }
            }

            // Free any unmanaged objects here.
            //
            m_disposed = true;
        }

        ~Car()
        {
            Debug.WriteLine("{0} - Car::~Car()", m_sName, null);
            Dispose(false);
        }

        public void WheelID()
        {
            Debug.WriteLine("{0} - Car::WheelID()", m_sName, null);
            Debug.WriteLine("{0}.m_wheelProperty = {1}", m_sName, m_wheelProperty.ID, null);
            Debug.WriteLine("{0}.m_wheelMethod = {1}", m_sName, m_wheelMethod.ID, null);
        }

        public Wheel GetWheel()
        {
            return m_wheelMethod;
        }

        public void SetWheel(Wheel value)
        {
            m_wheelMethod = value;
        }

        public Wheel Wheel
        {
            get { return m_wheelProperty; }
            set { m_wheelProperty = value; }
        }

        public string Name
        {
            get { return m_sName; }
        }
    }
}
