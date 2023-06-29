using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
        internal class Uczen
        {
            public string Id { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Plec { get; set; }
            public int Inteligencja { get; set; }
            public int Sila { get; set; }

            public Uczen(string imie, string nazwisko, string plec, int inteligencja, int sila)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                Plec = plec;
                Inteligencja = inteligencja;
                Sila = sila;
            }
        }
    }
