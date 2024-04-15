using PaintIn3D.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    public GameObject[] stepGos;
    public Image[] stepImgs;
    public Sprite[] stepSprites;
    public GameObject blockGo;
    public GameObject stencilGo;
    public GameObject stickerPrinterGo;
    public GameObject finishGo;
    public int nextScene;

    [Header("Step1")]
    public Animator blockAnim;

    [Header("Step2")]
    public Animator graveAnim;
    public Animator stencilAnim;

    public int stepIndex;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        stepIndex = 0;
        finishGo.SetActive(false);
        blockGo.SetActive(true);
        stencilGo.SetActive(false);
        stickerPrinterGo.SetActive(false);
        SetStep(); 
    }

    public void SetStep()
    {
        for (int i = 0; i < stepGos.Length; i++)
        {
            stepGos[i].SetActive(false);
        }
        stepGos[stepIndex].SetActive(true);
        for (int i = 0; i < stepImgs.Length; i++)
        {
            stepImgs[i].sprite = stepSprites[0];
        }
        for (int i = 0; i < stepIndex; i++)
        {
            stepImgs[i].sprite = stepSprites[1];
        }
        stepImgs[stepIndex].sprite = stepSprites[2];

        stepIndex++;

        if (stepIndex == 1)
        {
            blockGo.SetActive(true);
        }
        else if (stepIndex == 3)
        {
            stencilGo.SetActive(true);
        }
        else if (stepIndex == 4)
        {
            stencilGo.SetActive(false);
            stickerPrinterGo.SetActive(true);
        }
    }

    public void CuttingStepComplete()
    {
        blockAnim.SetTrigger("fall");
        StartCoroutine(StepCompleteCo());
    }
    public void BasePaintStepComplete()
    {
        graveAnim.SetTrigger("set");
        StartCoroutine(StepCompleteCo());
    }
    public void StencilPaintStepComplete()
    {
        stencilAnim.SetTrigger("out");
        StartCoroutine(StepCompleteCo());
    }
    public void StickerStepComplete()
    {
        stickerPrinterGo.SetActive(false);
        StartCoroutine(StepCompleteCo());
    }
    public void CustomTextStepComplete()
    {
        StartCoroutine(FinishCo());
    }

    private IEnumerator StepCompleteCo()
    {
        yield return new WaitForSeconds(2f);
        SetStep();
    }

    private IEnumerator FinishCo()
    {
        for (int i = 0; i < stepImgs.Length; i++)
        {
            stepImgs[i].sprite = stepSprites[1];
        }
        yield return new WaitForSeconds(1f);
        finishGo.SetActive(true);
        graveAnim.SetTrigger("complete");

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(nextScene);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
