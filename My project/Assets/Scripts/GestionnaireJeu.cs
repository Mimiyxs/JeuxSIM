using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class VerrouillerSouris : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}
