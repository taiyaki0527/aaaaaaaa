using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  [SerializeField]  private GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 7.0f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      
     
    }
   
  
}
