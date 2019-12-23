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
    public partial class Acta_Recogida_Traslado : DevExpress.XtraReports.UI.XtraReport
    {
        public Acta_Recogida_Traslado(int id)
        {
            InitializeComponent();
            var db = new SigedapContext();
                var expedienteData = db.Expedientes.Include(e => e.ActaRecogidaEquipos).Include(e => e.DictamenDeReclamacion).Single(e => e.DictamenDeReclamacionId == id);

                uebObet.Text = expedienteData.DictamenDeReclamacion.Ueb;
                expediente.Text = expedienteData.Numero;
                fecha.Text = expedienteData.ActaRecogidaEquipos.Fecha.ToShortDateString();

                cliente.Text = expedienteData.DictamenDeReclamacion.Cliente.NombreCompleto;
                ciCliente.Text = expedienteData.DictamenDeReclamacion.Cliente.Ci;
                dirCliente.Text = expedienteData.DictamenDeReclamacion.Cliente.Direccion;
                reparto.Text = expedienteData.DictamenDeReclamacion.Cliente.Rpto;
                municipio.Text = expedienteData.DictamenDeReclamacion.Cliente.Municipio;
                representanteEmpElect.Text = expedienteData.ActaRecogidaEquipos.NombreRepresentante;
                ciRepresentante.Text = expedienteData.ActaRecogidaEquipos.CiRepresentante;

                DataSource = expedienteData.EquiposDañados.ToList();

                this.tipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TipoDeEquipo.Nombre")});

                this.marca.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Marca.Nombre")});

                this.descripcion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Descripcion")});
                
                this.modelo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Modelo")});
            }
        
    }
}
