using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Aggregation
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Main();
        }

        public void Main()
        {
            Car car = new Car("car");
            Wheel wheelP = new Wheel("wheelP");
            Wheel wheelM = new Wheel("wheelM");
            wheelP.ID = 1;
            wheelM.ID = 2;
            Debug.WriteLine("");

            car.Wheel = wheelP;
            car.SetWheel(wheelM);
            car.WheelID();
            Debug.WriteLine("");

            Debug.WriteLine("Change Wheel ID");
            wheelP.ID = 3;
            wheelM.ID = 4;
            car.WheelID();

            Debug.WriteLine("");
            wheelP.Dispose();
            wheelM.Dispose();
            car.Dispose();
            car.Dispose();
        }
    }
}
