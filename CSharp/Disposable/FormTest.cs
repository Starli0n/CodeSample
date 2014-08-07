using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Disposable
{
    public partial class FormTest : Form
    {
        private BaseClass m_obj;

        public FormTest()
        {
            Debug.WriteLine("FormTest::FormTest()");
            InitializeComponent();
            m_obj = new BaseClass("FormTest");
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("FormTest::FormClosing()");
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("FormTest::FormClosed()");
            if (m_obj != null)
            {
                m_obj.Dispose();
                m_obj = null;
            }
        }
    }
}
