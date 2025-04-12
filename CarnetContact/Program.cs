using System.ComponentModel.DataAnnotations.Schema;
using CarnetContact;

/******************************************************* A FAIRE *******************************************************
 - apporter modifications pour qu'il y ait une creation d'utilisateur pour avoir des listes personnelles
 - faire en sorte que quand on se connecte a un utilisateur ca enregistre les contacts dans son dossier
 - regarder si un fichier user existe sinon en creer un nouveau et demander le nom qu'on lui donne
 - coder la fonction supprimerContact
 - coder la fonction afficherInfoUtilisateur
 - peut etre coder une fonction qui liste tout les utilisateurs (regarder le nombre de dossier dans utilisateur)
*/
public class Program
{
    
    // a coder pour que ca génere un nombre random qui n'existe pas deja
    public static int definirId()
    {
        int id = 1;
        return id;
    }
    
    // fonction pour ajouter les contacts au carnet
    public static void ajouterContact(List<Contact> carnet)
    {
        Console.WriteLine("entre le nom du contact");
        String nom = Console.ReadLine();
        Console.WriteLine("entre le prenom du contact");
        String prenom = Console.ReadLine();
        Console.WriteLine("entre le mail du contact");
        String email = Console.ReadLine();
        int id = definirId();
        Contact newContact = new Contact(nom, prenom, email, 1);
        carnet.Add(newContact);
    }
    
    // fontcion pour afficher tout les contacts
    public static void afficherContacts(List<Contact> contacts)
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + contacts[i].getNom());
        }
    }

    // fonction pour afficher les infos de 1 contact
    public static void afficherInfoContact(Contact contact)
    {
        Console.WriteLine("Nom : " + contact.getNom());
        Console.WriteLine("Prenom : " + contact.getPrenom());
        Console.WriteLine("Mail : " + contact.getEmail());
        Console.WriteLine("Numero : " + contact.getNum());
    }

    public static Contact compteTrouver(Contact contact, List<Contact> carnet)
    {
        foreach (Contact c in carnet)
        {
            if (c.getNom() == contact.getNom())
                return c;
        }
        return null;
    }
    
    // fonction pour chercher un contact dans le carnet
    public static void chercherContacts(List<Contact> carnet)
    {
        Console.WriteLine("quelle est le numero du contact que tu cherche");
        int num = int.Parse(Console.ReadLine());
        int count = 0;
        foreach (var contact in carnet)
        {
            if (contact.getNum() == num)
            {
                afficherInfoContact(contact);
                count++;
            }
        }
        if (count == 0)
            Console.WriteLine("le contact n'existe pas");
    }

    // fonction pour supprimer des contacts
    public static void supprimerContacts(Contact contact, List<Contact> carnet)
    {
        
    }

    // fonction pour modifier des contacts
    public static void modifierContacts(List<Contact> carnet)
    {
        Console.WriteLine("entre le numerot du contact que tu veux modifier");
        int num = int.Parse(Console.ReadLine());
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
                            supprimerContacts(contact, carnet);
                            ajouterContact(carnet);
                            break;
                    }
                }
            }
        }
    }

    // fonction pour afficher les infos sur un utilisateur
    public static void afficherInfoUtilisateur()
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
        Console.WriteLine("6. help");
        Console.WriteLine("7. quitter");
    }
    
    public static void Main(string[] args)
    {
        List<Contact> carnet = new List<Contact>();
        int choix = 0;
        while (choix != 7)
        {
            menu();
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                
            }
        }
    }
}