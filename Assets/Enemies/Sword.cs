using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{


    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (isAttacking && health != null && health.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(10f);
            isAttacking = false;
        }
    }
}
