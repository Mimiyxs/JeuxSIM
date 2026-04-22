using UnityEngine;
using System.Collections.Generic;

public abstract class StrategieChoixRessource : MonoBehaviour
{
    public abstract int ChoisirRessource(Villageois villageois,List <Ressource> ressources);
}
