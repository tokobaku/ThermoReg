using ThermoReg.Core;
using ThermoReg.Data;
using ThermoReg.Data.Model;

namespace ThermoReg.UI
{
    public partial class ConfigurationForm : Form
    {
        private Label lbMinWaterTemp;
        private NumericUpDown nmMinWaterTemp;
        private Label lbMaxWaterTemp;
        private NumericUpDown nmMaxWaterTemp;
        private Label lbProportionalBand;
        private NumericUpDown nmProportionalBand;
        private Label lbMinEmptyTime;
        private DateTimePicker dtMinEmptyTime;
        private Label lbEmptyTemp;
        private NumericUpDown nmEmptyTemp;
        private Button btSave;

        public ConfigurationForm()
        {
            InitializeComponent();

            lbMinWaterTemp = new Label
            {
                Text = "Min water temperature",
                Width = 150,
            };
            nmMinWaterTemp = new NumericUpDown
            {
                Value = (decimal)DataBase.Data.Configuration.MinWaterTemp,
                Minimum = 30,
                Maximum = 45,
                DecimalPlaces = 1,
                Increment = 0.5m,
                Width = 150,
            };
            lbMaxWaterTemp = new Label
            {
                Text = "Max water temperature",
                Width = 150,
            };
            nmMaxWaterTemp = new NumericUpDown
            {
                Value = (decimal)DataBase.Data.Configuration.MaxWaterTemp,
                Minimum = 50,
                Maximum = 70,
                DecimalPlaces = 1,
                Increment = 0.5m,
                Width = 150,
            };
            lbProportionalBand = new Label
            {
                Text = "Proportional band",
                Width = 150,
            };
            nmProportionalBand = new NumericUpDown
            {
                Value = (decimal)DataBase.Data.Configuration.ProportionalBand,
                Minimum = 1,
                Maximum = 10,
                DecimalPlaces = 1,
                Increment = 0.1m,
                Width = 150,
            };
            lbMinEmptyTime = new Label
            {
                Text = "Minimum time till empty",
                Width = 150,
            };
            var defaultTime = DateTime.UnixEpoch + DataBase.Data.Configuration.MinEmptyTime;

            dtMinEmptyTime = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                Width = 150,
                ShowUpDown = true,
                Value = defaultTime,
            };
            lbEmptyTemp = new Label
            {
                Text = "Empty house temperature",
                Width = 150,
            };
            nmEmptyTemp = new NumericUpDown
            {
                Value = (decimal)DataBase.Data.Configuration.EmptyTemp,
                Minimum = 10,
                Maximum = 30,
                DecimalPlaces = 1,
                Increment = 0.1m,
                Width = 150,
            };
            btSave = new Button
            {
                Text = "Save",
                AutoSize = true,
            };
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            lbMinWaterTemp.Location = new Point(12, 12);
            nmMinWaterTemp.Location = new Point(lbMinWaterTemp.Location.X + lbMinWaterTemp.Width + 12, lbMinWaterTemp.Location.Y);

            lbMaxWaterTemp.Location = new Point(lbMinWaterTemp.Location.X, lbMinWaterTemp.Location.Y + lbMinWaterTemp.Height + 12);
            nmMaxWaterTemp.Location = new Point(lbMaxWaterTemp.Location.X + lbMaxWaterTemp.Width + 12, lbMaxWaterTemp.Location.Y);

            lbProportionalBand.Location = new Point(lbMaxWaterTemp.Location.X, lbMaxWaterTemp.Location.Y + lbMaxWaterTemp.Height + 12);
            nmProportionalBand.Location = new Point(lbMaxWaterTemp.Location.X + lbProportionalBand.Width + 12, lbProportionalBand.Location.Y);

            lbMinEmptyTime.Location = new Point(lbProportionalBand.Location.X, lbProportionalBand.Location.Y + lbProportionalBand.Height + 12);
            dtMinEmptyTime.Location = new Point(lbMinEmptyTime.Location.X + lbMinEmptyTime.Width + 12, lbMinEmptyTime.Location.Y);

            lbEmptyTemp.Location = new Point(lbMinEmptyTime.Location.X, lbMinEmptyTime.Location.Y + lbMinEmptyTime.Height + 12);
            nmEmptyTemp.Location = new Point(lbEmptyTemp.Location.X + lbMinEmptyTime.Width + 12, lbEmptyTemp.Location.Y);

            btSave.Location = new Point(lbEmptyTemp.Location.X, lbEmptyTemp.Location.Y + lbEmptyTemp.Height + 12);
            btSave.Click += SaveSettings;

            Controls.AddRange(
                lbMinWaterTemp,
                nmMinWaterTemp,
                lbMaxWaterTemp,
                nmMaxWaterTemp,
                lbProportionalBand,
                nmProportionalBand,
                lbMinEmptyTime,
                dtMinEmptyTime,
                lbEmptyTemp,
                nmEmptyTemp,
                btSave
            );
        }

        void SaveSettings(object? sender, EventArgs args)
        {
            Configuration config = DataBase.Data.Configuration;

            config.MinWaterTemp = (float)nmMinWaterTemp.Value;
            config.MaxWaterTemp = (float)nmMaxWaterTemp.Value;
            config.ProportionalBand = (float)nmProportionalBand.Value;
            config.MinEmptyTime = dtMinEmptyTime.Value - DateTime.UnixEpoch;
            config.EmptyTemp = (float)nmEmptyTemp.Value;

            ConfigurationManager.UpdateConfiguration(config);

            Close();
        }
    }
}
