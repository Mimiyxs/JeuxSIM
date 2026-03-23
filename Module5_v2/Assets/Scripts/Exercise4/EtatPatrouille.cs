using UnityEngine;

public class EtatPatrouille : EtatEnnemis
{
    public EtatPatrouille(ComportementObjet _sujet) : base(_sujet)
    {
    }
    public override void Enter()
    {
        sujet.animateur.SetBool("Walk", true);
        ChoisirPoint();
    }

    public override void Executer()
    {
        if (sujet.JoueurIsVisible())
        {
            //sujet.ChangerEtat(sujet.etatPoursuivre);
        }
        else if (sujet.agent.remainingDistance < 0.5f) ChoisirPoint();
    }

    private void ChoisirPoint()
    {
        int nombre = Random.Range(0, sujet.pointPatrouilles.Count);

        //point dans le liste
        Vector3 pointSelect = sujet.pointPatrouilles[nombre].transform.position;
        sujet.agent.SetDestination(pointSelect);
    }
}
