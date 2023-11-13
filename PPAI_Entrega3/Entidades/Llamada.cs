using PPAI_Entrega3.Entidades;
using PPAI_Entrega3.Gestor;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_Entrega3.Entidades
{
    public class Llamada
    {
        // Atributos
        [Key]
        public int Id {  get; set; }
        public string DescripcionOperador { get; set; }
        public string DetalleAccionRequerida { get; set; }
        public TimeSpan Duracion { get; set; }
        public bool EncuestaEnviada { get; set; }
        public string ObservacionAuditor { get; set; }

        // Relaciones
        public virtual Cliente Cliente { get; set; }
        public virtual SubOpcionLlamada SubOpcionLlamada { get; set; }
        public virtual OpcionLlamada? OpcionLlamada { get; set; }
        public virtual List<CambioEstado> CambiosDeEstado { get; set; }
        public virtual Estado Estado { get; set; }

        // estado

        // Constructor
        public Llamada(string descripcionOperador, string detalleAccionRequerida, TimeSpan duracion,
            bool encuestaEnviada, string observacionAuditor, Cliente cliente,
            SubOpcionLlamada subOpcionLlamada, OpcionLlamada opcionLlamada,
            List<CambioEstado> cambioDeEstado, Estado estado)
        {
            // Inicializar atributos
            this.DescripcionOperador = descripcionOperador;
            this.DetalleAccionRequerida = detalleAccionRequerida;
            this.Duracion = duracion;
            this.EncuestaEnviada = encuestaEnviada;
            this.ObservacionAuditor = observacionAuditor;

            // Inicializar relaciones
            this.Cliente = cliente;
            this.SubOpcionLlamada = subOpcionLlamada;
            this.OpcionLlamada = opcionLlamada;
            this.CambiosDeEstado = cambioDeEstado; // Cambiado por el new
            this.Estado = estado;
        }

        public Llamada() { }

        //Metodos de Seteo

        public void setCambioEstado(CambioEstado estado)
        {
            this.CambiosDeEstado.Add(estado); // ACCESO BD
        }

        public void setEstadoLlamada(Estado estado)
        {

            this.Estado = estado; // ACCESO BD

        }

        public void setDescripcionOperador(string descripcionOperador)
        {
            this.DescripcionOperador = descripcionOperador;
        }

        public String getDescripcionOperador()
        {
            return this.DescripcionOperador;
        }

        public void setDetalleAccionRequerida(string detalleAccionRequerida)
        {
            this.DetalleAccionRequerida = detalleAccionRequerida;
        }

        public String getDetalleAccionRequerida()
        {
            return this.DetalleAccionRequerida;
        }
        public void setDuracion(TimeSpan duracion)
        {
            this.Duracion = duracion;
        }

        public TimeSpan getDuracion()
        {
            return this.Duracion;
        }
        public void setEncuestaEnviada(bool encuestaEnviada)
        {
            this.EncuestaEnviada = encuestaEnviada;
        }
        public bool getEncuestaEnviada()
        {
            return this.EncuestaEnviada;
        }
        public void setObservacionAuditor(string observacionAuditor)
        {
            this.ObservacionAuditor = observacionAuditor;
        }

        public String getObservacionAuditor()
        {
            return this.ObservacionAuditor;
        }

        // Métodos
        public void tomadaPorOperador(string fechaHoraActual)
        {
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            this.Estado.tomadaPorOperador(fechaFormateada, this, CambiosDeEstado);
        }

        public string getCliente()
        {
            string nom = Cliente.getNombreClienteLlamada();
            return nom;
        }

        public string buscarInfoCorrecta(Llamada llamada, string validacion)
        {
            string correcta = llamada.Cliente.buscarInfoCorrecta(llamada, validacion);
            return correcta;
        }

        public bool validarInformacionCliente(string info, string validacion, Llamada llamada)
        {
            
            bool bandera = llamada.Cliente.esInformacionCorrecta(info, validacion, llamada);
            return bandera;
        }
        
        public void calcularDuracion(string fechaHoraEnCurso, string fechaHoraFinalizada)
        {
            DateTime Inicio = DateTime.Parse(fechaHoraEnCurso);
            DateTime Fin = DateTime.Parse(fechaHoraFinalizada);
            this.Duracion = Fin - Inicio;
        }
        public void finalizar(string fechaHoraActual, string respuesta)
        {
            this.DescripcionOperador = respuesta; //ACCESO BD
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            this.Estado.finalizar(fechaFormateada, this, CambiosDeEstado);

        }
    }

}

   





