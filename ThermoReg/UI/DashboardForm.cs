using ThermoReg.Core;
using ThermoReg.Data;

namespace ThermoReg.UI
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();

            lvDesiredTemperatures.Width = 90 + 90 + 90 + 50;
            lvDesiredTemperatures.Columns.Add("Start time", 90);
            lvDesiredTemperatures.Columns.Add("End time", 90);
            lvDesiredTemperatures.Columns.Add("Temperature", 90);
            lvDesiredTemperatures.View = View.Details;
            lvDesiredTemperatures.FullRowSelect = true;
            lvDesiredTemperatures.GridLines = true;

            var dtpStartTime = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                Width = 60,
                Location = new Point(lvDesiredTemperatures.Location.X + lvDesiredTemperatures.Width + 12, lvDesiredTemperatures.Location.Y),
                ShowUpDown = true,
            };
            var dtpEndTime = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                Width = 60,
                Location = new Point(dtpStartTime.Location.X, dtpStartTime.Location.Y + dtpStartTime.Height + 12),
                ShowUpDown = true,
            };
            var nmTemperature = new NumericUpDown
            {
                Width = 60,
                Location = new Point(dtpEndTime.Location.X, dtpEndTime.Location.Y + dtpEndTime.Height + 12),
                Value = 22,
                Minimum = 10,
                Maximum = 30,
                DecimalPlaces = 1,
                Increment = 0.5m,
            };
            var btAddDesiredTemperature = new Button
            {
                Text = "Add",
                Location = new Point(nmTemperature.Location.X, nmTemperature.Location.Y + nmTemperature.Height + 12),
            };
            var btRemove = new Button
            {
                Text = "Remove",
                Location = new Point(btAddDesiredTemperature.Location.X, btAddDesiredTemperature.Location.Y + btAddDesiredTemperature.Height + 12),
            };

            btAddDesiredTemperature.Click += (s, e) =>
            {
                try
                {
                    ConfigurationManager.AddNewDesiredTemperature(new Data.Model.DesiredTemperature
                    {
                        StartHour = dtpStartTime.Value.Hour,
                        StartMinute = dtpStartTime.Value.Minute,
                        EndHour = dtpEndTime.Value.Hour,
                        EndMinute = dtpEndTime.Value.Minute,
                        Temperature = (float)nmTemperature.Value,
                    });

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            btRemove.Click += (s, e) =>
            {
                foreach (ListViewItem desiredTemp in lvDesiredTemperatures.SelectedItems)
                {
                    var tag = desiredTemp.Tag;

                    if (tag != null)
                    {
                        ConfigurationManager.RemoveDesiredTemperature((string)tag);
                    }
                }
            };

            Controls.AddRange(dtpStartTime, dtpEndTime, nmTemperature, btAddDesiredTemperature, btRemove);

            lvSensors.Width = 100 + 120 + 90 + 140;
            lvSensors.Columns.Add("Identifier", 100);
            lvSensors.Columns.Add("Name", 120);
            lvSensors.Columns.Add("Temperature", 90);
            lvSensors.Columns.Add("Last Read At", 140);
            lvSensors.View = View.Details;
            lvSensors.FullRowSelect = true;
            lvSensors.GridLines = true;

            btSettings.AutoSize = true;
            btSettings.Location = new Point(Width - btSettings.Width - 24, 12);

            gbTempBox.Location = new Point(Width - gbTempBox.Width - 24, btSettings.Location.Y + btSettings.Height + 12);

            lvKeys.Width = 90 + 90 + 90 + 90;
            lvKeys.Columns.Add("Key ID", 90);
            lvKeys.Columns.Add("Key Name", 90);
            lvKeys.Columns.Add("Last read", 90);
            lvKeys.Columns.Add("Active", 90);
            lvKeys.View = View.Details;
            lvKeys.FullRowSelect = true;
            lvKeys.GridLines = true;

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
            ConfigurationManager.ConfigUpdated += (s, e) =>
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

            lvDesiredTemperatures.Items.Clear();
            DataBase.Data.DesiredTemperatures.ForEach(desiredTemp =>
            {
                var item = new ListViewItem($"{desiredTemp.StartHour:D2}:{desiredTemp.StartMinute:D2}");

                item.SubItems.Add($"{desiredTemp.EndHour:D2}:{desiredTemp.EndMinute:D2}");

                item.SubItems.Add(desiredTemp.Temperature.ToString());
                item.Tag = desiredTemp.GetTag();

                lvDesiredTemperatures.Items.Add(item);
            });

            var averageTemp = DataBase.Data.Sensors.Where(s => s.LastMeasuredTemperature != null)
                .Select(s => s.LastMeasuredTemperature)
                .Average();

            lbAverageTemp.Text = $"Average temperature: {averageTemp}";

            var desiredTemp = TemperatureController.CalculateDesiredTemperature();
            lbDesiredTemp.Text = $"Desired temperature: {desiredTemp}";

            var sentTemp = TemperatureController.CaluclateTemperatureSentToBoiler(averageTemp ?? 15, desiredTemp);

            lbTemperatureSent.Text = $"Sent temperature: {sentTemp}";

            lvKeys.Location = new Point(lvSensors.Location.X + lvSensors.Width + 12, lvSensors.Location.Y);

            lvKeys.Items.Clear();
            DataBase.Data.LoRaKeys.ForEach(key =>
            {
                var item = new ListViewItem(key.Identifier);
                item.SubItems.Add(key.Name);
                item.SubItems.Add(key.LastReadAt?.ToString() ?? "Never read");
 
                if (key.LastReadAt is not null)
                {
                    item.SubItems.Add((DateTime.Now - key.LastReadAt) <= DataBase.Data.Configuration.MinEmptyTime ? "Active" : "Inactive");
                } else
                {
                    item.SubItems.Add("Inactive");
                }

                lvKeys.Items.Add(item);
            });
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            (new ConfigurationForm()).ShowDialog();
        }

        private void btMock_Click(object sender, EventArgs e)
        {
            (new MockDataForm()).Show();
        }
    }
}
