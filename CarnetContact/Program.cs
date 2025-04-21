using System.ComponentModel.DataAnnotations.Schema;
using CarnetContact;

/******************************************************* A FAIRE *******************************************************
 - faire en sorte que quand on se connecte a un utilisateur ça enregistre les contacts dans son dossier
 - faire un système de sauvegarde pour les contacts
 - faire un système de sauvegarde pour les utilisateurs
 - faire un système de sauvegarde pour le carnet
 - coder une fonction qui regarde si le carnet existe ou pas
 - coder une fonction qui regarde si l'utilisateur existe ou pas
 - coder une fonction qui regarde si le contact existe ou pas
 - faire un systeme d'authentification (peut etre plus tard)
 - faire un systeme de confirmation avant de supprimer un contact
 - faire un systeme de confirmation avant de supprimer un utilisateur
 - coder une fonction qui liste tous les utilisateurs (regarder le nombre de dossiers dans le dossier utilisateur)
 - coder tout le système de gestions des utilisateurs
 - système de mots de passes associé à chaques utilisateurs ???
 - mettre les consoles.clear
 
 ajouterContact :
  - faire systeme qui regarde si le numero existe deja dans le tableau (peut etre base de donnee plus tard)

 supprimerContact :
  - message de verification avec info contact qui s'affiche pour savoir si c'est bien le bon contact
 
 creerUtilisateur :
  - message qui dit que l'utilisateur existe deja puis propose de mettre un autre nom
  
 changerUtilisateur : 
  - peut etre passer le type de la fonction en Utilisateur
  
 existeFile :
  - a modifier car il faut que le parametre soit un chemin vers le fichier recherché
*/
public class Program
{
    /************************************************ Partie Contacts ************************************************/
    
    // fonction pour ajouter les contacts au carnet
    public static void ajouterContact(List<Contact> carnet)
    {
        Console.WriteLine("entre le nom du contact");
        String nom = Console.ReadLine();
        Console.WriteLine("entre le prénom du contact");
        String prenom = Console.ReadLine();
        Console.WriteLine("entre le mail du contact");
        String email = Console.ReadLine();
        Console.WriteLine("entre le numéro du contact");
        int numero = int.Parse(Console.ReadLine());
        Contact newContact = new Contact(nom, prenom, email, numero);
        carnet.Add(newContact);
    }
    
