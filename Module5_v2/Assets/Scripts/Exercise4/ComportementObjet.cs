using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportementObjet : MonoBehaviour
{
    [SerializeField] public GameObject joueur;
    
    [SerializeField] public List<Transform> pointPatrouilles;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animateur;

    private EtatEnnemis etatEnnemis;

    public EtatPatrouille etatPatrouille;
    public EtatPoursuite etatPoursuite;
    public EtatAttends etatAttente;
    public EtatAttaque etatAttaque;

    void Start()
    {
        etatPatrouille = new EtatPatrouille(this);
        etatPoursuite = new EtatPoursuite(this);
        etatAttente = new EtatAttends(this);
        etatAttaque = new EtatAttaque(this);

        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        etatEnnemis = etatPatrouille;
        etatEnnemis.Enter();

    }

    private void Update()
    {
        etatEnnemis.Executer(Time.deltaTime);
    }

    public void ChangerEtat(EtatEnnemis nouvelEtat)
    {
        etatEnnemis.Exit();
        etatEnnemis = nouvelEtat;
        etatEnnemis.Enter();
    }

    public bool JoueurIsVisible()
    {
        //Direction du joueur 
        Vector3 positionJoueur = joueur.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, positionJoueur);

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
