// Titre : créateur d'initiales qui peut prendre des strings avec plein de caractères superflus, et qui redonne des initiales bien formatées

// Déclarer puis initialiser les constantes et les variables
// NOTE IMPORTANTE : pour une raison que j'ignore les symboles "Ÿ", "Æ" et "Œ" ne sortent pas comme il le faut pendant l'exécution du programme.
// Pourquoi? Je ne sais pas, mais c'est peut-être parce que ces symboles sont mal supportés. C'est la seule explication que je vois en ce moment.
// Je les ai donc enlevés des symboles présents dans le string[] SYMBOLES_AUTORISES
string[] SYMBOLES_AUTORISES = new string[53] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "À", "Â", "Ä", "Ç", "É", "È", "Ê", "Ë", "Î", "Ï", "Ô", "Ö", "Ù", "Û", "Ü", "-", " " };
string texte_valide = "";
string initiales = "";

// Tant que texte_valide est vide, répéter la boucle suivante
while (texte_valide == "")
{
    // Déclarer puis initialiser les variables
    // Note -> Chaque valeur de la variable bool[] detection[i] est associée à une détection spécifique :
    // detection[0] -> détection des espaces et des apostrophes
    // detection[1] -> détection des tirets
    bool[] detection = new bool[2] { false, false };
    string texte_brut = "";

    // Afficher ce message
    Console.WriteLine("Entrez un prénom, suivi d'un nom :");

    // Lire la console, ensuite enlever les tirets, les apostrophes et les espaces au début et à la fin de la valeur de texte_brut,
    // par la suite remplacer les apostrophes par des espaces, puis mettre la valeur lue en majuscules dans la variable texte_brut
    // Note : en remplaçant les apostrophes par des espaces, on évite d'avoir à gêrer les apostrophes.
    texte_brut = Console.ReadLine().Trim('-', '\'', ' ').Replace("'", " ").ToUpper();

    // Pour chaque symbole qui forme le contenu de texte_brut
    for (int compteur = 0; compteur < texte_brut.Length; compteur++)
    {
        // Déclarer et initialiser la variable symbole en prenant le symbole de texte_brut dont l'index est défini par la valeur de compteur
        string symbole = texte_brut.Substring(compteur, 1);

        // Si la valeur de symbole est contenue dans les symboles autorisés, on concatène la valeur de ce symbole à la fin de la valeur de texte_valide
        if (SYMBOLES_AUTORISES.Contains(symbole))
        {
            // Si le symbole actuel est différent d'un espace et d'un tiret
            if (symbole != " " && symbole != "-")
            {
                // Ajouter le symbole actuel à la fin de texte_valide
                texte_valide += symbole;

                // Si la valeur de detection[0] ou de detection[1] est true
                if (detection[0] || detection[1])
                {
                    // Réinitialiser toutes les valeurs de bool[] detection
                    detection[0] = false;
                    detection[1] = false;
                }
            }

            // Autrement, si le symbole actuel est un espace
            else if (symbole == " ")
            {
                // Si la valeur de detection[0] est false
                if (!detection[0])
                {
                    // Ajouter le symbole actuel à la fin de texte_valide
                    texte_valide += symbole;

                    // Changer la valeur de detection[0] pour true
                    detection[0] = true;
                }
            }

            // Si le symbole actuel est un tiret
            else
            {
                // Si la valeur de detection[1] est false
                if (!detection[1])
                {
                    // Ajouter le symbole actuel à la fin de texte_valide
                    texte_valide += symbole;

                    // Changer la valeur de detection[1] pour true
                    detection[1] = true;
                }
            }
        }
    }

    // Afficher ce message
    Console.Write("\n");
}

// Déclarer et initialiser un string[] noms de la façon suivante :
// Enlever les tirets, les apostrophes et les espaces au début et à la fin de la valeur de texte_valide,
// et séparer la valeur lue à partir de chaque espace, en plaçant chaque mot qui est séparé par un espace
// dans le string[] noms, tout en enlevant les espaces du résultat final
string[] noms = texte_valide.Trim('-', '\'', ' ').Split(' ');

// Afficher ce message
Console.WriteLine("Vos initiales sont :");

// Pour chaque element du string[] noms, exécuter la boucle for suivante
for (int element = 0; element < noms.Length; element++)
{
    // Si noms[element] ne contient pas de tiret
    if (!noms[element].Contains("-"))
    {
        // On ajoute le premier symbole de noms[element] et un point à la fin de la valeur de initiales
        initiales += noms[element].Substring(0, 1) + ".";
    }

    // Si noms[element] contient un tiret
    else
    {
        // Déclarer et initialiser la variable bool[] detection
        bool[] detection = new bool[2] { false, false };

        // Si noms[element] commence par un tiret, enlever le tiret et changer la valeur de la variable detection[0] pour true
        if (noms[element].StartsWith("-"))
        {
            noms[element] = noms[element].Remove(0, 1);

            detection[0] = true;
        }

        // Si noms[element] fini par un tiret, enlever le tiret et changer la valeur de la variable detection[1] pour true
        if (noms[element].EndsWith("-"))
        {
            noms[element] = noms[element].Remove(noms[element].Length - 1, 1);

            detection[1] = true;
        }

        // Séparer chaque element du string[] noms pour chaque tiret trouvé, en plaçant chaque mot qui est séparé
        // par un tiret dans le string array noms_composes, tout en enlevant les tirets du résultat final
        string[] noms_composes = noms[element].Split('-');

        // Si la variable detection[0] est vraie, ajouter un tiret à la fin de initiales
        if (detection[0])
        {
            initiales += "-";
        }

        // Pour chaque element du string[] noms_composes trouvé, exécuter la boucle for suivante
        for (int element_2 = 0; element_2 < noms_composes.Length; element_2++)
        {

            // Si la variable noms_composes.Length contient plus d'un élément
            if (noms_composes.Length - 1 > 0)
            {
                // Si on n'est pas rendus au dernier élément de noms_composes, on ajoute le premier symbole
                // de noms_composes[element_2], un point et un tiret à la fin de initiales
                if (element_2 + 1 < noms_composes.Length)
                {
                    initiales += noms_composes[element_2].Substring(0, 1) + ".-";
                }

                // Si on est rendus au dernier élément de noms_composes, on ajoute le premier symbole
                // de noms_composes[element_2] et un point à la fin de initiales
                else
                {
                    initiales += noms_composes[element_2].Substring(0, 1) + ".";
                }
            }

            // Si la variable noms_composes.Length contient un seul élément, on ajoute le premier symbole
            // de noms_composes[element_2] et un point à la fin de initiales
            else
            {
                initiales += noms_composes[element_2].Substring(0, 1) + ".";
            }
        }

        // Si la variable detection[1] est vraie, ajouter un tiret à la fin de initiales
        if (detection[1])
        {
            initiales += "-";
        }

        // Réinitialiser la variable bool[] detection
        detection[0] = false;
        detection[1] = false;
    }
}

// Afficher la valeur de initiales
Console.WriteLine(initiales);