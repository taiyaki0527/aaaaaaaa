using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
     


public class PlayerScript : MonoBehaviour
{
    
    int currentHp;
    Vector3 movingDirecion;
    public float speedManager;
    public float gravityPower;
    public Rigidbody rb;
    private Vector3 movingVelocity;
    public float jumpPower;
    private bool jumpNow = true;
    public float HP=30;
    int maxHp = 30;
    public Slider slider;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        Debug.Log(jumpNow);
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movingDirecion = new Vector3(x, 0, z);
        movingDirecion.Normalize();
        movingVelocity = movingDirecion * speedManager;
    }
    Vector3 latestPos;
    private void FixedUpdate()
    {
        Gravity(); 
        if (jumpNow == true) return;
        rb.velocity = new Vector3(movingVelocity.x*15, 0, movingVelocity.z*15);
        Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
        latestPos = transform.position;
        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            if (movingDirecion == new Vector3(0, 0, 0)) return;
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.2f);
            this.transform.rotation = rot;
            animator.SetBool("WK_heavy_infantry_06_combat_walk", true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
       
        if (jumpNow == true)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                Debug.Log("OK");
                jumpNow = false;
            }
        }
        if (other.gameObject.tag == ("Enemy"))
        {
            HP--;
            Debug.Log(HP);
            currentHp--;
            Debug.Log("After currentHp : " + currentHp);
            slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + slider.value);
        }

    }
    void jump()
    {
        Debug.Log("ok");
        
        if (Input.GetKeyDown(KeyCode.Space)&&jumpNow==false)
        {
            Debug.Log("ok");
            rb.AddForce(transform.up * jumpPower,ForceMode.Impulse);
            jumpNow = true;
        }

    }
    void Gravity()
    {
        if (jumpNow == true)
        {
            rb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }



    }
