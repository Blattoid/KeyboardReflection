
namespace KeyboardReflection
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.startButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.effectDebugShowNames = new System.Windows.Forms.CheckBox();
            this.effectDebugShowRegion = new System.Windows.Forms.CheckBox();
            this.effectDebugEnable = new System.Windows.Forms.CheckBox();
            this.effectSaturationSlider = new System.Windows.Forms.TrackBar();
            this.effectSaturationReadout = new System.Windows.Forms.Label();
            this.effectSaturationEnable = new System.Windows.Forms.CheckBox();
            this.labelPerformance = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.effectSaturationSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(95, 44);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(86, 48);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.effectDebugShowNames);
            this.panel1.Controls.Add(this.effectDebugShowRegion);
            this.panel1.Controls.Add(this.effectDebugEnable);
            this.panel1.Controls.Add(this.effectSaturationSlider);
            this.panel1.Controls.Add(this.effectSaturationReadout);
            this.panel1.Controls.Add(this.effectSaturationEnable);
            this.panel1.Location = new System.Drawing.Point(44, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 143);
            this.panel1.TabIndex = 4;
            // 
            // effectDebugShowNames
            // 
            this.effectDebugShowNames.AutoSize = true;
            this.effectDebugShowNames.Enabled = false;
            this.effectDebugShowNames.Location = new System.Drawing.Point(34, 126);
            this.effectDebugShowNames.Name = "effectDebugShowNames";
            this.effectDebugShowNames.Size = new System.Drawing.Size(110, 17);
            this.effectDebugShowNames.TabIndex = 9;
            this.effectDebugShowNames.Text = "Show Key Names";
            this.effectDebugShowNames.UseVisualStyleBackColor = true;
            this.effectDebugShowNames.CheckedChanged += new System.EventHandler(this.effectDebugShowNames_CheckedChanged);
            // 
            // effectDebugShowRegion
            // 
            this.effectDebugShowRegion.AutoSize = true;
            this.effectDebugShowRegion.Checked = true;
            this.effectDebugShowRegion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.effectDebugShowRegion.Enabled = false;
            this.effectDebugShowRegion.Location = new System.Drawing.Point(34, 109);
            this.effectDebugShowRegion.Name = "effectDebugShowRegion";
            this.effectDebugShowRegion.Size = new System.Drawing.Size(133, 17);
            this.effectDebugShowRegion.TabIndex = 8;
            this.effectDebugShowRegion.Text = "Show Average Region";
            this.effectDebugShowRegion.UseVisualStyleBackColor = true;
            this.effectDebugShowRegion.CheckedChanged += new System.EventHandler(this.effectDebugShowRegion_CheckedChanged);
            // 
            // effectDebugEnable
            // 
            this.effectDebugEnable.AutoSize = true;
            this.effectDebugEnable.Location = new System.Drawing.Point(23, 91);
            this.effectDebugEnable.Name = "effectDebugEnable";
            this.effectDebugEnable.Size = new System.Drawing.Size(130, 17);
            this.effectDebugEnable.TabIndex = 7;
            this.effectDebugEnable.Text = "Show Debug Squares";
            this.effectDebugEnable.UseVisualStyleBackColor = true;
            this.effectDebugEnable.CheckedChanged += new System.EventHandler(this.effectDebugEnable_CheckedChanged);
            // 
            // effectSaturationSlider
            // 
            this.effectSaturationSlider.Enabled = false;
            this.effectSaturationSlider.Location = new System.Drawing.Point(9, 23);
            this.effectSaturationSlider.Maximum = 200;
            this.effectSaturationSlider.Name = "effectSaturationSlider";
            this.effectSaturationSlider.Size = new System.Drawing.Size(183, 45);
            this.effectSaturationSlider.TabIndex = 5;
            this.effectSaturationSlider.TickFrequency = 10;
            this.effectSaturationSlider.Value = 35;
            this.effectSaturationSlider.ValueChanged += new System.EventHandler(this.effectSaturationSlider_ValueChanged);
            // 
            // effectSaturationReadout
            // 
            this.effectSaturationReadout.AutoSize = true;
            this.effectSaturationReadout.Location = new System.Drawing.Point(60, 61);
            this.effectSaturationReadout.Name = "effectSaturationReadout";
            this.effectSaturationReadout.Size = new System.Drawing.Size(67, 13);
            this.effectSaturationReadout.TabIndex = 6;
            this.effectSaturationReadout.Text = "1x saturation";
            // 
            // effectSaturationEnable
            // 
            this.effectSaturationEnable.AutoSize = true;
            this.effectSaturationEnable.Checked = true;
            this.effectSaturationEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.effectSaturationEnable.Location = new System.Drawing.Point(23, 3);
            this.effectSaturationEnable.Name = "effectSaturationEnable";
            this.effectSaturationEnable.Size = new System.Drawing.Size(137, 17);
            this.effectSaturationEnable.TabIndex = 4;
            this.effectSaturationEnable.Text = "Enable saturation boost";
            this.effectSaturationEnable.UseVisualStyleBackColor = true;
            this.effectSaturationEnable.CheckedChanged += new System.EventHandler(this.effectSaturationEnable_CheckedChanged);
            // 
            // labelPerformance
            // 
            this.labelPerformance.AutoSize = true;
            this.labelPerformance.Location = new System.Drawing.Point(12, 98);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(106, 13);
            this.labelPerformance.TabIndex = 5;
            this.labelPerformance.Text = "Performance readout";
            this.labelPerformance.Visible = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 274);
            this.Controls.Add(this.labelPerformance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(305, 313);
            this.MinimumSize = new System.Drawing.Size(305, 313);
            this.Name = "Window";
            this.Text = "Keyboard Lighting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.effectSaturationSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar effectSaturationSlider;
        private System.Windows.Forms.Label effectSaturationReadout;
        private System.Windows.Forms.CheckBox effectSaturationEnable;
        private System.Windows.Forms.CheckBox effectDebugEnable;
        private System.Windows.Forms.CheckBox effectDebugShowRegion;
        private System.Windows.Forms.CheckBox effectDebugShowNames;
        private System.Windows.Forms.Label labelPerformance;
    }
}

