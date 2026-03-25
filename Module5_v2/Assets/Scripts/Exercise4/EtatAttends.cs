using UnityEngine;

public class EtatAttends : EtatEnnemis
{
    public EtatAttends(ComportementObjet _sujet) : base(_sujet)
    {
    }

    private float tempsAttente = 0f;

    public override void Enter()
    {
        sujet.animateur.SetBool("Walk", false);
        tempsAttente = Random.Range(3f, 5f);
    }
    public override void Executer(float timer)
    {
        tempsAttente -= timer;
        if (tempsAttente < 0f)
        {
            sujet.ChangerEtat(sujet.etatPatrouille);
        }
    }

}
