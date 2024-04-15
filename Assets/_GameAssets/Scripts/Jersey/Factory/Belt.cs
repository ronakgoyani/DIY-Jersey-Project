using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
  
  
    private void OnCollisionStay(Collision collision)
    {
        collision.transform.position += Vector3.back*1*Time.deltaTime;
    }
   
}
