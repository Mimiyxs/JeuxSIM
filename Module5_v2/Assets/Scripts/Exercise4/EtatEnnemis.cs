public abstract class EtatEnnemis 
{
    public ComportementObjet sujet;
    public EtatEnnemis(ComportementObjet _sujet)
    {
        sujet = _sujet;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public abstract void Executer();
}
