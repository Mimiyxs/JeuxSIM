using UnityEngine;
using System.Collections.Generic;
public class StrategieChoixEquilibre : StrategieChoixRessource
{
    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        int indexMax = 0;

        // Calculer la valeur ajustée pour la première ressource
        float distanceMax = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);
        float valeurMax = ressources[0].Valeur / (distanceMax * distanceMax);

        // Parcourir les ressources pour trouver celle avec la meilleure valeur ajustée
        for(int i = 1; i < ressources.Count; i++)
        {
            // Calculer la distance entre le villageois et la ressource courante (i)
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            float valeur = ressources[i].Valeur / (distance * distance);

            // Si la valeur ajustée de la ressource courante est supérieure à la valeur maximale actuelle, mettre à jour la valeur maximale et l'index
            if (valeur > valeurMax)
            {
                valeurMax = valeur;
                indexMax = i;
            }
        }
        return indexMax;
    }
}
    
