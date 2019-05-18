using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class CallbackHandler : IPhoneContractCallback
    {
        Form1 form;
        public CallbackHandler(Form1 form)
        {
            this.form = form;
        }

        public void AddPhoneCallback(Phone[] phonesList)
        {
            form.renderPhonesList(phonesList);
        }
    }
}
