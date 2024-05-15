using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


public class CovidContext : DbContext
{
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Vacuna> Vacunas { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Proceso> Procesos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opcionsBuilder)
    {
        opcionsBuilder.UseSqlite("Data Source=covid.db");
    }
}

public class Persona{

    public int Id { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido {get; set; }
    public string Telefono { get; set; }
}

public class Provincia{
     
     public int Id { get; set; }
     public string Nombre { get; set; }

}

public class Vacuna{

    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class Proceso{
    
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Persona Persona { get; set; }
    public Provincia Provincia { get; set; }
    public Vacuna Vacuna {get; set; }

}



public class Persona_cedula
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string IdSexo { get; set; }
        public string IdEstadoCivil { get; set; }
        public string IDEstatus { get; set; }
        public string EstatusCedulaAzul { get; set; }
        public string CedulaAnterior { get; set; }
        public bool ok { get; set; }
        public string foto { get; set; }
    }
