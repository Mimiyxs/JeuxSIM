using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [SerializeField] GameObject bras1;
    [SerializeField] GameObject bras2;

    public float rotationSpeed = 10f;
    void Start()
    {
        //bras1 = GetComponent<GameObject>();
        //bras2 = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        bras1.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        bras2.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
