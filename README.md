# Createur-dinitiales
Mon programme permet d'extraire les initiales à partir de strings qui peuvent contenir plein de caractères superflus, et il redonne des initiales bien formatées.

Voici la liste des symboles acceptés par mon programme (chaque symbole autorisé se trouve entre guillemets), et tout symbole qui n'est pas dans cette liste sera tout simplement ignoré :
"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "À", "Â", "Ä", "Ç", "É", "È", "Ê", "Ë", "Î", "Ï", "Ô", "Ö", "Ù", "Û", "Ü", "'", "-" et " ".

Note importante :
Étant donnée la nature de l'extraction des initiales, la présence d'un apostrophe, d'un espace ou d'un symbole non autorisé donne le même résultat au final, soit l'absence de symbole ajouté aux initiales, et la fin d'un mot, d'un nombre, d'un chiffre ou d'une lettre. On peut dire qu'ici, l'apostrophe, l'espace et les symboles non autorisés agissent uniquement comme des séparateurs pour les initiales. Le tiret agit lui aussi comme un séparateur, sauf qu'il apparaît dans les intiales, une seule fois, et uniquement entre deux initiales. Finalement, tous les autres symboles autorisés ressortent tels quels, tant que le symbole se trouve au début d'un mot, d'un nombre, d'un chiffre ou d'une lettre.

Exemple d'extraction des initales :
![Screenshot](https://github.com/TheRealDAZL/Createur-dinitiales/assets/116024728/5161be03-82e1-49b8-a21a-b6bbe9a64fd3)
