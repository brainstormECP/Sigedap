using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using DevExpress.XtraReports.UI;
using Sigedap.Models;

namespace Sigedap.Reportes
{
    public partial class Expediente_de_Reclamacion : DevExpress.XtraReports.UI.XtraReport
    {
        public Expediente_de_Reclamacion(int id)
        {
            InitializeComponent();
            var db = new SigedapContext();
            
                var expedienteData = db.Expedientes.Include(e => e.EquiposDañados).Single(e => e.DictamenDeReclamacionId == id);
                expediente.Text = expedienteData.Numero;
                ueb.Text = expedienteData.DictamenDeReclamacion.Ueb;
                oficina.Text = expedienteData.DictamenDeReclamacion.OficinaComercial;
                nombres.Text = expedienteData.DictamenDeReclamacion.Cliente.Nombres;
                apellido1.Text = expedienteData.DictamenDeReclamacion.Cliente.PrimerApellido;
                apellido2.Text = expedienteData.DictamenDeReclamacion.Cliente.SegundoApellido;
                calle.Text = expedienteData.DictamenDeReclamacion.Cliente.Calle;
                no.Text = expedienteData.DictamenDeReclamacion.Cliente.No.ToString();
                entre.Text = expedienteData.DictamenDeReclamacion.Cliente.EntreCalle1;
                y.Text = expedienteData.DictamenDeReclamacion.Cliente.EntreCalle2;
                apto.Text = expedienteData.DictamenDeReclamacion.Cliente.Apto;
                rpto.Text = expedienteData.DictamenDeReclamacion.Cliente.Rpto;
                telefonop.Text = expedienteData.DictamenDeReclamacion.Cliente.TelefonoParticular.ToString();
                telefonot.Text = expedienteData.DictamenDeReclamacion.Cliente.TelefonoTrabajo.ToString();
                ruta.Text = expedienteData.DictamenDeReclamacion.Cliente.Ruta.ToString();
                control.Text = expedienteData.DictamenDeReclamacion.Cliente.Control.ToString();
                folio.Text = expedienteData.DictamenDeReclamacion.Cliente.Folio.ToString();
                nombrer.Text = expedienteData.DictamenDeReclamacion.NombreReclamante;
                carne.Text = expedienteData.DictamenDeReclamacion.CiReclamante;
                pagado.Text = expedienteData.PagadoHasta.ToString("M");
                año.Text = expedienteData.PagadoHasta.Year.ToString();
                //TODO: Arreglar la entidad para incluir la explicacion de porque no coinciden.
                explicacion.Text = expedienteData.DictamenDeReclamacion.NombreReclamante;
                causas.Text = expedienteData.Causas;
                amparado.Text = expedienteData.AmparadoPorNt;
                afectacion.Text = expedienteData.FechaAfectacion.ToShortDateString();
                horaa.Text = expedienteData.FechaAfectacion.ToShortTimeString();
                normalizado.Text = expedienteData.FechaDeNormalizacionServicio.ToShortDateString();
                horan.Text = expedienteData.FechaDeNormalizacionServicio.ToShortTimeString();
                operario.Text = expedienteData.Operario.NombreCompleto;
                despachador.Text = expedienteData.Despachador.NombreCompleto;
                recibido.Text = expedienteData.FechaRecibidoUebMunicipal.ToShortDateString();
                visita.Text = expedienteData.FechaVisitaCliente.ToShortDateString();
                inspector.Text = expedienteData.Inspector.NombreCompleto;
                noNt.Text = expedienteData.AmparadoPorNt;
                fechaNt.Text = expedienteData.FechaNt.ToShortDateString();

                DataSource = expedienteData.EquiposDañados.ToList();

                this.tipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TipoDeEquipo.Nombre")});

                this.marca.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Marca.Nombre")});

                this.nacionalidad.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Nacionalidad")});

                this.serie.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Serie")});

                this.modelo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Modelo")});

                observaciones.Text = expedienteData.Observaciones;


            }

    }
}
