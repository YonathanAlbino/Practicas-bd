﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos_ado_net
{
    public partial class Form1 : Form
    {

        private List<Pokemon> listaPokemon; //Creo atributo de tipo lista de Pokemon
       
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar(); //Cargo el atributo-lista con el metodo (listar de la clase PokemonNegocio)
            dgvPokemons.DataSource = listaPokemon; //Le paso el atributo-lista a la DataGriv
            dgvPokemons.Columns["UrlImagen"].Visible = false; //Oculta la columna (UrlImagen) de la dgvPokemons
            cargarImagen(listaPokemon[0].UrlImagen); //Al cargase la ventana, se selecciona en la pbxPokemon la listaPokemon con la propiedad UrlImagen en el indice[0]

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e) //Cuando se cambia la seleccion de la grilla-dgvPokemons, se cambia la imagen en la pictureBox-pbxPokemon
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;  //Se obtiene el objeto enlazado de la grilla-dgvPokemons en la fila actual, y se lo transforma en un objeto de tipo Pokemon y se guarda en (seleccionado)
            cargarImagen(seleccionado.UrlImagen); //Llamado al metodo (cargar imagen)
        }

        private void cargarImagen(string imagen) //Metodo encargado de cargar imagen
        {
            try
            {
                pbxPokemon.Load(imagen); //Se carga en la pictureBox-pbxPokemon el objeto (seleccionado) con la propiedad (UrlImagen) obtenida anteriormente
            }
            catch (Exception ex)
            {

                pbxPokemon.Load("https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"); // Carga una imagen pre-seleccionada en caso de error
            }
        }

    }
}
