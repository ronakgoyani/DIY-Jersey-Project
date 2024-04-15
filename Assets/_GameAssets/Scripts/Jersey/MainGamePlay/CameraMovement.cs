using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;

    public float clampX = 1450;
    public float clampXm = 1450;
    public float clampZ = 1370;
    public float clampZm = 1370;
    public float yPos;

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;

    public static CameraMovement instate;

   
  
    void Update()
    {
       
        if (SaveManager.Instance.state.totalJerseyCount == 0)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

   
    void LeftMouseDrag()
    {
        current_position.z = hit_position.z = camera_position.y;

        Vector3 direction = cam.ScreenToWorldPoint(current_position) - cam.ScreenToWorldPoint(hit_position);

        direction *= -1;

        Vector3 position = camera_position + direction;

        float xPos = position.x;
        float zPos = position.z;

        if (xPos <= clampXm)
            xPos = clampXm;

        if (xPos >= clampX)
            xPos = clampX;

        if (zPos >= clampZ)
            zPos = clampZ;

        if (zPos <= clampZm)
            zPos = clampZm;

        transform.position = new Vector3(xPos, yPos, zPos);
    }

}