// ******************************************************************************************
// Arroyo Auz Christian Xavier.                                                             *
// 22/07/2016.                                                                              *
// ******************************************************************************************


using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Runtime.Remoting;
using System.Web.UI;
using ObjetoRemoto;
using System.Text;
using System.Linq;
using System.Web;
using System;


public partial class Servidor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Se inicia la conexion con el servidor para el uso del componente
        //Se comienxa la escucha por el puerto 59982
        HttpChannel canal = new HttpChannel(59982);
        //Se registra el canal de escucha y a los clientes por el canal designado e informando al cliente
        ChannelServices.RegisterChannel(canal, false);
        etiquetaIniciando.Text = "Iniciando el Servidor";
        //Registrando los servicios del componente Objerto Remoto
        RemotingConfiguration.RegisterWellKnownServiceType(typeof(ObjetoRemoto.ObjetoRemoto), "ObjetoRemoto.ObjetoRemoto", WellKnownObjectMode.Singleton);
    }
}