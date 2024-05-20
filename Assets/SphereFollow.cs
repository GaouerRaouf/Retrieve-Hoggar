using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFollow : MonoBehaviour
{
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemy!=null)
        {
            transform.position = enemy.position + new Vector3(0,30,0);
        }
        else
        {
            Destroy(gameObject);
        }

        
        
    }
}
