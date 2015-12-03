﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;

namespace Cpln.Enigmos.Enigmas
{

    class ZombieInvasionEnigmaPanel : EnigmaPanel
    {
        //déclaration des variables
        bool bViseurRouge = true;
        int iTimer = 0;//variable qui permet de compter les ticks dans le Timer

        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();
        PictureBox pbxZombie = new PictureBox();

        //création d'un timer
        private Timer Timer = new Timer();

        //création d'une liste
        List<Zombie> zombies = new List<Zombie>();

        public ZombieInvasionEnigmaPanel()
        {
            

            //Modification des parametre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) - 100;

            //Création du batiment
            pbxBatiment.Size = Properties.Resources.Batiment.Size;
            pbxBatiment.Image = Properties.Resources.Batiment;
            pbxBatiment.Location = new Point(this.Width / 2 - pbxBatiment.Width / 2, this.Bottom - pbxBatiment.Height);

            //Mise en place d'un timer
            Timer.Interval = 100; // 10 millisecondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            //changement du curseur
            this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//de base on met le curseur en rouge

            //création d'un evenement de click
            MouseClick += new MouseEventHandler(PanelClick);

            //ajout de l'image
            Controls.Add(pbxCible);
            Controls.Add(pbxBatiment);
        }

        //evenements
        private void PanelClick(object sender, MouseEventArgs e)//quand on click sur le panel
        {
            this.Cursor = new Cursor(Properties.Resources.CibleNoir.GetHicon());//changement de l'image du curseur
            bViseurRouge = false;//on inverse la variable une fois que l'utilisateur à cliquer
            iTimer = 0;//on remet la varaible à zero
        }
 
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (iTimer % 100 == 0)
            {
                AjouterZombie();
            }

            iTimer++;//incrementation de la variable de timer

            if(!bViseurRouge && iTimer > 2)//si le curseur n'est pas en rouge et que 10 seconde ce sont écoulées
            {
                this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//changement de l'image du curseur
            }

            foreach (Zombie zombie in zombies)
            {
                zombie.AvancerGauche();
            }
        }

        private void AjouterZombie()
        {
            Zombie zombie = new Zombie(this);
            Controls.Add(zombie);
            zombies.Add(zombie);

        }
    }
}
