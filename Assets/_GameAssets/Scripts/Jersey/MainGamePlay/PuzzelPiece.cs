using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPiece : MonoBehaviour
{
    public Transform piece; //highlight
    public float y;

    public bool isItemPlaced = false;
    public float distance;

    private Vector3 originalPos;
    private Vector3 originalRot;

    private Vector3 mOffset;
    private float mZCoord;

    private void Start()
    {
        if (isItemPlaced)
            return;

        piece.gameObject.SetActive(false);
        originalPos = transform.position;
        originalRot = transform.eulerAngles;
    }

    private void OnMouseDown()
    {
        piece.gameObject.SetActive(true);
        MainGameCanvasObject.instate.fingureTutorial.SetActive(false);

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    IEnumerator PlaceObjCo()
    {
        float t = 0.0f;
        float duration = 0.5f;

        while (t < duration)
        {
            t += Time.deltaTime;
            transform.eulerAngles = new Vector3(piece.eulerAngles.x,
                                                 piece.eulerAngles.y,
                                                 piece.eulerAngles.z);

            transform.position = Vector3.Lerp(transform.position, piece.position, t / duration);
            yield return null;
        }
        isItemPlaced = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (isItemPlaced)
            return;

        transform.position = new Vector3(GetMouseWorldPos().x, y, GetMouseWorldPos().z) + mOffset;
        //Debug.Log(Vector3.Distance(gameObject.transform.position, piece.localPosition));
        if (Vector3.Distance(gameObject.transform.position, piece.localPosition) < distance)
        {
            //Debug.LogWarning("HA BHAI...");
            isItemPlaced = true;
            piece.gameObject.SetActive(false);
            MainGameCanvasObject.instate.counterOfPiece++;
            if (MainGameCanvasObject.instate.selectedJerseyIs.transform.GetChild(3).gameObject.GetComponent<InJerseyHowmanyParts>().totalParts == MainGameCanvasObject.instate.counterOfPiece)
            {
                MainGameCanvasObject.instate.AllStepsAreComplet();
            }
            StartCoroutine(PlaceObjCo());
        }
        else
        {
            isItemPlaced = false;
        }
    }

    private void OnMouseUp()
    {
        if (piece.gameObject != null)
            piece.gameObject.SetActive(false);

        if (!isItemPlaced)
        {
            transform.position = originalPos;
            transform.eulerAngles = originalRot;
        }
    }
}
