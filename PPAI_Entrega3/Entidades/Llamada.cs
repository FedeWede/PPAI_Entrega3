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
        public int idLlamada {  get; set; }
        public string descripcionOperador { get; set; }
        public string detalleAccionRequerida { get; set; }
        public TimeSpan duracion { get; set; }
        public bool encuestaEnviada { get; set; }
        public string observacionAuditor { get; set; }

        // Relaciones
        public virtual Cliente cliente { get; set; }
        public virtual SubOpcionLlamada subOpcionLlamada { get; set; }
        public virtual OpcionLlamada opcionLlamada { get; set; }
        public virtual List<CambioEstado> cambiosDeEstado { get; set; }
        public virtual Estado estado { get; set; }

        // estado

        // Constructor
        public Llamada(string descripcionOperador, string detalleAccionRequerida, TimeSpan duracion,
            bool encuestaEnviada, string observacionAuditor, Cliente cliente,
            SubOpcionLlamada subOpcionLlamada, OpcionLlamada opcionLlamada,
            List<CambioEstado> cambioDeEstado, Estado estado)
        {
            // Inicializar atributos
            this.descripcionOperador = descripcionOperador;
            this.detalleAccionRequerida = detalleAccionRequerida;
            this.duracion = duracion;
            this.encuestaEnviada = encuestaEnviada;
            this.observacionAuditor = observacionAuditor;

            // Inicializar relaciones
            this.cliente = cliente;
            this.subOpcionLlamada = subOpcionLlamada;
            this.opcionLlamada = opcionLlamada;
            this.cambiosDeEstado = cambioDeEstado; // Cambiado por el new
            this.estado = estado;
        }

        public Llamada() { }

        //Metodos de Seteo

        public void setCambioEstado(CambioEstado estado)
        {
            this.cambiosDeEstado.Add(estado);
        }

        public void setEstadoLlamada(Estado estado)
        {

            this.estado = estado;

        }

        public void setDescripcionOperador(string descripcionOperador)
        {
            this.descripcionOperador = descripcionOperador;
        }

        public String getDescripcionOperador()
        {
            return this.descripcionOperador;
        }

        public void setDetalleAccionRequerida(string detalleAccionRequerida)
        {
            this.detalleAccionRequerida = detalleAccionRequerida;
        }

        public String getDetalleAccionRequerida()
        {
            return this.detalleAccionRequerida;
        }
        public void setDuracion(TimeSpan duracion)
        {
            this.duracion = duracion;
        }

        public TimeSpan getDuracion()
        {
            return this.duracion;
        }
        public void setEncuestaEnviada(bool encuestaEnviada)
        {
            this.encuestaEnviada = encuestaEnviada;
        }
        public bool getEncuestaEnviada()
        {
            return this.encuestaEnviada;
        }
        public void setObservacionAuditor(string observacionAuditor)
        {
            this.observacionAuditor = observacionAuditor;
        }

        public String getObservacionAuditor()
        {
            return this.observacionAuditor;
        }

        // Métodos
        public void tomadaPorOperador(string fechaHoraActual)
        {
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            this.estado.tomadaPorOperador(fechaFormateada, this);
        }

        public string getCliente()
        {
            string nom = cliente.getNombreClienteLlamada();
            return nom;
        }

        public string buscarInfoCorrecta(Llamada llamada, string validacion)
        {
            string correcta = llamada.cliente.buscarInfoCorrecta(llamada, validacion);
            return correcta;
        }

        public bool validarInformacionCliente(string info, string validacion, Llamada llamada)
        {
            
            bool bandera = llamada.cliente.esInformacionCorrecta(info, validacion, llamada);
            return bandera;
        }
        
        public void calcularDuracion(string fechaHoraEnCurso, string fechaHoraFinalizada)
        {
            DateTime Inicio = DateTime.Parse(fechaHoraEnCurso);
            DateTime Fin = DateTime.Parse(fechaHoraFinalizada);
            this.duracion = Fin - Inicio;
        }
        public void finalizar(string fechaHoraActual, string respuesta)
        {
            this.descripcionOperador = respuesta;
            DateTime fechaFormateada = DateTime.Parse(fechaHoraActual);
            this.estado.finalizar(fechaFormateada, this);
        }
    }

}

   





