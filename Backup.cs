/*
https://www.tutorialsteacher.com/csharp/csharp-stringbuilder#:~:text=Use%20the%20Append()%20method,newline%20character%20at%20the%20end.
*/
/*
Universidad Rafael Landivar
Facultad de Ingeniería
Introducción a la Programación
Proyecto Practico #1
*/
// Librerias Utilizadas
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
    //para guaradr las fechas y meses
    string mes;
    int mes_numero=0;
    string dia;
    int dia_numero=0;
    //ciclos para los do
    bool ciclo =true;
    bool ciclo2=true;
    bool posible_compra=false;
    //para seleccionar opciones
    int seleccion_menu2=0;
    //donde se guardan los tipos de compras y ventas y sus fechas respectivas
    string[] compras ={};
    DateTime[] fechas = {};
    //valores inicilaes del consumidor
    double dinero = 500D;
    double bitcoin = 0D;
    double ethereum = 0D;
    double ripple = 0D;
    DateTime fecha;
    do{
      Console.WriteLine("______________________________");
      Console.WriteLine("Dinero total: $" + dinero );
      Console.WriteLine("Bitcoin: " + bitcoin);
      Console.WriteLine("Ethereum: " + ethereum);
      Console.WriteLine("Ripple: " + ripple);
      Console.WriteLine("______________________________");
      Console.WriteLine("1. Comprar criptomonedas");
      Console.WriteLine("2. Vender criptomonedas");
      Console.WriteLine("3. Intercambiar criptomonedas");
      Console.WriteLine("4. Prediccion de ganancias");
      Console.WriteLine("5. Resumen de operaciones");
      Console.WriteLine("6. Salir");
      
      try{
        Console.WriteLine("\n Elija una opcion.\t ");
        seleccion_menu2=Convert.ToInt32(Console.ReadLine());
        int seleccion_moneda=0;
        int cantidad_moneda=0;
        string fecha_ingresada;
        DateTime fecha_ingresada_prueba;
        switch(seleccion_menu2){
          //comprar criptomonedas
          case 1:
            bool pregunta = true;
            do{
              Console.WriteLine("Escoja que criptomoneda desea comprar. \n");
              Console.WriteLine("1. BTC");
              Console.WriteLine("2. ETH");
              Console.WriteLine("3. XRP \n");
              //seleccion_moneda = float.Parse(Console.ReadLine())
              //Se asumio que la compra de criptomonedas son valores enteros
              try{
                seleccion_moneda = Convert.ToInt32(Console.ReadLine());
                if(seleccion_moneda == 1){
                  Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                      //Console.WriteLine(fecha_ingresada);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            //demostrar todas las fechas que se ingresan
                            /*for(int i = 0; i < fechas.Length ; i++){
                              Console.WriteLine(fechas[i]);
                            }*/
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                        //int resultado = DateTime.Compare()
                      }
                      //Console.WriteLine(fechas.Length);
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = BTC(dia_numero, m);
                    double total_gasto = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto<=dinero){
                      string mensaje_compra= ("Se realizo una compra de " + cantidad_moneda + " bitcoins y fue un gasto total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      bitcoin += cantidad_moneda;
                      dinero -=total_gasto;
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  /*
                  for(int i = 0; i < fechas.Length ; i++){
                    Console.WriteLine(compras[i]);
                    Console.WriteLine(fechas[i]);
                  }*/
                  //terminar el ciclo 
                  ciclo=false;

                }else if(seleccion_moneda== 2){
                  Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                      //Console.WriteLine(fecha_ingresada);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            //demostrar todas las fechas que se ingresan
                            /*for(int i = 0; i < fechas.Length ; i++){
                              Console.WriteLine(fechas[i]);
                            }*/
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                        //int resultado = DateTime.Compare()
                      }
                      //Console.WriteLine(fechas.Length);
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = ETH(dia_numero, m);
                    double total_gasto = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto<=dinero){
                      string mensaje_compra= ("Se realizo una compra de " + cantidad_moneda + " ethereum y fue un gasto total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      ethereum += cantidad_moneda;
                      dinero -=total_gasto;
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  /*
                  for(int i = 0; i < fechas.Length ; i++){
                    Console.WriteLine(compras[i]);
                    Console.WriteLine(fechas[i]);
                  }*/
                  //terminar el ciclo 
                  ciclo=false;

                }else if(seleccion_moneda== 3){
                 Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                      //Console.WriteLine(fecha_ingresada);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            //demostrar todas las fechas que se ingresan
                            /*for(int i = 0; i < fechas.Length ; i++){
                              Console.WriteLine(fechas[i]);
                            }*/
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                        //int resultado = DateTime.Compare()
                      }
                      //Console.WriteLine(fechas.Length);
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = XRP(dia_numero, m);
                    double total_gasto = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto<=dinero){
                      string mensaje_compra= ("Se realizo una compra de " + cantidad_moneda + " ripple y fue un gasto total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      ripple += cantidad_moneda;
                      dinero -=total_gasto;
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  /*
                  for(int i = 0; i < fechas.Length ; i++){
                    Console.WriteLine(compras[i]);
                    Console.WriteLine(fechas[i]);
                  }*/
                  //terminar el ciclo 
                  ciclo=false;
                  
                }else{
                  Console.WriteLine("Porfavor, escoja entre 1 al 3. \n");
                }

              }catch(Exception e){
                Console.WriteLine("Error, porfavor solo valores numericos \n");
              }
              
            }while(ciclo);
            break;  
          //vender criptomonedas  
          case 2:
          ciclo=true;
          pregunta = true;
          //verificar si existe alguna criptomoneda, de lo contrario no ocurre nada
          if(bitcoin>0 || ethereum>0 || ripple>0){
            //preguntar el tipo de criptomoneda que desea vender
            do{
              Console.WriteLine("Escoja que criptomoneda desea vender, escribiendo el numero. \n");
              Console.WriteLine("1. BTC");
              Console.WriteLine("2. ETH");
              Console.WriteLine("3. XRP \n");
              //Se asumio que la venta de criptomonedas son valores enteros
              try{
                seleccion_moneda = Convert.ToInt32(Console.ReadLine());
                if(seleccion_moneda == 1){
                  if(bitcoin>0){
                    Console.WriteLine("Ingrese la cantidad que desea vender. \n");
                    do{
                      try{
                        cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                        //verificar si cumple con las condiciones
                        if(cantidad_moneda>0 && cantidad_moneda<=bitcoin){
                          pregunta=false;
                        }else{
                          Console.WriteLine("Error, no se logro intente de nuevo\n");
                        }
                      }catch(Exception e){
                        pregunta = true;
                        Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                      }
                    }while(pregunta);
                    pregunta = true;
                    Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                    do{
                      try{
                        //ingreso de fecha
                        fecha_ingresada = Console.ReadLine();
                        //partir la fecha por sus dias y mes para el calculo 
                        string[] division= fecha_ingresada.Split("/");
                        mes=division[0];
                        mes_numero=int.Parse(mes);
                        dia=division[1];
                        dia_numero=int.Parse(dia);
                        //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                        //Console.WriteLine(fecha_ingresada);
                        fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                        //Console.WriteLine(fecha_ingresada_prueba);
                        //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                        //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                        //Console.WriteLine(fechas.Length);
                        if(fechas.Length == 0){
                          fechas = fechas.Append(fecha_ingresada_prueba);
                          for(int i=0;i<fechas.Length;i++){
                            Console.WriteLine(fechas[i]);
                          }
                          pregunta = false;
                          posible_compra=true;
                        }
                        else{
                            int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                            
                            //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                            if(resultado <= 0){
                              Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                            }
                            else{
                              fechas = fechas.Append(fecha_ingresada_prueba);
                              //demostrar todas las fechas que se ingresan
                              /*for(int i = 0; i < fechas.Length ; i++){
                                Console.WriteLine(fechas[i]);
                              }*/
                              posible_compra=true;
                            }
                          
                          pregunta = false;
                          //int resultado = DateTime.Compare()
                        }
                        //Console.WriteLine(fechas.Length);
                      }catch(Exception e){
                        Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                      }
                    }while(pregunta);
                    //Realizar la compra de las criptomonedas
                    while(posible_compra){
                      float m = multiplicador(mes_numero);
                      double y = BTC(dia_numero, m);
                      double total_gasto = y * cantidad_moneda;
                      /*
                      revisar si el costo total de las criptomonedas no supera su saldo, 
                      en caso que no supere realizar la compra, de lo contrario mencionar que 
                      no se puedo y explciar la razon de ella 
                      */
                      
                      string mensaje_compra= ("Se realizo una venta de " + cantidad_moneda + " bitcoins y se obtuevo una ganacia total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      bitcoin -= cantidad_moneda;
                      dinero +=total_gasto;
                      
                      posible_compra=false;
                    };
                    /*
                    for(int i = 0; i < fechas.Length ; i++){
                      Console.WriteLine(compras[i]);
                      Console.WriteLine(fechas[i]);
                    }*/
                    //terminar el ciclo 
                    ciclo=false;
                  }else{
                    Console.WriteLine("No se puede debio a que no tienes ningun bitcoin.\n");
                    ciclo=false;
                  }

                }else if(seleccion_moneda== 2){
                  if(ethereum>0){
                    Console.WriteLine("Ingrese la cantidad que desea vender. \n");
                    do{
                      try{
                        cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                        //verificar si cumple con las condiciones
                        if(cantidad_moneda>0 && cantidad_moneda<=ethereum){
                          pregunta=false;
                        }else{
                          Console.WriteLine("Error, no se logro intente de nuevo\n");
                        }
                      }catch(Exception e){
                        pregunta = true;
                        Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                      }
                    }while(pregunta);
                    pregunta = true;
                    Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                    do{
                      try{
                        //ingreso de fecha
                        fecha_ingresada = Console.ReadLine();
                        //partir la fecha por sus dias y mes para el calculo 
                        string[] division= fecha_ingresada.Split("/");
                        mes=division[0];
                        mes_numero=int.Parse(mes);
                        dia=division[1];
                        dia_numero=int.Parse(dia);
                        //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                        //Console.WriteLine(fecha_ingresada);
                        fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                        //Console.WriteLine(fecha_ingresada_prueba);
                        //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                        //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                        //Console.WriteLine(fechas.Length);
                        if(fechas.Length == 0){
                          fechas = fechas.Append(fecha_ingresada_prueba);
                          for(int i=0;i<fechas.Length;i++){
                            Console.WriteLine(fechas[i]);
                          }
                          pregunta = false;
                          posible_compra=true;
                        }
                        else{
                            int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                            
                            //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                            if(resultado <= 0){
                              Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                            }
                            else{
                              fechas = fechas.Append(fecha_ingresada_prueba);
                              //demostrar todas las fechas que se ingresan
                              /*for(int i = 0; i < fechas.Length ; i++){
                                Console.WriteLine(fechas[i]);
                              }*/
                              posible_compra=true;
                            }
                          
                          pregunta = false;
                          //int resultado = DateTime.Compare()
                        }
                        //Console.WriteLine(fechas.Length);
                      }catch(Exception e){
                        Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                      }
                    }while(pregunta);
                    //Realizar la compra de las criptomonedas
                    while(posible_compra){
                      float m = multiplicador(mes_numero);
                      double y = ETH(dia_numero, m);
                      double total_gasto = y * cantidad_moneda;
                      /*
                      revisar si el costo total de las criptomonedas no supera su saldo, 
                      en caso que no supere realizar la compra, de lo contrario mencionar que 
                      no se puedo y explciar la razon de ella 
                      */
                      
                      string mensaje_compra= ("Se realizo una venta de " + cantidad_moneda + " ethereum y se obtuevo una ganacia total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      ethereum -= cantidad_moneda;
                      dinero +=total_gasto;
                      
                      posible_compra=false;
                    };
                    /*
                    for(int i = 0; i < fechas.Length ; i++){
                      Console.WriteLine(compras[i]);
                      Console.WriteLine(fechas[i]);
                    }*/
                    //terminar el ciclo 
                    ciclo=false;
                  }else{
                    Console.WriteLine("No se puede debio a que no tienes ningun ethereum.\n");
                    ciclo=false;
                  }

                }else if(seleccion_moneda== 3){
                  if(ripple>0){
                    Console.WriteLine("Ingrese la cantidad que desea vender. \n");
                    do{
                      try{
                        cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                        //verificar si cumple con las condiciones
                        if(cantidad_moneda>0 && cantidad_moneda<=ripple){
                          pregunta=false;
                        }else{
                          Console.WriteLine("Error, no se logro intente de nuevo\n");
                        }
                      }catch(Exception e){
                        pregunta = true;
                        Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                      }
                    }while(pregunta);
                    pregunta = true;
                    Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                    do{
                      try{
                        //ingreso de fecha
                        fecha_ingresada = Console.ReadLine();
                        //partir la fecha por sus dias y mes para el calculo 
                        string[] division= fecha_ingresada.Split("/");
                        mes=division[0];
                        mes_numero=int.Parse(mes);
                        dia=division[1];
                        dia_numero=int.Parse(dia);
                        //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                        //Console.WriteLine(fecha_ingresada);
                        fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                        //Console.WriteLine(fecha_ingresada_prueba);
                        //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                        //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                        //Console.WriteLine(fechas.Length);
                        if(fechas.Length == 0){
                          fechas = fechas.Append(fecha_ingresada_prueba);
                          for(int i=0;i<fechas.Length;i++){
                            Console.WriteLine(fechas[i]);
                          }
                          pregunta = false;
                          posible_compra=true;
                        }
                        else{
                            int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                            
                            //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                            if(resultado <= 0){
                              Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                            }
                            else{
                              fechas = fechas.Append(fecha_ingresada_prueba);
                              //demostrar todas las fechas que se ingresan
                              /*for(int i = 0; i < fechas.Length ; i++){
                                Console.WriteLine(fechas[i]);
                              }*/
                              posible_compra=true;
                            }
                          
                          pregunta = false;
                          //int resultado = DateTime.Compare()
                        }
                        //Console.WriteLine(fechas.Length);
                      }catch(Exception e){
                        Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                      }
                    }while(pregunta);
                    //Realizar la compra de las criptomonedas
                    while(posible_compra){
                      float m = multiplicador(mes_numero);
                      double y = XRP(dia_numero, m);
                      double total_gasto = y * cantidad_moneda;
                      /*
                      revisar si el costo total de las criptomonedas no supera su saldo, 
                      en caso que no supere realizar la compra, de lo contrario mencionar que 
                      no se puedo y explciar la razon de ella 
                      */
                      
                      string mensaje_compra= ("Se realizo una venta de " + cantidad_moneda + " ripple y se obtuevo una ganacia total de " + total_gasto);
                      compras = compras.Append(mensaje_compra);
                      Console.WriteLine(mensaje_compra);
                      ripple -= cantidad_moneda;
                      dinero +=total_gasto;
                      
                      posible_compra=false;
                    };
                    /*
                    for(int i = 0; i < fechas.Length ; i++){
                      Console.WriteLine(compras[i]);
                      Console.WriteLine(fechas[i]);
                    }*/
                    //terminar el ciclo 
                    ciclo=false;
                  }else{
                    Console.WriteLine("No se puede debio a que no tienes ningun ripple.\n");
                    ciclo=false;
                  }
                 
                }else{
                  Console.WriteLine("Porfavor, escoja entre 1 al 3. \n");
                }

              }catch(Exception e){
                Console.WriteLine("Error, porfavor solo valores numericos \n");
              }
              
            }while(ciclo);
          }else{
            Console.WriteLine("No es posible debido a que no tiene ninguna criptomoneda.\n");
          }
              break;
          //intercambiar criptomonedas
          case 3:
            ciclo = true;
            pregunta = true;
          //verificar si existe alguna criptomoneda, de lo contrario no ocurre nada
            if(bitcoin>0 || ethereum>0 || ripple>0){
              //preguntar el tipo de criptomoneda que desea vender
              do{
                Console.WriteLine("Escoja que criptomoneda desea intercambiar como origen, escribiendo el numero. \n");
                Console.WriteLine("1. BTC");
                Console.WriteLine("2. ETH");
                Console.WriteLine("3. XRP \n");
                //Se asumio que la venta de criptomonedas son valores enteros
                try{
                  seleccion_moneda = Convert.ToInt32(Console.ReadLine());
                  if(seleccion_moneda == 1){
                    if(bitcoin>0){
                      Console.WriteLine("Ingrese la cantidad que desea intercambiar. \n");
                      do{
                        try{
                          cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                          //verificar si cumple con las condiciones
                          if(cantidad_moneda>0 && cantidad_moneda<=bitcoin){
                            pregunta=false;
                          }else{
                            Console.WriteLine("Error, no se logro intente de nuevo\n");
                          }
                          
                        }catch(Exception e){
                          pregunta = true;
                          Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                        }
                      }while(pregunta);
                      pregunta = true;
                      do{
                        Console.WriteLine("Escoja que criptomoneda desea intercambiar como destino, escribiendo el numero. \n");
                        Console.WriteLine("1. ETH");
                        Console.WriteLine("2. XRP \n");
                        
                        try{
                          int seleccion_destino = Convert.ToInt32(Console.ReadLine());
                          if(seleccion_destino == 1){
                            Console.WriteLine("Ingrese la fecha que desea para intercambiar la criptomoneda. (Ejemplo: 09/16/2021). \n"); 
                            do{
                              try{
                                //ingreso de fecha
                                fecha_ingresada = Console.ReadLine();
                                //partir la fecha por sus dias y mes para el calculo 
                                string[] division= fecha_ingresada.Split("/");
                                mes=division[0];
                                mes_numero=int.Parse(mes);
                                dia=division[1];
                                dia_numero=int.Parse(dia);
                                //fecha_ingresada_prueba = DateTime.Parse(Console.ReadLine());
                                //Console.WriteLine(fecha_ingresada);
                                fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                                //Console.WriteLine(fecha_ingresada_prueba);
                                //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                                //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                                //Console.WriteLine(fechas.Length);
                                if(fechas.Length == 0){
                                  fechas = fechas.Append(fecha_ingresada_prueba);
                                  for(int i=0;i<fechas.Length;i++){
                                    Console.WriteLine(fechas[i]);
                                  }
                                  pregunta = false;
                                  posible_compra=true;
                                }else{
                                  int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                                  //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                                  if(resultado <= 0){
                                    Console.WriteLine("No se puede intercambiar esta fecha porque ya son pasadas o son iguales... \n");
                                  }
                                  else{
                                    fechas = fechas.Append(fecha_ingresada_prueba);
                                    posible_compra=true;
                                  }
                                  
                                  pregunta = false;
                                  }
                                }catch(Exception e){
                                  Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                                }
                            }while(pregunta);
                            //Realizar el intercambio de las criptomonedas
                            while(posible_compra){
                              float m = multiplicador(mes_numero);
                              double y = BTC(dia_numero, m);
                              double x = ETH(dia_numero, m);

                              double total_intercambio = (y * cantidad_moneda)/x;
                              total_intercambio = Math.Round(total_intercambio);
                              /*
                              revisar si el costo total de las criptomonedas no supera su saldo, 
                              en caso que no supere realizar la compra, de lo contrario mencionar que 
                              no se puedo y explciar la razon de ella 
                              */
                              
                              string mensaje_compra= ("Se realizo un intercambio de " + cantidad_moneda + " bitcoins y se obtuevo una cantidad de Ethereum de " + total_intercambio);
                              compras = compras.Append(mensaje_compra);
                              Console.WriteLine(mensaje_compra);
                              bitcoin -= cantidad_moneda;
                              ethereum +=total_intercambio;
                              
                              posible_compra=false;
                            };
                            //terminar el ciclo 
                            ciclo=false;
                          }else if(seleccion_destino == 2){
                            Console.WriteLine("algo");
                          }
                        }catch(Exception e){

                        }
                      }while(pregunta);
                    } 
                  }else if(seleccion_moneda == 2){
                    Console.WriteLine("algo");
                  }else if(seleccion_moneda == 3){
                    Console.WriteLine("algo");
                  }else{
                    Console.WriteLine("Error");
                  }
                }catch(Exception e){
                  Console.WriteLine("Porfavor, solo valores numericos. \n");
                }
              }while(pregunta);
            }    
            break;
          //Prediccion de criptomonedas
          case 4:
            pregunta = true;
            do{
              Console.WriteLine("Prediccion de ganancias");
              Console.WriteLine("Escoja que criptomoneda desea comprar. \n");
              Console.WriteLine("1. BTC");
              Console.WriteLine("2. ETH");
              Console.WriteLine("3. XRP \n");
              //seleccion_moneda = float.Parse(Console.ReadLine())
              //Se asumio que la compra de criptomonedas son valores enteros
              try{
                seleccion_moneda = Convert.ToInt32(Console.ReadLine());
                if(seleccion_moneda == 1){
                  Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                      }
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = BTC(dia_numero, m);
                    double total_gasto_1 = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto_1<=dinero){
                      //realizar la venta de la criptomenda en una fecha que sea ingresada por el usuario
                      Console.WriteLine("Ingrese la fecha que desea para vender la moneda. (Ejemplo: 09/16/2021). \n"); 
                      do{
                        try{
                          //ingreso de fecha
                          fecha_ingresada = Console.ReadLine();
                          //partir la fecha por sus dias y mes para el calculo 
                          string[] division= fecha_ingresada.Split("/");
                          mes=division[0];
                          mes_numero=int.Parse(mes);
                          dia=division[1];
                          dia_numero=int.Parse(dia);
                          fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                          //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                          //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                          //Console.WriteLine(fechas.Length);
                          if(fechas.Length == 0){
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            for(int i=0;i<fechas.Length;i++){
                              Console.WriteLine(fechas[i]);
                            }
                            pregunta = false;
                            posible_compra=true;
                          }
                          else{
                              int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                              
                              //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                              if(resultado <= 0){
                                Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                              }
                              else{
                                fechas = fechas.Append(fecha_ingresada_prueba);
                                posible_compra=true;
                              }
                            
                            pregunta = false;
                          }
                        }catch(Exception e){
                          Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                        }
                      }while(pregunta);
                      //Realizar la compra de las criptomonedas
                      while(posible_compra){
                        m = multiplicador(mes_numero);
                        y = BTC(dia_numero, m);
                        double total_gasto_2 = y * cantidad_moneda;
                        //realizar la comparacion y ver si es ganancia o perdida
                        double total_gasto_general=total_gasto_2-total_gasto_1;
                        if(total_gasto_general>0){
                          Console.WriteLine("Se logra generar una ganancia de $" + total_gasto_general);
                        }else{
                          Console.WriteLine("Se genera una perdida de $" + total_gasto_general);
                        }
                        //eliminar la fecha de esa compra debido a que fue cancelada
                        fechas = fechas.SkipLast(1).ToArray();
                        fechas = fechas.SkipLast(1).ToArray();

                        posible_compra=false;
                      };
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  //terminar el ciclo 
                  ciclo=false;

                }else if(seleccion_moneda== 2){
                  Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                      }
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = ETH(dia_numero, m);
                    double total_gasto_1 = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto_1<=dinero){
                      //realizar la venta de la criptomenda en una fecha que sea ingresada por el usuario
                      Console.WriteLine("Ingrese la fecha que desea para vender la moneda. (Ejemplo: 09/16/2021). \n"); 
                      do{
                        try{
                          //ingreso de fecha
                          fecha_ingresada = Console.ReadLine();
                          //partir la fecha por sus dias y mes para el calculo 
                          string[] division= fecha_ingresada.Split("/");
                          mes=division[0];
                          mes_numero=int.Parse(mes);
                          dia=division[1];
                          dia_numero=int.Parse(dia);
                          fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                          //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                          //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                          //Console.WriteLine(fechas.Length);
                          if(fechas.Length == 0){
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            for(int i=0;i<fechas.Length;i++){
                              Console.WriteLine(fechas[i]);
                            }
                            pregunta = false;
                            posible_compra=true;
                          }
                          else{
                              int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                              
                              //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                              if(resultado <= 0){
                                Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                              }
                              else{
                                fechas = fechas.Append(fecha_ingresada_prueba);
                                posible_compra=true;
                              }
                            
                            pregunta = false;
                          }
                        }catch(Exception e){
                          Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                        }
                      }while(pregunta);
                      //Realizar la compra de las criptomonedas
                      while(posible_compra){
                        m = multiplicador(mes_numero);
                        y = ETH(dia_numero, m);
                        double total_gasto_2 = y * cantidad_moneda;
                        //realizar la comparacion y ver si es ganancia o perdida
                        double total_gasto_general=total_gasto_2-total_gasto_1;
                        if(total_gasto_general>0){
                          Console.WriteLine("Se logra generar una ganancia de $" + total_gasto_general);
                        }else{
                          Console.WriteLine("Se genera una perdida de $" + total_gasto_general);
                        }
                        //eliminar la fecha de esa compra debido a que fue cancelada
                        fechas = fechas.SkipLast(1).ToArray();
                        fechas = fechas.SkipLast(1).ToArray();

                        posible_compra=false;
                      };
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  //terminar el ciclo 
                  ciclo=false;
                }else if(seleccion_moneda== 3){
                  Console.WriteLine("Ingrese la cantidad que desea Comprar. \n");
                  do{
                    try{
                      cantidad_moneda = Convert.ToInt32(Console.ReadLine());
                      //verificar si cumple con las condiciones
                      if(cantidad_moneda>0){
                        pregunta=false;
                      }else{
                        Console.WriteLine("Error, no se logro intente de nuevo\n");
                      }
                    }catch(Exception e){
                      pregunta = true;
                      Console.WriteLine("Porfavor, solo valores numericos.\n"); 
                    }
                  }while(pregunta);
                  pregunta = true;
                  Console.WriteLine("Ingrese la fecha que desea para comprar la moneda. (Ejemplo: 09/16/2021). \n"); 
                  do{
                    try{
                      //ingreso de fecha
                      fecha_ingresada = Console.ReadLine();
                      //partir la fecha por sus dias y mes para el calculo 
                      string[] division= fecha_ingresada.Split("/");
                      mes=division[0];
                      mes_numero=int.Parse(mes);
                      dia=division[1];
                      dia_numero=int.Parse(dia);
                      fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                      //Console.WriteLine(fecha_ingresada_prueba);
                      //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                      //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                      //Console.WriteLine(fechas.Length);
                      if(fechas.Length == 0){
                        fechas = fechas.Append(fecha_ingresada_prueba);
                        for(int i=0;i<fechas.Length;i++){
                          Console.WriteLine(fechas[i]);
                        }
                        pregunta = false;
                        posible_compra=true;
                      }
                      else{
                          int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                          
                          //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                          if(resultado <= 0){
                            Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                          }
                          else{
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            posible_compra=true;
                          }
                        
                        pregunta = false;
                      }
                    }catch(Exception e){
                      Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                    }
                  }while(pregunta);
                  //Realizar la compra de las criptomonedas
                  while(posible_compra){
                    float m = multiplicador(mes_numero);
                    double y = XRP(dia_numero, m);
                    double total_gasto_1 = y * cantidad_moneda;
                    /*
                    revisar si el costo total de las criptomonedas no supera su saldo, 
                    en caso que no supere realizar la compra, de lo contrario mencionar que 
                    no se puedo y explciar la razon de ella 
                    */
                    if(total_gasto_1<=dinero){
                      //realizar la venta de la criptomenda en una fecha que sea ingresada por el usuario
                      Console.WriteLine("Ingrese la fecha que desea para vender la moneda. (Ejemplo: 09/16/2021). \n"); 
                      do{
                        try{
                          //ingreso de fecha
                          fecha_ingresada = Console.ReadLine();
                          //partir la fecha por sus dias y mes para el calculo 
                          string[] division= fecha_ingresada.Split("/");
                          mes=division[0];
                          mes_numero=int.Parse(mes);
                          dia=division[1];
                          dia_numero=int.Parse(dia);
                          fecha_ingresada_prueba=Convert.ToDateTime(fecha_ingresada);
                          //(fecha,fecha2). Una lista de fechas, for recorrido a todas las fechas que no sean menores al ingresado, 
                          //y si es el mayor el ingresado, se hace la compra, de lo contrario, lo mnada a la mierda
                          //Console.WriteLine(fechas.Length);
                          if(fechas.Length == 0){
                            fechas = fechas.Append(fecha_ingresada_prueba);
                            for(int i=0;i<fechas.Length;i++){
                              Console.WriteLine(fechas[i]);
                            }
                            pregunta = false;
                            posible_compra=true;
                          }
                          else{
                              int resultado = DateTime.Compare(fecha_ingresada_prueba, fechas[fechas.Length-1]);
                              
                              //Console.WriteLine(resultado); // 0 ambos son iguales, >0: fecha 1 es despues que fecha2, <0: fecha 1 es antes que fecha2
                              if(resultado <= 0){
                                Console.WriteLine("No se puede comprar esta fecha porque ya son pasadas o son iguales... \n");
                              }
                              else{
                                fechas = fechas.Append(fecha_ingresada_prueba);
                                posible_compra=true;
                              }
                            
                            pregunta = false;
                          }
                        }catch(Exception e){
                          Console.WriteLine("Porfavor, solo el formato de fechas. \n"); 
                        }
                      }while(pregunta);
                      //Realizar la compra de las criptomonedas
                      while(posible_compra){
                        m = multiplicador(mes_numero);
                        y = XRP(dia_numero, m);
                        double total_gasto_2 = y * cantidad_moneda;
                        //realizar la comparacion y ver si es ganancia o perdida
                        double total_gasto_general=total_gasto_2-total_gasto_1;
                        if(total_gasto_general>0){
                          Console.WriteLine("Se logra generar una ganancia de $" + total_gasto_general);
                        }else{
                          Console.WriteLine("Se genera una perdida de $" + total_gasto_general);
                        }
                        //eliminar la fecha de esa compra debido a que fue cancelada
                        fechas = fechas.SkipLast(1).ToArray();
                        fechas = fechas.SkipLast(1).ToArray();

                        posible_compra=false;
                      };
                    }else{
                      Console.WriteLine("No se pudo realizar esta compra debido a que el saldo no alcanza. \n");
                      //eliminar la fecha de esa compra debido a que fue cancelada
                      fechas = fechas.SkipLast(1).ToArray();
                    }
                    posible_compra=false;
                  };
                  //terminar el ciclo 
                  ciclo=false;
                }else{
                  Console.WriteLine("Porfavor, escoja entre 1 al 3. \n");
                }

              }catch(Exception e){
                Console.WriteLine("Error, porfavor solo valores numericos \n");
              }
              
            }while(ciclo);
            break;
          //Resumen de operaciones
          case 5:
            //mostrar el saldo con el que inicio originalmente
            Console.WriteLine("Saldo Inicial $500");
            //mostrar el saldo actual
            Console.WriteLine("Saldo actual $" + dinero);
            //Motrar los detalles de cada criptomoneda
            Console.WriteLine("_______________________________________");
            Console.WriteLine("BTC bitcoins " + bitcoin);
            Console.WriteLine("ETH ethereum " + ethereum);
            Console.WriteLine("XRP ripple " + ripple);
            Console.WriteLine("_______________________________________");
            //mostrar la cantidad de operaciones totales
            for(int i=0;i<compras.Length;i++){
              Console.WriteLine(fechas[i] + " " + compras[i]);
            }
            Console.WriteLine("_______________________________________");
            //mostrar el saldo neto ya con todo y criptomonedas
            string date = (fechas[fechas.Length-1]).ToString();
            Console.WriteLine("Fecha actual del sistema: " + date);
            string[] division_final= date.Split("/");
            string mes_final=division_final[0];
            int mes_numero_final=int.Parse(mes_final);
            string dia_final=division_final[1];
            int dia_numero_final=int.Parse(dia_final);
            
            float m_final = multiplicador(mes_numero);
            double x_final = BTC(dia_numero_final, m_final);
            x_final*=bitcoin;
            double y_final = ETH(dia_numero_final,m_final);
            y_final*=ethereum;
            double z_final = XRP(dia_numero_final,m_final);
            z_final*=ripple;
            double total_ganancia=dinero + x_final + y_final + z_final;
            Console.WriteLine("Saldo neto: $" + total_ganancia);
            break;
          //salir
          case 6:
            Console.WriteLine("Regresando al menu principal... \n");
            break;
          default:
            Console.WriteLine("Porfavor ingresar del 1 al 6 \n");
            break;
        }

      }
      catch(Exception e){
          Console.WriteLine("Por favor ingresar solo valores numericos... \n");
        }

    }while(seleccion_menu2!=6);
    

    
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