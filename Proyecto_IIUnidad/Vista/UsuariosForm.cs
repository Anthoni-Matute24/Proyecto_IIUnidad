using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        // Instanciar objeto
        UsuarioDatos userDatos = new UsuarioDatos();

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }

        // Procedimiento para llenar/cargar el DataGridView con el listado de la tabla Usuario
        private async void LlenarDataGrid()
        {
            // DataSource: Obtiene todos los datos de un DataSet, DataTable, DataGridView, Lista, Colección
            UsuariosDataGridView.DataSource = await userDatos.DevolverListaAsync();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            RolComboBox.Enabled = true;
            EstaActivoCheckBox.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            RolComboBox.Enabled = false;
            EstaActivoCheckBox.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            CorreoTextBox.Clear();
            RolComboBox.Text = String.Empty;
            EstaActivoCheckBox.Checked = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }
    }
}
