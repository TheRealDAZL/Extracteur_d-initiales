// Titre : créer des initiales à partir de strings pleins de caractères superflus, tout en redonnant des initiales bien formatées

// NOTE IMPORTANTE : pour une raison que j'ignore les symboles "Ÿ", "Æ" et "Œ" ne sortent pas comme il le faut pendant l'exécution du programme.
// Pourquoi? Peut-être parce que ces symboles sont mal supportés. C'est la seule explication que je vois en ce moment. J'ai donc enlevé ces symboles
// du string[] SYMBOLES_AUTORISES

// Déclarer, puis initialiser le string[] SYMBOLES_AUTORISES de constantes et le string initiales
// Note : j'ai ajouté les chiffres dans les initiales possibles, en raison du nom de l'enfant d'Elon Musk.
// Vous savez, on ne sait jamais quel peut être le prénom et le nom d'une personne en avance, lol!
string[] SYMBOLES_AUTORISES = new string[54] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "À", "Â", "Ä", "Ç", "É", "È", "Ê", "Ë", "Î", "Ï", "Ô", "Ö", "Ù", "Û", "Ü", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", "-", "'" };
string initiales = "";

// Tant que initiales est vide, répéter la boucle suivante
while (initiales == "")
{
    // Déclarer puis initialiser la variable bool[] detection
    // Note : chaque valeur de bool[] detection est associée à une détection spécifique :
    // detection[0] -> détection des espaces
    // detection[1] -> détection des tirets
    // detection[2] -> détection des lettres et des chiffres
    bool[] detection = new bool[3] { false, false, false };

    // Afficher ce message
    Console.WriteLine("Entrez un prénom, suivi d'un nom :");

    // Lire la console, ensuite enlever les tirets, les apostrophes et les espaces au début et à la fin de la valeur lue,
    // puis mettre la valeur ainsi obtenue en majuscules dans la variable texte_original
    string texte_original = Console.ReadLine().Trim('-', '\'', ' ').ToUpper();

    // Pour chaque symbole qui forme le contenu de texte_original
    for (int compteur = 0; compteur < texte_original.Length; compteur++)
    {
        // Déclarer et initialiser la variable symbole en isolant le symbole de texte_original dont l'index est défini par la valeur de compteur
        string symbole = texte_original.Substring(compteur, 1);

        // Si la valeur de symbole est contenue dans les symboles autorisés, on exécute le code suivant
        if (SYMBOLES_AUTORISES.Contains(symbole))
        {
            // Si le symbole actuel est différent d'un espace et d'un tiret
            if (symbole != " " && symbole != "-" && symbole != "'")
            {
                // Si la valeur de detection[2] est false
                if (!detection[2])
                {
                    // Ajouter le symbole actuel à la fin de initiales
                    initiales += symbole;

                    // Si la valeur de detection[0] ou de detection[1] est true
                    if (detection[0] || detection[1])
                    {
                        // Réinitialiser toutes les valeurs de bool[] detection
                        detection[0] = false;
                        detection[1] = false;
                    }

                    // Changer la valeur de la variable detection[2] pour true
                    detection[2] = true;
                }
            }

            // Autrement, si le symbole actuel est un espace ou un apostrophe
            else if (symbole == " " || symbole == "'")
            {
                // Si la valeur de detection[0] est false
                if (!detection[0])
                { 
                    // Changer la valeur de detection[0] pour true
                    detection[0] = true;
                }

                // Changer la valeur de la variable detection[2] pour false
                detection[2] = false;
            }

            // Si le symbole actuel est un tiret
            else
            {
                // Si la valeur de detection[1] est false
                if (!detection[1])
                {
                    // Ajouter le symbole actuel à la fin de initiales
                    initiales += symbole;

                    // Changer la valeur de detection[1] pour true
                    detection[1] = true;
                }

                // Changer la valeur de la variable detection[2] pour false
                detection[2] = false;
            }
        }

        // Si la valeur de symbole n'est pas contenue dans les symboles autorisés, on change la valeur de tous les éléments de detection
        else
        {
            detection[0] = false;
            detection[1] = false;
            detection[2] = false;
        }
    }

    // Afficher ce message
    Console.Write("\n");
}

// Afficher ce message
Console.WriteLine("Vos initiales sont :");

// Afficher la valeur de initiales
Console.WriteLine(initiales);