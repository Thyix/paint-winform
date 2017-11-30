﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TP6_Programmation_III
{
    [Serializable]
    public class Dessin
    {

        #region Variables
        private string m_NomDessin;
        private DateTime m_MomentCreation;
        private double m_Cost;
        public List<Point> m_Coords;
        public Color m_Couleur;
        private float m_Largeur;
#endregion

        #region Properties
        public string Nom
        {
            get
            {
                return m_NomDessin;
            }
            set
            {
                m_NomDessin = value;
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return m_MomentCreation;
            }
            set
            {
                m_MomentCreation = value;
            }
        }

        public double Cost
        {
            get
            {
                return m_Cost;
            }
            set
            {
                m_Cost = value;
            }
        }

        public List<Point> Coords
        {
            get
            {
                return m_Coords;
            }
            set
            {
                m_Coords = value;
            }
        }


        public Color Couleurs
        {
            get { return m_Couleur; }
            set
            {
                m_Couleur = value;
            }
        }

        public float Largeur
        {
            get { return m_Largeur; }
            set
            {
                m_Largeur = value;
            }
        }
#endregion

        public Dessin(string name, DateTime dateCreation, double cout)
        {
            Nom = name;
            DateCreation = dateCreation;
            Cost = cout;
            Coords = new List<Point>();
            Couleurs = Color.Black;
        }

        public bool AjouterPoint(Point pt)
        {
            this.Coords.Add(pt);
            return true;
        }

        public void Dessiner(Graphics g)
        {
            Brush b = new SolidBrush(this.m_Couleur);
            Pen p = new Pen(b);
            if (this.Coords.Count > 0)
            {
                g.DrawEllipse(p, this.Coords.Last().X, this.Coords.Last().Y, 6, 6);
            }
        }

        Point TrouverCoinGH()
        {
            Point p = new Point();
            return p;
        }

        int Supprimer(Rectangle Rect)
        {
            return 0;
        }

        void Serialize()
        {
            Dessin ToSer = new Dessin(Nom, DateCreation, Cost);
            ToSer.Coords = Coords;
            IFormatter formatter = new BinaryFormatter();
            string Path = string.Format("{0}.don", ToSer.Nom);
            Stream stream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);

        }
    }
}
