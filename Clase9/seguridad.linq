<Query Kind="Program">
  <Reference Relative="..\Datos.dll">D:\LINQPad5\Datos.dll</Reference>
  <Reference Relative="..\Newtonsoft.Json.dll">D:\LINQPad5\Newtonsoft.Json.dll</Reference>
  <Namespace>Datos</Namespace>
</Query>

//<Query Kind="Program">
//  <Reference Relative="Datos.dll">F:\CURSO_EMPLEAR\src_git\Clase9\Datos.dll</Reference>
//  <Reference Relative="Newtonsoft.Json.dll">F:\CURSO_EMPLEAR\src_git\Clase9\Newtonsoft.Json.dll</Reference>
//  <Namespace>Datos</Namespace>
//</Query>




void Main()
{
  Database db = new Database();
  
    //db.Provincias.Dump();
	var xx = db.Localidades                                     // creo un tipo anonimo q ue contiene los datos del select
	.Where(loc => loc.Nombre.ToLower().Contains("rosario"))      //metodo de extension where con una funcion lambda como predicado
	.Select(loc => new { loc.IDLocalidad, loc.Nombre} )		//metodo de extension Select con una funcion lambda como predicado
	.Dump();    												
														    //
  	db.TiposContacto.Dump();
	
	db.Personas.Dump();
	
}


public class Database
{
  private List<Persona> _personas ;
  private List<Usuario> _usuarios;
  private List<Empleado> _empleados;
  private List<TipoContacto> _tiposContacto;
  
  public List<Persona> Personas 
  { 
    get  
    {
      return _personas;
    }
  }
  
  //  agregar el resto...
  
  public List<Provincia> Provincias { get { return Datos.Info.Provincias; } }   //Si la libreria està declarada no es encesario usar aca, por ej datos se podrìa obviar.

  public List<Localidad> Localidades { get { return Datos.Info.Localidades; }}
  
  public List<TipoContacto> TiposContacto  { get { return _tiposContacto; } }
  
  public Database()
  {
    _tiposContacto = new List<TipoContacto>() 
    {
      new TipoContacto() { IDTipoContacto = 1, Descripcion = "Cuenta de twitter" },
      new TipoContacto() { IDTipoContacto = 2, Descripcion = "Correo Electronico", 
                           RegExp = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" },
      new TipoContacto() { IDTipoContacto = 3, Descripcion = "Telefono Fijo Particular",
                            RegExp= "tel_fijo" },
      new TipoContacto() { IDTipoContacto = 4, Descripcion = "Telefono Fijo Laboral", 
                            RegExp= "tel_fijo" },
      new TipoContacto() { IDTipoContacto = 5, Descripcion = "Telefono Movil Particular",
                            RegExp = "tel_movil" },
      new TipoContacto() { IDTipoContacto = 6, Descripcion = "Cuenta de Facebook" }
    };
    
   
    _empleados = new List<Empleado>() 
    {
      //  agregar Empleados
    };
    
    _usuarios = new List<Usuario>() 
    {
      //  agregar usuarios
    };
  
  	  
	_personas = new List<Persona>() {
	  	new Persona() { IdPersona = 1, Apellido = "Maiorano"},
	  	new Persona() { IdPersona = 2, Apellido = "Thedy" },
	  	new Persona() { IdPersona = 3, Apellido = "Marques" },
	  	new Persona() { IdPersona = 4, Apellido = "Almada" },
	  	new Persona() { IdPersona = 5, Apellido = "Contesti"}
								};

  
  }
}

public class Persona
{
	public int IdPersona { get; set; }
	public string Apellido { get; set; }
	public string Nombres { get; set; }
	public string Domicilio { get; set; }
	public string AmpliacionDomicilio { get; set; }
	public Localidad Localidad { get; set; }
	public string CodigoPostal { get; set; }
	public string Documento { get; set; }
	public string TipoDocumento { get; set; }
	public DateTime Nacimiento { get; set; }
	public enum Sex { M, F, O };
	public Sex Sexo { get; set; }
	public String comentario { get; set; }
	public TipoContacto Tipo { get; set; }
	public Contacto InfoContacto { get; set; }
}

		


public class Contacto
{
	public int IdContacto { get; set; }
	public string dato { get; set; }
	public String comentario { get; set; }
	public TipoContacto Tipo { get; set; }
}


public class Empleado { }

public class Usuario {}

public enum Sexo
{
  Femenino,
  Masculino,
  NoInformado,
  Indefinido
}

public class TipoContacto
{
  public int IDTipoContacto { get; set; }

  /// <summary>
  /// Por ejemplo: Movil Particular, Movil Empresa, Domicilio, Trabajo, Correo Electronico, etc... 
  /// </summary>
  public string Descripcion { get; set; }

  /// <summary>
  /// 
  /// </summary>
  public string RegExp { get; set; }
  
  
}