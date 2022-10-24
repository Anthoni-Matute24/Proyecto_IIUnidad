using Datos;
using Entidades;
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
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        // Instanciación de Objetos
        ProductoDatos proDatos = new ProductoDatos();
        Producto producto = new Producto();
        string TipoOperacion = string.Empty;
        private void ProductosForm_Load(object sender, EventArgs e)
        {
            LlenarProductos();
        }
        // Procedimiento para llenar/cargar/actualizar el DataGridView
        private async void LlenarProductos()
        {
            ProductosDataGridView.DataSource = await proDatos.DevolverListaAsync();
        }

        // Procedimiento para Habilitar Controles
        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            FechaDateTimePicker.Enabled = true;
            ImagenPictureBox.Enabled = true;
            AdjuntarButton.Enabled = true;
        }

        // Procedimiento para Habilitar Controles
        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            FechaDateTimePicker.Enabled = false;
            ImagenPictureBox.Enabled = false;
            AdjuntarButton.Enabled = false;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            TipoOperacion = "Nuevo";
            HabilitarControles();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
