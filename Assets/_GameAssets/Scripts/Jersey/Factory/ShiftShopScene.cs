using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftShopScene : MonoBehaviour
{
    public int beltNoIs;
    public bool assignOnMe = false;

    public int jColor = 0;
    public int jShape = 0;

    private void OnEnable()
    {
        if (SaveManager.Instance == null)
            return;


        if (SaveManager.Instance.state.tapOnMachineIndex == beltNoIs)
        {
            assignOnMe = SaveManager.Instance.state.assignOnBelt;

            jShape = SaveManager.Instance.state.customerChooseJerseyNo[SaveManager.Instance.state.selectJInFactory];
            jColor = SaveManager.Instance.state.customerChooseJerseyColour[SaveManager.Instance.state.selectJInFactory];
        }
        else
        {
            jShape = SaveManager.Instance.state.customerChooseJerseyNo[0];
            jColor = SaveManager.Instance.state.customerChooseJerseyColour[0];
        }
    }

    private void Start()
    {
        SaveManager.Instance.state.beltNo[beltNoIs] = beltNoIs;

        if (SaveManager.Instance.state.beltCount <= 1)
            SaveManager.Instance.state.tapOnMachineIndex = 1;
    }

    private void OnMouseDown()
    {
        if (SaveManager.Instance.state.totalJerseyCount == 0)
            return;

        SaveManager.Instance.state.tapOnMachineIndex = beltNoIs;
        assignOnMe = true;
        SaveManager.Instance.state.assignOnBelt = assignOnMe;
        SaveManager.Instance.UpdateState();
        FactoryMainScript.instate.LoadNewScene(false);
    }
}
