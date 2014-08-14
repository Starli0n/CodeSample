using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EnvDTE;
using EnvDTE100;

// Used for Extension Methods
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}

namespace Disposable
{
    static class Program
    {
        // Tools > Options... > Debugging > General > [Enable] Redirect all Output Window text to the Immediate Window

        static long previousUsed = 0;
        static long GCpreviousUsed = 0;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
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

            List();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest("Main"));
            Debug.WriteLine("");

            FormTest test = new FormTest("Other");
            test.Show();
            Debug.WriteLine("");

            Debug.WriteLine("");
            Singleton.Initialize();
            Singleton.Release();
            Debug.WriteLine("Main::End()");

            Debug.WriteLine("Main::End()");
            Debug.WriteLine("");
        }

        static public void ClassE()
        {
            BaseClass e = new BaseClass("e");
            Debug.WriteLine("");
        }

        static public void List()
        {
            List<BaseClass> list = new List<BaseClass>();
            list.Add(new BaseClass("List1"));
            list.Add(new BaseClass("List2"));
            list.Add(new BaseClass("List3"));
            list.DisposeAll();
            list.Clear();
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

        static public void Mem()
        {
            long memoryUsed = System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64;
            Debug.WriteLine("Mem: {0}", memoryUsed, null);
            if (previousUsed != 0)
                Debug.WriteLine("MemDiff: {0}", memoryUsed - previousUsed, null);
            previousUsed = memoryUsed;
            Debug.WriteLine("");
        }

        static public void GCMem()
        {
            long memoryUsed = GC.GetTotalMemory(false);
            Debug.WriteLine("GCMem: {0}", memoryUsed, null);
            if (GCpreviousUsed != 0)
                Debug.WriteLine("MemDiff: {0}", memoryUsed - GCpreviousUsed, null);
            GCpreviousUsed = memoryUsed;
            Debug.WriteLine("");
        }

        public static void AfterClosingForm()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DisposeAll(this IEnumerable set)
        {
            foreach (Object obj in set)
            {
                IDisposable disp = obj as IDisposable;
                if (disp != null)
                    disp.Dispose();
            }
        }
    }
}
