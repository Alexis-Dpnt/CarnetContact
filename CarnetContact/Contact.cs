namespace CarnetContact;

public class Contact
{
    private String nom;
    private String prenom;
    private String email;
    private int num;

    public Contact(String nom, String prenom, String email, int num)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.email = email;
        this.num = num;
    }

    public String getNom()
    {
        return this.nom;
    }

    public String getPrenom()
    {
        return this.prenom;
    }

    public String getEmail()
    {
        return this.email;
    }

    public int getNum()
    {
        return this.num;
    }

    public void setNom(String nom)
    {
        this.nom = nom;
    }

    public void setPrenom(String prenom)
    {
        this.prenom = prenom;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    public void setNum(int num)
    {
        this.num = num;
    }
    
}