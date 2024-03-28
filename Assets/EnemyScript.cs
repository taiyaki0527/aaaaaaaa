using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float dis;
    private GameObject target;
    Animator animator;
   
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(target.transform.position, transform.position);
        transform.LookAt(target.transform);
        if (dis <= 50 && dis>30)
        {
            animator.SetBool("walk", true);
            transform.position += transform.forward * speed;

        } 
        else if (dis <= 30 && dis>1)
        {
            animator.SetBool("walk", false);
            animator.SetBool("Run", true);
            speed = 0.05f;

        }
        else if (dis <= 1)
        {
            speed = 0;

            animator.SetBool("Basic Attack", true);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
