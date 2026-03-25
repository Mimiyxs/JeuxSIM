using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;

    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
    }

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;

        if (_pointsDeVie <= 0)
        {
            ComportementEnnemi mourant = GetComponent<ComportementEnnemi>();
            GetComponent<ComportementEnnemi>().ChangerEtat(new EtatMort(mourant));
        }
    }
}
