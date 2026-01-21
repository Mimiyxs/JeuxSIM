using UnityEngine;

public class Arrondir : MonoBehaviour
{
    private bool arrondiActif = true; //Variable pour activer ou désactiver l'arrondisement

    private Vector3 vCroissance = new Vector3(0.1f, 0.1f, 0.1f); // Vecteur de croissance

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    { 
        // magnitude = longeur de l'objet
        if (transform.localScale.magnitude >= 8.0f)
        {
            arrondiActif = false;
        }
        else if(transform.localScale.magnitude <= 2.0f)
        {
            arrondiActif = true;
        }

        // Appliquer l'arrondisement
        if (arrondiActif)
        {
            transform.localScale += vCroissance *Time.deltaTime ;
        }
        else
        {
            transform.localScale -= vCroissance * Time.deltaTime;
        }
    }
}
