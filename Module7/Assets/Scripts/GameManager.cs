using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabsRessources;

    [SerializeField]
    private int nbRessources;

    [SerializeField]
    private Villageois villageois; // Exercice 3

    [HideInInspector]
    public List<Ressource> ressources;

    public static GameManager Instance;

    private string nomFichierSauvegarde; // Exercice 3

    void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    void Start()
    {
        // Exercice 3
        //Définit le chemin du fichier de sauvegarde et charge l'état du jeu s'il existe
        nomFichierSauvegarde = Application.persistentDataPath + "/etat-jeu.json";

        ChargerEtatJeu(); // Récupèr les scores sauvegarés.

        // Exercice 2
        ChargerStrategie(); // Récupèr la stratégie choisie par l'utilisateur
    }

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources(nbRessources);
        }
    }

    // Exercice 3
    // Sauvegarde l'état du jeu lorsque l'application est quittée
    void OnApplicationQuit()
    {
        SauvegarderEtatJeu();
    }

    private void CreerRessources(int nb)
    {
        for (int i = 0; i < nb; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int indexAleatoire = Random.Range(0, prefabsRessources.Count);
            GameObject ressourceAleatoire = Instantiate(prefabsRessources[indexAleatoire], position, Quaternion.identity);
            ressources.Add(ressourceAleatoire.GetComponent<Ressource>());
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        ressources.Remove(ressource);
    }

    // Exercice 3
    private void SauvegarderEtatJeu()
    {
        // Crée un objet EtatJeu avec les données actuelles du jeu
        EtatJeu etatJeu = new EtatJeu
        {
            orCollecte = villageois.or,
            plantesCollecte = villageois.plantes,
            rochesCollecte = villageois.roches,
            ressourcesRestantes = ressources.Count
        };

        //On transforme l'objet EtatJeu en format JSON et on l'écrit dans un fichier de sauvegardes
        string json = JsonUtility.ToJson(etatJeu);
        File.WriteAllText(nomFichierSauvegarde, json); //Sauvegarde de l'état du jeu dans un fichier
    }

    // Exercice 2
    private void ChargerStrategie()
    {
        // Récupère la stratégie choisie par l'utilisateur à partir des PlayerPrefs (clé, valeur)
        // 0 = Hasard (par defaut), 1 = Proche, 2 = Equilibre
        int type = PlayerPrefs.GetInt("TypeStrategie", 0);

        StrategieChoixRessource strategieChoix;

        switch ((TypeStrategie)type)
        {
            case TypeStrategie.Hasard:
                strategieChoix = new StrategieChoixHasard();
                break;
            case TypeStrategie.Proche:
                strategieChoix = new StrategieChoixPlusProche();
                break;
            default:
                strategieChoix = new StrategieChoixEquilibre();
                break;
        }

        villageois.ChangerStrategieChoix(strategieChoix);
    }

    // Exercice 3
    private void ChargerEtatJeu()
    {
        if (File.Exists(nomFichierSauvegarde))
        {
            string json = File.ReadAllText(nomFichierSauvegarde);
            EtatJeu etatJeu = JsonUtility.FromJson<EtatJeu>(json);

            villageois.or = etatJeu.orCollecte;
            villageois.plantes = etatJeu.plantesCollecte;
            villageois.roches = etatJeu.rochesCollecte;
            villageois.MiseAJourTextes();

            CreerRessources(etatJeu.ressourcesRestantes);
        }
        else
        {
            CreerRessources(nbRessources);
        }
    }
}