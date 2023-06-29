using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
        internal class Klasa
        {
            public string Id { get; set; }
            public Uczen[] Uczniowie { get; set; }
            public int Liczba_uczniow { get; set; }

            private const string _cross = "├─";
            private const string _end = "└─";
            private const string _line = "│";

            public Klasa(string id)
            {
                Id = id;
                Uczniowie = new Uczen[6];
                Liczba_uczniow = Uczniowie.Length;
            }

            //Obliczanie średniej inteligencji klasy
            public int Licz_srednia_int()
            {
                int suma = 0;
                foreach (var Uczen in Uczniowie)
                {
                    suma += Uczen.Inteligencja;
                }
                int srednia = suma / Liczba_uczniow;

                return srednia;
            }

            //Obliczanie średniej siły klasy
            public int Licz_srednia_sila()
            {
                int suma = 0;
                foreach (var Uczen in Uczniowie)
                {
                    suma += Uczen.Sila;
                }
                int srednia = suma / Liczba_uczniow;

                return srednia;
            }

            //Oblicznie % chłopów w klasie 
            public int Licz_procent_chlopow()
            {
                int suma = 0;
                foreach (var Uczen in Uczniowie)
                {
                    if (Uczen.Plec == "m") { suma++; }
                }
                int procent = (suma * 100 / Liczba_uczniow);

                return procent;
            }
        }
 }

