using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace GestionDeStock.PL
{
    public partial class FRM_ajouter_modifier_client : Form
    {
        private UserControl usclient;
        public FRM_ajouter_modifier_client(UserControl userC)
        {
            InitializeComponent();
            this.usclient = userC;
        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //les champs obligatoires
        string testObligatoire()
        {
            
            if(txtNom.Text==""||txtNom.Text=="Nom du client")
            {
                return ("Entrez le nom du client");
            }
            if (txtPrenom.Text == "" || txtPrenom.Text == "Prenom du client")
            {
                return ("Entrez le prenom du client");
            }
            if (txtAdresse.Text == "" || txtAdresse.Text == "Adresse client")
            {
                return ("Entrez l'adresse du client");
            }
            if (txtEmail.Text == "" || txtEmail.Text == "Email client")
            {
                
                return ("Entrez l'email du client");
            }
            if (txtVille.Text == "" || txtVille.Text == "Ville client")
            {
                return ("Entrez la ville du client");
            }
            if (txtTelephone.Text == "" || txtTelephone.Text == "Ville client")
            {
                return ("Entrez le numero de telephone du client");
            }
            //verification du mail
            if (txtEmail.Text != "" || txtEmail.Text != "Email client")
            {

                try
                {
                    new MailAddress(txtEmail.Text);//pour verifier si le mail est valide
                }
                catch(Exception e)
                {
                    return ("Email invalide");
                }
            }


            return null;
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if(txtNom.Text=="Nom du client")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            
            Close(); 
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom du client";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void txtPrenom_Enter(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "Prenom du client")
            {
                txtPrenom.Text = "";
                txtPrenom.ForeColor = Color.White;
            }
        }

        private void txtPrenom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtPrenom.Text = "Prenom du client";
                txtPrenom.ForeColor = Color.Silver;
            }
        }

        private void txtAdresse_Enter(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "Adresse client")
            {
                txtAdresse.Text = "";
                txtAdresse.ForeColor = Color.White;
            }
        }

        private void txtAdresse_Leave(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "")
            {
                txtAdresse.Text = "Adresse client";
                txtAdresse.ForeColor = Color.Silver;
            }
        }

        private void txtTelephone_Enter(object sender, EventArgs e)
        {
            if(txtTelephone.Text=="Telephone client")
            {
                txtTelephone.Text = "";
                txtTelephone.ForeColor = Color.White;
            }
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "Telephone client")
            {
                txtTelephone.Text = "Telephone client";
                txtTelephone.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if(txtEmail.Text=="Email client")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;

            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email client";
                txtEmail.ForeColor = Color.Silver;

            }
        }

        private void txtPays_Enter(object sender, EventArgs e)
        {
            if(txtPays.Text=="Pays client")
            {
                txtPays.Text = "";
                txtPays.ForeColor = Color.White;
            }
        }

        private void txtPays_Leave(object sender, EventArgs e)
        {
            if (txtPays.Text == "")
            {
                txtPays.Text = "Pays client";
                txtPays.ForeColor = Color.Silver;
            }
        }

        private void txtVille_Enter(object sender, EventArgs e)
        {
            if(txtVille.Text=="Ville client")
            {
                txtVille.Text = "";
                txtVille.ForeColor = Color.White;
            }
        }

        private void txtVille_Leave(object sender, EventArgs e)
        {
            if (txtVille.Text == "")
            {
                txtVille.Text = "Ville client";
                txtVille.ForeColor = Color.Silver;
            }
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null) {
                MessageBox.Show(testObligatoire(),"Obligatoire",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }else
            if(lblTitre.Text=="Ajouter Client")
            {
                BL.CLS_Client clclient = new BL.CLS_Client();
                if (clclient.Ajouter_Client(txtNom.Text, txtPrenom.Text, txtAdresse.Text, txtEmail.Text, txtTelephone.Text, txtPays.Text,txtVille.Text) == true)
                {
                    MessageBox.Show("Client ajouter avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usclient as USER_Liste_Client).ActualiserDatagrid();
                }
                else
                {
                    MessageBox.Show("Nom et penom dejà existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // le lblTitre=modifier client
            {

                BL.CLS_Client clclient = new BL.CLS_Client();
                DialogResult R = MessageBox.Show("Voulez vous vraiment modifier ce client","Modification",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    clclient.Modifier_Client(IdSELECT, txtNom.Text, txtPrenom.Text, txtAdresse.Text, txtEmail.Text, txtTelephone.Text, txtPays.Text, txtVille.Text);
                    //actualisation de la datagrid client
                    (usclient as USER_Liste_Client).ActualiserDatagrid();
                    MessageBox.Show("Client modifier avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }else
                {
                    MessageBox.Show("Client non modifier","modification",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
        }
        public int IdSELECT;

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtNom.Text = "Nom du client"; txtNom.ForeColor = Color.Silver;
            txtPrenom.Text = "Prenom du client"; txtPrenom.ForeColor = Color.Silver;
            txtAdresse.Text = "Adresse client";txtAdresse.ForeColor = Color.Silver;
            txtEmail.Text = "Email client"; txtEmail.ForeColor = Color.Silver;
            txtTelephone.Text = "Telephone client";txtTelephone.ForeColor = Color.Silver;
            txtPays.Text = "Pays client"; txtPays.ForeColor = Color.Silver;
            txtVille.Text = "Ville client"; txtVille.ForeColor = Color.Silver;
        }

        private void FRM_ajouter_modifier_client_Load(object sender, EventArgs e)
        {

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
