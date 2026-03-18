using UnityEditor;
using UnityEngine;

public class Controleur : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Quitter()
    {
#if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
