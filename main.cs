using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {

  //atributos globales guardar datos
  public string[] nombres={};
  public string[] CUI={};
  public string[] correos={};
  //primer menu
  public static void PrimerMenu(){
    Program objetos = new Program();
    //atributos globales para revision
    string[] revision_correos = {"@gmail.com","@yahoo.com"};

    //atributos
    int seleccion_menu=0;
    //opciones del primer menu
    do{
      Console.WriteLine("1. Registro");
      Console.WriteLine("2. Iniciar simulacion");
      Console.WriteLine("3. Valor de criptomonedas");
      Console.WriteLine("4. Salir");
      //ingreso de opcion y revision que sea un valor numerico
      try{
        //conversion del tipo string a int
        seleccion_menu=Convert.ToInt32(Console.ReadLine());
        //Registro de usuario
        if(seleccion_menu==1){
          Registro(revision_correos,objetos);

          for (int i=0;i<objetos.nombres.Length;i++){
            Console.WriteLine(objetos.nombres[i]);
            Console.WriteLine(objetos.CUI[i]);
            Console.WriteLine(objetos.correos[i]);
          }
        //Inicio de simulacion enviar al segundo menu
        }else if(seleccion_menu==2){

        //Mostrar los valores de las criptomonedas
        }else if(seleccion_menu==3){

        //Salir
        }else if(seleccion_menu==4){
          Console.WriteLine("Gracias, espero que vuelva pronto");
        //mensaje para advertencia
        }else{
          Console.WriteLine("Por favor, ingreso una de las opciones que se presenta en el menu");
        }
      //mostrar error
      }catch(Exception e){
        Console.WriteLine("Por favor ingresar solo valores numericos");
      }
    }while(seleccion_menu!=4);
  }

  //generacion de un nuveo registro
  public static void Registro(string[] revision_correos, Program objetos){

    //ingreso del nombre
    Console.WriteLine("Nombre Completo");
    string name = Console.ReadLine();
    name.ToLower();
    objetos.nombres=objetos.nombres.Append(name);
    //ingreso del CUI
    bool ciclo = true;
    do{
      Console.WriteLine("CUI completo");
      string cui = Console.ReadLine();
      if(cui.Length == 13){
        objetos.CUI = objetos.CUI.Append(cui);
        ciclo=false;
      }else{
        Console.WriteLine("Error, vuelva a intentar");
      }
    }while(ciclo);
    //Ingreso del correo electronico
    ciclo=true;
    do{
      Console.WriteLine("Correo electronico");
      string mail = Console.ReadLine();
      for(int i=0;i<revision_correos.Length;i++){
        //Console.WriteLine(revision_correos[i]);
        if(mail.Contains(revision_correos[i])){
          //Console.WriteLine("Si la contiene");
          objetos.correos=objetos.correos.Append(mail);
          ciclo=false;
        }
      }
      if(ciclo==true){
        Console.WriteLine("Error, vuelva a intentar");
      }
    }while(ciclo);
    //al terminar ciclo desplegar si desea ingreasr o no

  }

  public static void Main (string[] args) {
    PrimerMenu();
    
  }
}
//es para el uso del append de los arrays
public static class Extensions
  {
    public static T[] Append<T>(this T[] array, T item)
    {
      if (array == null) {
        return new T[] { item };
      }
      T[] result = new T[array.Length + 1];
      array.CopyTo(result, 0);
      result[array.Length] = item;
      return result;
    }
  }