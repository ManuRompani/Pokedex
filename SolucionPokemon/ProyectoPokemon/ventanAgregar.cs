using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using dominio;
using negocio;

namespace ProyectoPokemon
{
    public partial class ventanAgregar : Form
    {
        private Pokemon pokemon = null;
        private OpenFileDialog archivo = null;
        public ventanAgregar()
        {
            InitializeComponent();
        }
        public ventanAgregar(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Numero = int.Parse(tboxNumero.Text);
                pokemon.Nombre = tboxNombre.Text;
                pokemon.Descripcion = tboxDescripcion.Text;
                pokemon.Tipo = (Elemento)cboxTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboxDebilidad.SelectedItem;
                pokemon.UrlImagen = tboxUrlImagen.Text;

                if(pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente.");
                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente.");
                }

                if (archivo != null && !(tboxUrlImagen.Text.ToUpper().Contains("HTPP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }

                Close();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ventanAgregar_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cboxTipo.DataSource = elementoNegocio.listar();
                cboxTipo.ValueMember = "Id";
                cboxTipo.DisplayMember = "Descripcion";
                cboxDebilidad.DataSource = elementoNegocio.listar();
                cboxDebilidad.ValueMember = "Id";
                cboxDebilidad.DisplayMember = "Descripcion";

                if (pokemon != null)
                {
                    tboxNumero.Text = pokemon.Numero.ToString();
                    tboxNombre.Text = pokemon.Nombre;
                    tboxDescripcion.Text = pokemon.Descripcion;
                    tboxUrlImagen.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    cboxTipo.SelectedValue = pokemon.Tipo.Id;
                    cboxDebilidad.SelectedValue = pokemon.Debilidad.Id;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pboxImagenAgregar.Load(imagen);
            }
            catch (Exception ex)
            {
                pboxImagenAgregar.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void tboxUrlImagen_Leave(object sender, EventArgs e)
        {

                cargarImagen(tboxUrlImagen.Text);

        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "png|*.png;|jpg|*.jpg";
            archivo.ShowDialog();
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                tboxUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"]);
            }
        }
    }
}
