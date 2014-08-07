using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EnvDTE;
using EnvDTE100;

namespace Disposable
{
    class Program
    {
        // Tools > Options... > Debugging > General > [Enable] Redirect all Output Window text to the Immediate Window

        static void Main(string[] args)
        {
            ClearImmediateWindow();

            Debug.WriteLine("Main::Start()");
            Debug.WriteLine("");
            
            BaseClass a = new BaseClass("a");
            Debug.WriteLine("");

            using (BaseClass b = new BaseClass("b"))
            {
                Debug.WriteLine("Main::using b");                
            }
            Debug.WriteLine("");
        
            using (DerivedClass c = new DerivedClass("c"))
            {
                Debug.WriteLine("Main::using c");
            }
            Debug.WriteLine("");

            using (BaseClass d = new DerivedClass("d"))
            {
                Debug.WriteLine("Main::using d");
            }
            Debug.WriteLine("");

            ClassE();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Debug.WriteLine("");

            BaseClass f = new BaseClass("f");
            Aggregate g = new Aggregate(f);
            f.Dispose();
            g.Dispose();
            Debug.WriteLine("");

            Debug.WriteLine("Main::End()");
            Debug.WriteLine("");
        }

        static public void ClassE()
        {
            BaseClass e = new BaseClass("e");
            Debug.WriteLine("");
        }

        static public void ClearImmediateWindow()
        {
            EnvDTE.DTE dte = (EnvDTE.DTE)
                System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
            EnvDTE.Window currentActiveWindow = dte.ActiveWindow;
            dte.Windows.Item("{ECB7191A-597B-41F5-9843-03A4CF275DDE}").Activate();
            dte.ExecuteCommand("Edit.SelectAll");
            dte.ExecuteCommand("Edit.ClearAll");
            currentActiveWindow.Activate();            
        }
    }
}
