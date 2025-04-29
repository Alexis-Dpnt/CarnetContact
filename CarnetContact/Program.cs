using System.ComponentModel.DataAnnotations.Schema;
using CarnetContact;
using System.Text.Json;

/******************************************************* A FAIRE *******************************************************
 - système de mots de passes associé à chaque utilisateur ???
 - soigner l'affichage
 - carnet partagé peut être plus tard
 
 
 ⚠ chanager chemins car ca currentdirectory prend de la ou est le .exe
 
*/
public class Program
{
    /************************************************ Partie Contacts ************************************************/

    // fonction pour regarder si un numero est deja rentre dans le carnet
    public static bool existeNum(int num, List<Contact> contacts)
    {
        foreach (var contact in contacts)
        {
            if (contact.Num == num)
                return true;
        }
        return false;
    }
    
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
        if (!existeNum(numero, carnet))
        {
            Contact newContact = new Contact(nom, prenom, email, numero);
            carnet.Add(newContact);
        }
        else
            Console.WriteLine("Ce numero est déjà enregistré");
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

    // fonction pour modifier les infos sur un utilisateur
    public static String modifierInfoUtilisateur(Utilisateur usr)
    {
        Console.WriteLine("quel nom veux tu donner a cet utilisateur");
        usr.setNomUser(Console.ReadLine());
        return usr.getNomUser();
    }

    // fonction qui regarde si un utilisateur existe deja
    public static bool existeUtilisateur(String nom, List<Utilisateur> utilisateurs)
    {
        foreach (var usr in utilisateurs)
        {
            if (usr.getNomUser().Equals(nom))
                return true;
        }
        return false;
    }
    
