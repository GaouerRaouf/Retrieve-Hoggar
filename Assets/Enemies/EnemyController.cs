using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public GameObject swordOn;
    public GameObject swordOff;
    public bool swordOut = false;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float attackDistance;
    private Transform target;
    public Sword sword;
    // Start is called before the first frame update
    void Start()
    {
        swordOut = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sword = swordOn.GetComponent<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if(Vector3.Distance(transform.position, target.position) < attackDistance)
            {
                Attack();
            }   
        }
    }

    public void Attack()
    {
        transform.LookAt(target);
        animator.SetTrigger("Attack");
    }


    public void StartAttack()
    {
        if(!swordOut) {
            animator.SetTrigger("Attack0");
            swordOff.SetActive(false);
            swordOn.SetActive(true);
        }
        

    }
    public void StartChasing(Collider navTarget)
    {
        if(swordOut)
        {
            print("iiii");
            target = navTarget.transform;
            navMeshAgent.SetDestination(target.position);
        }
    }

    public void ReceiveDamage()
    {
        animator.SetTrigger("Hit");
        
    }
    public void Die()
    {
        animator.SetTrigger("Die");
        navMeshAgent.isStopped = true;
        GetComponent<FieldOfView>().enabled = false;
        GameManager.instance.CheckWin();
        Destroy(gameObject, 3f);
    }

    public void AttackWithSword()
    {
        sword.isAttacking = true;   
        swordOn.GetComponent<Collider>().isTrigger = true;
    }

    public void StopAttackWithSword()
    {
        swordOn.GetComponent<Collider>().isTrigger = false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * attackDistance, Color.red);
        
    }
}
