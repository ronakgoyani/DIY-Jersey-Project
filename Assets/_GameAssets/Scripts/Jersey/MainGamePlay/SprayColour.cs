using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using PaintIn3D.Examples;

public class SprayColour : MonoBehaviour
{
    public static SprayColour instate;
    public bool sprayBool = false;
    public LayerMask layerMask;
    public P3dHitScreen p3DHitScreen;
    public P3dPaintSphere p3DPaintSphere;
    public P3dChangeCounter paintCounter;
    public float maxPaintValue;
    
    private void Awake()
    {
        instate = this;
    }

    private void OnEnable()
    {
        maxPaintValue = MainGameCanvasObject.instate.sprayMaxPaintValue[MainGameCanvasObject.instate.jerseyFinalNo];
        paintCounter = MainGameCanvasObject.instate.jInnerShape[MainGameCanvasObject.instate.jerseyFinalNo];
    }

    void Update()
    {
        if (!sprayBool)
            return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
        {
            Vector3 hitPointIs = hit.point;
            if (Input.GetMouseButton(0))
            {
                transform.position = new Vector3(hitPointIs.x, transform.position.y, hitPointIs.z);
                Vector3 paintPos = Camera.main.WorldToScreenPoint(hit.point);
                MainGameCanvasObject.instate.infinityTutorial.SetActive(false);

                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);
                p3DHitScreen.PaintAt(null, paintPos, false, 1.0f, p3DHitScreen);
                    //Debug.Log("paintCounter" + paintCounter.Count);
               
                if (paintCounter.Count < maxPaintValue)
                {
                    ScrapComplet();
                }
            }
            else
            {
                MainGameCanvasObject.instate.infinityTutorial.SetActive(true);
                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(true);
            }
        }
    }
    void ScrapComplet()
    {
        sprayBool = false;
        MainGameCanvasObject.instate.infinityTutorial.SetActive(false);
       MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);

        p3DPaintSphere.Radius = 10;
        Vector2 pos = new Vector2(Screen.width / 2, Screen.height / 2);
        p3DHitScreen.PaintAt(null, pos, false, 1.0f, p3DHitScreen);
        FXScript.instate.ConfettiStart();
        MainGameCanvasObject.instate.JerseyReadyForShower();
        gameObject.SetActive(false);
    }
}
