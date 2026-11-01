using ThermoReg.Core;
using ThermoReg.Data;

namespace ThermoReg.UI;

public partial class MockDataForm : Form
{
    private GroupBox gbSensors;
    private GroupBox gbKeys;
    Dictionary<string, bool> keysActive;

    public MockDataForm()
    {
        InitializeComponent();
        gbSensors = new GroupBox
        {
            Text = "Sensors",
            AutoSize = true,
        };
        gbKeys = new GroupBox
        {
            Text = "Keys",
            AutoSize= true,
        };
        Controls.AddRange(gbSensors, gbKeys);

        keysActive = new();

        SignalsReceiver.StateUpdated += (s, e) =>
        {
            CalculateLayout();
        };
        CalculateLayout();
    }

    private void CalculateLayout()
    {
        RenderTemperatureSensors();
        RenderKeys();
    }

    private void RenderTemperatureSensors()
    {
        gbSensors.Location = new Point(12, 12);
        gbSensors.MaximumSize = new Size(500, 0);
        gbSensors.Controls.Clear();
        var tbNewSensorId = new TextBox
        {
            Location = new Point(12, 12),
            PlaceholderText = "New sensor id",
            Width = 100,
        };
        var tbNewSensorName = new TextBox
        {
            Location = new Point(tbNewSensorId.Location.X + tbNewSensorId.Width + 12, tbNewSensorId.Location.Y),
            PlaceholderText = "New sensor name",
            Width = 100,
        };
        var btAddSensor = new Button
        {
            Text = "Add sensor",
            Location = new Point(tbNewSensorName.Location.X + tbNewSensorName.Width + 12, tbNewSensorName.Location.Y),
            AutoSize = true,
        };

        btAddSensor.Click += (s, e) =>
        {
            try
            {
                SignalsReceiver.AddSensor(new Data.Model.TemperatureSensor
                {
                    Identifier = tbNewSensorId.Text,
                    Name = tbNewSensorName.Text,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        };

        gbSensors.Controls.AddRange(tbNewSensorId, tbNewSensorName, btAddSensor);

        var pnSensors = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            AutoSize = true,
            Location = new Point(tbNewSensorId.Location.X, tbNewSensorId.Location.Y + tbNewSensorId.Height + 12),
        };

        DataBase.Data.Sensors.ForEach(sensor =>
        {
            var pnSensor = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
            };

            var lbSensor = new Label
            {
                Text = sensor.Name,
                Location = new Point(0, 0),
                Width = 50,
            };

            var nmTemperature = new NumericUpDown
            {
                Location = new Point(lbSensor.Location.X + lbSensor.Width + 12, lbSensor.Location.Y),
                Width = 50,
                Minimum = -100,
                Maximum = 100,
                DecimalPlaces = 1,
                Increment = 0.1m,
                Value = (decimal)(sensor.LastMeasuredTemperature ?? 17),
            };

            var btRead = new Button
            {
                Text = "Send signal",
                Width = 50,
            };

            btRead.Click += (s, e) =>
            {
                SignalsReceiver.ReadTemperature(sensor.Identifier, (float)nmTemperature.Value, DateTime.Now);
            };

            pnSensor.Controls.AddRange(lbSensor, nmTemperature, btRead);

            pnSensors.Controls.Add(pnSensor);
        });

        gbSensors.Controls.Add(pnSensors);
    }

    private void RenderKeys()
    {
        gbKeys.Controls.Clear();
        gbKeys.Location = new Point(gbSensors.Location.X + gbSensors.Width + 12, gbSensors.Location.Y);

        var tbNewKeyId = new TextBox
        {
            Location = new Point(12, 12),
            PlaceholderText = "New key id",
            Width = 100,
        };
        var tbNewKeyName = new TextBox
        {
            Location = new Point(tbNewKeyId.Location.X + tbNewKeyId.Width + 12, tbNewKeyId.Location.Y),
            PlaceholderText = "New key name",
            Width = 100,
        };
        var btAddKey = new Button
        {
            Text = "Add key",
            Location = new Point(tbNewKeyName.Location.X + tbNewKeyName.Width + 12, tbNewKeyName.Location.Y),
            AutoSize = true,
        };

        btAddKey.Click += (s, e) =>
        {
            try
            {
                SignalsReceiver.AddKey(new Data.Model.LoRaKey
                {
                    Identifier = tbNewKeyId.Text,
                    Name = tbNewKeyName.Text,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        };

        gbKeys.Controls.AddRange(tbNewKeyId, tbNewKeyName, btAddKey);

        var pnKeys = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            AutoSize = true,
            Location = new Point(tbNewKeyId.Location.X, tbNewKeyId.Location.Y + tbNewKeyId.Height + 12),
        };

        DataBase.Data.LoRaKeys.ForEach(key =>
        {
            var pnKey = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
            };

            var lbKey = new Label
            {
                Text = key.Name,
                Location = new Point(0, 0),
                Width = 50,
            };

            if (!keysActive.ContainsKey(key.Identifier))
            {
                keysActive[key.Identifier] = false;
            }

            var cbWillRead = new CheckBox
            {
                Location = new Point(lbKey.Location.X + lbKey.Width + 12, lbKey.Location.Y),
                Width = 50,
                Checked = keysActive[key.Identifier],
            };

            pnKey.Controls.AddRange(lbKey, cbWillRead);

            pnKeys.Controls.Add(pnKey);
        });

        gbKeys.Controls.Add(pnKeys);
    }
}
