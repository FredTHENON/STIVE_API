﻿using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TvasController : ControllerBase
    {
        //ACTION SUR LA TVA

        //Lister les taux de TVA
        [HttpGet]
        public List<Tva> ListeTVA()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Tva> tvas = context.tvas.ToList();
                    return tvas;
                }

            }
        }

        //Ajouter un taux de TVA
        [HttpPost]
        public void AjouterTVA(double Taux)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Tva NouvelleTva = new Tva();
                NouvelleTva.TauxTva = Taux;
                NouvelleTva.LibelleTVA = Taux + "%";

                context.Add(NouvelleTva);
                context.SaveChanges();
            }
        }


        //Supprimer une TVA
        [HttpDelete]
        public void SupprimerTva(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Tva uneTva = context.tvas.Where(x => x.IdTva == ID).First();
                context.Remove(uneTva);
                context.SaveChanges();
            }
        }
    }
}
