using Listas0.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.IO;
using Newtonsoft.Json;

namespace Listas0.Controllers
{
   
    public class HomeController : Controller
    {
        int retorna;
        string devuelto = "";
        Areas.AreaProyectos.Models.DBALUMNOSEntities db = new Areas.AreaProyectos.Models.DBALUMNOSEntities();


        public ActionResult Index() // pagina principal
        {
            var amigas = new DatoJson() { nombre = "Marlenep", edad = 25 };
            var amigas2 = new DatoJson() { nombre = "Juliza", edad = 30 ,dire="Guayas"};
            //return Json(new List<DatoJson>() { amigas,amigas2}, JsonRequestBehavior.AllowGet);
            //return Json(amigas, JsonRequestBehavior.AllowGet);

            return View();
        }

        [HttpGet]
        public ActionResult About() // página de inicio acerca de  INDEX
        {
             retorna=1;
            CargarCombo(); // funcion
            datosTabla(); // funcion
            ViewBag.Message = "Página de ensayos para listas.";
            List<Part> parts = new List<Part>();
            // Add parts to the list.
            parts.Add(new Part() { PartName = "Chevrolet", PartId = 1234 });
            parts.Add(new Part() { PartName = "Mazda", PartId = 85020 });
            parts.Add(new Part() { PartName = "Toyota", PartId = 123 });

            if(Session["ResultGenero"] != null)// por que biene de un evento Post al clikear un boton, da un resultado.
            {
                ViewBag.ResultGenero = GetGenero(Convert.ToInt32(Session["ResultGenero"])); Session["ResultGenero"] = null;
            }
                

            var data = parts;  if (data == null) { return View(); }         
            int numeroItems2 = data.Count();
            ViewBag.info =" Registros:" +Convert.ToString(numeroItems2.ToString());
           // FnVistaData(); // funcion

            //if (Session["ResultUser"] != null)// por que biene de un evento Post al clikear un boton, da un resultado.
            //{
            //    ViewBag.ResultUser = FnVistaData(Convert.ToInt32(Session["ResultUser"])); Session["ResultUser"] = null;
            //}
             FnVistaData(Convert.ToInt32(Session["ResultUser"])); Session["ResultUser"] = null;

            return View(data.ToList()); // aqui la magia
        }

        public ActionResult datosTabla()
        {
            // Create an ArrayList and fill it with Guid values.
            ArrayList guidList = new ArrayList();
            guidList.Add(new Guid("3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE"));
            guidList.Add(new Guid("2AAAAAAA-BBBB-CCCC-DDDD-1EEEEEEEEEEE"));
            guidList.Add(new Guid("1AAAAAAA-BBBB-CCCC-DDDD-3EEEEEEEEEEE"));

            //foreach (Guid guidValue in guidList)
            //{
            //    Console.WriteLine(" {0}", guidValue);

            //}
            if (guidList == null) { return View(); }
          // guidList.Sort();// ordena el array
            ViewBag.Collection = guidList;
      
            
            
            return View();
        }
    
    
        [HttpGet]
        public ActionResult FnVistaData( int id=0)// Vista con Datatable, lista .
        {
            // OJO: Esto vale solo para datos unicos, no LISTADOS
            DataTable dtGrid = new DataTable();
            LogOnModel objGrid = new LogOnModel();
            dtGrid = objGrid.GetgridData(); // Llenar un grid con Lista y DataTable
            List<LogOnModel> Gridd = new List<LogOnModel>();
            foreach (DataRow dr in dtGrid.Rows)
            {
                LogOnModel users = new LogOnModel();
                users.idusuario_ = Convert.ToInt32(dr["codigo"].ToString());
                users.nombre = dr["nombre"].ToString().Trim();
              //  users.estado = dr["estado"].ToString();
                Gridd.Add(users);
                Session["ResultUser"] = users.idusuario_; // mi BANDERA Gridd;
                ViewBag.ResultUser = users.nombre.Trim(); // dtGrid;
            }

            return View();
            //return View("VistaAbout", Gridd);


        }


        #region"Llenar combos de forma generica, sin conectarse al SQL"

