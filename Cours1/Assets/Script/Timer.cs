using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject Gameobjc;

    [SerializeField] private TMP_Text textTime;
    private int timeValue;
    void Start()
    {
        timeValue = 0;
        textTime = gameObject.AddComponent<TMP_Text>();
        textTime.text = "Timer : " + timeValue.ToString();
    }

    private float tempTime;
    // Update is called once per frame
    void Update()
    {

        tempTime += Time.deltaTime;
        if (tempTime >= 1) {
            timeValue++;
            textTime.text = "Timer : " + timeValue.ToString();

        }
        
    }
}
