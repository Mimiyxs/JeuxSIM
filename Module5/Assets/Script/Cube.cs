using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private InputAction _espace;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _espace = InputSystem.actions.FindAction("Jump");
        navMeshAgent.destination = new Vector3(5.46999979f, 0.439999998f, -5.59000015f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_espace.IsPressed())
        {

        }
    }
}
