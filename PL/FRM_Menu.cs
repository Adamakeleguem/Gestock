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
    public partial class FRM_Menu : Form
    {
        public FRM_Menu()
        {
            InitializeComponent();
            panel1.Size = new Size(229,612);
            pnlParametre.Visible = false;
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            
        }*/

        private void FRM_Menu_Load(object sender, EventArgs e)
        {
            desactiverForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //Desactiver le formulaire
        public void desactiverForm()
        {
            btnClient.Enabled = false;
            btnProduit.Enabled = false;
            btnCategories.Enabled = false;
            btnCommande.Enabled = false;
            btnUtilisateur.Enabled = false;
            //activer le bouton de connexion
            btnconnecter.Enabled = true;

            btncopie.Enabled = false;
            btnrestaurer.Enabled = false;
            btndeconnecter.Enabled = false;
            pnlBut.Enabled = false;

        }
        //activer le formulaire
        public void activerForm()
        {
            btnClient.Enabled = true;
            btnProduit.Enabled = true;
            btnCategories.Enabled = true;
            btnCommande.Enabled = true;
            btnUtilisateur.Enabled = true;
            //desactiver le bouton de connexion
            btnconnecter.Enabled = false;
            btncopie.Enabled = true;
            btnrestaurer.Enabled = true;
            btndeconnecter.Enabled = true;
            pnlBut.Enabled = true;
            pnlParametre.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(panel1.Width==229){
                panel1.Size=new Size(70,612);
            }
            else
            {
                panel1.Size = new Size(229,612);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnProduit.Top;
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnClient.Top;
            if (!pnlfichier.Controls.Contains(USER_Liste_Client.Instance))
            {
                pnlfichier.Controls.Add(USER_Liste_Client.Instance);
                USER_Liste_Client.Instance.Dock = DockStyle.Fill;
                USER_Liste_Client.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Client.Instance.BringToFront();
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnCategories.Top;
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnCommande.Top;
        }

        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnUtilisateur.Top;
        }

        private void btnParametter_Click(object sender, EventArgs e)
        {
            pnlParametre.Size = new Size(284, 175);
            pnlParametre.Visible = !pnlParametre.Visible;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //afficher le formulaire
            FRM_Connexion frmC = new FRM_Connexion(this);// this est le FRM_Menu
            frmC.ShowDialog();
        }

        private void btndeconnecter_Click(object sender, EventArgs e)
        {
            desactiverForm();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
