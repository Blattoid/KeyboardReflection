using System;
using System.Threading;
using System.Windows.Forms;

namespace KeyboardReflection
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            effectSaturationReadout.BringToFront();
            UpdateEffectParameters();
        }

        // Thread LedUpdateThread;
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Text = "Started";
            startButton.Enabled = false;

            Program.LedUpdateThread = new Thread(Program.LedUpdateThread_Task);
            Program.LedUpdateThread.Start();
        }

        void UpdateReadout(object sender, EventArgs e)
        {
            /*
            form.labelPerformance.Invoke((MethodInvoker)delegate
            {
                load_values[i] = timer.ElapsedMilliseconds;
                i++;
                if (i >= load_values.Length) i = 0;
                int load = (int)(Mean(load_values) / (double)delay * 100.0);
                form.labelPerformance.Text = string.Format("Thread load at {0}%", load);
                form.labelPerformance.ForeColor = load > 95 ? Color.Red : SystemColors.ControlText;
            });*/
        }
        /*static long Mean(long[] values)
        {
            long output = 0;
            foreach (int value in values) output += value;
            return output / values.Length;
        }*/

        private void effectSaturationEnable_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEffectParameters();
        }
        private void effectSaturationSlider_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffectParameters();
        }
        private void effectDebugEnable_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEffectParameters();
        }
        private void effectDebugShowRegion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEffectParameters();
        }
        private void effectDebugShowNames_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEffectParameters();
        }
        /// <summary>
        /// Recalculate readout values and update internal variables related to UI controls
        /// </summary>
        private void UpdateEffectParameters()
        {
            Program.Flags.saturation_enable = effectSaturationEnable.Checked;
            effectSaturationSlider.Enabled = Program.Flags.saturation_enable;
            Program.Flags.saturation_factor = effectSaturationSlider.Value / 10.0;
            effectSaturationReadout.Text = (Program.Flags.saturation_enable ? Program.Flags.saturation_factor : 1) + "x saturation";

            Program.Flags.debug_enable = effectDebugEnable.Checked;
            effectDebugShowRegion.Enabled = Program.Flags.debug_enable;
            effectDebugShowNames.Enabled = Program.Flags.debug_enable;
            Program.Flags.debug_showscanregion = effectDebugShowRegion.Checked;
            Program.Flags.debug_showkeynames = effectDebugShowNames.Checked;
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Don't actually quit,
            Hide(); // instead just hide the form.
        }
    }
}