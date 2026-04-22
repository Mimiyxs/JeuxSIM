using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class Villageois : MonoBehaviour
{
    private int or;
    private int plantes;
    private int roches;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent _navMeshAgent;
    
    [SerializeField] private TMP_Text texteOr;
    [SerializeField] private TMP_Text textePlantes;
    [SerializeField] private TMP_Text texteRoches;

    private StrategieChoixRessource strategieChoix;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        strategieChoix = new StrategieChoixHasard();
    }

    private void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            AllerVersNouvelleRessource();
        }
        else if (numeroRessourceChoisie != -1 && Vector3.Distance(_navMeshAgent.destination, transform.position) < 1.4f)
        {
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

            var ressource = objet.GetComponent<Ressource>();
            if (ressource.Type == TypeRessource.Or)
                or++;
            else if (ressource.Type == TypeRessource.Plante)
                plantes++;
            else if (ressource.Type == TypeRessource.Roche)
                roches++;

            MiseAJourTextes();
            
            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            
            AllerVersNouvelleRessource();
        }
    }

    private void MiseAJourTextes()
    {
        texteOr.text = "Or: " + or;
        textePlantes.text = "Plantes: " + plantes;
        texteRoches.text = "Roches: " + roches;
    }

    public void ChargerStrategieChoix(StrategieChoixRessource strategie)
    {
        strategieChoix =  strategie;
        AllerVerLeProchainsRessources();
    }

    private void AllerVerLeProchainsRessources()
    {
        List<Ressource> ressource = GameManager.Instance.ressources;
        if (ressource.Count == 0) {
            numeroRessourceChoisie = -1;

        }
        

    }

    //private void AllerVersNouvelleRessource()
    //{
    //    // Choix au hasard
    //    int nbRessourcesDisponibles = GameManager.Instance.NbRessourcesDisponibles;

    //    if (nbRessourcesDisponibles == 0)
    //    {
    //        numeroRessourceChoisie = -1;
    //    }
    //    else
    //    {
    //        numeroRessourceChoisie = ChoisirRessource(GameManager.Instance.Ressources, GameManager.Instance.NbRessourcesDisponibles);

    //        var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

    //        _navMeshAgent.destination = objet.transform.position;
    //    }
    //}

    // TODO : Cette fonction devrait faire partie d'une des classes de votre patron Stratégie au lieu de faire partie du villageois
    //private int ChoisirRessource(Ressource[] ressources, int nbRessourcesDisponibles)
    //{
    //    return Random.Range(0, nbRessourcesDisponibles);
    //}

    //private StrategieChoixHasard strategieChoixHasard;
    //private StrategieChoixEquilibre strategieChoixEquilibre;
    //private StrategieChoixPlusProche strategieChoixPlusProche;

    //public void onChoixHasard()
    //{
    //    strategieChoixHasard = new StrategieChoixHasard();
    //    strategieChoixHasard.ChoisirRessource(this, GameManager.);
    //}
}