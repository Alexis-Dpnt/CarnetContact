namespace CarnetContact;

public class Utilisateur
{
    private String nomUser;

    public Utilisateur(String nomUser)
    {
        this.nomUser = nomUser;
    }

    public String getNomUser()
    {
        return nomUser;
    }
}