using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Patrouille : MonoBehaviour
{
    [SerializeField] private List<Transform> pointPatrouilles;
    private NavMeshAgent agent;
    private Animator animateur;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        animateur.SetBool("Walk", true);
        ChoisirPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f) ChoisirPoint();
        
    }

    private void ChoisirPoint()
    {
        int nombre = Random.Range(0, pointPatrouilles.Count);

        //point dans le liste
        Vector3 pointSelect = pointPatrouilles[nombre].transform.position;
        agent.SetDestination(pointSelect);
    }
}
