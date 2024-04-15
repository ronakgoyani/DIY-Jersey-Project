using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using PaintIn3D.Examples;
using TMPro;
public class Scrap : MonoBehaviour
{
    public static bool scrapBool=false;
    public LayerMask layerMask;
    public P3dHitScreen p3DHitScreen;
    public P3dPaintSphere p3DPaintSphere;
    public P3dChangeCounter paintCounter;
    public float maxPaintValue;

    private void Start()
    {
        scrapBool = true;
    }
    void Update()
    {
        if (!scrapBool)
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
                p3DHitScreen.PaintAt(null, paintPos, false, 1.0f, p3DHitScreen);
                MainGameCanvasObject.instate.infinityTutorial.SetActive(false);
                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
                if (paintCounter.Count < maxPaintValue)
                {
                    ScrapComplet();
                }
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                MainGameCanvasObject.instate.infinityTutorial.SetActive(true);
                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(true);
                //MainGameCanvasObject.instate.tutorialText.text = "Spray To Paint.";
            }
        }
    }
    void ScrapComplet()
    {
        scrapBool = false;
        transform.GetChild(0).gameObject.SetActive(false);
        MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);
        MainGameCanvasObject.instate.infinityTutorial.SetActive(false);
        p3DPaintSphere.Radius = 10;
        Vector2 pos = new Vector2(Screen.width / 2, Screen.height / 2);
        p3DHitScreen.PaintAt(null, pos, false, 1.0f, p3DHitScreen);
        FXScript.instate.ConfettiStart();
        MainGameCanvasObject.instate.GRIDOfJerseyFirstSelectFN();
    }
}
