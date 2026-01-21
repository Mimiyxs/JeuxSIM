using UnityEngine;

public class Arrondir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale: " + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
