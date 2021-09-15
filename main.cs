using System;

class Program {

  //primer menu
  public static void PrimerMenu(){
    //atributos
    int seleccion_menu=0;
    //opciones del primer menu
    do{
      Console.WriteLine("1. Registro");
      Console.WriteLine("2. Iniciar simulacion");
      Console.WriteLine("3. Valor de criptomonedas");
      Console.WriteLine("4. Salir");
      seleccion_menu=Convert.ToInt32(Console.ReadLine());

    }while(seleccion_menu!=4);
  }

  public static void Main (string[] args) {
    PrimerMenu();
    Console.WriteLine("Gracias, espero que vuelva pronto");
  }

  
}