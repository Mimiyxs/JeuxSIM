using UnityEngine;
using UnityEngine.InputSystem;

public class Balancer : MonoBehaviour
{
    private InputAction _move;
    private Rigidbody platoforme;
    [SerializeField] private Rigidbody BIGBALLS;
    [SerializeField] private float niveauForce;
    private Vector3 positionDepart;

    void Start()
    {
        positionDepart = BIGBALLS.transform.localPosition ;
        _move = InputSystem.actions.FindAction("Move");
        platoforme = GetComponent<Rigidbody>();
        BIGBALLS = GetComponent<Rigidbody>(); 

    }

    private void Update()
    {
      if(BIGBALLS.position.y < -15f) {

            replacerJoueur();
        }

    }



    private void FixedUpdate()
    {
        Vector2 mouvementApplique = _move.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvementApplique.x, 0, mouvementApplique.y);
        force *= niveauForce;
        platoforme.AddTorque(force);
    }

    public void replacerJoueur()
    {
        BIGBALLS.transform.position = positionDepart;
        BIGBALLS.linearVelocity = Vector3.zero;
        BIGBALLS.angularVelocity = Vector3.zero;
    }
}
