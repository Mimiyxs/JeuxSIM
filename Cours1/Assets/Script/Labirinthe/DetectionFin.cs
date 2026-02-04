using UnityEngine;

public class DetectionFin : MonoBehaviour
{

    // Le joueur qu on surveille, quand il tombe dans la boite on le replace
    [SerializeField]
    private GameObject joueur;

    private float tempsAttente = 0;
    private bool attenteDemarree = false;

    private MouvementJoueur scriptMouvement;

    void Update()
    {
        if (attenteDemarree)
        {
            tempsAttente += Time.deltaTime;
        }

        if (tempsAttente > 2)
        {
            // On remet l attente a zero
            tempsAttente = 0;
            attenteDemarree = false;

            if (scriptMouvement == null)
            {
                scriptMouvement = joueur.GetComponent<MouvementJoueur>();
            }
            scriptMouvement.replacerJoueur();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == joueur)
        {
            Debug.Log("Le joueur est dedans, on le replace");
            attenteDemarree = true;
        }
    }
}