    // fonction pour afficher tous les contacts
    public static void afficherContacts(List<Contact> contacts)
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {contacts[i].getNom()}");
        }
    }
    
    // fonction qui retourne le numéro d'un potentiel compte
    public static int retournerNum()
    {
        Console.WriteLine("entre le numéro du contact");
        return int.Parse(Console.ReadLine());
    }

    // fonction qui retourne un contact grâce à son numéro
    public static Contact retournerContact(List<Contact> carnet)
    {
        int num = retournerNum();
        for (int i = 0; i < carnet.Count; i++)
        {
            if (carnet[i].getNum() == num)
                return carnet[i];
        }
        return null;
    }

    // fonction pour afficher les infos de 1 contact
    public static void afficherInfoContact(Contact contact)
    {
        Console.WriteLine("Nom : " + contact.getNom());
        Console.WriteLine("Prénom : " + contact.getPrenom());
        Console.WriteLine("Mail : " + contact.getEmail());
        Console.WriteLine("Numéro : " + contact.getNum());
    }
    
    // fonction pour trouver l'index d'un compte
    public static int indexCompte(int num, List<Contact> carnet)
    {
        for (int i = 0; i < carnet.Count; i++)
        {
            if (carnet[i].getNum() == num)
                return i;
        }
        return -1;
    }

    // fonction pour supprimer des contacts
    public static void supprimerContacts(int num, List<Contact> carnet)
    {
        int index = indexCompte(num, carnet);
        if (index!= -1)
            carnet.RemoveAt(index);
        else
            Console.WriteLine("impossible de supprimer le compte car il n'existe pas");
    }

    // fonction pour modifier des contacts
    public static void modifierContacts(int num, List<Contact> carnet) // a modifier car lecture entree avant affichage
    {
        int choix = 0;
        foreach (var contact in carnet)
        {
            if (contact.getNum() == num) // si le num = num du contact
            {
                while (choix != 6)
                {
                    Console.WriteLine("que veux tu modifier ?");
                    Console.WriteLine("1. Nom");
                    Console.WriteLine("2. Prénom");
                    Console.WriteLine("3. Mail");
                    Console.WriteLine("4. Numéro");
                    Console.WriteLine("5. Tout");
                    Console.WriteLine("6. Retour");
                    choix = int.Parse(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("quel Nom veux tu donner a ce contact");
                            contact.setNom(Console.ReadLine());
                            break;
                        
                        case 2:
                            Console.WriteLine("quel Prénom veux tu donner a ce contact");
                            contact.setPrenom(Console.ReadLine());
                            break;
                        
                        case 3:
                            Console.WriteLine("quel Mail veux tu donner a ce contact");
                            contact.setEmail(Console.ReadLine());
                            break;
                        
                        case 4:
                            Console.WriteLine("quel Numéro veux tu donner a ce contact");
                            contact.setNum(int.Parse(Console.ReadLine()));
                            break;
                        
                        case 5:
                            supprimerContacts(num, carnet);
                            ajouterContact(carnet);
                            break;
                    }
                }
            }
        }
    }
    
    // fonction qui affiche un message d'aide à l'utilisation du programme
    public static void afficherHelp()
    {
        Console.WriteLine("message d'aide");
    }

    
    
    /********************************************** Partie Utilisateurs **********************************************/
    
    
    // trouve l'index auquel est enregistré un utilisateur
    public static int indexUtilisateur(String nom, List<Utilisateur> utilisateurs)
    {
        for (int i = 0; i < utilisateurs.Count; i++)
        {
            if (utilisateurs[i].getNomUser().Equals(nom))
                return i;
        }
        return -1;
    }
    
    // fonction qui affiche la liste de tous les utilisateurs
    public static void listerUtilisateurs(List<Utilisateur> utilisateurs)
    {
        for (int i = 0; i < utilisateurs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {utilisateurs[i].getNomUser()}");
        }
    }

    // fonction pour afficher les infos sur un utilisateur
    public static void afficherInfoUtilisateur(Utilisateur usr)
    {
        Console.WriteLine($"nom d'utilisateur {usr.getNomUser}");
    }

    // fonction pour modifier les infos sur un utilisateur
    public static void modifierInfoUtilisateur(Utilisateur usr)
    {
        Console.WriteLine("quel nom veux tu donner a cet utilisateur");
        usr.setNomUser(Console.ReadLine());
    }

    // fonction pour créer un nouvel utilisateur
    public static void creerUtilisateur(String nom, List<Utilisateur> utilisateurs)
    {
        Utilisateur usr = new Utilisateur(nom);
        utilisateurs.Add(usr);
    }
    
    // fonction qui retourne un utilisateur en fonction de son index
    public static Utilisateur retournerUtilisateur(int index, List<Utilisateur> utilisateurs)
    {
        return utilisateurs[index];
    }

    // fonction pour changer d'utilisateur
    public static String changerUtilisateur(String CurrentUtilisateur, List<Utilisateur> utilisateurs)
    {
        Console.WriteLine($"L'utilisateur actuellement connecté est {CurrentUtilisateur}");
        Console.WriteLine("a quel utilisateur veux tu te connecter ?");
        String nom = Console.ReadLine();
        int index = indexUtilisateur(nom, utilisateurs);
        if (index != -1)
            return nom;
        Console.WriteLine("cet utilisateur n'existe pas");
        return null;
    }

    // fonction pour supprimer un utilisateur
    public static void supprimerUtilisateur(List<Utilisateur> utilisateurs)
    {
        Console.WriteLine("quel est le nom de l'utilisateur que tu veux supprimer ?");
        String nom = Console.ReadLine();
        int index = indexUtilisateur(nom, utilisateurs);
        if (index != -1)
            utilisateurs.RemoveAt(index);
        else
            Console.WriteLine("l'utilisateur n'existe pas");
    }
    
    
    
    /******************************************* Partie gestion de fichiers *******************************************/

    public static int creerDir(String nom, String chemin)
    {
        String cheminDossier = Path.Combine(chemin, nom);
        Directory.CreateDirectory(cheminDossier);
        if (existeDir(nom, chemin))
            return 0;
        return -1;
    }
    
    //fonction qui regarde si un dossier existe
    public static bool existeDir(String nom, String chemin)
    {
        String path = Path.Combine(chemin, nom);
        if (Directory.Exists(path))
            return true;
        return false;
    }
    
    // fonction qui regarde si un fichier existe
    public static bool existeFile(String nom)
    {
        if (File.Exists(nom))
            return true;
        return false;
    }
    
    // fonction qui compte le nombre de dossiers dans un dossier
    public static int compterDir(String nom)
    {
        String dossierUtilisateur = Path.Combine(Directory.GetCurrentDirectory(), nom);

        int compteur = Directory.EnumerateDirectories(dossierUtilisateur).Count();

        Console.WriteLine($"Il y a {compteur} dossiers dans le dossier utilisateur.");
        return compteur;
    }

    // fonction qui prend le nom des dossiers utilisateurs et enregistre les utilisateurs dans la liste
    public static void remplirListDir(List<Utilisateur> utilisateurs, String chemin)
    {
        String[] noms = Directory.GetDirectories(chemin);

        foreach (var nom in noms)
        {
            String nomDossier = Path.GetFileName(nom);
            utilisateurs.Add(new Utilisateur(nomDossier));
        }
    }

    // ouvre le fichier a Utilisateurs/chemin puis remplis la liste avec les contacts du fichier
    public static void remplirCarnet(List<Contact> carnet, String chemin)
    {
        String path = Path.Combine(Directory.GetCurrentDirectory(), "Utilisateurs");
        String completePath = Path.Combine(path, chemin);
        // ouvrir le fichier carnet et faire une boucle pour que tout se mette dans la liste
        // Json peut etre la meilleure solution car ca prend le json et ca le met directement en tableau
    }
    
    
    
    // fonction qui affiche le menu
    public static void menu()
    {
        Console.WriteLine("1. Ajouter un contact");
        Console.WriteLine("2. Supprimer un contact");
        Console.WriteLine("3. Afficher les contacts");
        Console.WriteLine("4. Modifier un contact");
        Console.WriteLine("5. Afficher les info d'un contact");
        Console.WriteLine("6. Modifier les infos d'un utilisateur");
        Console.WriteLine("7. Créer un utilisateur");
        Console.WriteLine("8. Lister les utilisateurs");
        Console.WriteLine("9. Changer d'utilisateur");
        Console.WriteLine("10. Supprimer un utilisateur");
        Console.WriteLine("11. help");
        Console.WriteLine("12. quitter");
    }
    
    public static void Main(string[] args)
    {
        String currentUtilisateur = ""; // utilisateur en cours d'utilisation (peut etre chager le type pour le mettre en Utilisateur)
        String utilisateurChange = ""; // variable temporaire pour faire le changement d'utilisateur
        String cheminCarnet = Path.Combine(Directory.GetCurrentDirectory(), "Utilisateurs"); // dossier où il y a tous les dossiers utilisateurs
        String cheminEnregistrement = cheminCarnet;
        List<Utilisateur> utilisateurs = new List<Utilisateur>();
        List<Contact> carnet = new List<Contact>();
        int choix = 0; // varible pour le choix de l'option du menu
        int num; // variable qui stockera le numero du contact
        String nom; // variable qoui stockera le nom de l'utilisateur
        int index; // variable qui stockera l'index dans la liste d'un utilisateur
        
        
        // remplir la liste des utilisateurs avec les dossier contenu dans Utilisateurs
        remplirListDir(utilisateurs, cheminCarnet);
        if (utilisateurs.Count > 0)
        {
            listerUtilisateurs(utilisateurs);
            Console.WriteLine("a quel utilisateur veux tu te connecter ?");
            currentUtilisateur = Console.ReadLine();
            if (existeDir(currentUtilisateur, cheminCarnet))
            {
                // pour que le chemin soit Utilisateurs/NOM_UTILISATEUR
                cheminEnregistrement = Path.Combine(cheminCarnet, currentUtilisateur);
                Console.WriteLine("connection effectuée");
            }
            else
            {
                Console.WriteLine("connection fail");
                currentUtilisateur = "";
            }
        }
        else
        {
            Console.WriteLine("Il n'existe pas d'utilisateurs, quel nom veux tu donner au tiens ?");
            nom = Console.ReadLine();
            creerUtilisateur(nom, utilisateurs);
            if (creerDir(nom, cheminCarnet) != -1)
                currentUtilisateur = nom;
            else
            {
                Console.WriteLine("impossible de creer l'utilisateur");
                if (utilisateurs.Count > 0)
                    utilisateurs.RemoveAt(utilisateurs.Count - 1);
            }
        }
        
        if (existeFile("carnet"))
        {
            Console.WriteLine("test"); // a coder
            remplirCarnet(carnet, currentUtilisateur);
        }
        
        while (choix != 12)
        {
            menu();
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    ajouterContact(carnet);
                    break;
                case 2:
                    num = retournerNum();
                    supprimerContacts(num, carnet);
                    break;
                case 3:
                    afficherContacts(carnet);
                    break;
                case 4:
                    num = retournerNum();
                    modifierContacts(num, carnet);
                    break;
                case 5:
                    afficherInfoContact(retournerContact(carnet));
                    break;
                
                case 6:
                    Console.WriteLine("quel est le nom de l'utilisateur que tu veux modifier ?");
                    nom = Console.ReadLine();
                    Utilisateur usr;
                    index = indexUtilisateur(nom, utilisateurs);
                    if (index != -1)
                    {
                        usr = utilisateurs[index];
                        modifierInfoUtilisateur(usr);
                    }
                    else
                        Console.WriteLine("l'utilisateur n'existe pas");
                    break;
                
                case 7:
                    Console.WriteLine("quel nom veux tu donner a ton utilisateur ?");
                    nom = Console.ReadLine();
                    creerUtilisateur(nom, utilisateurs);
                    Console.WriteLine("veux tu changer d'utilisateur ?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        utilisateurChange = changerUtilisateur(currentUtilisateur, utilisateurs);
                        if (utilisateurChange != null)
                        {
                            Console.WriteLine($"vous etes maintenant connecté en tant que {utilisateurChange}");
                            currentUtilisateur = utilisateurChange;
                        }
                    }
                    
                    break;
                case 8:
                    listerUtilisateurs(utilisateurs);
                    break;
                
                case 9:
                    utilisateurChange = changerUtilisateur(currentUtilisateur, utilisateurs);
                    if (utilisateurChange != null)
                    {
                        Console.WriteLine($"vous etes maintenant connecté en tant que {utilisateurChange}");
                        currentUtilisateur = utilisateurChange;
                    }
                    break;
                
                case 10:
                    Console.WriteLine("quel est le nom de l'utilisateur que tu veux supprimer ?");
                    nom = Console.ReadLine();
                    index = indexUtilisateur(nom, utilisateurs);
                    if (index != -1)
                        utilisateurs.RemoveAt(index);
                    break;
                
                case 11:
                    remplirListDir(utilisateurs, cheminCarnet);
                    foreach (Utilisateur utilisateur in utilisateurs)
                    {
                        Console.WriteLine(utilisateur.getNomUser());
                    }
                    
                    break;
            }
        }
    }
}