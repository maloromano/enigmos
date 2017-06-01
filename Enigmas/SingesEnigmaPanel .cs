﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;
using System.Collections.Generic;

namespace Cpln.Enigmos.Enigmas

{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        //Déclarations des variables
        Label Reponse = new Label();
        Label lblEnigme = new Label();
        Timer tChrono = new Timer();
        private Button[] btnReponse = new Button[6];
        private List<PictureBox> Tpbx = new List<PictureBox>();
        List<Singe> Tsinge = new List<Singe>();
        

        public SingesEnigmaPanel()
        {
            //Initialisation des singes + placement
            Tsinge.Add(new Singe(200));
            Tsinge.Add(new Singe(600));
            Tsinge.Add(new Singe(1000));

            //PictureBox
            foreach (Singe S in Tsinge)
            {
                Controls.Add(S);
            }

            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;
            Controls.Add(lblEnigme);
            //Image de base.
            BackgroundImage = Properties.Resources.jungle;
            Size = Properties.Resources.jungle.Size;

            //Création des boutons
            Button bouton = new Button();
            bouton.Size = new Size(50, 80);
            //bouton.Click += new EventHandler(bouton_Click);
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
            btnReponse[5].Location = new Point(750, 900);

            //Attribution d'une taille pour les boutons
            for (int i = 0; i < 6; i++)
            {
                btnReponse[i].Width = 50;
                btnReponse[i].Height = 30;
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }

            /*Réponse de l'énigme            
            if(Singe1.BEtat == true && Singe2.BEtat == true && Singe3.BEtat == true)*/
                
        }
        //Evènement sur le clic sur un bouton.


        private void TimerEventProcessor(object sender, EventArgs e)
        {
            if (Tsinge[0].bEtat)
            {
                Tsinge[0].Image = Properties.Resources.SingeBleuCymbalesOuvertes;
                Tsinge[0].bEtat = false;
            }
            else
            {
                Tsinge[0].Image = Properties.Resources.SingeBleuCymbalesFermees;
                Tsinge[0].bEtat = true;
            }
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

