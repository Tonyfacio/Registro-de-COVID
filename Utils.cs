class Utils{
public static void Pausa(){
Console.WriteLine("Presiona una tecla para continuar...");
Console.ReadLine();

}
public static string Input(string mensaje){
    Console.Write(mensaje);
    return Console.ReadLine()??"";
}



}