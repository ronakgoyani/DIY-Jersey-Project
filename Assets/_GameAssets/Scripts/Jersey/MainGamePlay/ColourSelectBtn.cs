using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelectBtn : MonoBehaviour
{
   
    [SerializeField] Material selectedColourMaterial;
    [SerializeField] Texture selectedTexture;
    [SerializeField] GameObject trueBtn;

    private void Start()
    {
        //trueBtn = GetComponent<GameObject>().GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().gameObject.transform.GetChild(3).gameObject;
        trueBtn.SetActive(false);
    }

    public void ColourSelectBtnClick(int colourNoIs)
    {
        MainGameCanvasObject.instate.selectedBtnMaterialIs = selectedColourMaterial;
        MainGameCanvasObject.instate.selectedTextureIs = selectedTexture;
        trueBtn.SetActive(true);
        //CurrentJerseyData.instance.jerseyDataStruct[SaveManager.Instance.state.totalJerseyCount].colourIndex = colourIndex;
        MainGameCanvasObject.instate.ColourIsSelected(colourNoIs);
    }
}
