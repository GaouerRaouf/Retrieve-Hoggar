using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public GameObject swordOn;
    public GameObject swordOff;
    private bool swordOut = false;
    [SerializeField] private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAttack(Collider target)
    {
        if(!swordOut) {
            animator.SetTrigger("Attack0");
            swordOff.SetActive(false);
            swordOn.SetActive(true);
            swordOut = true;
        }
        animator.SetBool("Run", true);
        navMeshAgent.SetDestination(target.transform.position);
    }

}
