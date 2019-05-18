using Client.ServiceReference1;
using Client.StreamServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        PhoneContractClient client;
        int phonesCount;
        public Form1()
        {
            InitializeComponent();

            IPhoneContractCallback handler = new CallbackHandler(this);
            InstanceContext instanceContext = new InstanceContext(handler);
            client = new PhoneContractClient(instanceContext);

            Phone[] phoneList = client.GetPhoneList();

            renderPhonesList(phoneList);
        }

        ~Form1()
        {
            client.Close();
        }

        private void AddPhoneBtn_Click(object sender, EventArgs e)
        {
            AddPhoneForm addPhoneForm = new AddPhoneForm();
            if (addPhoneForm.ShowDialog(this) == DialogResult.OK)
            {
                String filePath = addPhoneForm.pictureBox1.ImageLocation;
                String imageName = null;
                if (filePath != null )
                {
                    imageName = (phonesCount + 1).ToString() + Path.GetExtension(filePath);
                    FileStream file;
                    try
                    {
                        file = File.OpenRead(filePath);

                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.ToString());
                        throw ex;
                    }

                    StreamContractClient imageClient = new StreamContractClient();

                    imageClient.setMStream(imageName, file.Length, file);
                }

                Phone phone = new Phone
                {
                    Producer = addPhoneForm.producerTextBox.Text,
                    ReleaseYear = int.Parse(addPhoneForm.releaseYearTextBox.Text),
                    Name = addPhoneForm.nameTextBox.Text,
                    Weight = double.Parse(addPhoneForm.weightTextBox.Text),
                    Thickness = double.Parse(addPhoneForm.thicknessTextBox.Text),
                    OperatingSystem = addPhoneForm.operatingSystemTextBox.Text,
                    DualSim = addPhoneForm.dualSimCheckbox.Checked,
                    MicroSDCardSlot = addPhoneForm.microSDCardCheckbox.Checked,
                    Image = imageName,
                    Description = addPhoneForm.descriptionTextBox.Text
                };

                client.AddPhone(phone);
            }
        }

        void addLabel(object text, int col, int row)
        {
            Label label = new Label
            {
                Text = text.ToString()
            };
            label.DoubleClick += new EventHandler((object sender, EventArgs e) =>
            {
                Phone phone = client.GetPhone(row);
                DescriptionForm descriptionForm = new DescriptionForm(phone.Description, phone.Image);
                descriptionForm.ShowDialog(this);
            });

            this.phonesTableLayout.Controls.Add(label, col, row);
        }

       public void renderPhonesList(Phone[] phonesList)
        {
            phonesCount = phonesList.Length;
            this.phonesTableLayout.Controls.Clear();
            this.phonesTableLayout.RowCount = phonesList.Length;
            this.phonesTableLayout.ColumnCount = 8;

            for (int i = 0; i < phonesList.Length; i++)
            {
                Phone phone = phonesList[i];

                addLabel(phone.Producer, 0, i);
                addLabel(phone.Name, 1, i);
                addLabel(phone.ReleaseYear, 2, i);
                addLabel(phone.Weight, 3, i);
                addLabel(phone.Thickness, 4, i);
                addLabel(phone.OperatingSystem, 5, i);
                addLabel(phone.DualSim, 6, i);
                addLabel(phone.MicroSDCardSlot, 7, i);
            }
        }
    }
}
