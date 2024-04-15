using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
       if(MainGameCanvasObject.instate.waterTankeyBool)
       {
            if (Input.GetMouseButtonUp(0))
            {
                MainGameCanvasObject.instate.fingureTutorial.SetActive(false);

                MainGameCanvasObject.instate.allJerseyAniParent.Play("MainJerseyIntoWaterTank_anim");
                MainGameCanvasObject.instate.waterTankeyBool = false;
            }
       }
       
    }
}
