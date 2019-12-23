using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using DevExpress.XtraReports.UI;
using Sigedap.Models;

namespace Sigedap.Reportes
{
    public partial class Acta_de_Devolucion_Baja : DevExpress.XtraReports.UI.XtraReport
    {
        public Acta_de_Devolucion_Baja(int id)
        {
            InitializeComponent();

            var db = new SigedapContext();

            var expedienteData = db.Expedientes.Include(e => e.EquiposDañados).Single(e => e.DictamenDeReclamacionId == id);

            uebObet.Text = expedienteData.DictamenDeReclamacion.Ueb;
            noExpediente.Text = expedienteData.Numero;
            fecha.Text = expedienteData.ActaRecogidaEquipos.Fecha.ToShortDateString();

            cliente.Text = expedienteData.DictamenDeReclamacion.Cliente.NombreCompleto;
            ciCliente.Text = expedienteData.DictamenDeReclamacion.Cliente.Ci;            
            representante.Text = expedienteData.ActaRecogidaEquipos.NombreRepresentante;
            ciRepresentante.Text = expedienteData.ActaRecogidaEquipos.CiRepresentante;

            DataSource = expedienteData.EquiposDañados.Where(e => e.DictamenTecnico.Destino == Destino.BajaTecnica).ToList();

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