        public ActionResult CargarCombo()
        {
            datosTabla();

            List<vehiculo> veh = new List<vehiculo>();
            veh.Add(new vehiculo() {idmarcaveh=1,idmodeloveh=1,idparteveh=100,nombreveh="Vivant" });
            veh.Add(new vehiculo() { idmarcaveh = 2, idmodeloveh = 1, idparteveh = 201, nombreveh = "Mazda" });
            var dato = veh; if (veh == null) { return View(); }
            ViewBag.MessageToolTip = "Páginado #"+Convert.ToString(dato.Count());
            List<string> compra = new List<string>();
            List<string> cilindraje = new List<string>();
            int[] numbers = new int[6] { 1, 2, 3, 4, 5, 6 };
            IList<string> ListadoColores = new List<string>() {"ROJO","NEGRO","BLANCO","NEGRO BICOLOR","BLANCO BICOLOR","NARANJA BICOLOR" };

            List < SelectListItem > lsTaccion = new List<SelectListItem>();
            lsTaccion.Add(new SelectListItem() { Text = "4x2", Value = "1" });
            lsTaccion.Add(new SelectListItem() { Text = "4x4", Value = "2" }); // lo lleno de la otra forma  1

            List<string> Genero = new List<string>();
            List<SelectListItem> lsGenero = new List<SelectListItem>();
            //lsGenero.Add(new SelectListItem() { Text = "Masculino", Value = "0" });
            //lsGenero.Add(new SelectListItem() { Text = "Femenino", Value = "1" });
            
            compra.Add("Diesel");
            compra.Add("Gasolina");
            cilindraje.Insert(0, "1.5");
            cilindraje.Insert(1, "2.0");

            Genero.Insert(0,"Masculino");
            Genero.Insert(1, "Femenino");


            var listaPotencia = new SelectList(cilindraje);
            var listaDisponibilidad = new SelectList(compra);
            var listaGenero = new SelectList(Genero);
            var peso = from num in numbers where num > 1 select num;
            var tonelaje = new SelectList(peso);
            var colores = from color in ListadoColores where color.Contains("BICOLOR") select color;
            var colors = new SelectList(colores);

            ViewBag.Potencia = listaPotencia;
            ViewBag.Disponibilidad = listaDisponibilidad;
            ViewBag.Traccion = lsTaccion;// lo lleno de la otra forma de arriba 1
            ViewBag.Genero = listaGenero;
            ViewBag.peso = tonelaje; //  .ToList();
            ViewBag.Colores = colors;

            Cat sameCat = new Cat("Full_10000KM") { Age = 20 };
            List<Cat> Listcat = new List<Cat>();
            Cat gato = new Cat("MarcaCat") { name="Garantia_Base",Age=10};
            Cat gato2=new Cat("MarcaCat") { name = "Garantia_Completa", Age = 20 };
            Listcat.Add(gato); Listcat.Add(gato2); Listcat.Add(sameCat);


            ViewBag.Garantia = Listcat.ToList();
           // ViewBag.GarantiaExtra = sameCat;


            return View(dato.ToList());
        }
        #endregion

        #region"no action pruebas"
        //public class Generos
        //{
        //    public int pk { get; set; }
        //    public string sex { get; set; }
        //}
     [HttpPost]
        public ActionResult GetResultGenero(int SuDato)
        {
            GetGenero(SuDato);
            return RedirectToAction("About");
           // return View();
           // return Content(Convert.ToString(ViewBag.ResultGenero));//.

        }
   [NonAction]
        public string GetGenero(int id)//otra forma de hacerlo
        {
           // List<string> LstGeneros = new List<string>();
            if (id == 1)
            {
                // LstGeneros.Insert(1, "Aplica para modelo Mujer");
              //  ViewBag.ResultGenero = "Aplica para modelo Mujer"; //LstGeneros;
                Session["ResultGenero"] = Convert.ToString(id); 
                return "Aplica para modelo Mujer";
          

            }
            if(id==0)
            {
                //  LstGeneros.Insert(0, "Aplica para modelo Hombre");
                //ViewBag.ResultGenero = "Aplica para modelo Hombre"; //LstGeneros;
                Session["ResultGenero"] = Convert.ToString(id);
                return "Aplica para modelo Hombre";
            }

            else
            {
                //  LstGeneros.Insert(0, "Aplica para modelo Hombre");
               // ViewBag.ResultGenero = "Aplicación Indistinta"; //LstGeneros;
                Session["ResultGenero"] = Convert.ToString(id);
                return "Aplicación Indistinta";
            }
  
           


        } // fin de: GetGenero(1)


        //[NonAction]
        //public List<Genero>
        //{
        //    List<Genero> ListGetGenero = new List<Genero>();

        //     return ListGetGenero.Where(s => s.StudentId == id).FirstOrDefault();
        //   // return Genero;
        //}
        #endregion

