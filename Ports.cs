using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ports
{
    public partial class Ports : Form
    {
        public Ports()
        {
            InitializeComponent();
        }

        private void scanBT_Click(object sender, EventArgs e)
        {
            comportCB.Text = "";
            comportCB.Items.Clear(); //clearing present in the comport
            String[] ports = SerialPort.GetPortNames(); //initializing COM Port
            comportCB.Items.AddRange(ports);
        }

        private void connectBT_Click(object sender, EventArgs e)
        {
            if(ConnectPort() == true)
            {
                connectBT.Enabled = false; //Will disable the connect button
                disconnectBT.Enabled = true; //Will enable the Disconnect button
                comportCB.Enabled = false; //Prohibiting the user from changing the com port after connection
                baudrateCB.Enabled = false; //Prohibiting the user from changing the baud rate after connection
                scanBT.Enabled = false;
                sendBT.Enabled  = true;
            }
        }

        public bool ConnectPort() //This fun will generate error box if com or baud rate box is empty
        {
            try {
                if(comportCB.Text != "" || baudrateCB.Text != "") 
                {
                    serialPort1.PortName = comportCB.Text;
                    serialPort1.BaudRate = Int32.Parse(baudrateCB.Text);
                    serialPort1.Open();
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
            return false;
        }

        private void disconnectBT_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            connectBT.Enabled = true;
            disconnectBT.Enabled = false;
            comportCB.Enabled = true;
            baudrateCB.Enabled = true;
            scanBT.Enabled = true;
            sendBT.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(serialPort1_DataReceived));
        }
        private bool allowDataEntry = true;
        private int rowCount = 0;
        private const int MaxEntries = 30;
        private void serialPort1_DataReceived(object sender, EventArgs e)
        {
            string dump = serialPort1.ReadLine();
            incomingTB.Text = incomingTB.Text + dump;
            string[] values = dump.Split(',');
            if (values.Length >= 2)
            {
                string Sensor1 = values[0];
                string Sensor2 = values[1];

                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-76NRQUB\\SQLEXPRESS;Initial Catalog=MyTestDB;Integrated Security=True;Pooling=False"))
                {
                    connection.Open();

                    // Check if max entries have been reached
                    string countQuery = "SELECT COUNT(*) FROM Arduino";
                    using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                    {
                        int currentEntryCount = (int)countCommand.ExecuteScalar();

                        if (currentEntryCount >= MaxEntries)
                        {
                            // Get the minimum RowNumber of the oldest entries
                            string minRowNumberQuery = "SELECT MIN(RowNumber) FROM (SELECT TOP (@EntriesToDelete) RowNumber FROM Arduino ORDER BY RowNumber ASC) AS T";
                            using (SqlCommand minRowNumberCommand = new SqlCommand(minRowNumberQuery, connection))
                            {
                                minRowNumberCommand.Parameters.AddWithValue("@EntriesToDelete", currentEntryCount - MaxEntries + 1);
                                int minRowNumber = (int)minRowNumberCommand.ExecuteScalar();

                                // Delete the oldest entries
                                string deleteQuery = "DELETE FROM Arduino WHERE RowNumber <= @MinRowNumber";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@MinRowNumber", minRowNumber);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }

                            // Reset rowCount to 0
                            rowCount = 0;
                        }
                    }

                    // Retrieve the last used RowNumber from the database
                    string getLastRowNumberQuery = "SELECT MAX(RowNumber) FROM Arduino";
                    using (SqlCommand getLastRowNumberCommand = new SqlCommand(getLastRowNumberQuery, connection))
                    {
                        object lastRowNumberObj = getLastRowNumberCommand.ExecuteScalar();
                        int lastRowNumber = (lastRowNumberObj != DBNull.Value) ? Convert.ToInt32(lastRowNumberObj) : 0;
                        int newRowNumber = lastRowNumber + 1;

                        string sql = "INSERT INTO Arduino (RowNumber, Sensor1, Sensor2) VALUES (@RowNumber, @Sensor1, @Sensor2)";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            // Add parameters to the command
                            command.Parameters.AddWithValue("@RowNumber", newRowNumber);
                            command.Parameters.AddWithValue("@Sensor1", Sensor1);
                            command.Parameters.AddWithValue("@Sensor2", Sensor2);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Successfully inserted data, update rowCount
                                rowCount = newRowNumber;
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert data into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }



        private void clearBT_Click(object sender, EventArgs e)
        {
            incomingTB.Text = "";
        }

        private void sendBT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(serialPort1.IsOpen)) { serialPort1.Open(); }
                serialPort1.Write(outgoingTB.Text);
                outgoingTB.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
