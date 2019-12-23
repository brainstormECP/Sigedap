using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using Sigedap.Models;

namespace Sigedap.Reportes
{
    public partial class Solicitud_de_Reposicion : DevExpress.XtraReports.UI.XtraReport
    {
        public Solicitud_de_Reposicion(int id)
        {
            InitializeComponent();

            var db = new SigedapContext();
            var exp = db.Expedientes.Find(id);

            expediente.Text = exp.Numero;
            fecha.Text = exp.SolicitudReposicion.Fecha.ToShortDateString();
            nombre.Text = exp.DictamenDeReclamacion.NombreReclamante;
            direccion.Text = exp.DictamenDeReclamacion.Cliente.Direccion;
            carne.Text = exp.DictamenDeReclamacion.CiReclamante;

            DataSource = exp.EquiposDañados.Where(e => e.DictamenTecnico.Destino == Destino.BajaTecnica).ToList();

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
