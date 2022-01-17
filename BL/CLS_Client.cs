using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    class CLS_Client
    {
        private dbStockContext db = new dbStockContext();
        private Client C;
        public bool Ajouter_Client(string Nom, string Prenom, string Adresse, string Email, string Telephone, string Pays, string Ville) {
            C = new Client();//nouveau client
            C.Nom_Client = Nom;
            C.Prenom_Client = Prenom;
            C.Adresse_Client = Adresse;
            C.Email_Client = Email;
            C.Telephone_Client = Telephone;
            C.Pays_Client = Pays;
            C.Ville_Client = Ville;
            //verifier si le nom et le prenom existe dejà dans la base de données
            if (db.Clients.SingleOrDefault(s => s.Nom_Client == Nom && s.Prenom_Client == Prenom) == null)
            {
                db.Clients.Add(C);//ajouter dans la base de données
                db.SaveChanges();//sauvegarder dans la base de données
                return true;
            }
            else
            {
                return false;
            }
        }
        //  fonction pour modification d'un client déjà enregistrer dans la base de données
        public void Modifier_Client(int id, string Nom, string Prenom, string Adresse, string Email, string Telephone, string Pays, string Ville)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id);//verification sil'id du client existe
            if(C!=null)//si existe
            {
                C.Nom_Client = Nom;
                C.Prenom_Client = Prenom;
                C.Adresse_Client = Adresse;
                C.Email_Client = Email;
                C.Telephone_Client = Telephone;
                C.Pays_Client = Pays;
                C.Ville_Client = Ville;
                db.SaveChanges();//Sauvegarde dans la base de données
            }
        }
        public void Supprimer_Client(int id)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id);
            if (C != null)
            {
                db.Clients.Remove(C);
                db.SaveChanges();
            }
        }


    }
}
