using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FactoryMainScript : MonoBehaviour
{
    public static FactoryMainScript instate;
    public TextMeshProUGUI newJerseyText;
    public TextMeshProUGUI bankbalanceText;
    public Button inventoryBtn;

    [SerializeField] GameObject firstTimeTutorial;

    public List<MouseDown> factoryBtns;

    [SerializeField] TextMeshProUGUI firstTimeIntroText;
    [SerializeField] GameObject firstTimeIntroBFImage;


    private void Awake()
    {
        instate = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SaveManager.Instance.state.bankBalance += 100;
            bankbalanceText.text = IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.bankBalance, true);
            SaveManager.Instance.UpdateState();
        }
    }

    private void Start()
    {
        SaveManager.Instance.state.newJerseyAmount = 50 * SaveManager.Instance.state.totalJerseyCount;
        if (SaveManager.Instance.state.newJerseyAmount <= 0)
            newJerseyText.text = "FREE";
        else
            newJerseyText.text = IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.newJerseyAmount, false);

        bankbalanceText.text = IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.bankBalance, false);

        if (!SaveManager.Instance.state.firstTimeUserBool)
        {
            firstTimeIntroBFImage.SetActive(true);
            firstTimeIntroText.GetComponent<TextWriterEffect>().AddWriter(firstTimeIntroText, "Ready to become the ruler of your own Jersey Empire? Design your favorite jersey !", 0.05f);

        }
        //else
        //{
        //    firstTimeTutorial.SetActive(false);
        //    FirstTimeClickContinueBtn();
        //}

        if (SaveManager.Instance.state.totalJerseyCount == 0)
        {
            inventoryBtn.interactable = false;
            inventoryBtn.GetComponent<CanvasGroup>().alpha = 0.75f;
            if (SaveManager.Instance.state.firstTimeUserBool)
                firstTimeTutorial.SetActive(true);
        }
        else
        {
            inventoryBtn.interactable = true;
            inventoryBtn.GetComponent<CanvasGroup>().alpha = 1f;
        }
            
    }

    int count = 0;
    public void FirstTimeClickContinueBtn()
    {
        count++;
        if (count == 1)
        {
            firstTimeIntroText.GetComponent<TextWriterEffect>().AddWriter(firstTimeIntroText, " Assign it to the factory line to start building your empire!", 0.05f);
        }
        else if (count == 2)
        {
            firstTimeIntroBFImage.SetActive(false);
            firstTimeTutorial.SetActive(true);
            SaveManager.Instance.state.firstTimeUserBool = true;
            SaveManager.Instance.UpdateState();
        }
    }


    public void AddJerseyClick()
    {
        if (SaveManager.Instance.state.bankBalance >= SaveManager.Instance.state.newJerseyAmount)
        {
            IncreaseDecreaseCoin.instate.Decrese(SaveManager.Instance.state.newJerseyAmount);
            SceneManager.LoadScene(1);
        }
    }

    public void LoadNewScene(bool canView)
    {
        SaveManager.Instance.state.canView = canView;
        SceneManager.LoadScene(2);
    }

    public void ChangeMouseDownBtn() //activate or deactivate buttons from MouseDown script
    {
        foreach (var item in factoryBtns)
        {
            item.IsGray();
        }
    }
}