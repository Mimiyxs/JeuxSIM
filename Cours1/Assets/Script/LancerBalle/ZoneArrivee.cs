using TMPro;
using UnityEngine;

public class ZoneArrivee : MonoBehaviour
{
    [SerializeField] private GameObject balle;

    //position pour la nouvelle balle à déterminer dans unity
    [SerializeField] private Vector3 positionDepart;

    //Zone de point 
    [SerializeField] private TMP_Text textPoint;

    private int points;
    void Start()
    {
        points = 0;
        textPoint.text = "Points: .....";
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == balle)
        {
            Debug.Log("Le joueur est dedans, on le replace");

            points++;
            textPoint.text = "Points : "+points.ToString();
            DupliquerBalle();
        }
    }

    private void DupliquerBalle() {

        GameObject nouvelleBalle = Instantiate(balle, positionDepart, Quaternion.identity); 

        //quand la balle est dans le zone, désactivé le fonction bouger (script mouvement)
        Destroy(balle.GetComponent<Mouv_Mod2>());

        balle = nouvelleBalle;
    }
}
