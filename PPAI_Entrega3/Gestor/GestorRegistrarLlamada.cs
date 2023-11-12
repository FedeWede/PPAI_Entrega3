using PPAI_Entrega3.Entidades;
using PPAI_Entrega3.Interfaces;
using PPAI_Entrega3.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_Entrega3.Servicios;
using PPAI_Entrega3.Persistencia;

namespace PPAI_Entrega3.Gestor
{
    public class GestorRegistrarLlamada
    {
        private readonly InterfazIVR interfaz;

        // Constructor que recibe la instancia del formulario
        public GestorRegistrarLlamada(InterfazIVR interfaz)
        {

            this.interfaz = interfaz;
        }

        // relaciones
        public InterfazIVR interfazIVR;
        public GestorRegistrarRespuesta gestorRegistrarRespuesta;
        public InterfazRegistrarRespuesta interfazRegistrarLlamada;
        
        // Instanciamos los objetos a forma de simulación:
        public (Llamada, Categoria) opcionNuevaRespuestaOperador()
        {
            using IVRContexto context = new IVRContexto();

            TipoInformacion tipoInfoCantHijos = new TipoInformacion("Cantidad de Hijos", "Es la cantidad de hijos del cliente");

            TipoInformacion tipoInfoFechaNac = new TipoInformacion("Fecha de Nacimiento", "Es la fecha de nacimiento del cliente");

            TipoInformacion tipoInfoCodPostal = new TipoInformacion("Codigo postal", "Es el codigo postal del cliente");


            context.TipoInformacion.AddRange(tipoInfoCantHijos, tipoInfoFechaNac, tipoInfoCodPostal);
            context.SaveChanges();

            Validacion validacion1 = new Validacion() { AudioMensajeValidacion = "Audio", Nombre = "Cantidad de hijos: ", NroOrden = 1, TipoInformacion = tipoInfoCantHijos };

            Validacion validacion2 = new Validacion("Audio", "Fecha Nacimiento: ", 1, tipoInfoFechaNac);

            Validacion validacion3 = new Validacion("Audio", "Código postal", 1, tipoInfoCodPostal);

            context.Validacion.AddRange(validacion1, validacion2, validacion3);
            context.SaveChanges();  

            List<Validacion> validaciones = new List<Validacion>();
            validaciones.Add(validacion1);
            validaciones.Add(validacion2);
            validaciones.Add(validacion3);
            

            List<InformacionCliente> informacionClientes = new List<InformacionCliente>();

            InformacionCliente infoClienteCantHijos = new InformacionCliente() { DatoAValidar = "4", TipoInformacion = tipoInfoCantHijos, Validacion = validacion1 };
            informacionClientes.Add(infoClienteCantHijos);
           
            InformacionCliente infoClienteFechaNac = new InformacionCliente() { DatoAValidar = "22/09/2000", Validacion = validacion2, TipoInformacion = tipoInfoFechaNac };
           informacionClientes.Add(infoClienteFechaNac);

            InformacionCliente infoClienteCodPostal = new InformacionCliente() {DatoAValidar = "5000", Validacion = validacion3, TipoInformacion = tipoInfoCodPostal };
            informacionClientes.Add(infoClienteCodPostal);

            context.InformacionCliente.AddRange(infoClienteCantHijos, infoClienteFechaNac, infoClienteCodPostal);
            context.SaveChanges();

            SubOpcionLlamada subOpcion = new SubOpcionLlamada("Hablar con operador", 1, validaciones);
            List<SubOpcionLlamada> listaSubOpciones = new List<SubOpcionLlamada>();
            listaSubOpciones.Add(subOpcion);

            SubOpcionLlamada subOpcion2 = new SubOpcionLlamada("Volver atras", 2, null);
            listaSubOpciones.Add(subOpcion2);

            context.SubOpcionLlamada.AddRange(subOpcion, subOpcion2);
            context.SaveChanges();

            OpcionLlamada opcionLlamada1 = new OpcionLlamada()
            {
                AudioMensajeSubOpciones = "Audio",
                MensajeSubOpciones = "Hablar con operador 1. Finalizar 2",
                Nombre = "Informar robo y anular tarjeta",
                NroOrden = 1,
                SubOpciones = listaSubOpciones,
                Validacion = validaciones
            };
            List<OpcionLlamada> listaOpciones = new List<OpcionLlamada>();
            listaOpciones.Add(opcionLlamada1);

            context.opcionLlamada.Add(opcionLlamada1);
            context.SaveChanges();

            Categoria categoria = new Categoria() 
                {AudioMensajeOpciones = "Audio", 
                MensajeOpciones = "Informar robo y solicitar tarjeta 1. Informar robo y anular tarjeta 2.",
                Nombre = "Informar robo",
                NroOrden = 1, Opciones = listaOpciones};

            context.Categoria.Add(categoria);
            context.SaveChanges();

            Cliente cliente = new Cliente("23097372", "Juan Pérez", "9q9999", informacionClientes);

            context.Cliente.Add(cliente);
            context.SaveChanges();

            Iniciada iniciada = new Iniciada("Iniciada");
            EnCurso enCurso = new EnCurso("En Curso");
            Finalizada finalizada = new Finalizada("Finalizada");
            Cancelada cancelada = new Cancelada("Cancelada");

            context.Estado.AddRange(iniciada, enCurso, finalizada, cancelada);

            DateTime tiempo1 = new DateTime(1, 1, 1, 1, 1, 1);

            CambioEstado cambioEstado = new CambioEstado(tiempo1, iniciada);
            List<CambioEstado> historialEstados = new List<CambioEstado>();
            historialEstados.Add(cambioEstado);

            context.CambioEstado.Add(cambioEstado);
            context.SaveChanges();

            Llamada llamada = new Llamada()
            {
                DescripcionOperador = "Sin descripción",
                DetalleAccionRequerida = "Sin acción req",
                Duracion = TimeSpan.Zero,
                EncuestaEnviada = false,
                ObservacionAuditor = "Sin observación",
                Cliente = cliente,
                SubOpcionLlamada = subOpcion,
                OpcionLlamada = opcionLlamada1,
                CambiosDeEstado = historialEstados,
                Estado = iniciada
            };

            context.Llamada.Add(llamada);
            context.SaveChanges();


            // Llamar a los métodos del formulario para mostrar los datos
            interfaz.MostrarDNI(cliente.Dni);
            interfaz.MostrarCategoria(categoria.NroOrden);
            interfaz.MostrarOpcion(opcionLlamada1.NroOrden);
            interfaz.MostrarSubopcion(subOpcion.NroOrden);       
            return (llamada, categoria);
        }
       
    }
}
