using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
public class slowTeleport : MonoBehaviour
{
    // teleporter le personnage dans le point où le joueur a cliqué.
    [SerializeField] GameObject personnage;
    [SerializeField] GameObject plane;


    [SerializeField]  float moveSpeed;
    [SerializeField] float rotationSpeed;

    private Coroutine coroutine;
    private Vector3 objectif;

    
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit rayHit))
            {
                if (rayHit.collider.gameObject == plane)
                {

                    if (coroutine != null) StopAllCoroutines();

                    objectif = rayHit.point;
                    objectif.y = personnage.transform.position.y;

                    Vector3 direction = (objectif - personnage.transform.position).normalized;
                    coroutine = StartCoroutine(DeplacerPerso(direction));
                   
                }



            }
        }
    }

    IEnumerator DeplacerPerso(Vector3 direction)
    {
        var step = moveSpeed * Time.deltaTime;

        Quaternion rotationFinale = Quaternion.LookRotation(direction);

        while(Quaternion.Angle(personnage.transform.rotation, rotationFinale) > 0.01f)
        {
            float rotationApply = rotationSpeed ;
            personnage.transform.rotation = Quaternion.RotateTowards(personnage.transform.rotation, rotationFinale, rotationApply);
            yield return null;
        }
        float tempsEcoule = 0f;
        while (tempsEcoule < 0.5f)
        {
            tempsEcoule += Time.deltaTime;
            yield return null;
        }
        while ((personnage.transform.position - objectif).magnitude > 0.5f)
        {
            
            personnage.transform.position += moveSpeed * direction * Time.deltaTime;

            yield return null;
        }
        
    }
}
