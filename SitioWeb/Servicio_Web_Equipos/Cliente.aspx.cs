// ******************************************************************************************
// Arroyo Auz Christian Xavier.                                                             *
// 22/07/2016.                                                                              *
// ******************************************************************************************


using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Threading;
using System.Drawing;
using System.Web.UI;
using ObjetoRemoto;
using System.Data;
using System.Linq;
using System.Web;
using System;

public partial class Cliente : System.Web.UI.Page
{
    //referencia a la libreria de clases y al objeto remoto
    ObjetoRemoto.ObjetoRemoto objetoremotoUsario = new ObjetoRemoto.ObjetoRemoto();
    //Lista que me permitiran recibir los datos
    List<Piezas> recibir = new List<Piezas>();
    List<Piezas> recibirIDBusqueda = new List<Piezas>();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Nada
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Carga el ID autonomerado, funcion de inicio de formulario y limpiar los campos de ser necesario
        CargarIdentificador();
    }

    public void CargarIdentificador()
    {
        //Llamando al objeto remoto que hara la consulta para crear un ide auto numerado
        objetoremotoUsario.obtenerrID(0);
        txtID.Text = Convert.ToString(objetoremotoUsario.idenfificadorUsuario + 1);
    }

    public void cargarDatos()
    {
        //Recibiendo un lista con todos los datos de la tabla y presentarlos en el listview y limpiando la lista recibida
        objetoremotoUsario.mostarTodos(recibir);
        foreach (Piezas item in recibir)
        {
            listaDatos.Items.Add(item.Id + "   " + item.Nombre_Pieza + "   " + item.Descripcion + "   " + item.Costo);
        }
        recibir.Clear();
    }

    public void buscarID()
    {
        //Recibiendo los datos de la consulta
        objetoremotoUsario.buscarID(recibir);
        //Recorriendo la lista para presentarla en el dfatgridview
        foreach (Piezas item in recibir)
        {
            listaDatos.Items.Add(item.Id + "   " + item.Nombre_Pieza + "   " + item.Descripcion + "   " + item.Costo);
        }
        //Funcionalidad para verificar si existen datos en la consulta
        if (recibir.Count() > 0)
        {
            //Limpiando la lista recibida
            recibir.Clear();
        }
        else
        {
            //Nada
        }
    }

    public void eliminarDatos()
    {
        //Recieviendo la nueva lista sin el usario eliminado
        objetoremotoUsario.eliminarCliente(recibir);
        foreach (Piezas item in recibir)
        {
            //Recorriendo la lista recibida y presentandola en la listview
            listaDatos.Items.Add(item.Id + "   " + item.Nombre_Pieza + "   " + item.Descripcion + "   " + item.Costo);
        }
        //Limpiando la lista recibida
        recibir.Clear();
    }

    public void modificarDatos()
    {
        //reciviwndo la lista para la modificacion de los elemntos
        objetoremotoUsario.modificarCliente(recibir);
        foreach (Piezas item in recibir)
        {
            //recorriendo la lista para agregar los datos en el listview
            listaDatos.Items.Add(item.Id + "   " + item.Nombre_Pieza + "   " + item.Descripcion + "   " + item.Costo);
        }
        //Limpiando la lista recibida
        recibir.Clear();
    }

    public void agregarDatos()
    {
        //recieviendo la lista con los nuevos usuarios
        objetoremotoUsario.agregarCliente(recibir);
        foreach (Piezas item in recibir)
        {
            //Recorriendo la lista para agregar los datos al listview
            listaDatos.Items.Add(item.Id + "   " + item.Nombre_Pieza + "   " + item.Descripcion + "   " + item.Costo);
        }
        //Limpiando la lista recibida
        recibir.Clear();
    }

    protected void boton_Agregar_Click(object sender, EventArgs e)
    {
        //Se agregara un nuevo cliente en la base de datos usando el objeto remoto
        //Se enviaran los parametros al objeto remoto para la agregacion del nuevo usuario
        objetoremotoUsario.idenfificadorUsuario = Convert.ToInt32(txtID.Text);
        objetoremotoUsario.nombre = txtNombre.Text;
        objetoremotoUsario.descripcion = txtDescripcion.Text;
        objetoremotoUsario.costo = Convert.ToInt32(txtCosto.Text);
        listaDatos.Items.Clear();
        //Metodo para agregar los datos
        agregarDatos();
    }

    protected void boton_Modificar_Click(object sender, EventArgs e)
    {
        //Modificacion de un cliente existente
        //Se enviaran los datos al objeto remoto con los nuevos datos a actualizar
        objetoremotoUsario.identificadorModidifcar = Convert.ToInt32(txtID.Text);
        objetoremotoUsario.nombre = txtNombre.Text;
        objetoremotoUsario.descripcion = txtDescripcion.Text;
        objetoremotoUsario.costo = Convert.ToInt32(txtCosto.Text);
        //Codigo que me permite la modificacion de los parametros del elemento seleccionado
        modificarDatos();
        listaDatos.Items.Clear();
        //Mostrando los datos en el listbox
        cargarDatos();
    }

    protected void boton_Eliminar_Click(object sender, EventArgs e)
    {
        //Se  llama a la liberia de clases y al objeto remoto para hacer la eliminacion del cliente
        //Cargar la nueva informacion
        objetoremotoUsario.idenfificadorUsuario = Convert.ToInt32(txtID.Text);
        listaDatos.Items.Add(txtID.Text);
        eliminarDatos();
        listaDatos.Items.Clear();
        cargarDatos();
        CargarIdentificador();
    }

    protected void boton_Mostrar_Click(object sender, EventArgs e)
    {
        //Me permite mostrar todos los elemntos dentro de la tabla Piezas en la la base de datos, mostrarlos en
        //el listbox
        listaDatos.Items.Clear();
        CargarIdentificador();
        cargarDatos();
    }

    protected void boton_Buscar_Click(object sender, EventArgs e)
    {
        //Lamando a la libreria de clases y al objeto remoto para poder hacer la consulta de un id especifico
        objetoremotoUsario.identificadorBusqueda = Convert.ToInt32(txt_Buscar.Text);
        //Lamando al metodo para cargar el identificador en el formulario
        listaDatos.Items.Clear();
        CargarIdentificador();
        buscarID();
    }

    protected void listaDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Creacion de variables locales para la presentacion de los datos cuando se selecciona en el listbox
        string cadena;
        int tamaño;
        string cargarDatos;
        //Limpiando los textbox antes de seleccionar un nuevo elemento del listox
        txtID.Text = "";
        txtNombre.Text = "";
        txtDescripcion.Text = "";
        txtCosto.Text = "";
        //Eliminando los espacion en blanco de la cadena obtenida del listbox seleccionado
        cadena = listaDatos.SelectedItem.Text.Replace("   ", "");
        //Obteniendo el tamaño de la cadena de caracteres y removiendo los caracteres para que solo quede el id
        tamaño = cadena.Length;
        cargarDatos = cadena.Remove(1, tamaño - 1);
        //Lamando a la libreria de clases y al objeto remoto para poder hacer la consulta de un id especifico
        objetoremotoUsario.identificadorBusqueda = Convert.ToInt32(cargarDatos);
        //Recibiendo los datos de la consulta
        objetoremotoUsario.buscarID(recibir);
        //Recorriendo la lista para presentarla en el dfatgridview
        foreach (Piezas item in recibir)
        {
            txtID.Text = item.Id.ToString();
            txtNombre.Text = item.Nombre_Pieza.ToString();
            txtDescripcion.Text = item.Descripcion.ToString();
            txtCosto.Text = item.Costo.ToString();
        }
        //Funcionalidad para verificar si existen datos en la consulta
        if (recibir.Count() > 0)
        {
            recibir.Clear();
        }
        else
        {
            //Nada
        }
    }
}