using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueur : MonoBehaviour
{

    private InputAction _move;
    private Rigidbody sphereRigidbody;
    private Vector3 positionDepart;


    // Serializefield permet de donner une valeur dans Unity 
    [SerializeField] private float niveauForce = 5;

    private void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        positionDepart = transform.position;

        _move = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {

        //pusique le clavier est dans l'autre sens, il faut inversé les angles et les touches.
        Vector2 mouvementApplique = -_move.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvementApplique.x, 0, mouvementApplique.y);
        force *= niveauForce;
        sphereRigidbody.AddForce(force);
    }

    public void replacerJoueur()
    {
        transform.position = positionDepart;
        sphereRigidbody.linearVelocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;
    }
}
