namespace ThermoReg.UI
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvSensors = new ListView();
            lvDesiredTemperatures = new ListView();
            lbAverageTemp = new Label();
            gbTempBox = new GroupBox();
            lbTemperatureSent = new Label();
            lbDesiredTemp = new Label();
            btSettings = new Button();
            lvKeys = new ListView();
            btMock = new Button();
            gbTempBox.SuspendLayout();
            SuspendLayout();
            // 
            // lvSensors
            // 
            lvSensors.Location = new Point(12, 245);
            lvSensors.Name = "lvSensors";
            lvSensors.Size = new Size(121, 186);
            lvSensors.TabIndex = 1;
            lvSensors.UseCompatibleStateImageBehavior = false;
            // 
            // lvDesiredTemperatures
            // 
            lvDesiredTemperatures.Location = new Point(12, 27);
            lvDesiredTemperatures.Name = "lvDesiredTemperatures";
            lvDesiredTemperatures.Size = new Size(121, 97);
            lvDesiredTemperatures.TabIndex = 2;
            lvDesiredTemperatures.UseCompatibleStateImageBehavior = false;
            // 
            // lbAverageTemp
            // 
            lbAverageTemp.AutoSize = true;
            lbAverageTemp.Location = new Point(6, 35);
            lbAverageTemp.Name = "lbAverageTemp";
            lbAverageTemp.Size = new Size(126, 15);
            lbAverageTemp.TabIndex = 3;
            lbAverageTemp.Text = "Average Temperature: ";
            // 
            // gbTempBox
            // 
            gbTempBox.Controls.Add(lbTemperatureSent);
            gbTempBox.Controls.Add(lbDesiredTemp);
            gbTempBox.Controls.Add(lbAverageTemp);
            gbTempBox.Location = new Point(649, 59);
            gbTempBox.Name = "gbTempBox";
            gbTempBox.Size = new Size(200, 139);
            gbTempBox.TabIndex = 4;
            gbTempBox.TabStop = false;
            gbTempBox.Text = "Temperature";
            // 
            // lbTemperatureSent
            // 
            lbTemperatureSent.AutoSize = true;
            lbTemperatureSent.Location = new Point(6, 95);
            lbTemperatureSent.Name = "lbTemperatureSent";
            lbTemperatureSent.Size = new Size(105, 15);
            lbTemperatureSent.TabIndex = 5;
            lbTemperatureSent.Text = "Temperature sent: ";
            // 
            // lbDesiredTemp
            // 
            lbDesiredTemp.AutoSize = true;
            lbDesiredTemp.Location = new Point(6, 61);
            lbDesiredTemp.Name = "lbDesiredTemp";
            lbDesiredTemp.Size = new Size(122, 15);
            lbDesiredTemp.TabIndex = 4;
            lbDesiredTemp.Text = "Desired Temperature: ";
            // 
            // btSettings
            // 
            btSettings.Location = new Point(1041, 12);
            btSettings.Name = "btSettings";
            btSettings.Size = new Size(75, 23);
            btSettings.TabIndex = 5;
            btSettings.Text = "Settings";
            btSettings.UseVisualStyleBackColor = true;
            btSettings.Click += btSettings_Click;
            // 
            // lvKeys
            // 
            lvKeys.Location = new Point(468, 245);
            lvKeys.Name = "lvKeys";
            lvKeys.Size = new Size(121, 97);
            lvKeys.TabIndex = 6;
            lvKeys.UseCompatibleStateImageBehavior = false;
            // 
            // btMock
            // 
            btMock.Location = new Point(960, 12);
            btMock.Name = "btMock";
            btMock.Size = new Size(75, 23);
            btMock.TabIndex = 7;
            btMock.Text = "Mock";
            btMock.UseVisualStyleBackColor = true;
            btMock.Click += btMock_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 654);
            Controls.Add(btMock);
            Controls.Add(lvKeys);
            Controls.Add(btSettings);
            Controls.Add(gbTempBox);
            Controls.Add(lvDesiredTemperatures);
            Controls.Add(lvSensors);
            Name = "DashboardForm";
            Text = "DashboardForm";
            FormClosed += DashboardForm_FormClosed;
            Load += DashboardForm_Load;
            gbTempBox.ResumeLayout(false);
            gbTempBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListView lvSensors;
        private ListView lvDesiredTemperatures;
        private Label lbAverageTemp;
        private GroupBox gbTempBox;
        private Label lbDesiredTemp;
        private Label lbTemperatureSent;
        private Button btSettings;
        private ListView lvKeys;
        private Button btMock;
    }
}