using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class Practice_Follower : MonoBehaviour
{
    [SerializeField]
    PathFollower pathFollower;

    float speed=5;
    float distance;
   
    void Update()
    {
        distance += speed * Time.deltaTime;
        Debug.Log(distance);
        pathFollower.speed = 5;
    }
}
