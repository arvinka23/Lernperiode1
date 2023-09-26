using System;

class BuchstabenRaten
{
    static void Main()
    {
        string gesuchtesWort = "apfel";
        string benutzerAntwort;
        int versuche = 0;

        Console.WriteLine("Willkommen beim Buchstaben-Ratespiel!");
        Console.WriteLine("Versuche, das gesuchte Wort Buchstabe für Buchstabe zu erraten.");

        char[] gesuchteBuchstaben = gesuchtesWort.ToCharArray();
        bool[] buchstabenErraten = new bool[gesuchtesWort.Length];

        while (!AlleBuchstabenErraten(buchstabenErraten))
        {
            Console.Write("Geben Sie einen Buchstaben ein: ");
            char buchstabe = Console.ReadKey().KeyChar;
            Console.WriteLine();

            for (int i = 0; i < gesuchtesWort.Length; i++)
            {
                if (gesuchteBuchstaben[i] == buchstabe)
                {
                    buchstabenErraten[i] = true;
                }
            }

            versuche++;

            Console.WriteLine("Aktueller Fortschritt: " + AnzeigenFortschritt(gesuchtesWort, buchstabenErraten));
        }

        Console.WriteLine($"Glückwunsch! Du hast das Wort \"{gesuchtesWort}\" in {versuche} Versuchen erraten.");
        Console.ReadLine();
    }

    static string AnzeigenFortschritt(string wort, bool[] buchstabenErraten)
    {
        string fortschritt = "";

        for (int i = 0; i < wort.Length; i++)
        {
            if (buchstabenErraten[i])
            {
                fortschritt += wort[i];
            }
            else
            {
                fortschritt += "_";
            }

            fortschritt += " ";
        }

        return fortschritt;
    }

    static bool AlleBuchstabenErraten(bool[] buchstabenErraten)
    {
        foreach (bool erraten in buchstabenErraten)
        {
            if (!erraten)
            {
                return false;
            }
        }
        return true;
    }
}
