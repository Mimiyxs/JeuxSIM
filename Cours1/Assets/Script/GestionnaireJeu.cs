using TMPro;
using UnityEngine;


//Class observateur 
public class GestionnaireJeu : MonoBehaviour
{
    //La balle
    [SerializeField] private GameObject balle;

    
    private Vector3 positionDepart;


    //Pointage 
    [SerializeField] private TMP_Text textPoint;
    private int points; 

    //Zone 
    [SerializeField] private ZoneArrivee zone;


    void Start()
    {
     
        points = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
