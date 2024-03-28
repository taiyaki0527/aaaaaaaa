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
        animator.SetBool("walk", true);
        transform.LookAt(target.transform);
        if (dis < 50)
        {
            transform.position += transform.forward * speed;
            if (dis < 30)
            {
                speed = 0.05f;

            }
        }
            
        if (dis <= 50)
        {
            animator.SetBool("walk", true);

        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (dis <= 30)
        {
            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
