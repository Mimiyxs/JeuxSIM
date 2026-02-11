using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [SerializeField] GameObject bras1;
    [SerializeField] GameObject bras2;

    public float rotationSpeed = 10f;
    private float currentAngle = 0f;
    private int currentRotation_direction = 1;


    void Update()
    {

        bras1.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * currentRotation_direction);
        bras2.transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * currentRotation_direction);

        //mettre à jour l'angle actuel avec la vitess du bras, la vitesse de rotation et le temps écoulé
        currentAngle += rotationSpeed * Time.deltaTime * currentRotation_direction;

        if (currentAngle >= 45f)
        {
            currentRotation_direction = -1;
        }
        else if (currentAngle <= -45f)
        {
            currentRotation_direction = 1;
        }

    }
}
