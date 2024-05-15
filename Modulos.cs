using Microsoft.EntityFrameworkCore;
class Modulos {

public static void Configuracion(){
bool continuar = true;
while (continuar){


Console.Clear();
Console.WriteLine(@"
         __
 _(\    |@@|
(__/\__ \--/ __
   \___|----|  |   __
       \ }{ /\ )_ / _\
       /\__/\ \__O (__
      (--/\--)    \__/
      _)(  )(_
     `---''---`

    Configuracion
    p- Provincias
    v- Vacunas
    r- Regresar
    ");
    Console.WriteLine("Ingrese una opcion: ");
    string opcion = Console.ReadLine()??"";
    switch(opcion){
    
            case "p" :
                Console.WriteLine("Provincias");
                Modulos.Conf_Provincias();
                break;
            
            case "v" :
                Console.WriteLine("Vacunas");
                Modulos.Conf_Vacunas();
                break;
            
            case "r" :
                continuar = false;
                break;
            
            default:
                Console.WriteLine("Opcion no valida");
                Utils.Pausa();
                break;

        }  

    }
}

    public static void Conf_Provincias(){
        var db = new CovidContext();
       bool continuar = true;
       while(continuar){
        Console.Clear();
        Console.WriteLine(@" 
          Gestión de provincia
          1- Agregar provincia
          2- Editar provincia
          3- Eliminar provincia
          r- Regresar
        ");
         Console.Write("Ingrese una opcion: ");
         string opcion = Console.ReadLine()??"";
         switch(opcion){
            case "1":
              Console.Clear();
              Console.WriteLine("Agregar provincia");
              
              Console.WriteLine("Vamos aagregar una provincia");
              var p = new Provincia();
              p.Nombre = Utils.Input("Ingrese el nombre de la provincia: ");
              db.Provincias.Add(p);
              db.SaveChanges();
              
              Console.WriteLine("Provincia agregada");
              Utils.Pausa();
              break;


            case "2":
              Console.WriteLine("Editar provincia");
              Console.Clear();
              Console.WriteLine("Vamos a editar una provincia");
              
              List<Provincia> provincias = db.Provincias.ToList();
              foreach(var prov in provincias){
                 Console.WriteLine($"{prov.Id} - {prov.Nombre}");
              }
              
              Console.WriteLine("Ingrese el Id de la provincia a editar: ");
              var editar = db.Provincias.Find(int.Parse(Console.ReadLine()));
              if(editar == null){
                Console.WriteLine("No se encontro la provincia");
                Utils.Pausa();

              }else{
                  Console.WriteLine($"Ingrese el nuevo nombre de la provincia:({editar.Nombre}) ");
                  editar.Nombre = Console.ReadLine()??"";
                  db.SaveChanges();
                  Console.WriteLine("Provincia editada");
                
              }
              
              break;

            case "3":
              Console.Clear();
              Console.WriteLine("Eliminar Provincia");
              List<Provincia> provincias2 = db.Provincias.ToList();
              foreach(var prov in provincias2){
                  Console.WriteLine($"{prov.Id} - {prov.Nombre}");
              }
              Console.WriteLine("Ingrese el id de la provincia a eliminar: ");
              var eliminar = db.Provincias.Find(int.Parse(Console.ReadLine()));
              if(eliminar == null){
                Console.WriteLine("No se encontro la provincia");
                Utils.Pausa();

              }else{
                db.Provincias.Remove(eliminar);
                db.SaveChanges();
                Console.WriteLine("Provincia eliminada");

              }
              Utils.Pausa();
              break;
            case "r":
                continuar = false;
                break;
            default:
                Console.WriteLine("Opcion no valida");
                Utils.Pausa();
            break;

         }


       }

    }

    public static void Conf_Vacunas(){

    var db = new CovidContext();
       bool continuar = true;
       while(continuar){
        //Console.Clear();
        Console.WriteLine(@" 
          Gestión de vacunas

          1- Agregar vacuna
          2- Editar vacuna
          3- Eliminar vacuna
          r- Regresar
        ");
         Console.Write("Ingrese una opcion: ");
         string opcion = Console.ReadLine()??"";
         switch(opcion){
            case "1":
              //Console.Clear();
              Console.WriteLine("Agregar vacuna");
              
              Console.WriteLine("Vamos aagregar una vacuna");
              var v = new Vacuna();
              v.Nombre = Utils.Input("Ingrese el nombre de la vacuna: ");
              db.Vacunas.Add(v);
              db.SaveChanges();
              Console.WriteLine("Vacuna agregada");
              Utils.Pausa();
              break;
              
            case "2":
              Console.WriteLine("Editar vacuna");
              //Console.Clear();
              Console.WriteLine("Vamos a editar una vacuna");
              
              List<Vacuna> vacunas = db.Vacunas.ToList();
              foreach(var vac in vacunas){
                 Console.WriteLine($"{vac.Id} - {vac.Nombre}");
              }
              
              Console.WriteLine("Ingrese el Id de la vacuna a editar: ");
              var editar = db.Vacunas.Find(int.Parse(Console.ReadLine()));
              if(editar == null){
                Console.WriteLine("No se encontro la vacuna");
                

            }else{
                Console.WriteLine($"Ingrese el nuevo nombre de la vacuna:({editar.Nombre}) ");
                editar.Nombre = Console.ReadLine()??"";
                db.SaveChanges();
                Console.WriteLine("Vacuna editada");

              }
              Utils.Pausa();
              break;
            case "3":
              //Console.Clear();
              Console.WriteLine("Eliminar vacuna");
              
              Console.WriteLine("Vamos a eliminar una vacuna");
              List<Vacuna> vacunas2 = db.Vacunas.ToList();
              foreach(var vac in vacunas2){
                  Console.WriteLine($"{vac.Id} - {vac.Nombre}");
              }
              Console.WriteLine("Ingrese el id de la vacuna a eliminar: ");
              var eliminar = db.Vacunas.Find(int.Parse(Console.ReadLine()));
              if(eliminar == null){
                Console.WriteLine("No se encontro la vacuna");
                
              }else{
                db.Vacunas.Remove(eliminar);
                db.SaveChanges();
                Console.WriteLine("Vacuna eliminada");

              }
              Utils.Pausa();
              break;
            
            case "r":
                continuar = false;
                break;
            
         
         
         }   


       }





    }

 public static void Registrar_Vacunados(){
     
     var db = new CovidContext();
     //Console.Clear();
     Console.WriteLine("Registrar vacunados");
     var p = new Persona();
     var proceso = new Proceso();
     var cedula = Utils.Input("Ingrese la cedula sin guiones: ");
     
     p = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
     
     // Si la persona no existe
     if(p == null){
        p = new Persona();
        p.Cedula = cedula;

        var personaCedula = new Persona_cedula();
        personaCedula.ok = false;  
     try{    
     var url = "https://api.adamix.net/apec/cedula/"+cedula;
     var client = new HttpClient();
     var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
     personaCedula = Newtonsoft.Json.JsonConvert.DeserializeObject<Persona_cedula>(response);
     }
     catch(Exception){ }
    
    
    p = new Persona();
    p.Cedula = cedula;
    if(personaCedula.ok){
        p.Nombre = personaCedula.Nombres;
        p.Apellido = $"{personaCedula.Apellido1} {personaCedula.Apellido2}";
    }else{
        p.Nombre = Utils.Input("Ingrese el nombre: ");
        p.Apellido = Utils.Input("Ingrese el apellido: ");
    }
    p.Telefono = Utils.Input("Ingrese el telefono: ");
    db.Personas.Add (p);
     }
    proceso.Persona = p;
    proceso.Fecha = DateTime.Now;
var listadoVacunas =db.Vacunas.ToList();

     foreach(var vac in listadoVacunas){
        Console.WriteLine($" {vac.Id} - {vac.Nombre}");
     }

    while(proceso.Vacuna == null){
        
        Console.WriteLine("Ingrese el id de la vacuna: ");
        var vacuna = db.Vacunas.Find(int.Parse(Console.ReadLine()));
        if(vacuna == null){
            Console.WriteLine("No se encontro la vacuna");
    }
    else{
        proceso.Vacuna = vacuna;
    }


    }  

    var listadoProvincias = db.Provincias.ToList();
    foreach(var prov in listadoProvincias){
        Console.WriteLine($"{prov.Id} - {prov.Nombre}");
    }
    while(proceso.Provincia == null){
        Console.WriteLine("Ingrese el id de la provincia: ");
        var provincia = db.Provincias.Find(int.Parse(Console.ReadLine()));
        if(provincia == null){
            Console.WriteLine("No se encontro la provincia");
        }
        else{
            proceso.Provincia = provincia;
        }
    }

    db.Procesos.Add(proceso);
    db.SaveChanges();
    Console.WriteLine("Vacunado registrado");
    Utils.Pausa();

    
      
}

public static void Exportar(){
    var db = new CovidContext();
    Console.Clear();
    Console.WriteLine("Vamos a exportar una tarjeta :)");
    Persona persona = null;
    while(persona == null){
    var cedula = Utils.Input("Ingrese la cedula sin guiones o x para ver un listado de las personas: ");
    if(cedula.ToLower().Trim() == "x"){
        var listadoPersonas = db.Personas.ToList();
        foreach(var p in listadoPersonas){
            Console.WriteLine($"{p.Id}) {p.Cedula} - {p.Nombre} {p.Apellido}");
        }
        cedula = Utils.Input("Digite el id de la persona: ");
        persona = db.Personas.Find(int.Parse(cedula));
    }else{
        persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
    }
    }
    var listadoProcesos = db.Procesos.Where(x => x.Persona.Id == persona.Id)
    .Include(x => x.Vacuna).Include(x=> x.Provincia).ToList();
    
    Console.WriteLine($"{persona.Nombre} {persona.Apellido}");
    var detalle = "";
    foreach(var proceso in listadoProcesos){
        Console.WriteLine($"{proceso.Id} {proceso.Vacuna.Nombre} - {proceso.Provincia.Nombre} {proceso.Fecha.ToShortDateString()}");
        detalle += @$"
            <tr>
                <td>{proceso.Fecha.ToShortDateString()}</td>
                <td>{proceso.Vacuna.Nombre}</td>
                <td>{proceso.Provincia.Nombre}</td>
            </tr>
        ";
    }

    var html = @$"
        <html>
             <head>
                 <title>Tarjeta de {persona.Nombre} {persona.Apellido}</title>
                 <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'>
             </head>
             <body>
                 <dic class='container'> 
                     <img style='max-width:200px' src='https://api.adamix.net/apec/foto2\{persona.Cedula}' alt='logo' class='logo'>
                     <h1>Trajeta de {persona.Nombre} {persona.Apellido}</h1>
                     <h3>Cedula {persona.Cedula}</h3>
                     <h3>Telefono {persona.Telefono}</h3>

                     <h4>Procesos aplicados</h4>
                     <table>
                       <thead>
                          <tr>
                             <th>Fecha</th>
                             <th>Vacuna</th>
                             <th>Provincia</th>
                          </tr>
                          </thead>
                          <tbody>
                               {detalle}
                          </tbody>
                          </table>

                 </div>
             </body>
        </html>
    
    ";
    System.IO.File.WriteAllText("tarjeta.html", html);
    Console.WriteLine("Tarjeta generada");
    var uri = "tarjeta.html";
    var psi = new System.Diagnostics.ProcessStartInfo();
    psi.UseShellExecute = true;
    psi.FileName = uri;
    System.Diagnostics.Process.Start(psi);


    Utils.Pausa();
}
} 