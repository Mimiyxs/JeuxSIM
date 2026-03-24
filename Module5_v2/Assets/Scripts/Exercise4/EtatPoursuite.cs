using UnityEngine;

public class EtatPoursuite : EtatEnnemis
{
    public EtatPoursuite(ComportementObjet _sujet) : base(_sujet)
    {
    }
    public override void Enter()
    {
        sujet.animateur.SetBool("Walk", true);
    }
    public override void Executer(float timer)
    {

        Vector3 positionJoueur = sujet.joueur.transform.position;
        Vector3 positionEnnemi = sujet.transform.position;
        float distanceJoueur = (positionJoueur - positionEnnemi).magnitude;

        if (distanceJoueur < 2.5f)
        {
            sujet.ChangerEtat(sujet.etatAttaque);
        }
        else if (!sujet.JoueurIsVisible())
        {
            sujet.ChangerEtat(sujet.etatAttente);
        }
        else
        {
            sujet.agent.SetDestination(positionJoueur);
        }
    }
}
