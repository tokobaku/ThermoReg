using ThermoReg.Core;
using ThermoReg.Data;

namespace ThermoReg.UI
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();

            lvSensors.Width = 500;
            lvSensors.Columns.Add("Identifier", 100);
            lvSensors.Columns.Add("Name", 120);
            lvSensors.Columns.Add("Temperature", 90);
            lvSensors.Columns.Add("Last Read At", 140);
            lvSensors.View = View.Details;
            lvSensors.FullRowSelect = true;
            lvSensors.GridLines = true;

            var form = new MockDataForm();
            form.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            CalculateLayout();
            SignalsReceiver.StateUpdated += (s, e) =>
            {
                CalculateLayout();
            };
        }

        private void CalculateLayout()
        {
            lvSensors.Items.Clear();

            DataBase.Data.Sensors.ForEach(sensor =>
            {
                var item = new ListViewItem(sensor.Identifier);

                item.SubItems.Add(sensor.Name);

                string tempText = sensor.LastMeasuredTemperature.HasValue
                    ? sensor.LastMeasuredTemperature.Value.ToString("0.0") + " °C"
                    : "N/A";
                item.SubItems.Add(tempText);

                string dateText = sensor.LastReadAt.HasValue
                    ? sensor.LastReadAt.Value.ToString("yyyy-MM-dd HH:mm:ss")
                    : "Never read";
                item.SubItems.Add(dateText);

                lvSensors.Items.Add(item);
            });
        }

        private void BtDecrease_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
