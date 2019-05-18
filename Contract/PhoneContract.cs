using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Contract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PhoneContract : IPhoneContract
    {
        List<Phone> phonesList = new List<Phone>(new Phone[]{
            new Phone
            {
                Producer = "Samsung",
                ReleaseYear = 2018,
                Name = "Galaxy Note9",
                Weight = 201,
                Thickness = 8.8,
                OperatingSystem = "Android 9.0",
                DualSim = true,
                MicroSDCardSlot = true,
                Description = "Qualcomm SDM845 Snapdragon 845 (10 nm) - USA/LATAM, China",
                Image = "note9.jpg"
            },
            new Phone
            {
                Producer = "Meizu",
                ReleaseYear = 2019,
                Name = "Note 9",
                Weight = 170,
                Thickness = 8.7,
                OperatingSystem = "Android 9.0",
                DualSim = false,
                MicroSDCardSlot = false,
                Description = "Fingerprint (rear-mounted), accelerometer, gyro, proximity, compass",
                Image = "meizu9.jpg"
            }
        });

        IPhoneCallbackHandler callback = null;

        public PhoneContract()
        {
            callback = OperationContext.Current.GetCallbackChannel<IPhoneCallbackHandler>();
        }

        public void AddPhone(Phone phone)
        {
            Thread.Sleep(5000);
            phonesList.Add(phone);
            callback.AddPhoneCallback(phonesList);
        }

        public Phone GetPhone(int index)
        {
            return phonesList[index];
        }

        public List<Phone> GetPhoneList()
        {
            return phonesList;
        }
    }
}
