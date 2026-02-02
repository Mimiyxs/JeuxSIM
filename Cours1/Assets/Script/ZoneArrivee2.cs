using System;
using UnityEngine;

public class ZoneArrivee2 : MonoBehaviour
{
    public event Action zoneAtteint;
    public GameObject ball;

    private void OnCollisionEnter (Collision other)
    {
        if(other.gameObject == ball)
        {
            zoneAtteint?.Invoke ();
        }
    }
}
