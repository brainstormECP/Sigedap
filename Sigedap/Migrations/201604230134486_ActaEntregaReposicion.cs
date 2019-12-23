namespace Sigedap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActaEntregaReposicion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActasEntregaEquiposReposicion", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes");
            DropIndex("dbo.ActasEntregaEquiposReposicion", new[] { "Expediente_DictamenDeReclamacionId" });
            RenameColumn(table: "dbo.ActasEntregaEquiposReposicion", name: "Expediente_DictamenDeReclamacionId", newName: "ExpedienteDictamenDeReclamacionId");
            AlterColumn("dbo.ActasEntregaEquiposReposicion", "ExpedienteDictamenDeReclamacionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActasEntregaEquiposReposicion", "ExpedienteDictamenDeReclamacionId");
            AddForeignKey("dbo.ActasEntregaEquiposReposicion", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes", "DictamenDeReclamacionId", cascadeDelete: true);
            DropColumn("dbo.ActasEntregaEquiposReposicion", "ExpedienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActasEntregaEquiposReposicion", "ExpedienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ActasEntregaEquiposReposicion", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes");
            DropIndex("dbo.ActasEntregaEquiposReposicion", new[] { "ExpedienteDictamenDeReclamacionId" });
            AlterColumn("dbo.ActasEntregaEquiposReposicion", "ExpedienteDictamenDeReclamacionId", c => c.Int());
            RenameColumn(table: "dbo.ActasEntregaEquiposReposicion", name: "ExpedienteDictamenDeReclamacionId", newName: "Expediente_DictamenDeReclamacionId");
            CreateIndex("dbo.ActasEntregaEquiposReposicion", "Expediente_DictamenDeReclamacionId");
            AddForeignKey("dbo.ActasEntregaEquiposReposicion", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes", "DictamenDeReclamacionId");
        }
    }
}
