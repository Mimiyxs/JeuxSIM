using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject balle;

    private MouvementJoueur scriptMouvement;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == balle)
        {
            Debug.Log("Le joueur est dedans, on le replace");
        }
        scriptMouvement.replacerJoueur();
    }
}
