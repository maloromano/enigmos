﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;
namespace Cpln.Enigmos.Enigmas

{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        //Déclarations des variables
        Label Reponse = new Label();
        Label lblEnigme = new Label();
        Timer tChrono = new Timer();
        private Button[] btnReponse = new Button[5];
        private PictureBox pbxReponse;
        // Classe non-reconnue, trouver la raison
        //List<Singe> singe = new List<Singe>();

        public SingesEnigmaPanel()
        {
            //Initialisation des singes
            //Singe pbxSinge = new Singe();

            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;
            Controls.Add(lblEnigme);
            //Image de base.
            BackgroundImage = Properties.Resources.jungle;
            Size = Properties.Resources.jungle.Size;

            //Placement des PictureBox (A Modifier pour faire correspondre avec la liste de singe créer dans la classe Singe)
            /*PbxSinge.Location = new Point(200, 500);
            PbxSinge.Location = new Point(600, 500);
            PbxSinge.Location = new Point(1000, 500);*/

            //Création des boutons
            Button bouton = new Button();
            bouton.Size = new Size(50, 80);
            bouton.Click += new EventHandler(bouton_Click);
            for (int i = 0; i < 5; i++)
            {
                Controls.Remove(btnReponse[i]);
                btnReponse[i] = new Button();
            }
            //Placement des boutons
            btnReponse[0].Location = new Point(450, 800);
            btnReponse[1].Location = new Point(600, 850);
            btnReponse[2].Location = new Point(750, 800);
            btnReponse[3].Location = new Point(900, 850);
            btnReponse[4].Location = new Point(1050, 800);

            //Attribution d'une taille pour les boutons
            for (int i = 0; i < 5; i++)
            {
                btnReponse[i].Width = 50;
                btnReponse[i].Height = 30;
                //btnReponse[i].Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }
            //Réponse à l'énigme
            //Si l'état des trois singes est à vrai
            {
                pbxReponse = new PictureBox();
                pbxReponse.Image = Properties.Resources.BananesWTF;
                pbxReponse.Size = Properties.Resources.BananesWTF.Size;
                pbxReponse.Location = new Point(500, 100);
                pbxReponse.BackColor = Color.Transparent;
                Controls.Add(pbxReponse);
            }
        }
        //Evènement sur le clic sur un bouton.
        private void bouton_Click(object sender, EventArgs e)
        {
            //Créer une méthode permettant "d'orienter" chaque bouton vers la bonne action.
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            //Comment différencier les singes ? 
            //Vérifie l'Etat du singe, si il est à vrai, le sige s'anime, si il est à faux le singe s'arrête.s
            /*if( singeX.bEtat == true)
             {
                Altèrne les deux images toutes les demi-secondes en fonction de BEtatCymbales.
                Si bEtatCymbales vaut TRUE l'image affiché est le singe avec les cymbales ouvertes.
                Si BEtatCymbales vaut FALSE c'est l'image du singe avec les cymbales fermées qui est affiché.
                *********************************************************************************************
                (if bEtatCymbales == true)
                pbxSinge.Image = Properties.Resources.SingeBleuCymbalesOuvertes;
                bEtatCymbales = false;
                else
                {
                    pbxSinge.Image = Properties.Resources.SingeBleuCymbalesFermees;
                }
             }
                if( singeX.bEtat == false)
                 {
                     pbxSinge.Image = Properties.Resources.SingeBleuCymbalesFermees;
                     bEtatCymbales = true;
                 }
             */
        }

        /// <summary>
        /// Initialise le timer, créer une intervalle d'une demi-seconde, et le démarre
        /// </summary>
        public override void Load()
        {
            tChrono.Tick += new EventHandler(TimerEventProcessor);
            tChrono.Interval = 500;
            tChrono.Start();
        }
         public override void Unload()
       {
          tChrono.Stop();
       }
    }
}

