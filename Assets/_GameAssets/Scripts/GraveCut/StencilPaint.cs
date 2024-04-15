using PaintIn3D;
using PaintIn3D.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilPaint : MonoBehaviour
{
    public GameObject paintUIGo;
    public P3dHitScreen p3DHitScreen;
    public LayerMask layerMask;
    public ParticleSystem paintParticle;

    private bool canPaint;

    private void OnEnable()
    {
        paintUIGo.SetActive(true);
        canPaint = true;
        transform.position = new Vector3(0, 6, 0);
    }

    public void OnSelectPaint()
    {
        paintUIGo.SetActive(false);
        canPaint = false;
        Controller.instance.StencilPaintStepComplete();
    }

    private void Update()
    {
        if (!canPaint)
            return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = default(RaycastHit);

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask) == true)
        {
            var finalPosition = hit.point + hit.normal;
            var finalRotation = Quaternion.identity;

            transform.position = finalPosition;
            transform.rotation = finalRotation;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 hitScreenPos = Camera.main.WorldToScreenPoint(hit.point);
            p3DHitScreen.PaintAt(null, hitScreenPos, false, 1.0f, p3DHitScreen);
            paintParticle.Emit(10);
        }
    }
}
