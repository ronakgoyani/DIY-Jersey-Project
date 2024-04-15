using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGameControll : MonoBehaviour
{
    [SerializeField] JerseyPrefab jerseyScript;
    [SerializeField] Transform jerseyGenerationPos;

    private ShiftShopScene plus;

    private void Start()
    {
        plus = GetComponentInChildren<ShiftShopScene>();
        if (SaveManager.Instance.state.totalJerseyCount != 0)
        {
            JerseyGenerate();
        }
    }

    public void JerseyGenerate()
    {
        JerseyPrefab newJersey = Instantiate(jerseyScript);


        if (SaveManager.Instance.state.beltCount <= 1)
        {
            newJersey.jerseyObject[plus.jShape].gameObject.SetActive(true);
            newJersey.jerseyObject[plus.jShape].material = newJersey.jerseyMaterial[plus.jColor];
            //newJersey.jerseyObject[SaveManager.Instance.state.customerChooseJerseyNo[SaveManager.Instance.state.selectJInFactory]].gameObject.SetActive(true);

            //newJersey.jerseyObject[SaveManager.Instance.state.customerChooseJerseyNo[SaveManager.Instance.state.selectJInFactory]].material =
            //newJersey.jerseyMaterial[SaveManager.Instance.state.customerChooseJerseyColour[SaveManager.Instance.state.selectJInFactory]];
        }
        else
        {
            newJersey.jerseyObject[plus.jShape].gameObject.SetActive(true);
            newJersey.jerseyObject[plus.jShape].material = newJersey.jerseyMaterial[plus.jColor];
        }

        jerseyScript.transform.position = jerseyGenerationPos.position;
        jerseyScript.transform.eulerAngles = jerseyGenerationPos.eulerAngles;

        StartCoroutine(JerseyGenerateIEnumerator());
    }

    IEnumerator JerseyGenerateIEnumerator()
    {
        yield return new WaitForSeconds(2f);
        JerseyGenerate();
    }
}