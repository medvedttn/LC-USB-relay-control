using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using LC_USB_relay_control.Properties;

namespace LC_USB_relay_control
{
    public partial class frmMain : Form
    {
        private SerialPort gCOMPort=null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbCOMPort.Items.Clear();
            string[] arr_com_ports = SerialPort.GetPortNames();

            btnOpenRelay.Enabled = false;
            btnCloseRelay.Enabled = false;
            btnDisconnectPort.Enabled = false;

            if (arr_com_ports.Length > 0)
            {
                foreach (string com_name in arr_com_ports)
                {
                    cmbCOMPort.Items.Add((string)com_name);
                }
            }
            else
            {
                lblPortStatus.Text = "COM-ports not found in system!";
                cmbCOMPort.Enabled = false;
                return;
            }

            // restore saved COM port name, if any
            if (Settings.Default.ComName != null)
            {
                if (Settings.Default.ComName.Length>3)
                {
                    foreach (string com_list_name in cmbCOMPort.Items)
                    {
                        if (com_list_name == Settings.Default.ComName)
                        {
                            cmbCOMPort.SelectedItem = com_list_name;
                        }
                    }
                }
            }
        }

        private void cmbCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel_com = (string)cmbCOMPort.SelectedItem;
            try
            {
                // close prev opened port, if any
                if (gCOMPort != null)
                {
                    if (gCOMPort.IsOpen)
                    {
                        gCOMPort.Close();
                    }
                }
                
                SerialPort ser_com_port = new SerialPort(sel_com);

                if (ser_com_port.IsOpen)
                {
                    ser_com_port.Close();
                }
            
                gCOMPort = new SerialPort(sel_com, 9600, Parity.None, 8, StopBits.One);
                gCOMPort.ReadBufferSize = 20;
                gCOMPort.ReadTimeout = 500;
                gCOMPort.WriteBufferSize = 20;
                gCOMPort.WriteTimeout = 500;
                gCOMPort.Handshake = Handshake.None;
                gCOMPort.Encoding = Encoding.ASCII;

                gCOMPort.Open();

                if (gCOMPort.IsOpen)
                {
                    lblPortStatus.Text = "Port " + sel_com + " OPENED OK!";
                    lblPortStatus.BackColor = Color.Green;
                    btnDisconnectPort.Enabled = true;
                    btnOpenRelay.Enabled = true;
                    btnCloseRelay.Enabled = true;
                    Settings.Default.ComName = sel_com;
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                lblPortStatus.Text = "ERROR OPENING " + sel_com + " port!";
                lblPortStatus.BackColor = Color.Red;
                btnDisconnectPort.Enabled = false;
                btnOpenRelay.Enabled = false;
                btnCloseRelay.Enabled = false;
                MessageBox.Show("ERROR while OPENING " + sel_com + " !. Exception: " + ex.Message);
                return;
            }
        }

        private void btnOpenRelay_Click(object sender, EventArgs e)
        {
            byte[] arr_data = new byte[4];
            arr_data[0] = 0xA0;
            arr_data[1] = 0x01;
            arr_data[2] = 0x01;
            arr_data[3] = 0xA2; // checksum(%SUM in Terminal 1.9)

            try
            {
                if (gCOMPort != null)
                {
                    if (gCOMPort.IsOpen)
                    {
                        if (gCOMPort.BytesToWrite == 0)
                        {
                            gCOMPort.Write(arr_data, 0, 4);
                            lblPortStatus.Text = "RELAY ON for port " + (string)cmbCOMPort.SelectedItem;
                            lblPortStatus.BackColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblPortStatus.Text = "ERROR WHILE RELAY ON for port " + (string)cmbCOMPort.SelectedItem;
                lblPortStatus.BackColor = Color.Red;
                MessageBox.Show("ERROR while RELAY ON " + (string)cmbCOMPort.SelectedItem + " !. Exception: " + ex.Message);
                return;
            }
        }

        private void btnCloseRelay_Click(object sender, EventArgs e)
        {
            byte[] arr_data = new byte[4];
            arr_data[0] = 0xA0;
            arr_data[1] = 0x01;
            arr_data[2] = 0x00;
            arr_data[3] = 0xA1; // checksum(%SUM in Terminal 1.9)

            try
            {
                if (gCOMPort != null)
                {
                    if (gCOMPort.IsOpen)
                    {
                        if (gCOMPort.BytesToWrite == 0)
                        {
                            gCOMPort.Write(arr_data, 0, 4);
                            lblPortStatus.Text = "RELAY OFF for port " + (string)cmbCOMPort.SelectedItem;
                            lblPortStatus.BackColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblPortStatus.Text = "ERROR WHILE RELAY OFF for port " + (string)cmbCOMPort.SelectedItem;
                lblPortStatus.BackColor = Color.Red;
                MessageBox.Show("ERROR while RELAY OFF " + (string)cmbCOMPort.SelectedItem + " !. Exception: " + ex.Message);
                return;
            }
        }

        private void btnDisconnectPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (gCOMPort != null)
                {
                    if (gCOMPort.IsOpen)
                    {
                        gCOMPort.Close();
                        lblPortStatus.Text = "Port " + (string)cmbCOMPort.SelectedItem + " disconnected!";
                        btnDisconnectPort.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblPortStatus.Text = "ERROR WHILE DISCONNECT port " + (string)cmbCOMPort.SelectedItem;
                lblPortStatus.BackColor = Color.Red;
                MessageBox.Show("ERROR while DISCONNECT " + (string)cmbCOMPort.SelectedItem + " !. Exception: " + ex.Message);
                return;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (gCOMPort != null)
                {
                    if (gCOMPort.IsOpen) gCOMPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR while CLOSE port " + gCOMPort.PortName + " on exit. Exception: " + ex.Message);
                return;
            }
        }
    }
}
