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
    Console.WriteLine("3- Asignar medicamneto a paciente");
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

                if (existe)
                {
                    mxp.CodigoCedula = cedula;
                }
                else
                {
                    Console.WriteLine("No ha sido registrado un paciente con ese número de cédula.");
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                }

                #endregion

                #region validarCedula
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
                }
                else
                {
                    Console.WriteLine("No ha sido registrado un medicamento con ese código.");
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                }
                #endregion

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

                if(medicamento.Cantidad > cantidad)
                {

                    Console.WriteLine("¿Agregar al los medicamentos del paciente {0} ");
                    Console.WriteLine("el medicamento {0} en una cantidad de {1}");
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
                }

                //Se agrega el medicamento a la lista
                listaMxP.Add(mxp);

                Console.WriteLine("¿Desea realizar otro registro? (S/N)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper() != "S")
                {
                    break;
                }
            }
            break;
        default:
        break;
    }
}
