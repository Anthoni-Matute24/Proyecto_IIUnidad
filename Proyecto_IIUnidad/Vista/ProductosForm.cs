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
        Producto producto;
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

        // Procedimiento para Deshabilitar Controles
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

        // Procedimiento para Limpiar Controles
        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            ExistenciaTextBox.Clear();
            PrecioTextBox.Clear();
            FechaDateTimePicker.Value = DateTime.Now; // Fecha actual
            ImagenPictureBox.Image = null;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            TipoOperacion = "Nuevo";
            HabilitarControles();
        }

        private async void ModificarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                TipoOperacion = "Modificar";
                HabilitarControles();
                CodigoTextBox.ReadOnly = true;

                CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                FechaDateTimePicker.Value = Convert.ToDateTime(ProductosDataGridView.CurrentRow.Cells["FechaCreacion"].Value.ToString());

                // Consultar imagen del producto: var/byte[], byte[] es un arreglo de bytes
                var ImagenBD = await proDatos.SeleccionarImagen(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                // If para comprobar si hay una imagen
                if (ImagenBD.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(ImagenBD); // De MemoryStream a PictureBox
                    ImagenPictureBox.Image = System.Drawing.Bitmap.FromStream(ms); // Fotografía en PictureBox
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoTextBox.Text))
            {
                errorProvider1.SetError(CodigoTextBox, "Ingrese el código");
                CodigoTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider1.SetError(DescripcionTextBox, "Ingrese una descripción");
                DescripcionTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
            {
                errorProvider1.SetError(ExistenciaTextBox, "Ingrese una existencia");
                ExistenciaTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Ingrese el precio");
                PrecioTextBox.Focus();
                return;
            }

            producto = new Producto();
            // validar que el PictureBox contenga una Imagen
            if (ImagenPictureBox.Image != null)
            {
                MemoryStream ms = new MemoryStream(); // Objeto para acceder a la propiedad Imagen
                ImagenPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Guardar Imagen en PictureBox y su formato
                producto.Imagen = ms.GetBuffer(); // Carga la imagen para el método Insertar/Guardar
            }
            else
            {
                producto.Imagen = null;
            }

            // Asignar valores a los campos del formulario
            producto.Codigo = Convert.ToInt32(CodigoTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.FechaCreacion = FechaDateTimePicker.Value;

            if (TipoOperacion == "Nuevo")
            {
                bool inserto = await proDatos.InsertarAsync(producto); // Guardar un nuevo producto

                if (inserto)
                {
                    LlenarProductos();
                    LimpiarControles();
                    DeshabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se guardo el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (TipoOperacion == "Modificar")
            {
                bool modifico = await proDatos.ActualizarAsync(producto);

                if (modifico)
                {
                    LlenarProductos();
                    LimpiarControles();
                    DeshabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se modificó el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await proDatos.EliminarAsync(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    LlenarProductos();
                    LimpiarControles();
                    DeshabilitarControles();
                    MessageBox.Show("Producto eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se eliminó el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {

        }

        private void AdjuntarButton_Click(object sender, EventArgs e)
        {
            // Abrir cuadro de diálogo para que el usuario pueda buscar en su directorio de archivos
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog(); // Muestra el cuadro de diálogo

            if (result == DialogResult.OK) // Comprobar si contiene un archivo "result"
            {
                ImagenPictureBox.Image = Image.FromFile(dialog.FileName); // Cargar Imagen en PictureBox
            }
        }

        private void ExistenciaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si no es un dígito y no es un evento control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Se activa Handled y bloquea los caracteres
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.') )
            {
                e.Handled = true; // Se activa Handled y bloquea los caracteres
            }
            // Si es un punto y ya hay otro caracter '.': Activa evento Handled
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
