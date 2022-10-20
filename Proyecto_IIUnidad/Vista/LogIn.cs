using Datos;

namespace Vista
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un código de usuario");
                UsuarioTextBox.Focus();
                return;

            }
            errorProvider1.Clear();

            if (ClaveTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                UsuarioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            // Instanciar un objeto de la clase "UsuarioDatos"
            UsuarioDatos userDatos = new UsuarioDatos();

            // Llamada del método "LoginAsync" para validar el acceso al sistema
            bool valido = await userDatos.LoginAsync(UsuarioTextBox.Text, ClaveTextBox.Text);

            if (valido)
            {
                // Muestra el menú principal
                Menu formulario = new Menu();
                Hide(); // Oculta el formulario Login 
                formulario.Show();
            }
            else 
            {   // Error en el inicio de sesión
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}