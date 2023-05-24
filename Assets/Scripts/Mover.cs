
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

public class Mover : MonoBehaviour
{
    

    private NavMeshAgent navMeshAgent;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float stoppingDistance = 0.3f;

    bool isRunning=false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        GetComponent<Animator>().SetBool("isRunning", isRunning);
    }
    public void MoveTo(Vector3 destination)
    {   isRunning = true;
        if (Vector3.Distance(destination, transform.position) > 0.5f)
        {
            transform.LookAt(destination);
        }

        navMeshAgent.destination = destination;
        navMeshAgent.speed = maxSpeed;
        navMeshAgent.isStopped = false;
    }

    public void CancelMoveAction()
    {
        isRunning = false;
        navMeshAgent.isStopped = true;
    }

}
