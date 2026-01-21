using UnityEngine;

public class exercise1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int Scale;
    void Start()
    {
        var depart = new Vector3(3,3,3);

        //var Scale = transform.localScale = depart ;
        Debug.Log("Sale" + Scale);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
s