namespace Sigedap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoActaDestruir : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActasRecogidaDestruir", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes");
            DropIndex("dbo.ActasRecogidaDestruir", new[] { "Expediente_DictamenDeReclamacionId" });
            RenameColumn(table: "dbo.ActasRecogidaDestruir", name: "Expediente_DictamenDeReclamacionId", newName: "ExpedienteDictamenDeReclamacionId");
            AlterColumn("dbo.ActasRecogidaDestruir", "ExpedienteDictamenDeReclamacionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActasRecogidaDestruir", "ExpedienteDictamenDeReclamacionId");
            AddForeignKey("dbo.ActasRecogidaDestruir", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes", "DictamenDeReclamacionId", cascadeDelete: true);
            DropColumn("dbo.ActasRecogidaDestruir", "ExpedienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActasRecogidaDestruir", "ExpedienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ActasRecogidaDestruir", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes");
            DropIndex("dbo.ActasRecogidaDestruir", new[] { "ExpedienteDictamenDeReclamacionId" });
            AlterColumn("dbo.ActasRecogidaDestruir", "ExpedienteDictamenDeReclamacionId", c => c.Int());
            RenameColumn(table: "dbo.ActasRecogidaDestruir", name: "ExpedienteDictamenDeReclamacionId", newName: "Expediente_DictamenDeReclamacionId");
            CreateIndex("dbo.ActasRecogidaDestruir", "Expediente_DictamenDeReclamacionId");
            AddForeignKey("dbo.ActasRecogidaDestruir", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes", "DictamenDeReclamacionId");
        }
    }
}
