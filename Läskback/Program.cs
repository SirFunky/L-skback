using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Läskback
{
    class Dryckbacken // Skapar klassen dryckback och sätter antalet till 0 från början.
    {
        public Dryck[] drycker = new Dryck[25];
        public int antalDrycker = 0;
    }
    class Dryck //skapar klassen dryck med en get set för att få tag på den från andra klasser utan att ändra till public
    {
        string namn;
        int pris;
        string typ;
        public Dryck (string namn, int pris, string typ)
        {
            this.namn = namn;
            this.pris = pris;
            this.typ = typ;
        }
        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }
        public int Pris
        {
            get { return pris; }
            set { pris = value; }
        }
        public string Typ
        {
            get { return typ; }
            set { typ = value; }
        }
    }
    class Program
    {
        static Dryckbacken dryckbacken;// sätter dryckbacken så att samtliga metoder kan få tag på den via denna
        static List<Dryck> minDryckLista = new List<Dryck>();// sätter minDryckLista så att samtliga metoder kan få tag på denna
        static int LinearSearch(List<Dryck> list, string str)//metod för att söka igenom läsk listan på namn pris och typ
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Namn == str || list[i].Pris.ToString() == str || list[i].Typ == str)
                    return i;
            }
            return -1;
        }

        static Dryck SearchDrinck()//metod som skriver ut namn, pris osv samt säger om den inte kunde hitta läsken
        {


            Console.WriteLine("Skriv namn, pris eller typ att söka efter:");
            string str = Console.ReadLine();
             
            int index = LinearSearch(minDryckLista, str);

            if (index == -1)
            {
                Console.WriteLine("Kunde inte hitta läsken.");
                return null;
            }
            else
                Console.WriteLine("Här har du" + " " + minDryckLista[index].Namn + " " + minDryckLista[index].Pris + "kr" + " " + minDryckLista[index].Typ);

            return minDryckLista[index];
        }

        static void Stoppai(Dryck drycken) //Här har jag metoden som jag använder för att stoppa i läsken i läskbacken via sökningen
        {
            Console.WriteLine("Vill du stoppa läsken i läskbacken? Yes/No");
            string svar = Console.ReadLine();
            if (svar.Contains("Yes"))
            {
                dryckbacken.drycker[dryckbacken.antalDrycker] = drycken;
                if (dryckbacken.antalDrycker < 25 - 1)
                    dryckbacken.antalDrycker++;
                else
                    Console.WriteLine("Backen är full nu");
            }
        }

        static void Sortera() // Metod som sorterar läskbacken via en buble sort
        {
            int max = dryckbacken.antalDrycker - 1;
            for (int i = 0; i < max; i++)
            {
                Dryck temp;
                int nrLeft = max - i;
                for (int j = 0; j <nrLeft; j++)
                {
                    if (dryckbacken.drycker[j].Pris > dryckbacken.drycker[j+1].Pris)
                    {
                        temp = dryckbacken.drycker[j];
                        dryckbacken.drycker[j] = dryckbacken.drycker[j + 1];
                        dryckbacken.drycker[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < dryckbacken.antalDrycker; i++)
                Console.WriteLine(dryckbacken.drycker[i].Namn);
        }

        static void SkapaBack() //Lätt sätt att börja lägga in ny läsk utan att behöva söka upp varje individuel.
        {
            int Dryckmeny = 0;
            Console.WriteLine("Meny: Lägg till Dryck");
            Console.WriteLine("Lägg till dryck genom att ange siffran för drycken");
            Console.WriteLine("Tryck på 0 för att återgå till förregående meny");
            Console.WriteLine("");


            Console.WriteLine("Sortiment av drycker");
            Console.WriteLine("1. Coca-Cola");
            Console.WriteLine("2. Loka");
            Console.WriteLine("3. Opigårds");
            Console.WriteLine("4. Cola light");
            Console.WriteLine("5. Spendrups Lättöl");
            bool meny = false;

            do
            {

                Dryckmeny = int.Parse(Console.ReadLine());

                if (dryckbacken.antalDrycker == 25)//Kollar om backen är full annars går den vidare så du får börja välja.
                {
                    Console.WriteLine("Din back är nu full!");
                    break;
                }
                    switch (Dryckmeny)
                    {
                        case 1:
                            Console.WriteLine("Coca Cola");
                            dryckbacken.drycker[dryckbacken.antalDrycker] = minDryckLista[Dryckmeny -1];
                            dryckbacken.antalDrycker++;
                            break;
                        case 2:
                            Console.WriteLine("Loka");
                            dryckbacken.drycker[dryckbacken.antalDrycker] = minDryckLista[Dryckmeny -1];
                            dryckbacken.antalDrycker++;
                            break;
                        case 3:
                            Console.WriteLine("Opigårds");
                            dryckbacken.drycker[dryckbacken.antalDrycker] = minDryckLista[Dryckmeny -1];
                            dryckbacken.antalDrycker++;
                            break;
                        case 4:
                            Console.WriteLine("Cola light");
                            dryckbacken.drycker[dryckbacken.antalDrycker] = minDryckLista[Dryckmeny -1];
                            dryckbacken.antalDrycker++;
                            break;
                        case 5:
                            Console.WriteLine("Spendrups Lättöl");
                            dryckbacken.drycker[dryckbacken.antalDrycker] = minDryckLista[Dryckmeny -1];
                            dryckbacken.antalDrycker++;
                            break;
                        default:
                            Console.WriteLine("Ange siffra 1-5 för dryck, ange siffra 0 för  att återgå till Huvudmenyn");
                            meny = true;
                            break;
                }

            }
            while (Dryckmeny != 0);
        }

        static void Main()// här har jag mina olika drycker och switch case huvudmenyn.
        {
            minDryckLista.Add(new Dryck("Cola", 15, "läsk"));
            minDryckLista.Add(new Dryck("Loka", 12, "vatten"));
            minDryckLista.Add(new Dryck("Opigårds", 25, "cider"));
            minDryckLista.Add(new Dryck("Cola light", 15, "läsk"));
            minDryckLista.Add(new Dryck("Spendrups Lättöl", 23, "öl"));
            dryckbacken = new Dryckbacken();
            int menyval = 0;
            while (menyval !=6) 
            {
                Console.WriteLine("Meny");
                Console.WriteLine("(1)Skapa en egen läskback.");
                Console.WriteLine("(2)Skriv ut nuvarande läskback.");
                Console.WriteLine("(3)Sortera läskback.");
                Console.WriteLine("(4)Sök läsk.");
                Console.WriteLine("(5)Räkna ut pris.");
                Console.WriteLine("(6)Avsluta.");

                menyval = int.Parse(Console.ReadLine());

                switch (menyval)
                {
                    case 1:
                        SkapaBack();
                        break;

                    case 2:
                        foreach (var dryck in dryckbacken.drycker)
                        {
                            if (dryck != null) Console.WriteLine(dryck.Namn);
                            else Console.WriteLine("Tom plats");
                        }
                        break;

                    case 3:
                        Sortera();
                        break;

                    case 4:
                        Dryck drycken = SearchDrinck();
                        Stoppai(drycken);
                        break;

                    case 5:
                        int sum = 0;
                        for (int i = 0; i < dryckbacken.antalDrycker; i++)
                            sum = sum + dryckbacken.drycker[i].Pris;
                        Console.WriteLine("Total priset är " + sum);
                        break;

                    case 6:

                    default:
                        Console.WriteLine("Felaktigt val försök igen");
                        break;
                }
            }
        }
    }
}
