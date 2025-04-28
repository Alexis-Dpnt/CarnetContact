namespace CarnetContact;

public class Contact
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public int Num { get; set; }

    public Contact(String nom, String prenom, String email, int num)
    {
        this.Nom = nom;
        this.Prenom = prenom;
        this.Email = email;
        this.Num = num;
    }

    public String getNom()
    {
        return Nom;
    }

    public String getPrenom()
    {
        return this.Prenom;
    }

    public String getEmail()
    {
        return this.Email;
    }

    public int getNum()
    {
        return this.Num;
    }

    public void setNom(String nom)
    {
        this.Nom = nom;
    }

    public void setPrenom(String prenom)
    {
        this.Prenom = prenom;
    }

    public void setEmail(String email)
    {
        this.Email = email;
    }

    public void setNum(int num)
    {
        this.Num = num;
    }
    
}