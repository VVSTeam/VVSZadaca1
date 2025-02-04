﻿using System;
using System.Collections.Generic;

namespace VVSZadace
{
    public class Kandidat : Glasac
    {
        private Stranka stranka;
        private List<Glasac> glasaci;
        private int brojGlasova;
        Boolean mandat = false;
        //Zejneb Kost
        private String historijaStranaka = "";

        //po defaultu se kreira nezavisni kandidat u kojem je stranka null
        public Kandidat(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, string jmbg) : base(ime, prezime, adresa, datumRodjenja, brojLicneKarte, jmbg)
        {
            this.glasaci = new List<Glasac>();
            brojGlasova = 0;
        }

        //osoba postaje kandidat kada se kreira instanca kandidat, budi član neke stranke koristeći ovu metodu.
        public void pridruziStranci(Stranka stranka)
        {
            this.stranka = stranka;
            //Zejneb Kost
            if (historijaStranaka == "") historijaStranaka = "Kandidat je bio član stranke " + stranka.getPuniNaziv() + " od " + DateTime.Now.ToString("d/M/yyyy");
            else historijaStranaka += " do " + DateTime.Now.ToString("d/M/yyyy") + ", član stranke " + stranka.getPuniNaziv() + "od " + DateTime.Now.ToString("d/M/yyyy");
        }

        public void ispisiHistorijuStranaka()
        {
            Console.WriteLine(historijaStranaka);
        }


        public void dodajGlas(Glasac glasac)
        {
            glasaci.Add(glasac);
            brojGlasova++;
        }
        public void ukloniGlas(Glasac glasac)
        {
            glasaci.Remove(glasac);
            brojGlasova--;
        }

        public int getBrojGlasova()
        {
            return brojGlasova;
        }

        public Stranka getStranka()
        {
            return stranka;
        }

        public Boolean getMandat()
        {
            return mandat;
        }

        public Boolean provjeraMandata()
        {
            if (this.getBrojGlasova() >= 0.2 * this.getStranka().getBrojGlasova())
            {
                mandat = true;
            }
            return mandat;
        }
        public override string ToString()
        {
            return getIme() + " " + getPrezime();
        }

        public List<Glasac> getGlasaci()
        {
            return glasaci;
        }

        //Zejneb Kost
        public String getHistorijaStranaka()
        {
            return historijaStranaka;
        }
    }
}
