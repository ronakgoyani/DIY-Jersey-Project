using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomText : MonoBehaviour
{
    public GameObject textUIGo;
    public InputField inputField;
    public TextMeshProUGUI textMeshProUGUI;

    private void OnEnable()
    {
        textUIGo.SetActive(true);
        textMeshProUGUI.text = inputField.text = "";
    }

    public void OnValueChanged()
    {
        textMeshProUGUI.text = inputField.text;
    }

    public void EndEdit()
    {
        textUIGo.SetActive(false);
        Controller.instance.CustomTextStepComplete();
    }
}