        #region"Conexión para los Combo Box SQL"
        public ActionResult GetCombos() //bool
        {
         

            // //******************************* Combo Pais  ****************
            List<TablaViewModel> lst = (from d in db.pais
                   select new TablaViewModel
                   {
                        id = d.idpais,
                       nombre = d.nombre.ToString()
                      //,Selected=false
                   }).ToList();

            List<SelectListItem> itemsPais = lst.ConvertAll(z =>
            {
                return new SelectListItem()
                {
                    Text = z.nombre.ToString(),
                    Value = z.id.ToString(),
                    Selected = false
                };
            });
            //******************************* Cmbo Ciudad
            List<TablaViewModel> lst2 = (from x in db.ciudad
                                         select new TablaViewModel
                                         {
                                             id = x.id,
                                             nombre = x.nombre.ToString()
                                             //,Selected=false
                                         }).ToList();
            List<SelectListItem> itemsCiudad = lst2.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.nombre.ToString(),
                    Value = x.id.ToString(),
                    Selected = false
                };
            });
            //******************************* Cmbo Documentos
            List<TablaViewModel> lst3 = (from d in db.DocumentosId
                                         select new TablaViewModel
                                         {
                                             id = d.iddoc,
                                             nombre = d.nombres.ToString()
                                             //,Selected=false
                                         }).ToList();
            List<SelectListItem> itemsDocumentos = lst3.ConvertAll(y =>
            { //  ** coge los datos de mi clase TablaViewModel *****
                return new SelectListItem()
                {
                    Text = y.nombre.ToString(),
                    Value = y.id.ToString(),
                    Selected = false
                };
            });

            if (lst != null || lst2 != null || lst3 != null)
                    {
                         retorna = 1;               
               ViewBag.CmbPais = itemsPais; ViewBag.CmbCiudad = itemsCiudad; ViewBag.CmbDocumentosId = itemsDocumentos;
                         return View(lst.ToList());
                     }

            retorna = 0;
            return null;
        }
        #endregion

      


        public ActionResult Contact()
        {
            ViewBag.Message = "Sus datos.";
            GetCombos();// Llena los combo Box
            return View();
        }


        private string FnCantCeros(int i)
        {
         
            switch(i)
            {
                case 1: devuelto = "0"; break;
                case 2: devuelto = "00"; break;
                case 3: devuelto = "000"; break;
                case 4: devuelto = "0000"; break;
                case 5: devuelto = "00000"; break;
                case 6: devuelto = "000000"; break;
                case 7: devuelto = "00000000"; break;
                case 8: devuelto = "000000000"; break;
                case 9: devuelto = "0000000000"; break;
                default: devuelto = ""; break;
            }
            return devuelto;
        }


       [HttpPost]
        public ActionResult Recupero(string dato1)
        {
            if (dato1 == "") { return null; }
            int a = 0; int n1 = 0; int n2 = 0;int r = 0; int rt = 0;
            int Repeticiones=0; n1 = dato1.Trim().Length;
            //             a = dato1.ToList().ConvertAll(x => Convert.ToInt32(x.ToString())).Max();
            a = Convert.ToInt32(dato1.ToString());  // usando funciones lambada linq c#
            //var results = dato1.GroupBy(p => p).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(b => b.Count).ToList();
            var results = dato1.GroupBy(p => p).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(b => b.Count).ToList();
            var contarceros = from dt in results select new { dt };
            if (results!=null)
            { // Repeticiones = dato1.ToArray().Where(lr => lr.Equals('0')).Count();
                foreach (var caracter in contarceros)
                {
                    if (caracter.dt.Key.ToString() == "0") { Repeticiones = caracter.dt.Count; }
                }
            }
            a++;dato1 = Convert.ToString(FnCantCeros(Repeticiones)+a);
            n2 = dato1.Trim().Length;
            if(n2>n1)
            {
                r = n2 - n1; rt = Repeticiones - r;dato1 = "";
                dato1 = Convert.ToString(FnCantCeros(rt) + a);
            }
            Session["Resultado"] = dato1;
            
            return RedirectToAction("About");
        }


        [HttpPost]
        public ActionResult Recupero2(int dato1)
        {
            double r = 0;
            r = dato1 * (-1.2);
            var dato = 0.00; dato = r;
            //Session["Resultado"] = dato;
            ViewBag.Resultado = dato;
            return Content(Convert.ToString(ViewBag.Resultado));// presento el resultado en una nueva pagina.
        }
    }

  public class DatoJson
    {
        public string nombre { get; set; }
        public int edad { get; set; }
        public string cel { get; set; }
        public string dire{ get; set; }
}

    //public ActionResult metodo(DatoJson data)
    //{
    //    var amigas = new DatoJson() { nombre = "Marlenep", edad = 25 };
    //    return Json(amigas, JsonRequestBehavior.AllowGet);
    //}

 
} // fin de todo