using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnJerseyFirstSelect : MonoBehaviour
{
    [SerializeField] GameObject selectMyJersey;
    [SerializeField] GameObject finalBtn;

    private void Start()
    {
        finalBtn.SetActive(false);
    }

    public void btnClick(int btnNo)
    {
        finalBtn.SetActive(true);

        MainGameCanvasObject.instate.JerseySelect(btnNo);
        MainGameCanvasObject.instate.selectedJerseyIs = selectMyJersey;
    }

    public void DisableJ()
    {
        selectMyJersey.SetActive(false);
    }
}
