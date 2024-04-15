using PaintIn3D;
using PaintIn3D.Examples;
using UnityEngine;

public class MyPaint : MonoBehaviour
{
    public GameObject paintUIGo;
    public P3dHitScreen p3DHitScreen;
    public P3dPaintSphere p3DPaintSphere;
    public P3dChangeCounter paintCounter;
    public int paintValue;
    public LayerMask layerMask;
    public ParticleSystem paintParticle;

    private bool canPaint;

    private void OnEnable()
    {
        paintUIGo.SetActive(true);
        canPaint = false;
        transform.position = new Vector3(0, 6, 0);
    }

    public void OnSelectPaint()
    {
        paintUIGo.SetActive(false);
        canPaint = true;
    }

    private void Update()
    {
        if (!canPaint)
            return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        var hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
        {
            var finalPosition = hit.point;
            //+hit.normal
            var finalRotation = Quaternion.identity;

            transform.position = finalPosition;
            transform.rotation = finalRotation;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 hitScreenPos = Camera.main.WorldToScreenPoint(hit.point);
            //Vector2 pos = new Vector2(Screen.width / 2, Screen.height / 2);
            p3DHitScreen.PaintAt(null, hitScreenPos, false, 1.0f, p3DHitScreen);

            paintParticle.Emit(10);
            Debug.Log("paintCounter" + paintCounter.Count);
        }

        if (paintCounter.Count < paintValue)
        {
            Debug.Log("END");
            canPaint = false;
            p3DPaintSphere.Radius = 20;
            Vector2 pos = new Vector2(Screen.width / 2, Screen.height / 2);
            p3DHitScreen.PaintAt(null, pos, false, 1.0f, p3DHitScreen);
            Controller.instance.BasePaintStepComplete();
        }
    }
}
