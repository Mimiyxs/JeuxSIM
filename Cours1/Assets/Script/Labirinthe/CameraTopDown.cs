using UnityEngine;

public class CameraToDown : MonoBehaviour
{
    [SerializeField]
    private GameObject joueur;

    [SerializeField]
    private float hauteur;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlacerCamera();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlacerCamera();
    }

    private void PlacerCamera()
    {
        float positionX = joueur.transform.position.x;
        float positionZ = joueur.transform.position.z;
        transform.localPosition = new Vector3(positionX, hauteur, positionZ);
    }
}
