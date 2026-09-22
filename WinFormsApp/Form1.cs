using System.Net.Http.Json;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://tiendaapi-fvanc4hhezd2fpa4.centralus-01.azurewebsites.net/")
        };
        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await httpClient.GetFromJsonAsync<List<Producto>>("api/productos");

                dataGridView1.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var producto = new Producto
                {
                    Nombre = textBox1.Text,
                    Precio = decimal.Parse(textBox2.Text)
                };

                var respuesta = await httpClient.PostAsJsonAsync("api/productos", producto);

                if (respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto guardado correctamente.");

                    await CargarProductosAsync();

                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}

