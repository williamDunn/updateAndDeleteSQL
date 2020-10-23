/*
 * -------------------------------------------------------------
   April Something 2018
   Using SQL Server
   Inserts, Updates, Deletes
-------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Needed to use SQL Server
using Microsoft.VisualBasic;

namespace Updates_with_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------
        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.address_BookTableAdapter.Fill(this.cPSC285DataSet.Address_Book);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void address_BookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.address_BookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cPSC285DataSet);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //String strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sample.accdb"
            String strConn = "Data Source=CISSQL;Initial Catalog=CPSC285;Integrated Security=True;Persist Security Info=False";
            //OleDBConnection cnnSample
            SqlConnection cnnSample;
            //OleDBCommand cmdUpdates
            SqlCommand cmdUpdates;
            int intRecordsAffected;
            String strSQL;
            
            strSQL = "Insert into [Address Book] " +
                "([id], [last name], [First Name], [salary], [State], [Married]) " +
                 "values (45, 'Bond', 'James', 98765, 'IL', 1)";

            /*
              
             String strLastName;
            strLastName = "Smith";
            strSQL = "Insert into [Address Book] " +
                 "([last name], [First Name], [salary], [State]) " +
                 "values ('" + strLastName + "', 'James', 98765, 'IL')";
                 */
            MessageBox.Show(strSQL);

            try
            {
                cnnSample = new SqlConnection(strConn);
                cnnSample.Open();

                cmdUpdates = new SqlCommand();

                cmdUpdates.Connection = cnnSample;
                cmdUpdates.CommandType = CommandType.Text;
                cmdUpdates.CommandText = strSQL;

                intRecordsAffected = cmdUpdates.ExecuteNonQuery();
                MessageBox.Show(intRecordsAffected + " records were added");
                cnnSample.Close();
                this.address_BookTableAdapter.Fill(this.cPSC285DataSet.Address_Book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------
        //  Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            String strConn = "Data Source=CISSQL;Initial Catalog=CPSC285;Integrated Security=True;Persist Security Info=False";
            SqlConnection cnnSample;
            SqlCommand cmdUpdates;
            int intRecordsAffected;
            String strSQL;

            strSQL = "Delete from [address book] where [last name] = 'Bond'";
            MessageBox.Show(strSQL);
            try
            {
                cnnSample = new SqlConnection(strConn);
                cnnSample.Open();

                cmdUpdates = new SqlCommand();

                cmdUpdates.Connection = cnnSample;
                cmdUpdates.CommandType = CommandType.Text;
                cmdUpdates.CommandText = strSQL;

                intRecordsAffected = cmdUpdates.ExecuteNonQuery();
                MessageBox.Show(intRecordsAffected + " records were deleted");
                cnnSample.Close();
                this.address_BookTableAdapter.Fill(this.cPSC285DataSet.Address_Book);
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------
        //  Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String strConn = "Data Source=CISSQL;Initial Catalog=CPSC285;Integrated Security=True;Persist Security Info=False";
            SqlConnection cnnSample;
            SqlCommand cmdUpdates;
            int intRecordsAffected;
            String strSQL;

            String strState = txtState.Text;

            strSQL = "Update [address book] " +
                 "set salary = salary + 100 " +
                 "where state = '" + strState + "'";
            MessageBox.Show(strSQL);
            try
            {
                cnnSample = new SqlConnection(strConn);
                cnnSample.Open();

                cmdUpdates = new SqlCommand();

                cmdUpdates.Connection = cnnSample;
                cmdUpdates.CommandType = CommandType.Text;
                cmdUpdates.CommandText = strSQL;

                intRecordsAffected = cmdUpdates.ExecuteNonQuery();
                MessageBox.Show(intRecordsAffected + " records were updated");
                cnnSample.Close();
                this.address_BookTableAdapter.Fill(this.cPSC285DataSet.Address_Book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

