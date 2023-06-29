using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
        internal class Szkola
        {
            public string Id { get; set; }
            public Klasa[] Klasy { get; set; }
            public int Ilosc_klas { get; set; }
            public string Nazwa { get; set; }

            private const string _cross = "├─";
            private const string _end = "└─";
            private const string _line = "│";

            public Szkola(string id, int ilosc_klas, string nazwa)
            {
                Id = id;
                Klasy = new Klasa[ilosc_klas];
                Ilosc_klas = ilosc_klas;
                Nazwa = nazwa;
            }

            //Obliczanie średniej inteligencji szkoły
            public int Licz_srednia_int()
            {
                int suma = 0;
                foreach (var Klasa in Klasy)
                {
                    suma += Klasa.Licz_srednia_int();
                }
                int srednia = suma / Ilosc_klas;

                return srednia;
            }

            //Obliczanie średniej siły szkoły
            public int Licz_srednia_sila()
            {
                int suma = 0;
                foreach (var Klasa in Klasy)
                {
                    suma += Klasa.Licz_srednia_sila();
                }
                int srednia = suma / Ilosc_klas;

                return srednia;
            }

            //Nadawanie nr identyfikacyjnych uczniom
            public void Nadaj_id_uczniom()
            {
                for (int i = 0; i < Klasy.Length; i++)
                {
                if(Klasy[i] != null) { return; }
                    for (int j = 0; j < Klasy[i].Uczniowie.Length; j++)
                    {
                        Klasy[i].Uczniowie[j].Id = Id + Klasy[i].Id + (j + 1);
                    }
                }
            }

            //Wyświetla Strukturę szkoły i klas
            public void Wyswietl()
            {
                while (true)
                {
                    //Znaki poprzedzające linie
                    string znaki = "";

                    Console.WriteLine(Nazwa);

                    znaki += _line + " ";
                    for (int i = 1; i <= Ilosc_klas; i++)
                    {
                        //Wyświetla strukture klas
                        if (i != Ilosc_klas)
                        {
                            Console.WriteLine(_cross + Klasy[i - 1].Id);
                            for (int j = 1; j <= Klasy[i - 1].Liczba_uczniow; j++)
                            {
                                //Wyświetla uczniów
                                if (j != Klasy[i - 1].Liczba_uczniow)
                                {
                                    Console.Write(znaki + _cross + " ");
                                    Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Id);
                                }
                                //Wyświetla ostatniego ucznia
                                else
                                {
                                    Console.Write(znaki + _end + " ");
                                    Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Id);
                                }
                            }
                        }
                        //Wyświetla strukturę ostatniej klasy
                        else
                        {
                            Console.WriteLine(_end + Klasy[i - 1].Id);
                            for (int j = 1; j <= Klasy[i - 1].Liczba_uczniow; j++)
                            {
                                //Wyświetla uczniów ostatniej klasy
                                if (j != Klasy[i - 1].Liczba_uczniow)
                                {
                                    Console.Write("  " + _cross + " ");
                                    Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Id);
                                }
                                //Wyświetla ostatniego ucznia ostatniej klasy
                                else
                                {
                                    Console.Write("  " + _end + " ");
                                    Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Id);
                                }
                            }
                        }

                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    //Zwijanie listy
                    if (key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        Wyswietl_strukt_zwinieta();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (statystyki)
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Wyswietl_statystyki();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (instrukcja)
                    if (key == ConsoleKey.I)
                    {
                        Console.Clear();
                        Instrukcja();
                    }

                    //Wyłączanie aplikacji
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }

            //Wyświetla statystyki szkoły i klas
            public void Wyswietl_statystyki()
            {
                while (true)
                {
                    //Znaki poprzedzające linie
                    string znaki = "";

                    Console.WriteLine(Nazwa + "\t" + "\t" + "\t" + "\t" + "\t" + "Plec" + "\t" + "\t" + "Inteligencja" + "\t" + "Sila");

                    znaki += _line + " ";
                    for (int i = 1; i <= Ilosc_klas; i++)
                    {
                        //Wyświetla statystyki klas
                        if (i != Ilosc_klas)
                        {

                            Console.WriteLine(_cross + " " + "Liczba uczniow: " + Klasy[i - 1].Liczba_uczniow + "\t" + "\t" + "\t" + "\t" + "\t" + "Avg int: " + Klasy[i - 1].Licz_srednia_int() + "\t" + "Avg sila: " + Klasy[i - 1].Licz_srednia_sila() + "\t" + "% chlopow: " + Klasy[i - 1].Licz_procent_chlopow());
                            for (int j = 1; j <= Klasy[i - 1].Liczba_uczniow; j++)
                            {
                                //Wyświetla statystyki uczniów
                                if (j != Klasy[i - 1].Liczba_uczniow)
                                {
                                    Console.Write(znaki + " " + _cross + " ");
                                    //Dla nazwisk lub imion dłuższych niż 7 znaków
                                    if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 || Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                    {
                                        //imie i nazwisko: 1 tabulacja, 1 i reszta po 2
                                        if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 && Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko imie: 1 tabulacja i reszta po 2
                                        else if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko nazwisko: 2 tabulacje, 1 i reszta po 2
                                        else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                    }
                                    //Dla nazwisk i imion krótszych niż 7 znaków daje 2 tabulacje
                                    else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                }
                                //Wyświetla ostatniego ucznia w klasie
                                else
                                {
                                    Console.Write(znaki + " " + _end + " ");
                                    //Dla nazwisk lub imion dłuższych niż 7 znaków daje 2 tabulacje, później 1 i następnie po 2
                                    if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 || Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                    {
                                        //imie i nazwisko: 1 tabulacja, 1 i reszta po 2
                                        if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 && Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko imie: 1 tabulacja i reszta po 2
                                        else if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko nazwisko: 2 tabulacje, 1 i reszta po 2
                                        else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                    }
                                    //Dla nazwisk i imion krótszych niż 7 znaków daje 2 tabulacje
                                    else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                }
                            }
                        }
                        //Wyświetla ostatnią klasę
                        else
                        {
                            Console.WriteLine(_end + " " + "Liczba uczniow: " + Klasy[i - 1].Liczba_uczniow + "\t" + "\t" + "\t" + "\t" + "\t" + "Avg int: " + Klasy[i - 1].Licz_srednia_int() + "\t" + "Avg sila: " + Klasy[i - 1].Licz_srednia_sila() + "\t" + "% chlopow: " + Klasy[i - 1].Licz_procent_chlopow());
                            for (int j = 1; j <= Klasy[i - 1].Liczba_uczniow; j++)
                            {
                                //Wyświetla statystyki uczniów ostatniej klasy
                                if (j != Klasy[i - 1].Liczba_uczniow)
                                {
                                    Console.Write("  " + " " + _cross + " ");
                                    //Dla nazwisk lub imion dłuższych niż 7 znaków daje 2 tabulacje, później 1 i następnie po 2
                                    if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 || Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                    {
                                        //imie i nazwisko: 1 tabulacja, 1 i reszta po 2
                                        if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 && Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko imie: 1 tabulacja i reszta po 2
                                        else if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko nazwisko: 2 tabulacje, 1 i reszta po 2
                                        else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                    }
                                    //Dla nazwisk i imion krótszych niż 7 znaków daje 2 tabulacje
                                    else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                }
                                //Wyświetla ostatniego ucznia ostatniej klasy
                                else
                                {
                                    Console.Write("  " + " " + _end + " ");
                                    //Dla nazwisk lub imion dłuższych niż 7 znaków daje 2 tabulacje, później 1 i następnie po 2
                                    if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 || Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                    {
                                        //imie i nazwisko: 1 tabulacja, 1 i reszta po 2
                                        if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8 && Klasy[i - 1].Uczniowie[j - 1].Nazwisko.Length > 7)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko imie: 1 tabulacja i reszta po 2
                                        else if (Klasy[i - 1].Uczniowie[j - 1].Imie.Length > 8)
                                        { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                        //tylko nazwisko: 2 tabulacje, 1 i reszta po 2
                                        else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                    }
                                    //Dla nazwisk i imion krótszych niż 7 znaków daje 2 tabulacje
                                    else { Console.WriteLine(Klasy[i - 1].Uczniowie[j - 1].Imie + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Nazwisko + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Plec + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Inteligencja + "\t" + "\t" + Klasy[i - 1].Uczniowie[j - 1].Sila); }
                                }
                            }
                        }

                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    //Zwijanie listy
                    if (key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        Wyswietl_stat_zwiniete();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (struktura)
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Wyswietl();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (instrukcja)
                    if (key == ConsoleKey.I)
                    {
                        Console.Clear();
                        Instrukcja();
                    }

                    //Wyłączanie aplikacji
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }

            //Wyświetla zwiniętą listę struktury szkoły i klas
            public void Wyswietl_strukt_zwinieta()
            {
                while (true)
                {
                    //Znaki poprzedzające linie
                    string znaki = "";

                    Console.WriteLine(Nazwa);

                    znaki += _line + " ";
                    for (int i = 1; i <= Ilosc_klas; i++)
                    {
                        //Wyświetla klasy
                        if (i != Ilosc_klas) { Console.WriteLine(_cross + Klasy[i - 1].Id); }
                        //Wyświetla ostatnią klasę
                        else { Console.WriteLine(_end + Klasy[i - 1].Id); }
                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    //Rozwijanie listy
                    if (key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        Wyswietl();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (statystyki - zwinięta lista)
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Wyswietl_stat_zwiniete();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (instrukcja)
                    if (key == ConsoleKey.I)
                    {
                        Console.Clear();
                        Instrukcja();
                    }

                    //Wyłączanie aplikacji
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }

            //Wyświetla zwiniętą listę statystyk
            public void Wyswietl_stat_zwiniete()
            {
                while (true)
                {
                    //Znaki poprzedzające linie
                    string znaki = "";

                    Console.WriteLine(Nazwa);

                    znaki += _line + " ";
                    for (int i = 1; i <= Ilosc_klas; i++)
                    {
                        //Wyświetla statystyki klas
                        if (i != Ilosc_klas) { Console.WriteLine(_cross + " " + "Liczba uczniow: " + Klasy[i - 1].Liczba_uczniow + "\t" + "\t" + "\t" + "\t" + "\t" + "Avg int: " + Klasy[i - 1].Licz_srednia_int() + "\t" + "Avg sila: " + Klasy[i - 1].Licz_srednia_sila() + "\t" + "% chlopow: " + Klasy[i - 1].Licz_procent_chlopow()); }
                        //Wyświetla ostatnią klasę0
                        else { Console.WriteLine(_end + " " + "Liczba uczniow: " + Klasy[i - 1].Liczba_uczniow + "\t" + "\t" + "\t" + "\t" + "\t" + "Avg int: " + Klasy[i - 1].Licz_srednia_int() + "\t" + "Avg sila: " + Klasy[i - 1].Licz_srednia_sila() + "\t" + "% chlopow: " + Klasy[i - 1].Licz_procent_chlopow()); }
                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    //Zwijanie listy
                    if (key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        Wyswietl_statystyki();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (struktura - zwiniięta lista)
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Wyswietl_strukt_zwinieta();
                    }

                    //Przełączanie okna po wciśnięciu klawisza (instrukcja)
                    if (key == ConsoleKey.I)
                    {
                        Console.Clear();
                        Instrukcja();
                    }

                    //Wyłączanie aplikacji
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }

            //Wyświetla instrukcję
            public void Instrukcja()
            {
                while (true)
                {
                    //Instrukcja
                    Console.WriteLine("Instrukcja\n");
                    Console.WriteLine("z - zwin liste");
                    Console.WriteLine("s - przelacz okno (struktura szkoly/statystyki szkoly)");
                    Console.WriteLine("i - wlacz instrukcje");
                    Console.WriteLine("Esc - wylacz program");

                    ConsoleKey key = Console.ReadKey().Key;

                    //Przełączanie okna po wciśnięciu klawisza (struktura)
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Wyswietl();
                    }

                    //Wyłączanie aplikacji
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }
        }
}
