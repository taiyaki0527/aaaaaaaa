using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            EnemyScript.enemyHP--;
            Debug.Log("enemyHP"+EnemyScript.enemyHP);
        }
    }
}
