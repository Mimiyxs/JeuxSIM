using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportementObjet : MonoBehaviour
{
    [SerializeField] GameObject joueur;
    
    [SerializeField] public List<Transform> pointPatrouilles;
    public NavMeshAgent agent;
    public Animator animateur;

    private EtatEnnemis etatEnnemis;

    public EtatPatrouille etatPatrouille;
    //public EtatPoursuite etatPoursuite;
    //public EtatAttente etatAttente;
    //public EtatAttaque etatAttaque;

    void Start()
    {
        etatEnnemis = etatPatrouille;
        etatEnnemis.Enter();

        
    }

    //Detecte si le joueur est à 2.5m de distance 

    public bool JoueurIsVisible()
    {
        Vector3 positionJoueur = joueur.transform.position - transform.position;
        float angle = Vector3.Angle(transform.position, positionJoueur);

        if(angle < 60f)
        {
            if (Physics.Raycast(transform.position, positionJoueur, out RaycastHit hit))
            {
                if (hit.collider.gameObject == joueur)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
