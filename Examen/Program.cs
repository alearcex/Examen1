using Examen;

var existe = false;
var numeros = true;
var fecha = true;
var cantidad = 0;


List<Medicamento> medicamentos = new List<Medicamento>();
List<Paciente> pacientes = new List<Paciente>();
List<MedicamentoPaciente> listaMxP = new List<MedicamentoPaciente>(); // mxp = medicamentos por pacientes
while (true)
{
    Console.Clear();
    Console.WriteLine("******************************************************");
    Console.WriteLine("**        Gestión de Pacientes y Medicamentos       **");
    Console.WriteLine("******************************************************");
    Console.WriteLine("1- Agregar paciente");
    Console.WriteLine("2- Agregar medicamento");
    Console.WriteLine("3- Asignar medicamento a paciente");
    Console.WriteLine("4- Consultas");
    Console.WriteLine("Ingrese el número de opción:");
    var opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            while (true)
            {
                Paciente paciente = new Paciente();
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**               Registro de pacientes              **");
                Console.WriteLine("******************************************************");
                var cedula = 0;
                do
                    try
                    {
                        Console.WriteLine("Digite el número de cédula del paciente:");
                        cedula = int.Parse(Console.ReadLine());
                        numeros = false;
                    }
                    catch
                    {
                        Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                        numeros = true;
                    }
                while (numeros);


                foreach (var elemento in pacientes)
                {
                    if (elemento.Cedula == cedula)
                    {
                        existe = true;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    Console.WriteLine("El número de cédula ya fue registrado anteriormente.");
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar

                }
                else
                {
                    //Se ingresa y asigna el nombre
                    Console.WriteLine("Ingrese el nombre:");
                    paciente.Nombre = Console.ReadLine();

                    //Se asigna la cédula ya ingresada
                    paciente.Cedula = cedula;

                    //Se ingresa, valida y asigna el teléfono
                    do
                        try
                        {
                            Console.WriteLine("Digite el número de teléfono:");
                            paciente.Telefono = int.Parse(Console.ReadLine());
                            numeros = false;
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                            numeros = true;
                        }
                    while (numeros);

                    //Se ingresa y asigna el tipo de sangre
                    Console.WriteLine("Ingrese el tipo de sangre:");
                    paciente.TipoSangre = Console.ReadLine();

                    //Se ingresa y asigna la dirección
                    Console.WriteLine("Ingrese la dirección:");
                    paciente.Direccion = Console.ReadLine();

                    //Se ingresa y asigna la fecha de nacimiento
                    do
                        try
                        {
                            Console.WriteLine("Digite la fecha de nacimiento:");
                            paciente.FechaNacimiento = DateOnly.Parse(Console.ReadLine());
                            fecha = false;
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso con formato dd/mm/aaaa >>>");
                            fecha = true;
                        }
                    while (fecha);

                    //se agrega el paciente a la lista
                    pacientes.Add(paciente);

                    //Se consulta si de quieren ingresar más pacientes
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("¿Desea ingresar información de otro paciente? (S/N): ");
                    string continuar = Console.ReadLine();
                    if (continuar.ToUpper() != "S")
                    {
                        break;
                    }
                }
            }
                break;
        case 2:
            while (true)
            {
                Medicamento medicamento = new Medicamento();
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**             Registro de medicamentos             **");
                Console.WriteLine("******************************************************");
                var codigo = 0;
                do
                    try
                    {
                        Console.WriteLine("Digite el código de medicamento:");
                        codigo = int.Parse(Console.ReadLine());
                        numeros = false;
                    }
                    catch
                    {
                        Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                        numeros = true;
                    }
                while (numeros);

                foreach (var elemento in medicamentos)    
                {
                    if (elemento.Codigo == codigo)
                    {
                        existe = true;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    Console.WriteLine("El código de medicamento ya fue registrado anteriormente.");
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar

                }
                else
                {

                    //Se asigna la cédula ya ingresada
                    medicamento.Codigo = codigo;

                    //Se ingresa y asigna el nombre
                    Console.WriteLine("Ingrese el nombre:");
                    medicamento.Nombre = Console.ReadLine();


                    //Se ingresa, valida y asigna la cantidad de medicamento
                    do
                        try
                        {
                            Console.WriteLine("Digite la cantidad disponible:");
                            cantidad = int.Parse(Console.ReadLine());
                            if (cantidad > 0)
                            {
                                medicamento.Cantidad = cantidad;
                                numeros = false;
                            }
                            else
                            {
                                numeros = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                            numeros = true;
                        }
                    while (numeros);

                    medicamentos.Add(medicamento);

                    //Se consulta si de quieren ingresar más medicamentos
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("¿Desea ingresar información de otro medicamento? (S/N): ");
                    string continuar = Console.ReadLine();
                    if (continuar.ToUpper() != "S")
                    {
                        break;
                    }
                }
            }
                break;
        case 3:
            if (medicamentos.Count() == 0)
            {
                Console.WriteLine("No se han registrado medicamentos");
                Thread.Sleep(3000); // Espera 3 segundos antes de continuar

            }
            else if (pacientes.Count() == 0)
            {
                Console.WriteLine("No se han registrado pacientes");
                Thread.Sleep(3000); // Espera 3 segundos antes de continuar
            }
            else
            {
                while (true)
                {
                    MedicamentoPaciente mxp = new MedicamentoPaciente();
                    Medicamento medicamento = new Medicamento();
                    Paciente paciente = new Paciente();

                    Console.Clear();
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("**      Registro de medicamentos para pacientes     **");
                    Console.WriteLine("******************************************************");

                    #region validarCedula
                    var cedula = 0;
                    do
                        try
                        {
                            Console.WriteLine("Digite el número de cédula del paciente:");
                            cedula = int.Parse(Console.ReadLine());
                            numeros = false;
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                            numeros = true;
                        }
                    while (numeros);

                    // Valida si existe el paciente
                    foreach (var elemento in pacientes)
                    {
                        if (elemento.Cedula == cedula)
                        {
                            existe = true;
                            paciente = elemento;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }

                    //Valida cuantos medicamentos tiene asignados el paciente
                    if (existe)
                    {
                        mxp.CodigoCedula = cedula;

                    }
                    else
                    {
                        Console.WriteLine("No ha sido registrado un paciente con ese número de cédula.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        break;
                    }
                    //se hace una lista para según su cantidad de registros validar si el paciente ya tiene el límite de 3 medicamentos
                    List<MedicamentoPaciente> cuenta = listaMxP.Where(m => m.CodigoCedula == cedula).ToList();

                    if (cuenta.Count > 3)
                    {
                        Console.WriteLine("El paciente ya cuenta con el límite de 3 medicamentos.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        break;


                    }
                    #endregion

                    #region validarCodigo
                    var codigo = 0;
                    do
                        try
                        {
                            Console.WriteLine("Digite el código de medicamento:");
                            codigo = int.Parse(Console.ReadLine());
                            numeros = false;
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                            numeros = true;
                        }
                    while (numeros);

                    foreach (var elemento in medicamentos)
                    {
                        if (elemento.Codigo == codigo)
                        {
                            existe = true;
                            medicamento = elemento;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }

                    if (existe)
                    {
                        mxp.CodigoMedicamento = codigo;

                        //Valida si el medicamento ya forma parte de la lista para este paciente
                        var repetido = false;
                        var receta = listaMxP.Where(x => x.CodigoCedula == cedula).Select(x => x.CodigoMedicamento).ToList();
                        foreach (var elemento in receta)
                        {
                            if(elemento == codigo)
                            {
                                repetido = true;
                                break;
                            }
                            
                        }
                        if(repetido == true)
                        {
                            Console.WriteLine("Este medicamento ya fue recetado al paciente.");
                            Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ha sido registrado un medicamento con ese código.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        break;
                    }
                    #endregion

                    #region validar disponibilidad

                    //cantidad de medicamento para el paciente
                    do
                        try
                        {
                            Console.WriteLine("Digite la cantidad de medicamento para el paciente:");
                            cantidad = int.Parse(Console.ReadLine());
                            numeros = false;
                        }
                        catch
                        {
                            Console.WriteLine("<<< Solo se permite el ingreso de números >>>");
                            numeros = true;
                        }
                    while (numeros);

                    if (medicamento.Cantidad > cantidad)
                    {

                        Console.WriteLine("¿Agregar a los medicamentos del paciente {0} ", paciente.Nombre);
                        Console.WriteLine("el medicamento {0} en una cantidad de {1}? (S/N)", medicamento.Nombre, cantidad);
                        string confirmar = Console.ReadLine();
                        if (confirmar.ToUpper() != "S")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente medicamento para este paciente.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        break;
                    }
                    #endregion|

                    //Se agrega el medicamento a la lista luego de todas las validaciones
                    listaMxP.Add(mxp);

                    //Se busca el medicamento con ese código para bajar la cantidad disponible
                    Medicamento med = medicamentos.Find(m => m.Codigo == medicamento.Codigo);
                    med.Cantidad = med.Cantidad - cantidad;

                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("¿Desea realizar otro registro? (S/N)");
                    string respuesta = Console.ReadLine();
                    if (respuesta.ToUpper() != "S")
                    {
                        break;
                    }
                }
            }
            break;
        case 4:
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**               Submenú de Consultas               **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1- Reporte de pacientes");
                Console.WriteLine("2- Cantidad de pacientes");
                Console.WriteLine("3- Reporte de medicamentos recetados");
                Console.WriteLine("4- Regresar al menú principal");
                Console.WriteLine("Ingrese el número de opción:");
                var subOpcion = int.Parse(Console.ReadLine());

                switch (subOpcion)
                {
                    case 1:
                        var listaOrdenada = pacientes.OrderBy(p => p.Nombre);

                        Console.Clear();
                        Console.WriteLine("************************************************************************************************");
                        Console.WriteLine("*****                                  Reporte de Pacientes                                *****");
                        Console.WriteLine("************************************************************************************************");
                        Console.WriteLine($"{"Cédula",-10}{"Nombre",-30}{"Teléfono",-10}{"Tipo Sangre",-14}{"Fecha Nacimiento",-18}{"N° Medicamentos",-15}");
                        Console.WriteLine("===============================================================================================");

                        //p = paciente para que no se me haga muy larga la línea o no dividirla
                        foreach (var p in listaOrdenada)
                        {
                            //Se obtienen los medicamentos que toma para mostrarlos en el reporte
                            var receta = listaMxP.Where(x => x.CodigoCedula == p.Cedula).Select(x => x.CodigoMedicamento).ToList();

                            var nMedicamentos = receta.Count;


                            Console.WriteLine($"{p.Cedula,-10}{p.Nombre,-30}{p.Telefono,-10}{p.TipoSangre,-15}{p.FechaNacimiento,-18}{nMedicamentos,-15}");
                        }
                        Console.WriteLine("===============================================================================================");
                        Console.WriteLine("<<< Pulse cualquier tecla para volver >>>");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine("En este momento hay {0} pacientes en el sistema", pacientes.Count); 
                        Console.WriteLine();
                        Console.WriteLine("<<< Pulse cualquier tecla para volver >>>");
                        Console.ReadKey();
                        
                        break;
                    case 3:
                        //Se obtienen los codigos que se han asignado a un paciente sin repetirse
                        var lista = listaMxP.Select(x => x.CodigoMedicamento).Distinct().ToList();

                        Console.Clear();
                        Console.WriteLine("***************************************************");
                        Console.WriteLine("**       Reporte de Medicamentos Recetados       **");
                        Console.WriteLine("***************************************************");
                        Console.WriteLine($"{"Codigo",-10}{"Nombre",-30}{"Cantidad",-10}");
                        Console.WriteLine("===================================================");
                        foreach (var codigo in lista)
                        {
                            //Se obtienen los datos para cada medicamento usando cada codigo
                            var medicamento = medicamentos.Where(x => x.Codigo == codigo).FirstOrDefault();

                            Console.WriteLine($"{medicamento.Codigo,-10}{medicamento.Nombre,-30}{medicamento.Cantidad, -10}");
                        }
                        Console.WriteLine("===================================================");
                        Console.WriteLine("<<< Pulse cualquier tecla para volver >>>");
                        Console.ReadKey();

                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        Console.Clear();
                        break;
                }
                break;
            }
            break;
        default:
        break;
    }
}
