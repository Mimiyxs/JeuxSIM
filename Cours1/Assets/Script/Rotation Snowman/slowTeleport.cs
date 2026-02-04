using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class slowTeleport : MonoBehaviour
{
    // teleporter le personnage dans le point où le joueur a cliqué.
    [SerializeField] GameObject personnage;
    [SerializeField] GameObject plane;

    public RaycastHit rayHit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //var mousePosition = Mouse.current.position.ReadValue();
            //var ray = Camera.main.ScreenPointToRay(mousePosition);
            //RaycastHit rayHit;



            // if (Physics.Raycast(ray, out rayHit))
            // {

            //    if(rayHit.collider.gameObject == plane)
            //    {
            //       personnage.transform.position =  new Vector3(rayHit.point.x, personnage.transform.position.y, rayHit.point.z);
            //   }

            // }

            StartCoroutine(TeleporterPerso());
        }
    }

    IEnumerator TeleporterPerso()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {

            if (rayHit.collider.gameObject == plane)
            {
                personnage.transform.position = new Vector3(rayHit.point.x, personnage.transform.position.y, rayHit.point.z);
            }


            
        }
        yield return new WaitForSecondsRealtime(5);
    }
}
