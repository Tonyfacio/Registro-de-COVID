/*
     tarea 6 realizada por:

     Nombre: Tony
     Apellido: Batista
     Matricula: 20212096
     Fecha: 05/07/2022

     Gracias profesor por su enseñanza...

     */

     bool continuar = true;
     //Console.Clear();

     while (continuar){

    Console.WriteLine(@"
    TAREA 6 - REGISTRO DE VACUNADOS.

     _____
    [IIIII]
     )---(
    /     \
   /       \
   |`-...-'|
   |cov-19 |
 _ |`-...-'j    _
(\)`-.___.(I) _(/)
  (I)  (/)(I)(\)
            
    1- Registrar vacunados.
    2- Exportar tarjeta de vacunacion.
    3- Configuracion.
    x- Salir.

       
       ");
      Console.WriteLine("Ingrese una opcion: ");
      string opcion = Console.ReadLine()??"";
      switch(opcion){
          case "1":
                Modulos.Registrar_Vacunados();
                 break;

          case "2":
                Console.WriteLine("Exportar tarjeta de vacunacion");
                Modulos.Exportar();
                 break;

          case "3":
                Console.WriteLine("Configuracion");
                Modulos.Configuracion();
                 break;

          case "x":
                continuar = false;
                Console.WriteLine("Gracias por salvar la humanidad");
                 break;

                default:
                Console.WriteLine("Opcion no valida");
                break; 
      
      
      
      
      
      
      }



     }

     
        
    

      



