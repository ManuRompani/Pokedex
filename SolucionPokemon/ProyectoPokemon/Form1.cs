using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace ProyectoPokemon
{
    public partial class Form1 : Form
    {
        private List<Pokemon> pokemonList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboxCampo.Items.Add("Numero");
            cboxCampo.Items.Add("Nombre");
        }


        private void cargar()
        {
            PokemonNegocio dataBase = new PokemonNegocio();
            pokemonList = dataBase.listar();
            dgvPokemon.DataSource = pokemonList;
            cargarImagen(pokemonList[0].UrlImagen);
            this.dgvPokemon.Columns["UrlImagen"].Visible = false;
            this.dgvPokemon.Columns["Id"].Visible = false;
        }

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Pokemon seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);

            }
            catch
            {

            }

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                picBoxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                picBoxPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ventanAgregar agregar = new ventanAgregar();
            agregar.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem; 
            ventanAgregar modificar = new ventanAgregar(seleccionado);
            modificar.ShowDialog();
            cargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("Estas seguro que quieres eliminar el Pokemon " + seleccionado.Nombre + "?","Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("Estas seguro que quieres dar de baja el Pokemon " + seleccionado.Nombre + "?", "Dando baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.darBaja(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void txtboxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = tboxFiltro.Text;
            listaFiltrada = pokemonList.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Numero.ToString() == filtro);
            if (filtro.Length >= 2)
            {
                dgvPokemon.DataSource = null;
                dgvPokemon.DataSource = listaFiltrada;
                this.dgvPokemon.Columns["UrlImagen"].Visible = false;
                this.dgvPokemon.Columns["Id"].Visible = false;
            }
            else
            {
                dgvPokemon.DataSource = pokemonList;
            }
        }

        private void cboxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboxCampo.SelectedItem.ToString();

            if(opcion == "Numero")
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Mayor a");
                cboxCriterio.Items.Add("Igual a");
                cboxCriterio.Items.Add("Menor a");
            }
            else
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Comienza con");
                cboxCriterio.Items.Add("Contiene");
                cboxCriterio.Items.Add("Termina con");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                string criterio = cboxCriterio.SelectedItem.ToString();
                string campo = cboxCampo.SelectedItem.ToString();
                string filtro = tboxFiltroAvanzado.Text;
                dgvPokemon.DataSource = negocio.filtrado(criterio, campo, filtro);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
