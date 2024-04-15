using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementShop : MonoBehaviour
{
    public static CameraMovementShop instance;

    public bool canMove = false;
    public Camera cam;

    public float clampX = 1450;
    //public float clampZ = 1370;
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;

    public float startYPos;
    public Vector3 startRot;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //transform.position = SaveManager.Instance.state.camLastPos;
    }

    void Update()
    {
        if (!canMove)
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
    private void OnMouseDown()
    {
        canMove = true;
    }
    void LeftMouseDrag()
    {
        
        current_position.z = hit_position.z = camera_position.y;

        Vector3 direction = cam.ScreenToWorldPoint(current_position) - cam.ScreenToWorldPoint(hit_position);

        direction *= -1;

        Vector3 position = camera_position + direction;

        float xPos = position.x;
        float zPos = position.z;

        if (xPos <= -clampX)
            xPos = -clampX;

        if (xPos >= clampX)
            xPos = clampX;

        //if (zPos >= clampZ)
        //    zPos = clampZ;

        //if (zPos <= -clampZ)
        //    zPos = -clampZ;

        transform.position = new Vector3(xPos, startYPos, zPos);
    }
}