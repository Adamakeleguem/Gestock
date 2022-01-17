using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class USER_Liste_Client : UserControl
    {
        private static USER_Liste_Client Userclient;
        private dbStockContext db;
        // creation d'une instance de usercontrole
        public static USER_Liste_Client Instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new USER_Liste_Client();
                }
                return Userclient;
            }
        }
        public USER_Liste_Client()
        {
            InitializeComponent();
            db = new dbStockContext();
            // desactivation du textbox de recherche
            textrecherche.Enabled = false;
        }

        private void USER_Liste_Client_Load(object sender, EventArgs e)
        {
            // exeple d'ajout de client sans communication avec la base de données
            ActualiserDatagrid();
           
        }
        public void ActualiserDatagrid()
        {
            db = new dbStockContext();
            dvgclient.Rows.Clear();// Pour vider la data grid client
            foreach(var s in db.Clients){
                //ajouter des données dans la datagrid
                dvgclient.Rows.Add(false, s.ID_Client,s.Nom_Client,s.Prenom_Client,s.Adresse_Client, s.Email_Client, s.Telephone_Client, s.Pays_Client, s.Ville_Client);
            }
        }
        //verification du nombre de ligne selectionner pour la suppression
        public string SelectVerif()
        {
            int NombreLigneSelect = 0;
            for(int i = 0; i < dvgclient.Rows.Count; i++)
            {
                //verification sur la selection de la liste
                if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                {
                    NombreLigneSelect++;
                }
            }
            if (NombreLigneSelect == 0)
            {
                return "Selectionnez le client que vous voulez modifier";
            }
            if (NombreLigneSelect > 1)
            {
                return "Selectionnez seulement 1 seul client";
            }
            return null;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textrecherche.Text == "Recherche")
            {
                textrecherche.Text = "";
                textrecherche.ForeColor = Color.Black;
            }
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            // afficher le formulaire d ajout de clients
            PL.FRM_ajouter_modifier_client frmclient= new FRM_ajouter_modifier_client(this);
            frmclient.ShowDialog();
        }
        //public int IDselect;
        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            PL.FRM_ajouter_modifier_client frmclient = new FRM_ajouter_modifier_client(this);
            if (SelectVerif() == null)
            {
                //si le chekbox est vraie afficher les informations
                for(int i=0; i < dvgclient.Rows.Count; i++)
                {
                    if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                    {
                        frmclient.IdSELECT=(int)dvgclient.Rows[i].Cells[1].Value;
                        frmclient.txtNom.Text = dvgclient.Rows[i].Cells[2].Value.ToString();
                        frmclient.txtPrenom.Text = dvgclient.Rows[i].Cells[3].Value.ToString();
                        frmclient.txtAdresse.Text= dvgclient.Rows[i].Cells[4].Value.ToString();
                        frmclient.txtEmail.Text = dvgclient.Rows[i].Cells[5].Value.ToString();
                        frmclient.txtTelephone.Text = dvgclient.Rows[i].Cells[6].Value.ToString();
                        frmclient.txtVille.Text = dvgclient.Rows[i].Cells[8].Value.ToString();
                        frmclient.txtPays.Text = dvgclient.Rows[i].Cells[7].Value.ToString();
                    }
                }
                frmclient.lblTitre.Text = "Modifier client";
                frmclient.btnActualiser.Visible = false;
                frmclient.ShowDialog();
            }
            else
            {
                MessageBox.Show(SelectVerif(), "Modification",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dvgclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSupprimerClient_Click(object sender, EventArgs e)
        {
            BL.CLS_Client clclient = new BL.CLS_Client();
            int select = 0;
            for(int i = 0; i < dvgclient.Rows.Count; i++)
            {
                if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                {
                    select++;
                }
            }
            if (select == 0)
            {
                MessageBox.Show("Aucune selection","Suppression",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DialogResult R= MessageBox.Show("Voulez vous vraiment supprimer la selection", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dvgclient.Rows.Count; i++)
                    {
                        if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                        {
                            clclient.Supprimer_Client(int.Parse(dvgclient.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    ActualiserDatagrid();
                    MessageBox.Show("Client supprimer avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression Annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comborecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            // activation de la textbox lorsque je choisi un champ de recherche
            textrecherche.Enabled = true;
            //vider le textbox de recherche
            textrecherche.Text = "";

        }

        private void textrecherche_TextChanged(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var listerecherche = db.Clients.ToList();
            if (textrecherche.Text != "")
            {
                switch (comborecherche.Text)
                {
                    case "Nom":
                        listerecherche = listerecherche.Where(s => s.Nom_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Prenom":
                        listerecherche = listerecherche.Where(s => s.Prenom_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Ville":
                        listerecherche = listerecherche.Where(s => s.Ville_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Email":
                        listerecherche = listerecherche.Where(s => s.Email_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Telephone":
                        listerecherche = listerecherche.Where(s => s.Telephone_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Pays":
                        listerecherche = listerecherche.Where(s => s.Pays_Client.IndexOf(textrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                }
                
            }//vider la datagrid
            dvgclient.Rows.Clear();
            //ajouter la recherche dans la datagridview client
            foreach (var l in listerecherche)
            {
                dvgclient.Rows.Add(false, l.ID_Client, l.Nom_Client, l.Prenom_Client, l.Adresse_Client, l.Email_Client, l.Telephone_Client, l.Pays_Client, l.Ville_Client);
            }

        }
    }
}
