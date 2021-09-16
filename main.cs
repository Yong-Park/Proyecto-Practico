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
          if(objetos.nombres.Length==0){
            Registro(revision_correos,objetos);
          }else{
            Console.WriteLine("Ya existe un usuario");
          }
          
          //prueba para ver si se guardan los registros
          /*for (int i=0;i<objetos.nombres.Length;i++){
            Console.WriteLine(objetos.nombres[i]);
            Console.WriteLine(objetos.CUI[i]);
            Console.WriteLine(objetos.correos[i]);
          }*/
        //Inicio de simulacion enviar al segundo menu
        }else if(seleccion_menu==2){
          //revisar que ya haya un registro antes de lo contrario se generara un registro
          if(objetos.nombres.Length>0){
            SegundoMenu();
          }else{
            Console.WriteLine("No se puede acceder debido a que no existen registros previos");
            Console.WriteLine("Direccionando para crear registro");
            Registro(revision_correos,objetos);
          }
        //Mostrar los valores de las criptomonedas
        }else if(seleccion_menu==3){
          DateTime now = DateTime.Now;
          //mostrar la fecha actual
          Console.WriteLine("Fecha actual: "+now.ToString("dd/MM/yyyy"));
          //guardar el mes
          string mes=now.ToString("MM");
          int mes_numero = int.Parse(mes);
          //guardar el Dia 
          string dia=now.ToString("dd");
          int dia_numero = int.Parse(dia);
          //obtener el multiplicador por el mes
          float m = multiplicador(mes_numero);
          //obtener el valor del bitcoin
          double btc_valor =BTC(dia_numero,m);
          Console.WriteLine("Valor del bitcoin: " + btc_valor);
          //obtener el valor del Ethereum
          double eth_valor =ETH(dia_numero,m);
          Console.WriteLine("Valor del ethereum: "+ eth_valor);
          //obtener el valor del Ripple
          double xrp_valor =XRP(dia_numero,m);
          Console.WriteLine("Valor del ripple: "+ xrp_valor);
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

    ciclo=true;
    do{
      int acceder_simulacion=0;
      Console.WriteLine("____________________________");
      Console.WriteLine("Desea iniciar la simulacion?");
      Console.WriteLine("1. Si");
      Console.WriteLine("2. No");
      try{
        //conversion del tipo string a int
        acceder_simulacion=Convert.ToInt32(Console.ReadLine());
        if(acceder_simulacion==1){
          SegundoMenu();
          ciclo=false;
        }else if(acceder_simulacion==2){
          ciclo=false;
        }else{
          Console.WriteLine("Error, porfavor escoga entre 1 o 2");
        }
      }catch(Exception e){
        Console.WriteLine("Error, porfavor solo valores numericos");
      }
    }while(ciclo);
  }

  //obtener el multiplicador
  public static float multiplicador(int mes){
    switch(mes){
      case 1:
        return 0.86F;
        break;
      case 2:
        return 1.42F;
        break;
      case 3:
        return 0.97F;
        break;
      case 4:
        return 0.5F;
        break;
      case 5:
        return 1.71F;
        break;
      case 6:
        return 0.91F;
        break;
      case 7:
        return 0.35F;
        break;
      case 8:
        return 0.7F;
        break;
      case 9:
        return 1.82F;
        break;
      case 10:
        return 0.98F;
        break;
      case 11:
        return 1.82F;
        break;
      case 12:
        return 1.55F;
        break;
    }
    return 0F;
  }
 
  //calculo del costo del bitcoin
  public static double BTC(int x, float m){
    double y = (-(0.00001*(x*x*x))-(0.004*(x*x))+(0.1241*x)+(44.39*m));
    return y;
  }

  //calculo del costo del Ethereum
  public static double ETH(int x, float m){
    double y =(-(0.00003*(x*x*x))-(0.008*(x*x))+(0.2271*x)+(32.35*m));
    return y;
  }

  //calculo del costo del Ripple
  public static double XRP(int x, float m){
    double y=(-(0.00009*(x*x*x))-(0.002*(x*x))+(0.2539*x)+(25.78*m));
    return y;
  }

  //Segundo menu 
  public static void SegundoMenu(){
    Console.WriteLine("Hola");
  }

  //el main 
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