using UnityEngine;

public class EtatAttaque : EtatEnnemis
{
    public EtatAttaque(ComportementObjet _sujet) : base(_sujet)
    {
    }

    public override void Enter()
    {
        sujet.animateur.SetTrigger("Attack");
    }

    public override void Executer(float timer)
    {
        Vector3 positionJoueur = sujet.joueur.transform.position;
        Vector3 positionEnnemi = sujet.transform.position;
        float distanceJoueur = (positionJoueur - positionEnnemi).magnitude;

        if (distanceJoueur > 2.5f)
        {
            sujet.ChangerEtat(sujet.etatAttente);
        }
    }

}
