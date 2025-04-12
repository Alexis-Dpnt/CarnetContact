using System.ComponentModel.DataAnnotations.Schema;
using CarnetContact;

/******************************************************* A FAIRE *******************************************************
 - apporter modifications pour qu'il y ait une creation d'utilisateur pour avoir des listes personnelles
 - faire en sorte que quand on se connecte a un utilisateur ca enregistre les contacts dans son dossier
 - regarder si un fichier user existe sinon en créer un nouveau et demander le nom qu'on lui donne
 - coder la fonction afficherInfoUtilisateur
 - coder une fonction qui liste tous les utilisateurs (regarder le nombre de dossiers dans le dossier utilisateur)
 - coder une fonction qui modifie les informations d'un utilisateur
 - coder une fonction qui creer un nouel utilisateur
 - coder une fonction qui change de dossier de sauvegarde (changer d'utilisateur)
 - coder une fonction qui supprime un utilisateur
*/
public class Program
{
    // fonction pour ajouter les contacts au carnet
    public static void ajouterContact(List<Contact> carnet)
    {
        Console.WriteLine("entre le nom du contact");
        String nom = Console.ReadLine();
        Console.WriteLine("entre le prenom du contact");
        String prenom = Console.ReadLine();
        Console.WriteLine("entre le mail du contact");
        String email = Console.ReadLine();
        Console.WriteLine("entre le numero du contact");
        int numero = int.Parse(Console.ReadLine());
        Contact newContact = new Contact(nom, prenom, email, numero);
        carnet.Add(newContact);
    }
    
    // fonction pour afficher tous les contacts
    public static void afficherContacts(List<Contact> contacts)
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + contacts[i].getNom());
        }
    }
    
    // fonction qui retourne le numero d'un potentiel compte
    public static int retournerNum()
    {
        Console.WriteLine("entre le numero du contact");
        return int.Parse(Console.ReadLine());
    }

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
        Console.WriteLine("Prenom : " + contact.getPrenom());
        Console.WriteLine("Mail : " + contact.getEmail());
        Console.WriteLine("Numero : " + contact.getNum());
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
                    Console.WriteLine("2. Prenom");
                    Console.WriteLine("3. mail");
                    Console.WriteLine("4. numero");
                    Console.WriteLine("5. tout");
                    Console.WriteLine("6. retour");
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("quel Nom veux tu donner a ce contact");
                            contact.setNom(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("quel Prenom veux tu donner a ce contact");
                            contact.setPrenom(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("quel Mail veux tu donner a ce contact");
                            contact.setEmail(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("quel Numero veux tu donner a ce contact");
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

    // fonction pour afficher les infos sur un utilisateur
    public static void afficherInfoUtilisateur(Utilisateur usr)
    {
        Console.WriteLine($"nom d'utilisateur {usr.getNomUser}");
    }

    // fonction pour modifier les infos sur un utilisateur
    public static void modifierInfoUtilisateur()
    {
        
    }

    // fonction pour creer un nouvel utilisateur
    public static void creerUtilisateur()
    {
        
    }

    // fonction pour changer d'utilisateur
    public static void changerUtilisateur()
    {
        
    }

    // fonction pour supprimer un utilisateur
    public static void supprimerUtilisateur()
    {
        
    }

    public static void menu()
    {
        Console.WriteLine("1. Ajouter un contact");
        Console.WriteLine("2. Supprimer un contact");
        Console.WriteLine("3. Afficher les contacts");
        Console.WriteLine("4. Modifier un contact");
        Console.WriteLine("5. Afficher les info d'un contact");
        // Console.WriteLine("6. Afficher les infos d'un utilisateur");
        // Console.WriteLine("7. Modifier les infos d'un utilisateur");
        // Console.WriteLine("8. Créer un utilisateur");
        // Console.WriteLine("9. Changer d'utilisateur");
        // Console.WriteLine("10. Supprimer un utilisateur");
        Console.WriteLine("6. help");
        Console.WriteLine("7. quitter");
    }
    
    public static void Main(string[] args)
    {
        List<Contact> carnet = new List<Contact>();
        int choix = 0;
        int num;
        while (choix != 7)
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
                    afficherHelp();
                    break;
            }
        }
    }
}