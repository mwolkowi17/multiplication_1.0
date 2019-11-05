using System;
using System.Linq;

namespace mnozenie
{
    class Program
    {
        static void Main(string[] args)

        {
            using (var db = new WynikiA())
            {
                
                Console.WriteLine("Cześć Franek! Jak tam? Oto twoje przykłady na dziś. Zaczynamy?");
                Console.ReadLine();
                Console.WriteLine("Ale najpierw mama albo tata zdecydują ile tych przykładów będzie.");
                Console.Write("Podaj liczbę przykładów:");
                string choice_a = Console.ReadLine();
                int number_a=Convert.ToInt32(choice_a);
               
                //Console.Write("Podaj jeszcze dzisiejszą datę w dowolnym formacie:");
                var data_dzis = DateTime.Now;
                int dobre_odpowiedzi = 0;
                for (int n = 0; n < number_a; n++)
                {
                    var rand = new Random();
                    int a = rand.Next(2,10);
                    int b = rand.Next(2,10);
                    Console.Write(a + "*" + b + "=");
                    string odpowiedz = Console.ReadLine();
                    int odpowiedz_int = Convert.ToInt32(odpowiedz);

                    int result = a * b;

                    if (odpowiedz_int == result)
                    {
                        Colorgreen();
                        Console.WriteLine("Brawo! Prawidłowa odpowiedź");
                        dobre_odpowiedzi++;
                        Colorgrey();
                    }
                    else
                    {
                        Colorred();
                        Console.WriteLine("Przykro mi ale to zły wynik. Prawidłowa odpowiedź to:" + result);
                        Colorgrey();
                    }

                }

                Console.WriteLine("OK. Czas na podsumowanie.....");
                Console.WriteLine("Udało ci się rozwiązać prawidłowo " + dobre_odpowiedzi + " przykładów na " + number_a + ".");
                string ocena_a = "";
                if (number_a - dobre_odpowiedzi == 0)
                {
                    Console.WriteLine("Moja proponowana ocena to 6. Gratulacje!!!");
                    ocena_a = "6";

                }

                if (number_a - dobre_odpowiedzi >= 2 && number_a - dobre_odpowiedzi < 4)
                {
                    Console.WriteLine("Całkiem nieźle. Moja proponowana ocena to 5. Gratulacje");
                    ocena_a = "5";
                }
                if (number_a - dobre_odpowiedzi >= 4 && number_a - dobre_odpowiedzi < 6)
                {
                    Console.WriteLine("Przyzwoicie. Moja proponowana ocena to 4.");
                    ocena_a = "4";
                }
                if (number_a - dobre_odpowiedzi >= 6 && number_a - dobre_odpowiedzi < 8)
                {
                    Console.WriteLine("Jesteś z siebie zadowolony? Moja propownowana ocena to 3");
                    ocena_a = "3";
                }
                if (number_a - dobre_odpowiedzi >= 8 && number_a - dobre_odpowiedzi < 6)
                {
                    Console.WriteLine("Wygląda na to, że musisz jeszcze poćwieczyć. Moja proponowan ocena to 2.");
                    ocena_a = "2";
                }
                if (number_a - dobre_odpowiedzi >= 10)
                {
                    Colorred();
                    Console.WriteLine("Pozwolisz, że powstrzymam sie od komentarza i oceny.");
                    Colorgreen();
                    ocena_a = "0";
                    
                }
                db.Wyniki.Add(
                    new Grade

                    {
                        GradeValue = Convert.ToString(dobre_odpowiedzi),
                        Numberofex = choice_a,
                        Date = data_dzis.ToString(),
                        Ocena= ocena_a
                    }
                    );
                db.SaveChanges();
                Console.WriteLine("podsum?");
                string podsumowanie=Console.ReadLine();
                if (podsumowanie == "podsum")
                {
                    var efekty = db.Wyniki.ToList();
                    Console.WriteLine($"|{"Data",-25}|{"Ocena",30}|");
                    foreach(var n in efekty)
                    {
                        Colorgreen();
                        Console.WriteLine("==========================================================");
                        /*Console.WriteLine("Data: "+n.Date);
                        Console.WriteLine("Ocena: " + n.Ocena);
                        Console.WriteLine("Rozwiązanych przekładów " + n.GradeValue + " na " + n.Numberofex);*/
                        Console.WriteLine($"|{n.Date,-25}|{n.Ocena,30}|");
                        
                        Colorgrey();
                    }
                }
                Console.ReadLine();
            }
            static void Colorgreen()
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            static void Colorgrey()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void Colorred()
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

    }
}
