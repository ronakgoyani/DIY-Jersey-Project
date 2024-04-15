using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDecreaseCoin : MonoBehaviour
{
    public static IncreaseDecreaseCoin instate;

    private void Awake()
    {
        instate = this;
    }

    public void Increse(int increaseNo)
    {
        SaveManager.Instance.state.bankBalance += increaseNo;
        SaveManager.Instance.UpdateState();
        FactoryMainScript.instate.bankbalanceText.text = ConvertNumberToStore(SaveManager.Instance.state.bankBalance, true);
        FactoryMainScript.instate.ChangeMouseDownBtn();
    }

    public void Decrese(int decreaseNo)
    {
        SaveManager.Instance.state.bankBalance -= decreaseNo;
        SaveManager.Instance.UpdateState();

        FactoryMainScript.instate.ChangeMouseDownBtn();
        FactoryMainScript.instate.bankbalanceText.text = ConvertNumberToStore(SaveManager.Instance.state.bankBalance, true);
    }

    public string ConvertNumberToStore(double number, bool isSave)
    {
        string num = number.ToString();

        if (number >= 1000000000000)
            num = (number / 1000000000000).ToString("0.##") + "T";
        else if (number >= 1000000000)
            num = (number / 1000000000).ToString("0.##") + "B";
        else if (number >= 1000000)
            num = (number / 1000000).ToString("0.##") + "M";
        else if (number >= 1000)
            num = (number / 1000).ToString("0.##") + "K";
        else
            num = Mathf.Round((float)number).ToString();

        if (isSave)
        {
            SaveManager.Instance.state.bankBalance = number;
            SaveManager.Instance.UpdateState();
        }
        return num;
    }
}
