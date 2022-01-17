using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Connexion : Form
    {
        private dbStockContext db;
        private Form formmenu;
        // La classe connexion
        BL.CLS_Connexion C = new BL.CLS_Connexion();
        public FRM_Connexion(Form Menu)
        {
            InitializeComponent();

            this.formmenu = Menu;
            //initialisation de la base de donnees
            db = new dbStockContext();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_Connexion_Load(object sender, EventArgs e)
        {

        }

        private void txtboxMotdePasse_TextChanged(object sender, EventArgs e)
        {
           
        }
        // Pour verifier les champs obligatoires
        string testobligatoire()
        {
            if(textBoxNom.Text==""||textBoxNom.Text== "Nom d'utilisateur")// si le nom d'utilisateur est vide ou contient la chaine de caractère "Nom d'utilisateur"
            {
                return "entrer votre nom";
            }
            if (txtboxMotdePasse.Text =="" || txtboxMotdePasse.Text =="Mot de passe")
            {
                return "Entrer le mot de passe";
            }
            // Si l'utilisateur a pu bien saisie son nom et son mot de passe 
            return null;
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            // Pour quitter le formualaire
            this.Close();
        }

        private void textBoxNom_Enter(object sender, EventArgs e)
        {
            //Pour vider le textBox
            if(textBoxNom.Text== "Nom d'utilisateur")
            {
                textBoxNom.Text = "";
                textBoxNom.ForeColor = Color.WhiteSmoke;//Changer la couleur du texte
            }
        }

        private void txtboxMotdePasse_Enter(object sender, EventArgs e)
        {
            //Pour vider le textBox
            if (txtboxMotdePasse.Text == "Mot de passe")
            {
                txtboxMotdePasse.Text = "";
                txtboxMotdePasse.UseSystemPasswordChar = false;
                txtboxMotdePasse.PasswordChar = '*';
                txtboxMotdePasse.ForeColor = Color.WhiteSmoke;//Changer la couleur du texte
            }
        }

        private void textBoxNom_Leave(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "")
            {
                textBoxNom.Text = "Nom d'utilisateur";
                textBoxNom.ForeColor = Color.Silver;
            }
        }

        private void txtboxMotdePasse_Leave(object sender, EventArgs e)
        {
            if (txtboxMotdePasse.Text == "")
            {
                txtboxMotdePasse.Text = "Mot de passe";
                txtboxMotdePasse.UseSystemPasswordChar = true;// par desactiver passwdchar
                txtboxMotdePasse.ForeColor = Color.Silver;
            }
        }
          
        private void button1_Click(object sender, EventArgs e)
        { 
            if(testobligatoire() == null)
            {
                if (C.ConnexionValider(db, textBoxNom.Text, txtboxMotdePasse.Text) == true)// si l'utilisateur existe
                {
                    MessageBox.Show("La connexion a réussi","Connexion",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    (formmenu as FRM_Menu).activerForm();
                    this.Close();//il faut quitter le formulaire de connexion
                }
                else// au cas l'utilisateur n'existe pas
                {
                    MessageBox.Show("La connexion a échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
