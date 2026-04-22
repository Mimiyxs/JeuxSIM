using System;
using System.Collections.Generic;

public class StrategieChoixHasard : StrategieChoixRessource
{

    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        return UnityEngine.Random.Range(0, ressources.Count); // Retourne un index aléatoire entre 0 et le nombre de ressources disponibles       
    }


}

