using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    float dis;
    public static float enemyHP;
    private GameObject target;
    Animator animator;
    bool isDeath = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 100;
        speed = 0.025f;
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(target.transform.position, transform.position);
        if (enemyHP > 0)
        {
            transform.LookAt(target.transform);
        }
        
        if (enemyHP <= 0)
        {
            speed = 0;
           
        }
        else if (dis <= 50 && dis>30)
        {
            animator.SetBool("walk", true);
            transform.position += transform.forward * speed;

        } 
        else if (dis <= 30 && dis>10)
        {
            animator.SetBool("walk", false);
            animator.SetBool("Run", true);
            speed = 0.05f;
            transform.position += transform.forward * speed;

        }
        else if (dis <= 10)
        {
            speed = -0.05f;

            animator.SetBool("Attack", true);
            speed = -0.05f;
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run",false);
            animator.SetBool("walk", false);
            speed = 0f;
        }
        if (enemyHP <= 0 && isDeath== false)
        {
            Debug.Log("d");
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            animator.SetBool("walk", false);
            animator.SetTrigger("Death");
            isDeath = true;
            speed = 0;
            StartCoroutine(DelayCoroutine());
        }
       
    }
    private IEnumerator DelayCoroutine()
    {
       

        // 3•bŠÔ‘Ò‚Â
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Clear");

    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
