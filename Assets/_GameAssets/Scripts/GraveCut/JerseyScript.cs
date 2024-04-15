using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JerseyScript : MonoBehaviour
{
    public GameObject tool;
    private Texture2D dirtMaskTexture;
    [SerializeField] private Texture2D dirtBrush;
    public Material[] dirtyMaterial;

    private float dirtAmount;
    private float dirtAmountTotal;
    private int baseMaterial = 0;

    private Vector2Int lastPaintPixelPosition;
    private int per = 0;

    [SerializeField] Slider mainSlider;
    [SerializeField] private TextMeshProUGUI uiText;

    bool changeMaterialBool;

    private void OnEnable()
    {
        changeMaterialBool = false;
        mainSlider.maxValue = 100;
        mainSlider.minValue = 0;
        SetMaterial(baseMaterial);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (changeMaterialBool == true)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.gameObject.name.Contains("Grave"))
                    {
                        Vector2 textureCoord = raycastHit.textureCoord;
                        tool.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y, tool.transform.position.z);

                        int pixelX = (int)(textureCoord.x * dirtMaskTexture.width);
                        int pixelY = (int)(textureCoord.y * dirtMaskTexture.height);

                        Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);
                        int paintPixelDistance = Mathf.Abs(paintPixelPosition.x - lastPaintPixelPosition.x) + Mathf.Abs(paintPixelPosition.y - lastPaintPixelPosition.y);
                        int maxPaintDistance = 7;
                        if (paintPixelDistance < maxPaintDistance)
                        {
                            // Painting too close to last position
                            return;
                        }
                        lastPaintPixelPosition = paintPixelPosition;
                        int pixelXOffset = pixelX - (dirtBrush.width / 2);
                        int pixelYOffset = pixelY - (dirtBrush.height / 2);

                        for (int x = 0; x < dirtBrush.width; x++)
                        {
                            for (int y = 0; y < dirtBrush.height; y++)
                            {
                                Color pixelDirt = dirtBrush.GetPixel(x, y);
                                Color pixelDirtMask = dirtMaskTexture.GetPixel(pixelXOffset + x, pixelYOffset + y);

                                float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                                dirtAmount -= removedAmount;

                                dirtMaskTexture.SetPixel(
                                    pixelXOffset + x,
                                    pixelYOffset + y,
                                    new Color(0, pixelDirtMask.g * pixelDirt.g, 0)
                                );
                            }
                        }
                        dirtMaskTexture.Apply();
                        per = (100 - Mathf.RoundToInt(GetDirtAmount() * 100f));
                        mainSlider.value = per;
                        uiText.text = mainSlider.value.ToString() + "%";
                        if (per >= 98)
                        {
                            changeMaterialBool = false;
                            StartCoroutine(LevelCompletedCo());
                        }
                    }
                }
            }
        }
    }

    private float GetDirtAmount()
    {
        return this.dirtAmount / dirtAmountTotal;
    }

    IEnumerator LevelCompletedCo()
    {
        mainSlider.value = 0;
        yield return new WaitForSeconds(1.70f);
        Debug.Log("complet");
      
        SetMaterial(baseMaterial + 1);
    }

    public void SetMaterial(int _baseMaterialNo)
    {
        if (dirtyMaterial.Length <= _baseMaterialNo)
        {
            // all material complet
        }
    }
}
