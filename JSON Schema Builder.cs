using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Json_Builder;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;

namespace Json_Builder
{
    public partial class JSONBuilder : Form
    {
        BindingList<JObject> collected = new BindingList<JObject>();
        BindingList<JObject> chosenSchemas = new BindingList<JObject>();

        //Form Constructior
        public JSONBuilder()
        {
            InitializeComponent();
        }

        //FormLoad method, enabled when the form first runs
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                GetAndSort.GetNSort();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Add, Remove and Create button logic

        //when create button is clicked - Uses BuildJSON method to build the object
        private void btnCreate_Click(object sender, EventArgs e)
        {
            BuildJSON.Build(chosenSchemas);
        }

        //when add schema button is clicked - selected schema is added to the chosen selection
        private void btnAddSchema_Click(object sender, EventArgs e)
        {
            chosenSchemas.Add(collected[cmbCollectedSchemas.SelectedIndex]);

            lstChosenSchemas.DataSource = chosenSchemas;
            lstChosenSchemas.DisplayMember = "displaymember";
        }

        //when remove button is clicked - selected schema is removed from the chosen selection
        private void btnRemove_Click(object sender, EventArgs e)
        {
            chosenSchemas.Remove(chosenSchemas[lstChosenSchemas.SelectedIndex]);

            lstChosenSchemas.DataSource = chosenSchemas;
        }

#endregion

        #region Radio Buttons to choose which selection of schemas to build
        //ccaCase
        private void radCCACase_CheckedChanged(object sender, EventArgs e)
        {
            if (radCCACase.Checked == true) collected = GetAndSort.CCACaseSchemas;

            cmbCollectedSchemas.DataSource = null;
            cmbCollectedSchemas.DataSource = collected;

            cmbCollectedSchemas.DisplayMember = "displaymember";
        }
        //ccaAuth
        private void radCCAAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radCCAAuth.Checked == true) collected = GetAndSort.CCAAuthSchemas;

            cmbCollectedSchemas.DataSource = null;
            cmbCollectedSchemas.DataSource = collected;

            cmbCollectedSchemas.DisplayMember = "displaymember";
        }
        //ndrList
        private void radNDRList_CheckedChanged(object sender, EventArgs e)
        {
            if (radNDRList.Checked == true) collected = GetAndSort.NDRListSchemas;

            cmbCollectedSchemas.DataSource = null;
            cmbCollectedSchemas.DataSource = collected;

            cmbCollectedSchemas.DisplayMember = "displaymember";
        }
        //ndrVal
        private void radNDRVal_CheckedChanged(object sender, EventArgs e)
        {
            if (radNDRVal.Checked == true) collected = GetAndSort.NDRValuationSchemas;

            cmbCollectedSchemas.DataSource = null;
            cmbCollectedSchemas.DataSource = collected;

            cmbCollectedSchemas.DisplayMember = "displaymember";
        }
        //customer
        private void radCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (radCustomer.Checked == true) collected = GetAndSort.CustomerSchemas;

            cmbCollectedSchemas.DataSource = null;
            cmbCollectedSchemas.DataSource = collected;

            cmbCollectedSchemas.DisplayMember = "displaymember";
        }
        #endregion
    }
}
