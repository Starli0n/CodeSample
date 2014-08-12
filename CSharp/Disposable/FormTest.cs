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

        public FormTest(string a_name)
        {
            Debug.WriteLine("FormTest::FormTest()");
            InitializeComponent();
            m_obj = new BaseClass(a_name);
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
            if (m_button != null)
            {
                m_button.Dispose();
                m_button = null;
            }
        }

        private void m_button_Click(object sender, EventArgs e)
        {
            FormTest test = new FormTest("Child");
            test.Show();
        }
    }
}
