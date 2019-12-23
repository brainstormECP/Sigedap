namespace Sigedap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActasDevoluciones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Representante = c.String(nullable: false),
                        CiRepresentante = c.String(nullable: false, maxLength: 11),
                        ExpedienteDictamenDeReclamacionId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .ForeignKey("dbo.Expedientes", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Expedientes",
                c => new
                    {
                        DictamenDeReclamacionId = c.Int(nullable: false),
                        Numero = c.String(nullable: false),
                        PagadoHasta = c.DateTime(nullable: false),
                        Causas = c.String(nullable: false),
                        AmparadoPorNt = c.String(nullable: false),
                        FechaAfectacion = c.DateTime(nullable: false),
                        FechaDeNormalizacionServicio = c.DateTime(nullable: false),
                        FechaRecibidoUebMunicipal = c.DateTime(nullable: false),
                        FechaVisitaCliente = c.DateTime(nullable: false),
                        FechaNt = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Observaciones = c.String(),
                        OperarioId = c.Int(nullable: false),
                        InspectorId = c.Int(nullable: false),
                        DespachadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DictamenDeReclamacionId)
                .ForeignKey("dbo.Trabajadores", t => t.DespachadorId)
                .ForeignKey("dbo.DictamenesDeReclamacion", t => t.DictamenDeReclamacionId)
                .ForeignKey("dbo.Trabajadores", t => t.InspectorId)
                .ForeignKey("dbo.Trabajadores", t => t.OperarioId)
                .Index(t => t.DictamenDeReclamacionId)
                .Index(t => t.OperarioId)
                .Index(t => t.InspectorId)
                .Index(t => t.DespachadorId);
            
            CreateTable(
                "dbo.ActasRecogidaEquipos",
                c => new
                    {
                        ExpedienteDictamenDeReclamacionId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NombreRepresentante = c.String(nullable: false),
                        CiRepresentante = c.String(nullable: false, maxLength: 11),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExpedienteDictamenDeReclamacionId)
                .ForeignKey("dbo.Expedientes", t => t.ExpedienteDictamenDeReclamacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ExpedienteDictamenDeReclamacionId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Activo = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActasEntregaEquiposReposicion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ExpedienteId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        Expediente_DictamenDeReclamacionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expedientes", t => t.Expediente_DictamenDeReclamacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.Expediente_DictamenDeReclamacionId);
            
            CreateTable(
                "dbo.EquiposDañados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpedienteDictamenDeReclamacionId = c.Int(nullable: false),
                        TipoDeEquipoId = c.Int(nullable: false),
                        Nacionalidad = c.String(nullable: false),
                        Serie = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        ActasRecogidaDestruirId = c.Int(),
                        ActaEntregaEquiposReposicionId = c.Int(),
                        EquipoNuevo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActasEntregaEquiposReposicion", t => t.ActaEntregaEquiposReposicionId)
                .ForeignKey("dbo.ActasRecogidaDestruir", t => t.ActasRecogidaDestruirId)
                .ForeignKey("dbo.EquiposNuevos", t => t.EquipoNuevo_Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.TiposDeEquipos", t => t.TipoDeEquipoId, cascadeDelete: true)
                .ForeignKey("dbo.Expedientes", t => t.ExpedienteDictamenDeReclamacionId, cascadeDelete: true)
                .Index(t => t.ExpedienteDictamenDeReclamacionId)
                .Index(t => t.TipoDeEquipoId)
                .Index(t => t.MarcaId)
                .Index(t => t.ActasRecogidaDestruirId)
                .Index(t => t.ActaEntregaEquiposReposicionId)
                .Index(t => t.EquipoNuevo_Id);
            
            CreateTable(
                "dbo.ActasRecogidaDestruir",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Testigo2 = c.String(nullable: false),
                        Testigo1 = c.String(nullable: false),
                        Testigo3 = c.String(nullable: false),
                        FechaDestruccion = c.DateTime(nullable: false),
                        FechaEntregaAlmacen = c.DateTime(nullable: false),
                        RecibidoPor = c.String(nullable: false),
                        ExpedienteId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        Expediente_DictamenDeReclamacionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expedientes", t => t.Expediente_DictamenDeReclamacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.Expediente_DictamenDeReclamacionId);
            
            CreateTable(
                "dbo.DictamenesTecnicos",
                c => new
                    {
                        EquipoDañadoId = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tecnico1 = c.String(nullable: false),
                        Tecnico2 = c.String(nullable: false),
                        Tecnico3 = c.String(nullable: false),
                        RecibidoPor = c.String(nullable: false),
                        Destino = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EquipoDañadoId)
                .ForeignKey("dbo.EquiposDañados", t => t.EquipoDañadoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.EquipoDañadoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.DictamenesPorPartes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Defecto = c.String(nullable: false),
                        DictamenTecnicoEquipoDañadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DictamenesTecnicos", t => t.DictamenTecnicoEquipoDañadoId, cascadeDelete: true)
                .Index(t => t.DictamenTecnicoEquipoDañadoId);
            
            CreateTable(
                "dbo.EquiposNuevos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipoDañadoId = c.Int(nullable: false),
                        Modelo = c.String(nullable: false),
                        Serie = c.String(nullable: false),
                        Prestaciones = c.String(nullable: false),
                        Sistema = c.String(nullable: false),
                        EntregadoPor = c.String(nullable: false),
                        Cargo = c.String(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        TipoDeEquipoId = c.Int(nullable: false),
                        ActaEntregaEquiposReposicionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActasEntregaEquiposReposicion", t => t.ActaEntregaEquiposReposicionId, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.TiposDeEquipos", t => t.TipoDeEquipoId, cascadeDelete: true)
                .Index(t => t.MarcaId)
                .Index(t => t.TipoDeEquipoId)
                .Index(t => t.ActaEntregaEquiposReposicionId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposDeEquipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DictamenesDeReclamacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ueb = c.String(),
                        OficinaComercial = c.String(),
                        Procede = c.Boolean(nullable: false),
                        Estado = c.Int(nullable: false),
                        Observaciones = c.String(),
                        RevisadoPor = c.String(),
                        AutorizadoPor = c.String(),
                        FechaNotificacionAlCliente = c.DateTime(nullable: false),
                        NombreReclamante = c.String(),
                        CiReclamante = c.String(nullable: false, maxLength: 11),
                        ClienteId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ClienteId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ci = c.String(nullable: false, maxLength: 11),
                        Nombres = c.String(nullable: false),
                        PrimerApellido = c.String(nullable: false),
                        SegundoApellido = c.String(nullable: false),
                        Calle = c.String(nullable: false),
                        No = c.Int(nullable: false),
                        Piso = c.Int(),
                        Apto = c.String(),
                        EntreCalle1 = c.String(),
                        EntreCalle2 = c.String(),
                        Rpto = c.String(),
                        Municipio = c.String(nullable: false),
                        TelefonoParticular = c.Int(),
                        TelefonoTrabajo = c.Int(),
                        Control = c.String(nullable: false),
                        Ruta = c.Int(nullable: false),
                        Folio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabajadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SolicitudesReposicion",
                c => new
                    {
                        ExpedienteDictamenDeReclamacionId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Especialista = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExpedienteDictamenDeReclamacionId)
                .ForeignKey("dbo.Expedientes", t => t.ExpedienteDictamenDeReclamacionId)
                .Index(t => t.ExpedienteDictamenDeReclamacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActasDevoluciones", "Id", "dbo.Expedientes");
            DropForeignKey("dbo.SolicitudesReposicion", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes");
            DropForeignKey("dbo.Expedientes", "OperarioId", "dbo.Trabajadores");
            DropForeignKey("dbo.Expedientes", "InspectorId", "dbo.Trabajadores");
            DropForeignKey("dbo.Expedientes", "DictamenDeReclamacionId", "dbo.DictamenesDeReclamacion");
            DropForeignKey("dbo.Expedientes", "DespachadorId", "dbo.Trabajadores");
            DropForeignKey("dbo.DictamenesDeReclamacion", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DictamenesDeReclamacion", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActasRecogidaEquipos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActasEntregaEquiposReposicion", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActasEntregaEquiposReposicion", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes");
            DropForeignKey("dbo.EquiposDañados", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes");
            DropForeignKey("dbo.EquiposNuevos", "TipoDeEquipoId", "dbo.TiposDeEquipos");
            DropForeignKey("dbo.EquiposDañados", "TipoDeEquipoId", "dbo.TiposDeEquipos");
            DropForeignKey("dbo.EquiposNuevos", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.EquiposDañados", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.EquiposDañados", "EquipoNuevo_Id", "dbo.EquiposNuevos");
            DropForeignKey("dbo.EquiposNuevos", "ActaEntregaEquiposReposicionId", "dbo.ActasEntregaEquiposReposicion");
            DropForeignKey("dbo.DictamenesTecnicos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DictamenesTecnicos", "EquipoDañadoId", "dbo.EquiposDañados");
            DropForeignKey("dbo.DictamenesPorPartes", "DictamenTecnicoEquipoDañadoId", "dbo.DictamenesTecnicos");
            DropForeignKey("dbo.ActasRecogidaDestruir", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActasRecogidaDestruir", "Expediente_DictamenDeReclamacionId", "dbo.Expedientes");
            DropForeignKey("dbo.EquiposDañados", "ActasRecogidaDestruirId", "dbo.ActasRecogidaDestruir");
            DropForeignKey("dbo.EquiposDañados", "ActaEntregaEquiposReposicionId", "dbo.ActasEntregaEquiposReposicion");
            DropForeignKey("dbo.ActasDevoluciones", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActasRecogidaEquipos", "ExpedienteDictamenDeReclamacionId", "dbo.Expedientes");
            DropIndex("dbo.SolicitudesReposicion", new[] { "ExpedienteDictamenDeReclamacionId" });
            DropIndex("dbo.DictamenesDeReclamacion", new[] { "UsuarioId" });
            DropIndex("dbo.DictamenesDeReclamacion", new[] { "ClienteId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.EquiposNuevos", new[] { "ActaEntregaEquiposReposicionId" });
            DropIndex("dbo.EquiposNuevos", new[] { "TipoDeEquipoId" });
            DropIndex("dbo.EquiposNuevos", new[] { "MarcaId" });
            DropIndex("dbo.DictamenesPorPartes", new[] { "DictamenTecnicoEquipoDañadoId" });
            DropIndex("dbo.DictamenesTecnicos", new[] { "UsuarioId" });
            DropIndex("dbo.DictamenesTecnicos", new[] { "EquipoDañadoId" });
            DropIndex("dbo.ActasRecogidaDestruir", new[] { "Expediente_DictamenDeReclamacionId" });
            DropIndex("dbo.ActasRecogidaDestruir", new[] { "UsuarioId" });
            DropIndex("dbo.EquiposDañados", new[] { "EquipoNuevo_Id" });
            DropIndex("dbo.EquiposDañados", new[] { "ActaEntregaEquiposReposicionId" });
            DropIndex("dbo.EquiposDañados", new[] { "ActasRecogidaDestruirId" });
            DropIndex("dbo.EquiposDañados", new[] { "MarcaId" });
            DropIndex("dbo.EquiposDañados", new[] { "TipoDeEquipoId" });
            DropIndex("dbo.EquiposDañados", new[] { "ExpedienteDictamenDeReclamacionId" });
            DropIndex("dbo.ActasEntregaEquiposReposicion", new[] { "Expediente_DictamenDeReclamacionId" });
            DropIndex("dbo.ActasEntregaEquiposReposicion", new[] { "UsuarioId" });
            DropIndex("dbo.ActasRecogidaEquipos", new[] { "UsuarioId" });
            DropIndex("dbo.ActasRecogidaEquipos", new[] { "ExpedienteDictamenDeReclamacionId" });
            DropIndex("dbo.Expedientes", new[] { "DespachadorId" });
            DropIndex("dbo.Expedientes", new[] { "InspectorId" });
            DropIndex("dbo.Expedientes", new[] { "OperarioId" });
            DropIndex("dbo.Expedientes", new[] { "DictamenDeReclamacionId" });
            DropIndex("dbo.ActasDevoluciones", new[] { "UsuarioId" });
            DropIndex("dbo.ActasDevoluciones", new[] { "Id" });
            DropTable("dbo.SolicitudesReposicion");
            DropTable("dbo.Trabajadores");
            DropTable("dbo.Clientes");
            DropTable("dbo.DictamenesDeReclamacion");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.TiposDeEquipos");
            DropTable("dbo.Marcas");
            DropTable("dbo.EquiposNuevos");
            DropTable("dbo.DictamenesPorPartes");
            DropTable("dbo.DictamenesTecnicos");
            DropTable("dbo.ActasRecogidaDestruir");
            DropTable("dbo.EquiposDañados");
            DropTable("dbo.ActasEntregaEquiposReposicion");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ActasRecogidaEquipos");
            DropTable("dbo.Expedientes");
            DropTable("dbo.ActasDevoluciones");
        }
    }
}
