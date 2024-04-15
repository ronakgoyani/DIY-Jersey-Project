using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ShopControll : MonoBehaviour
{
    public static ShopControll instate;
    public JerseyPrefab jerseyPrefab;
    public List<Transform> jerseyPos;
    public GameObject starFX;
    public GameObject JersyIs;
    public List<GameObject> addToFactoryCollider;
    [SerializeField] TextMeshProUGUI bankBallanceText;
    private void Awake()
    {
        instate = this;
    }
    private void Start()
    {
        bankBallanceText.text = IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.bankBalance,false);

        JerseyShow();
    }
    public void JerseyShow()
    {

        StartCoroutine(JerseyShowCo());

    }
    IEnumerator JerseyShowCo()
    {
       
        for (int i = 0; i < SaveManager.Instance.state.totalJerseyCount; i++)
        {
            JerseyPrefab newJersey = Instantiate(jerseyPrefab);

           
            if (i == SaveManager.Instance.state.totalJerseyCount-1)
            {
                starFX.transform.position = new Vector3(jerseyPos[SaveManager.Instance.state.totalJerseyCount - 1].position.x,
                jerseyPos[SaveManager.Instance.state.totalJerseyCount - 1].position.y, 5.206f);
                
                yield return new WaitForSeconds(0.5f);
            }
            addToFactoryCollider[i].SetActive(true);
            newJersey.jerseyObject[SaveManager.Instance.state.savedJerseyNo[i]].gameObject.SetActive(true);

            newJersey.jerseyObject[SaveManager.Instance.state.savedJerseyNo[i]].material =
            newJersey.jerseyMaterial[SaveManager.Instance.state.savedColourNo[i]];

            newJersey.colourIs = SaveManager.Instance.state.savedColourNo[i];

            newJersey.jerseyObject[SaveManager.Instance.state.savedJerseyNo[i]].gameObject.transform.localPosition =
            jerseyPos[i].position;
        }
    }

    public void HomeBtnClick()
    {
        Debug.Log("click");
        SceneManager.LoadScene(0);
    }
}