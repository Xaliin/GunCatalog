using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Persistence
{
    public class GunData
    {
        public string Tipus { get; set; }
        public string Nev { get; set; }
        public string? Mukodes { get; set; }
        public string Loszer { get; set; }
        public string Tomeg { get; set; }
        public string Hossz { get; set; }
        public string? Csohossz { get; set; }
        public string Tarkapacitas { get; set; }
        public string? LovedekSebessege { get; set; }
        public string? Szarmazas { get; set; }
        public string? Tuzgyorsasag { get; set; }

        public GunData()
        {
                
        }

        public GunData(string tip, string nev, string muk, string losz, string tom, string hosz, string csoh, string tar, string lov, string szarm, string tuz)
        {
            Tipus = tip;
            Nev = nev;
            Mukodes = muk;
            Loszer = losz;
            Tomeg = tom;
            Hossz = hosz;
            Csohossz = csoh;
            Tarkapacitas = tar;
            LovedekSebessege = lov;
            Szarmazas = szarm;
            Tuzgyorsasag = tuz;
        }
    }
}
