using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseDown : MonoBehaviour
{
    public MeshFilter mesh;
    public Mesh grayMesh;
    public Mesh greenMesh;
    public int baseAmtToIncereaase = 50;
    [SerializeField] int maxAmount; //start amt
    [SerializeField] int arryNo;
    [SerializeField] int multiplyPriseIs;
    [SerializeField] TextMeshPro textIs;


    private void Start()
    {
        StartCoroutine(TextIenumrator());
    }

    IEnumerator TextIenumrator()
    {
        yield return new WaitForSeconds(0.1f);
        if (SaveManager.Instance.state.savePriseValue[arryNo] == 0) //to add value in array to save for 1st time
        {
            SaveManager.Instance.state.savePriseValue[arryNo] = maxAmount;
        }
        IsGray();
        SaveManager.Instance.UpdateState();
        textIs.text = "$" + IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.savePriseValue[arryNo], false);
    }

    private void OnMouseDown()
    {
        if (SaveManager.Instance.state.savePriseValue[arryNo] <= SaveManager.Instance.state.bankBalance)
        {
              SaveManager.Instance.state.increaseNo += multiplyPriseIs;
            IncreaseDecreaseCoin.instate.Decrese(SaveManager.Instance.state.savePriseValue[arryNo]);
            //SaveManager.Instance.state.savePriseValue[arryNo] = SaveManager.Instance.state.increaseNo * maxAmount;
            maxAmount += baseAmtToIncereaase;
            SaveManager.Instance.state.savePriseValue[arryNo] = maxAmount;

            textIs.text = "$" + IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.savePriseValue[arryNo], false);
            SaveManager.Instance.UpdateState();
        }
        IsGray();
    }

    public void IsGray()
    {
        if (SaveManager.Instance.state.savePriseValue[arryNo] <= SaveManager.Instance.state.bankBalance)
        {
            mesh.mesh = greenMesh;
        }
        else
        {
            mesh.mesh = grayMesh;
        }
    }
}
