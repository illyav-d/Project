namespace Project
{
    internal class Program
    {

        private static int GegevensValidatieGetal(int invoer, int min, int max)
        {

            while (!int.TryParse(Console.ReadLine(), out invoer) || invoer < min || invoer > max)
            {
                Console.WriteLine("U gaf geen geldig invoer in. Voer een geheel getal in van " + min + " tot en met " + max + ".");
            }
            return invoer;
        }
        private static void StringValidatie(string invoer)
        {
            while (String.IsNullOrWhiteSpace(invoer))
            {
                Console.WriteLine("Vul dit veld in alsjeblieft.");
                invoer = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            //Ik was bang om de antwoorden in de menu's te hergebruiken 
            //in het geval dat ik iets zou breken, omdat ik nu een while (true) loop gebruik denk ik dat ik het antwoord mocht hergebruiken, maar ik wou op veilig spelen.
            Console.Title = "Vehicom";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DateTime dateTime = DateTime.Now;
            DateTime accountGeboorte;

            string[] arrAccountNaam;
            string[] arrAccountWachtwoord;
            string[] arrAccountGemeente;
            string[] arrAccountGeboorte;
            string[] arrVoertuigen = { "Fiets", "Kinderfiets", "Elektrische fiets" };
            double[] arrPrijsPerDag = { 5, 3, 25 };
            double[] arrPrijsPerWeek = { 5 * 7 * 0.85, 3 * 7 * 0.85, 25 * 7 * 0.85 };
            string accountNaam;
            string accountWachtwoord;
            string accountGemeente;
            string accountGeboorteString;
            string inhoudAccountNaam;
            string inhoudAccountWachtwoord;
            string inhoudAccountGemeente;
            string inhoudAccountGeboorte;
            string opslag;
            string loginNaam = "";
            string loginWachtwoord;
            int antwoordHoofdMenu = 0;
            int antwoordSubMenuEen = 0;
            int antwoordDeleteAccount = 0;
            int antwoordEditAccount = 0;
            int antwoordAankoopfietsen = 0;
            int antwoordSoortFiets = 0;
            int huurDagen = 0;
            double prijsTotaal = 0;
            bool login = false;

            arrAccountNaam = File.ReadAllLines(@"accountnaam.txt");
            arrAccountWachtwoord = File.ReadAllLines(@"wachtwoord.txt");

            //TODO: SPELLFOUTEN etc
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welkom bij het Vehicom login scherm!");
            while (!login)
            {

                Console.WriteLine("Geef je accountnaam in:");
                loginNaam = Console.ReadLine();
                Console.WriteLine("Geef je wachtwoord in:");
                loginWachtwoord = Console.ReadLine();

                for (int i = 0; i < arrAccountWachtwoord.Length; i++)
                {
                    if (loginNaam == arrAccountNaam[i] && loginWachtwoord == arrAccountWachtwoord[i])
                    {
                        login = true;
                    }

                }
                if (login == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("U bent succesvol ingelogd. Goeiedag " + loginNaam + ".");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uw naam of wachtwoord was niet correct. (Deze zijn hoofdletter gevoelig!)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welkom bij Vehicom, waar kunnen we u vandaag mee helpen?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. " + " Accountbeheer.");
                Console.WriteLine("2. " + " De prijzenlijst bekijken.");
                Console.WriteLine("3. " + " Ik wil een fiets huren.");
                Console.WriteLine("4. " + " De applicatie afsluiten.");
                switch (GegevensValidatieGetal(antwoordHoofdMenu, 1, 4))
                {
                    case 1:

                        Console.Clear();
                        arrAccountNaam = File.ReadAllLines(@"accountnaam.txt");
                        arrAccountWachtwoord = File.ReadAllLines(@"wachtwoord.txt");
                        arrAccountGemeente = File.ReadAllLines(@"gemeente.txt");
                        arrAccountGeboorte = File.ReadAllLines(@"geboorte.txt");
                        Console.WriteLine("Naam".PadLeft(20) + "Wachtwoord".PadLeft(20) + "Gemeente".PadLeft(20) + "Geboortedatum".PadLeft(20));
                        for (int i = 0; i < arrAccountNaam.Length; i++)
                        {

                            Console.WriteLine((i + 1).ToString() + "." + arrAccountNaam[i].ToString().PadLeft(18) + arrAccountWachtwoord[i].ToString().PadLeft(20)
                                + arrAccountGemeente[i].ToString().PadLeft(20) + arrAccountGeboorte[i].ToString().PadLeft(20));
                        }

                        Console.WriteLine();
                        Console.WriteLine("1. " + "Ik wil een account toevoegen.");
                        Console.WriteLine("2. " + "Ik wil accountgegevens wijzigen.");
                        Console.WriteLine("3. " + "Ik wil een account verwijderen.");
                        Console.WriteLine("4. " + "Terug naar menu");

                        switch (GegevensValidatieGetal(antwoordSubMenuEen, 1, 4))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Geef uw naam in:");
                                accountNaam = Console.ReadLine();
                                StringValidatie(accountNaam);
                                StreamReader lezer = new StreamReader(@"accountnaam.txt");
                                inhoudAccountNaam = lezer.ReadToEnd();
                                lezer.Close();
                                using (StreamWriter writer = new StreamWriter(@"accountnaam.txt"))
                                {
                                    writer.Write(inhoudAccountNaam + Environment.NewLine);
                                    writer.Write(accountNaam);
                                }
                                Console.WriteLine();

                                Console.WriteLine("Geef uw wachtwoord in:");
                                accountWachtwoord = Console.ReadLine();
                                StringValidatie(accountWachtwoord);
                                lezer = new StreamReader(@"wachtwoord.txt");
                                inhoudAccountWachtwoord = lezer.ReadToEnd();
                                lezer.Close();
                                using (StreamWriter writer = new StreamWriter(@"wachtwoord.txt"))
                                {
                                    writer.Write(inhoudAccountWachtwoord + Environment.NewLine);
                                    writer.Write(accountWachtwoord);
                                }
                                Console.WriteLine();

                                Console.WriteLine("Geef uw gemeente in:");
                                accountGemeente = Console.ReadLine();
                                StringValidatie(accountGemeente);
                                lezer = new StreamReader(@"gemeente.txt");
                                inhoudAccountGemeente = lezer.ReadToEnd();
                                lezer.Close();
                                using (StreamWriter writer = new StreamWriter(@"gemeente.txt"))
                                {
                                    writer.Write(inhoudAccountGemeente + Environment.NewLine);
                                    writer.Write(accountGemeente);
                                }
                                Console.WriteLine();

                                Console.WriteLine("Geef uw geboortedatum in:(gebruik dd/mm/yyyy of 27 Oktober 1994)");
                                while (!(DateTime.TryParse(Console.ReadLine(), out accountGeboorte))) { Console.WriteLine("U gaf geen geldige datum op."); }
                                accountGeboorteString = accountGeboorte.ToShortDateString();
                                lezer = new StreamReader(@"geboorte.txt");
                                inhoudAccountGeboorte = lezer.ReadToEnd();
                                lezer.Close();
                                using (StreamWriter writer = new StreamWriter(@"geboorte.txt"))
                                {
                                    writer.Write(inhoudAccountGeboorte + Environment.NewLine);
                                    writer.Write(accountGeboorteString);
                                }

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("U heeft succesvol uw account aangemaakt.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Druk op een toets om terug te gaan naar het menu.");
                                Console.ReadKey();

                                break; //Toevoegen
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Naam".PadLeft(20) + "Wachtwoord".PadLeft(20) + "Gemeente".PadLeft(20) + "Geboortedatum".PadLeft(20));
                                for (int i = 0; i < arrAccountNaam.Length; i++)
                                {
                                    Console.WriteLine((i + 1).ToString() + "." + arrAccountNaam[i].ToString().PadLeft(18) + arrAccountWachtwoord[i].ToString().PadLeft(20)
                                        + arrAccountGemeente[i].ToString().PadLeft(20) + arrAccountGeboorte[i].ToString().PadLeft(20)); ;
                                }
                                Console.WriteLine("Welk account wilt u bewerken?");
                                antwoordEditAccount = GegevensValidatieGetal(antwoordEditAccount, 1, arrAccountNaam.Length);
                                Console.Clear();

                                Console.WriteLine("Geef de nieuwe naam in.");
                                accountNaam = Console.ReadLine();
                                StringValidatie(accountNaam);
                                opslag = File.ReadAllText(@"accountnaam.txt");
                                opslag = opslag.Replace(arrAccountNaam[antwoordEditAccount - 1], accountNaam);
                                File.WriteAllText(@"accountnaam.txt", opslag);
                                Console.WriteLine();

                                Console.WriteLine("Geef uw nieuwe wachtwoord in.");
                                accountWachtwoord = Console.ReadLine();
                                StringValidatie(accountWachtwoord);
                                opslag = File.ReadAllText(@"wachtwoord.txt");
                                opslag = opslag.Replace(arrAccountWachtwoord[antwoordEditAccount - 1], accountWachtwoord);
                                File.WriteAllText(@"wachtwoord.txt", opslag);
                                Console.WriteLine();

                                Console.WriteLine("Geef uw nieuwe gemeente in.");
                                accountGemeente = Console.ReadLine();
                                StringValidatie(accountGemeente);
                                opslag = File.ReadAllText(@"gemeente.txt");
                                opslag = opslag.Replace(arrAccountGemeente[antwoordEditAccount - 1], accountGemeente);
                                File.WriteAllText(@"gemeente.txt", opslag);
                                Console.WriteLine();

                                Console.WriteLine("Geef uw geboortedatum in. (gebruik dd/mm/yyyy of 27 Oktober 1994)");
                                while (!(DateTime.TryParse(Console.ReadLine(), out accountGeboorte))) { Console.WriteLine("U gaf geen geldige datum op."); }
                                accountGeboorteString = accountGeboorte.ToShortDateString();
                                opslag = File.ReadAllText(@"geboorte.txt");
                                opslag = opslag.Replace(arrAccountGeboorte[antwoordEditAccount - 1], accountGeboorteString);
                                File.WriteAllText(@"geboorte.txt", opslag);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Uw wijzigingen zijn opgeslagen.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Druk op een toets om terug te gaan.");
                                Console.ReadKey();

                                break; //Wijzigen
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Naam".PadLeft(20) + "Wachtwoord".PadLeft(20) + "Gemeente".PadLeft(20) + "Geboortedatum".PadLeft(20));
                                for (int i = 0; i < arrAccountNaam.Length; i++)
                                {
                                    Console.WriteLine((i + 1).ToString() + "." + arrAccountNaam[i].ToString().PadLeft(18) + arrAccountWachtwoord[i].ToString().PadLeft(20)
                                        + arrAccountGemeente[i].ToString().PadLeft(20) + arrAccountGeboorte[i].ToString().PadLeft(20)); ;
                                }
                                Console.WriteLine("Welk account wilt u verwijderen?");
                                antwoordDeleteAccount = GegevensValidatieGetal(antwoordDeleteAccount, 1, arrAccountNaam.Length);
                                Console.ForegroundColor = ConsoleColor.Green;                                                                        // valideerd de input, minimum 1, maximum de lengte van de array
                                Console.WriteLine("Het account van " + arrAccountNaam[antwoordDeleteAccount - 1] + " werd succesvol verwijderd.");   // Bevestiging
                                arrAccountNaam[antwoordDeleteAccount - 1] = "";                                                                      // Zet de index leeg, maar verwijderd die niet
                                Console.ForegroundColor = ConsoleColor.White;
                                using (StreamWriter writer = new StreamWriter(@"accountnaam.txt"))                          // Array herschrijven naar tekst file? (probleem : gaat er geen lege array instaan)                                     
                                {
                                    string inhoud = "";
                                    for (int i = 0; i < arrAccountNaam.Length; i++)
                                    {
                                        string naam = arrAccountNaam[i];

                                        if (naam == "")                                                 // Als de index leeg is ga naar de volgende
                                        {
                                            continue;                                                   // Dit gaat terug naar lijn 223 en doe i++, we gaan verder met de loop.
                                        }
                                        if (inhoud == "")                                               // als inhoud leeg is wilt dit zeggen dat we op de eerste lijn zitten, dus geen witregel, anders voegen we een witregel toe en gaan naar de volgende lijn
                                        {
                                            inhoud += naam;
                                        }
                                        else
                                        {
                                            inhoud += Environment.NewLine + naam;
                                        }
                                    }
                                    writer.Write(inhoud);
                                }

                                arrAccountWachtwoord[antwoordDeleteAccount - 1] = "";
                                using (StreamWriter writer = new StreamWriter(@"wachtwoord.txt"))
                                {
                                    string inhoud = "";
                                    for (int i = 0; i < arrAccountWachtwoord.Length; i++)
                                    {
                                        string watchwoord = arrAccountWachtwoord[i];

                                        if (watchwoord == "")
                                        {
                                            continue;
                                        }
                                        if (inhoud == "")
                                        {
                                            inhoud += watchwoord;
                                        }
                                        else
                                        {
                                            inhoud += Environment.NewLine + watchwoord;
                                        }
                                    }
                                    writer.Write(inhoud);
                                }
                                arrAccountGeboorte[antwoordDeleteAccount - 1] = "";
                                using (StreamWriter writer = new StreamWriter(@"geboorte.txt"))
                                {
                                    string inhoud = "";
                                    for (int i = 0; i < arrAccountGeboorte.Length; i++)
                                    {
                                        string geboorte = arrAccountGeboorte[i];

                                        if (geboorte == "")
                                        {
                                            continue;
                                        }
                                        if (inhoud == "")
                                        {
                                            inhoud += geboorte;
                                        }
                                        else
                                        {
                                            inhoud += Environment.NewLine + geboorte;
                                        }
                                    }
                                    writer.Write(inhoud);
                                }
                                arrAccountGemeente[antwoordDeleteAccount - 1] = "";
                                using (StreamWriter writer = new StreamWriter(@"gemeente.txt"))                          // Array herschrijven naar tekst file? (probleem : gaat er geen lege array instaan)                                     
                                {
                                    string inhoud = "";
                                    for (int i = 0; i < arrAccountGemeente.Length; i++)
                                    {
                                        string gemeente = arrAccountGemeente[i];
                                        if (gemeente == "")
                                        {
                                            continue;
                                        }
                                        if (inhoud == "")
                                        {
                                            inhoud += gemeente;
                                        }
                                        else
                                        {
                                            inhoud += Environment.NewLine + gemeente;
                                        }
                                    }
                                    writer.Write(inhoud);
                                }
                                Console.WriteLine("Druk op een toets om terug te gaan naar het hoofdmenu.");
                                Console.ReadKey();
                                break; //Verwijderen
                            case 4:
                                break; //Menu
                                       //ja iets

                            default:
                                Console.WriteLine("U brak mijn app , goed gedaan :)");
                                Console.ReadKey();
                                break;

                        }
                        break; //ACCOUNTBEHEER


                    case 2:

                        Console.Clear();
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.WriteLine("Prijs per dag (in €)".PadLeft(55) + "Prijs per week (in €)".PadLeft(35));
                        for (int i = 0; i < arrVoertuigen.Length; i++)
                        {
                            Console.WriteLine((i + 1).ToString() + "." + arrVoertuigen[i].ToString().PadLeft(18) + arrPrijsPerDag[i].ToString("0.00").PadLeft(35)
                                + arrPrijsPerWeek[i].ToString("0.00").PadLeft(35));
                        }
                        Console.WriteLine("Druk op een toets om terug te gaan naar het hoofdmenu.");
                        Console.ReadKey();
                        break; //PRIJSLIJST


                    case 3:
                        Console.WriteLine("Hoeveel fietsen wil je huren?");
                        antwoordAankoopfietsen = GegevensValidatieGetal(antwoordAankoopfietsen, 1, 25);
                        for (int i = 0; i < antwoordAankoopfietsen; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("1. Fiets");
                            Console.WriteLine("2. Kinderfiets");
                            Console.WriteLine("3. Elektrische Fiets");
                            Console.WriteLine("Welke fiets wil je huren?");
                            antwoordSoortFiets = GegevensValidatieGetal(antwoordSoortFiets, 1, 3);

                            Console.WriteLine("Hoeveel dagen wil je deze huren?");
                            huurDagen = GegevensValidatieGetal(huurDagen, 1, 100);
                            if (huurDagen >= 7 && antwoordSoortFiets == 1)
                            {
                                prijsTotaal += huurDagen * arrPrijsPerDag[0] * 0.85;
                            }
                            else if (huurDagen < 7 && antwoordSoortFiets == 1)
                            {
                                prijsTotaal += huurDagen * arrPrijsPerDag[0];
                            }
                            else if (huurDagen >= 7 && antwoordSoortFiets == 2)
                            {
                                prijsTotaal += huurDagen * arrPrijsPerDag[1] * 0.85;
                            }
                            else if (huurDagen < 7 && antwoordSoortFiets == 2)
                            {
                                prijsTotaal += huurDagen * arrPrijsPerDag[1];
                            }
                            else if (huurDagen >= 7 && antwoordSoortFiets == 3)
                            {
                                prijsTotaal += huurDagen * arrPrijsPerDag[2] * 0.85;
                            }
                            else if (huurDagen < 7 && antwoordSoortFiets == 3)
                            {
                                prijsTotaal += (huurDagen * arrPrijsPerDag[2]);
                            }


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Fiets " + (i + 1) + " is succesvol aangevraagd.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Dankuwel voor u bestelling, we wensen u een fijne rit alvast.");
                        Console.WriteLine("In totaal betaalt u €" + Math.Round(prijsTotaal, 2) + ".");
                        Console.ForegroundColor = ConsoleColor.White;
                        prijsTotaal = 0;
                        Console.ReadKey();


                        break; //FIETS KOPEN


                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Fijne dag, de applicatie wordt nu afgesloten.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(0);
                        break; //EXIT
                }
            }
        }


















    }
}
