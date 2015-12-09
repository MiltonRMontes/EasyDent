using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjEasyDent.Model;

namespace prjEasyDent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (bdEasyDentEntities bd = new bdEasyDentEntities())
                {
                    var validacion = bd.tblUsuarios.Where(a => a.email.Equals(usuario.email) && a.password.Equals(usuario.password)).FirstOrDefault();
                    if (validacion != null)
                    {
                        Session["LogedUserID"] = validacion.id_usuario.ToString();
                        Session["LogedUserFullname"] = validacion.nombres.ToString();
                        return RedirectToAction("Inicio");
                    }
                }
            }
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        public ActionResult Guardar(tblUsuario usuario)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    bd.tblUsuarios.Add(usuario);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("register");
            }
        }

        public ActionResult inicio()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult crearPaciente()
        {
            return View();
        }

        public ActionResult GuardarPaciente(tblPaciente paciente)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    paciente.fk_odontologo = Int32.Parse(Session["LogedUserID"].ToString());
                    bd.tblPacientes.Add(paciente);
                    bd.SaveChanges();
                    var validacion = bd.tblPacientes.Where(a => a.numero_documento.Equals(paciente.numero_documento)).FirstOrDefault();
                    Session["IdPaciente"] = validacion.id_paciente;
                }
                return RedirectToAction("Historial");
            }
            catch (Exception)
            {
                return View("crearPaciente");
            }
        }

        public ActionResult Historial()
        {
            return View();
        }

        public ActionResult GuardarHistorial(tblHistorial historial)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    historial.fk_paciente = Int32.Parse(Session["IdPaciente"].ToString());
                    bd.tblHistorials.Add(historial);
                    bd.SaveChanges();
                    var validacion = bd.tblHistorials.Where(a => a.fk_paciente.Equals(historial.fk_paciente)).FirstOrDefault();
                    Session["IdHistorial"] = validacion.id_historial;
                }
                return RedirectToAction("Antecedentes");
            }
            catch (Exception)
            {
                return View("Historial");
            }
        }

        public ActionResult Antecedentes()
        {
            ViewBag.Patologias = getPatologias();
            return View();
        }

        public ActionResult GuardarAntecedente(tblAntecedente antecedente)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    antecedente.fk_historial = Int32.Parse(Session["IdHistorial"].ToString());
                    bd.tblAntecedentes.Add(antecedente);
                    bd.SaveChanges();
                }
                return RedirectToAction("Odontograma");
            }
            catch (Exception)
            {
                return View("Antecedentes");
            }
        }

        public ActionResult Odontograma()
        {
            return View();
        }

        public ActionResult GuardarOdontograma(tblOdontograma odontograma)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    odontograma.fk_historial = Int32.Parse(Session["IdHistorial"].ToString());
                    odontograma.fecha_odontograma = DateTime.Today;
                    bd.tblOdontogramas.Add(odontograma);
                    bd.SaveChanges();
                }
                return RedirectToAction("inicio");
            }
            catch (Exception)
            {
                return View("Odontograma");
            }
        }

        private List<tblPatologia> getPatologias()
        {
            using (bdEasyDentEntities bd = new bdEasyDentEntities())
            {
                return bd.tblPatologias.ToList();
            }
        }

        public List<tblPaciente> getPacientes()
        {
            using (bdEasyDentEntities bd = new bdEasyDentEntities())
            {
                return bd.tblPacientes.ToList();
            }
        }

        public ActionResult Modificar_Usuario()
        {
            tblUsuario usuario = new tblUsuario();
            int id_usuario = Int32.Parse(Session["LogedUserID"].ToString());
            using (bdEasyDentEntities bd = new bdEasyDentEntities())
            {
                usuario = bd.tblUsuarios.Where(a => a.id_usuario.Equals(id_usuario)).FirstOrDefault();
            }
            return View(usuario);
        }

        public ActionResult Usuario_Modificado(tblUsuario usuario)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    if (ModelState.IsValid)
                    {
                        bd.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                }
                return RedirectToAction("inicio");
            }
            catch (Exception)
            {
                return View("Modificar_Usuario");
            }
        }

        public ActionResult Cerrar_Sesion()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("inicio");
            }
        }

        public ActionResult Mandar_Paciente()
        {
            bdEasyDentEntities bd = new bdEasyDentEntities();
            return View(bd.tblPacientes.ToList());
        }

        public ActionResult Modificar_Paciente(int id = 0)
        {
            try
            {
                using (bdEasyDentEntities bd = new bdEasyDentEntities())
                {
                    tblPaciente paciente = bd.tblPacientes.Find(id);
                    if (paciente == null)
                    {
                        return RedirectToAction("Mandar_Paciente");
                    }
                    return View(paciente);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Mandar_Paciente");
            }
        }

        [HttpPost]
        public ActionResult Modificar_Paciente(tblPaciente paciente)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    if (ModelState.IsValid)
                    {
                        bd.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    return RedirectToAction("inicio");
                }
            }
            catch (Exception)
            {
                return View("Mandar_Paciente");
            }
        }

        public ActionResult Consultar_Historia()
        {
            bdEasyDentEntities bd = new bdEasyDentEntities();
            return View(bd.tblPacientes.ToList());
        }

        public ActionResult Mostrar_Historia(int id = 0)
        {
            try
            {
                using (bdEasyDentEntities bd = new bdEasyDentEntities())
                {
                    tblHistorial historia = bd.tblHistorials.Where(a => a.fk_paciente.Equals(id)).FirstOrDefault();
                    tblPaciente paciente = bd.tblPacientes.Where(a => a.id_paciente.Equals(id)).FirstOrDefault();
                    ViewBag.nombres = paciente.nombres;
                    if (historia == null)
                    {
                        return RedirectToAction("Consultar_Historia");
                    }
                    return View(historia);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Mandar_Paciente");
            }
        }

        [HttpPost]
        public ActionResult Mostrar_Historia(tblHistorial historia)
        {
            return View();
        }

        public ActionResult Mostrar_Antecedentes(int id = 0)
        {
            try
            {
                using (bdEasyDentEntities bd = new bdEasyDentEntities())
                {
                    tblAntecedente antecedente = bd.tblAntecedentes.Where(a => a.fk_historial.Equals(id)).FirstOrDefault();
                    tblPatologia patologia = bd.tblPatologias.Where(a => a.id_patologia.Equals(antecedente.fk_patologia)).FirstOrDefault();
                    ViewBag.patologia = patologia.descripcion;
                    if (antecedente == null)
                    {
                        return RedirectToAction("Consultar_Historia");
                    }
                    return View(antecedente);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Mandar_Paciente");
            }
        }

        [HttpPost]
        public ActionResult Mostrar_Antecedentes(tblAntecedente antecedente)
        {
            return View();
        }

        public ActionResult Mostrar_Odontograma(int id = 0)
        {
            try
            {
                using (bdEasyDentEntities bd = new bdEasyDentEntities())
                {
                    tblOdontograma odontograma = bd.tblOdontogramas.Where(a => a.fk_historial.Equals(id)).FirstOrDefault();
                    if (odontograma == null)
                    {
                        return RedirectToAction("Consultar_Historia");
                    }
                    return View(odontograma);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Mandar_Paciente");
            }
        }

        [HttpPost]
        public ActionResult Mostrar_Odontograma()
        {
            return View();
        }

        public ActionResult Citas()
        {
            bdEasyDentEntities bd = new bdEasyDentEntities();
            return View(bd.tblPacientes.ToList());
        }

        public ActionResult Citas_Grafico()
        {
            return View();
        }

        public ActionResult GuardarCita()
        {

            ViewBag.pacientes = getPacientes();
            return View();
        }

        [HttpPost]
        public ActionResult Almacenar_Cita(tblCita cita)
        {
            try
            {
                using (var bd = new bdEasyDentEntities())
                {
                    cita.fk_odontologo = Int32.Parse(Session["LogedUserID"].ToString());
                    bd.tblCitas.Add(cita);
                    bd.SaveChanges();
                }
                return RedirectToAction("inicio");
            }
            catch (Exception)
            {
                return View("Citas");
            }
        }
    }
}