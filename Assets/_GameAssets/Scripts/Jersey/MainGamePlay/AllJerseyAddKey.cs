using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllJerseyAddKey : MonoBehaviour
{

   public void JerseyIntoWaterAddKey()
    {
        MainGameCanvasObject.instate.AllJerseyIntoWaterAni();
    }

    public void JerseyOutOfWater()
    {
        MainGameCanvasObject.instate.JerseyOutOfWaterAni();
    }

    public void MainJerseyOutofWaterBackToPos()
    {
        MainGameCanvasObject.instate.JrseyBackToPosition();
    }
}
