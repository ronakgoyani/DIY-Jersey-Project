using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class AddBeltClick : MonoBehaviour
{
    [SerializeField] int arryNo;
    [SerializeField] int maxNoIs;
    [SerializeField] TextMeshPro addBeltText;
    [SerializeField] int multiplyPriseIs;
    [SerializeField] GameObject newMachines;

   
    private void Start()
    {

        StartCoroutine(TextIenumrator());
    }
   
    IEnumerator TextIenumrator()
    {
        if (!SaveManager.Instance.state.newBeltBool)
        {
            yield return new WaitForSeconds(0.1f);
            if (SaveManager.Instance.state.savePriseValue[arryNo] == 0)
            {
                SaveManager.Instance.state.savePriseValue[arryNo] = maxNoIs;
            }
            SaveManager.Instance.UpdateState();
            addBeltText.text = "$" + IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.savePriseValue[arryNo],false);
            newMachines.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            newMachines.SetActive(true);
            gameObject.SetActive(false);
        }
       
    }
    private void OnMouseDown()
    {
        if (SaveManager.Instance.state.bankBalance >= SaveManager.Instance.state.savePriseValue[arryNo])
        {
            //Debug.Log("AddBelt");
            SaveManager.Instance.state.increaseNo += multiplyPriseIs;
            IncreaseDecreaseCoin.instate.Decrese(SaveManager.Instance.state.savePriseValue[arryNo]);
            SaveManager.Instance.state.savePriseValue[arryNo] = SaveManager.Instance.state.increaseNo * maxNoIs;
            addBeltText.text = "$" + IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.savePriseValue[arryNo],true);
            SaveManager.Instance.state.newBeltBool = true;
            SaveManager.Instance.state.beltCount++;
            SaveManager.Instance.UpdateState();
            newMachines.SetActive(true);
            gameObject.SetActive(false);

        }
    }

}
