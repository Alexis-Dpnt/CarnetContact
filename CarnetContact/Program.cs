using System.ComponentModel.DataAnnotations.Schema;
using CarnetContact;

/******************************************************* A FAIRE *******************************************************
 - apporter modifications pour qu'il y ait une creation d'utilisateur pour avoir des listes personnelles
 - faire en sorte que quand on se connecte a un utilisateur ça enregistre les contacts dans son dossier
 - regarder si un fichier user existe sinon en créer un nouveau et demander le nom qu'on lui donne
 - coder une fonction qui liste tous les utilisateurs (regarder le nombre de dossiers dans le dossier utilisateur)
 - coder une fonction qui change de dossier de sauvegarde (changer d'utilisateur)
*/
public class Program
{
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
    public static void modifierContacts(int num, List<Contact> carnet)
    {
        int choix = 0;
        foreach (var contact in carnet)
        {
            if (contact.getNum() == num) // si le num = num du contact
            {
                while (choix != 6)
                {
                    choix = int.Parse(Console.ReadLine());
                    Console.WriteLine("que veux tu modifier ?");
                    Console.WriteLine("1. Nom");
                    Console.WriteLine("2. Prénom");
                    Console.WriteLine("3. Mail");
                    Console.WriteLine("4. Numéro");
                    Console.WriteLine("5. Tout");
                    Console.WriteLine("6. Retour");
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

    public static void listerUtilisateurs(List<Utilisateur> utilisateurs)
    {
        for (int i = 0; i < utilisateurs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {utilisateurs[i].getNomUser()}");
        }
    }
    
    // fonction qui affiche un message d'aide à l'utilisation du programme
    public static void afficherHelp()
    {
        Console.WriteLine("message d'aide");
    }

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

    // fonction qui affiche le menu
    public static void menu()
    {
        Console.WriteLine("1. Ajouter un contact");
        Console.WriteLine("2. Supprimer un contact");
        Console.WriteLine("3. Afficher les contacts");
        Console.WriteLine("4. Modifier un contact");
        Console.WriteLine("5. Afficher les info d'un contact");
        Console.WriteLine("6. Modifier les infos d'un utilisateur"); //
        Console.WriteLine("7. Créer un utilisateur"); //
        Console.WriteLine("8. Changer d'utilisateur"); //
        Console.WriteLine("9. Supprimer un utilisateur"); //
        Console.WriteLine("10. help");
        Console.WriteLine("11. quitter");
    }
    
    public static void Main(string[] args)
    {
        // si un fichier carnet existe deja mettre tous les contacts dans la liste
        List<Contact> carnet = new List<Contact>();
        // si dosser existe deja dans le dossier utilisateurs alors remplir la liste avec le nom des dossiers
        List<Utilisateur> utilisateurs = new List<Utilisateur>();
        int choix = 0;
        int num;
        String currentUtilisateur = "test"; // a changer
        String nom;
        int index;
        while (choix != 11)
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
                        usr = utilisateurs[index];
                    else
                        Console.WriteLine("l'utilisateur n'existe pas");
                    break;
                case 7:
                    Console.WriteLine("quel nom veux tu donner a ton utilisateur ?");
                    nom = Console.ReadLine();
                    creerUtilisateur(nom, utilisateurs);
                    Console.WriteLine("veux tu changer d'utilisateur ?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                        changerUtilisateur(currentUtilisateur, utilisateurs);
                    break;
                case 8:
                    changerUtilisateur(currentUtilisateur, utilisateurs);
                    break;
                case 9:
                    Console.WriteLine("quel est le nom de l'utilisateur que tu veux modifier ?");
                    nom = Console.ReadLine();
                    index = indexUtilisateur(nom, utilisateurs);
                    if (index != -1)
                        utilisateurs.RemoveAt(index);
                    break;
                case 10:
                    afficherHelp();
                    break;
            }
        }
    }
}