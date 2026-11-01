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
            SuspendLayout();
            // 
            // lvSensors
            // 
            lvSensors.Location = new Point(32, 29);
            lvSensors.Name = "lvSensors";
            lvSensors.Size = new Size(121, 186);
            lvSensors.TabIndex = 1;
            lvSensors.UseCompatibleStateImageBehavior = false;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 654);
            Controls.Add(lvSensors);
            Name = "DashboardForm";
            Text = "DashboardForm";
            FormClosed += DashboardForm_FormClosed;
            Load += DashboardForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private ListView lvSensors;
    }
}