    // fonction pour créer un nouvel utilisateur
    public static void creerUtilisateur(String nom, List<Utilisateur> utilisateurs)
    {
        if (!existeUtilisateur(nom, utilisateurs))
        {
            Utilisateur usr = new Utilisateur(nom);
            utilisateurs.Add(usr);
        }
        else
            Console.WriteLine("Cet Utilisateur existe déjà");
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

    // fonction qui creer un dossier
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
    public static bool existeFile(String nom, String chemin)
    {
        String path = Path.Combine(chemin, nom);
        if (File.Exists(path))
            return true;
        return false;
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
    public static List<Contact> remplirCarnet(String chemin)
    { 
        String path = Path.Combine(chemin, "contact.json");
        try
        { 
            return JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText(path)) ?? new List<Contact>();
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Erreur lors de la désérialisation : {ex.Message}");
            return new List<Contact>();
        }
    }

    // fonction qui supprime un dossier
    public static int supprimerDir(String nom, String chemin)
    {
        String path = Path.Combine(chemin, nom);
        try
        {
            Directory.Delete(path, true);
            if (existeDir(nom, chemin))
                return -1;
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la suppression du dossier : {ex.Message}");
            return -1;
        }
    }

    // fonction qui sert à modifier le nom d'un dossier
    public static void modifierNomDir(String nomSrc, String nomDest, String chemin)
    {
        String pathSrc = Path.Combine(chemin, nomSrc);
        String pathDest = Path.Combine(chemin, nomDest);
        Directory.Move(pathSrc, pathDest);
    }

    // fonction qui sert a enregistrer la liste de constacts dans un fichier Json
    public static void toJson(List<Contact> contacts, String chemin)
    {
        String json = JsonSerializer.Serialize(contacts);
        String path = Path.Combine(chemin, "contact.json");
        File.WriteAllText(path, json);
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
        String currentUtilisateur = ""; // utilisateur en cours d'utilisation
        String utilisateurChange = ""; // variable temporaire pour faire le changement d'utilisateur
        String cheminCarnet = Path.Combine(AppContext.BaseDirectory, "..", "bin", "Debug", "net9.0", "Utilisateurs");
        Console.WriteLine(cheminCarnet + "ll");
        String cheminEnregistrement = cheminCarnet;
        String nom; // variable qui stockera le nom de l'utilisateur
        String nomModif = ""; // variable qui va stocker le nom modifié d'un utilisateur
        List<Utilisateur> utilisateurs = new List<Utilisateur>();
        List<Contact> carnet = new List<Contact>();
        int choix = 0; // variable pour le choix de l'option du menu
        int num; // variable qui stockera le numéro du contact
        int index; // variable qui stockera l'index dans la liste d'un utilisateur
        
        remplirListDir(utilisateurs, cheminCarnet);
        if (utilisateurs.Count > 0)
        {
            listerUtilisateurs(utilisateurs);
            Console.WriteLine("a quel utilisateur veux tu te connecter ?");
            currentUtilisateur = Console.ReadLine();
            if (existeDir(currentUtilisateur, cheminCarnet))
            {
                cheminEnregistrement = Path.Combine(cheminCarnet, currentUtilisateur);
                Console.WriteLine("connection effectuée");
            }
            else
            {
                Console.WriteLine("connection fail");
                currentUtilisateur = "";
                return;
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
                Console.WriteLine("impossible de créer l'utilisateur");
                if (utilisateurs.Count > 0)
                    utilisateurs.RemoveAt(utilisateurs.Count - 1);
                return;
            }
        }
        
        if (existeFile("contact.json", cheminEnregistrement))
        {
            carnet = remplirCarnet(cheminEnregistrement);
        }
        else
        {
            File.Create(Path.Combine(cheminEnregistrement, "contact.json"));
            if (File.Exists(Path.Combine(cheminEnregistrement, "contact.json")))
                Console.WriteLine("fichier creer avec succes");
            else
            {
                Console.WriteLine("le fichier na pas pu etre creer");
                return;
            }
        }
        
        while (choix != 12)
        {
            menu();
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    ajouterContact(carnet);
                    toJson(carnet, cheminEnregistrement);
                    break;
                case 2:
                    num = retournerNum();
                    supprimerContacts(num, carnet);
                    toJson(carnet, cheminEnregistrement);
                    break;
                case 3:
                    afficherContacts(carnet);
                    break;
                case 4:
                    num = retournerNum();
                    modifierContacts(num, carnet);
                    toJson(carnet, cheminEnregistrement);
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
                        Console.WriteLine("quel nom veux tu donner a cet utilisateur ?");
                        nomModif = Console.ReadLine();
                        modifierNomDir(nom, nomModif, cheminCarnet);
                        if (existeDir(nomModif, cheminCarnet))
                        {
                            usr = utilisateurs[index];
                            modifierInfoUtilisateur(usr);
                            Console.WriteLine("modification effectuée");
                        }
                        else
                            Console.WriteLine("modification fail");
                        if (currentUtilisateur == nom)
                            currentUtilisateur = nomModif;
                    }
                    else
                        Console.WriteLine("l'utilisateur n'existe pas");
                    break;
                case 7:
                    Console.WriteLine("quel nom veux tu donner a ton utilisateur ?");
                    nom = Console.ReadLine();
                    creerUtilisateur(nom, utilisateurs);
                    if (creerDir(nom, cheminCarnet) != -1)
                        Console.WriteLine("l'utilisateur à bien été crée");
                    else
                    {
                        Console.WriteLine("impossible de créer l'utilisateur");
                        if (utilisateurs.Count > 0)
                            utilisateurs.RemoveAt(utilisateurs.Count - 1);
                        return;
                    }
                    Console.WriteLine("veux tu te connecter a cet utilisateur ?");
                    if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                    {
                        currentUtilisateur = nom;
                        cheminEnregistrement = Path.Combine(cheminCarnet, currentUtilisateur);
                        carnet = remplirCarnet(cheminEnregistrement);
                    }
                    break;
                case 8:
                    listerUtilisateurs(utilisateurs);
                    break;
                case 9:
                    utilisateurChange = changerUtilisateur(currentUtilisateur, utilisateurs);
                    if (utilisateurChange.Equals(currentUtilisateur))
                        Console.WriteLine("tu est déjà connecté à cet utilisateur");
                    else
                    {
                        if (utilisateurChange != null)
                        {
                            if (existeDir(utilisateurChange, cheminCarnet))
                            {
                                Console.WriteLine($"vous êtes maintenant connecté en tant que {utilisateurChange}");
                                currentUtilisateur = utilisateurChange;
                                cheminEnregistrement = Path.Combine(cheminCarnet, currentUtilisateur);
                                carnet = remplirCarnet(cheminEnregistrement);
                            }
                            else
                                Console.WriteLine("l'utilisateur n'existe pas");
                        }
                    }
                    break;
                case 10:
                    Console.WriteLine("quel est le nom de l'utilisateur que tu veux supprimer ?");
                    nom = Console.ReadLine();
                    if (!(nom == currentUtilisateur))
                    {
                        index = indexUtilisateur(nom, utilisateurs);
                        if (index != -1)
                            utilisateurs.RemoveAt(index);
                        if (supprimerDir(nom, cheminCarnet) != 0)
                            Console.WriteLine("l'utilisateur n'a pas pu être supprimer");
                        else
                            Console.WriteLine("L'utilisateur a bien été supprimé");
                    }
                    else
                        Console.WriteLine("tu ne peut pas supprimer cet utilisateur car tu y est connecté");
                    break;
                
                case 11:
                    afficherHelp();
                    break;
            }
        }
        Console.ReadLine();
    }
}