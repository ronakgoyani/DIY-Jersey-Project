using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserAddJerseyToFactory : MonoBehaviour
{
    public static UserAddJerseyToFactory instate;

    public int JerseyNoIs;

    private void Awake()
    {
        instate = this;
    }

    private void OnMouseDown()
    {
        if (SaveManager.Instance.state.canView)
            return;

        SaveManager.Instance.state.customerChooseJerseyNo[JerseyNoIs] = JerseyNoIs;
        SaveManager.Instance.state.customerChooseJerseyColour[JerseyNoIs] = gameObject.GetComponentInParent<JerseyPrefab>().colourIs;
        SaveManager.Instance.state.selectJInFactory = JerseyNoIs;
        SaveManager.Instance.UpdateState();
        SceneManager.LoadScene(0);
    }
}