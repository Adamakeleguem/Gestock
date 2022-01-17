using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    class CLS_Connexion
    {
        //fonction pour verifier la connexion
        public bool ConnexionValider(dbStockContext db,string Nom,string Mot_De_Passe)
        {
            Utilisateur U = new Utilisateur();//table utilisateur
            U.NomUtilisateur = Nom;
            U.Mot_De_Passe = Mot_De_Passe;
            if (db.Utilisateurs.SingleOrDefault(s => s.NomUtilisateur == Nom && s.Mot_De_Passe == Mot_De_Passe)!=null)//si le nom et le mot de passe existe dans la base de donnees
            {
                return true;
            }
            else// au cas ou y a pas de correspondance
            {
                return false;
            }
        }
    }
}
 