using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //client.AddPhone(new Phone
            //{
            //    Producer = "Meizu",
            //    ReleaseYear = 2019,
            //    Name = "M 1",
            //    Weight = 170,
            //    Thickness = 8.7,
            //    OperatingSystem = "Android 9.0",
            //    DualSim = false,
            //    MicroSDCardSlot = false
            //});
            //client.AddPhone(new Phone
            //{
            //    Producer = "Meizu",
            //    ReleaseYear = 2019,
            //    Name = "M 2",
            //    Weight = 170,
            //    Thickness = 8.7,
            //    OperatingSystem = "Android 9.0",
            //    DualSim = false,
            //    MicroSDCardSlot = false
            //});

            //Debug.WriteLine("");

            //phoneList = client.GetPhoneList();
            //foreach (Phone phone in phoneList)
            //{
            //    Debug.WriteLine(phone.Name);
            //}


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }


    }
}
