using UnityEngine;

public class Projection : MonoBehaviour
{
    [SerializeField] private float forceProjecter;
    [SerializeField] private Vector3 directionProjecter;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        //Projecter dirrection haut et instantané 
        rb.AddForce(Vector3.up *  forceProjecter, ForceMode.Impulse);
    }
}
