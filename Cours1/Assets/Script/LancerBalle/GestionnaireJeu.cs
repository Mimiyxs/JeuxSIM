using TMPro;
using UnityEngine;


//Class observateur 
public class GestionnaireJeu : MonoBehaviour
{
    //La balle
    [SerializeField] private GameObject balle;

    //Zone arrivee
    [SerializeField] private ZoneArrivee2 zone;

    private Vector3 positionDepart;


    //Pointage 
    [SerializeField] private TMP_Text textPoint;
    private int points; 



    void Start()
    {
     
        points = 0;
        zone.zoneAtteint += AugementerPoint;
        zone.zoneAtteint += DupliquerBalle;
        
        positionDepart = balle.transform.position;
        textPoint.text = "Points : " + points.ToString();


    }

    private void AugementerPoint()
    {
        points++;
        textPoint.text = "Points : " + points.ToString();
    }

    private void DupliquerBalle()
    {
        GameObject nouvelleBalle = Instantiate(balle, positionDepart, Quaternion.identity);

        Destroy(balle.GetComponent<Mouv_Mod2>());
        zone.ball = nouvelleBalle;
        balle = nouvelleBalle;
    }
}
