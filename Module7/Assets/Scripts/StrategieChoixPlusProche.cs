using System;
using System.Collections.Generic;
using UnityEngine;

public class StrategieChoixPlusProche : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        int indexPlusProche = 0;
        // On initialise la distance plus proche avec la première ressource
        float distancePlusProche = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);

        // On parcourt les ressources restantes pour trouver la plus proche
        for (int i = 1; i < ressources.Count; i++)
        {
            // On calcule la distance entre le villageois et la ressource courante (i)
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);

            // Si la distance courante est plus petite que la distance plus proche, on met à jour l'index et la distance plus proche
            if (distance < distancePlusProche)
            {
                indexPlusProche = i;
                distancePlusProche = distance;
            }
        }
        return indexPlusProche; // On retourne l'index de la ressource la plus proche
    }
}

