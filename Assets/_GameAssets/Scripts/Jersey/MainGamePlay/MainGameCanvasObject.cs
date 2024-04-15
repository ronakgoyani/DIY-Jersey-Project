using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainGameCanvasObject : MonoBehaviour
{
    public static MainGameCanvasObject instate;

    [Header("CanvasUI")]
    public GameObject gridOfJerseyFirstSelect;
    public Color jerseyColour;
    public Color jerseyBackgroundColour;
    public GameObject gridOfJerseyColour;
    public GameObject fingureTutorial;
    public GameObject infinityTutorial;
    [SerializeField] Image[] innerCircle;
    [SerializeField] int charCount = 0;
    [SerializeField] Image[] jerseyBtnNoGameobj;
    [SerializeField] Color[] colors;
    [SerializeField] TextMeshProUGUI bankBallanceText;
    [SerializeField] GameObject[] selectedColourBtnBorder;
    public TextMeshProUGUI tutorialText;

    [Header("WorldSpace")]
    public GameObject woodBase;
    public GameObject selectedJerseyIs;
    public Animator camAni;
    public Animator allJerseyAniParent;
    public GameObject drillObject;
    public Material selectedBtnMaterialIs;
    public Texture selectedTextureIs;
    public bool drilBool = false;
    public bool waterTankeyBool = false;
    public int counterOfPiece = 0;
    public GameObject[] jerseyBase;
    public PathCreation.PathCreator[] jPath;
    public float[] pathMaxDist;
    public long[] sprayMaxPaintValue;
    public PaintIn3D.Examples.P3dChangeCounter[] jInnerShape;
    [SerializeField] GameObject scrapTool;
    [SerializeField] GameObject waterTanki;
    [HideInInspector] public int jerseyFinalNo;
    int colourNoIs;

    private void Awake()
    {
        instate = this;
    }
    private void Start()
    {
        Scrap.scrapBool = true;
        tutorialText.gameObject.SetActive(true);
        tutorialText.text = "Scrape The Wood";
        bankBallanceText.text = IncreaseDecreaseCoin.instate.ConvertNumberToStore(SaveManager.Instance.state.bankBalance, false);
        for (int i = 0; i < jerseyBtnNoGameobj.Length; i++)
        {
            jerseyBtnNoGameobj[i].enabled = false;
            jerseyBtnNoGameobj[i].transform.GetChild(0).GetComponent<Image>().color = jerseyColour;
        }
        for (int i = 0; i < jerseyBase.Length; i++)
        {
            jerseyBase[i].SetActive(false);
        }
        charCount = 0;
        ResetDots();
        gridOfJerseyFirstSelect.SetActive(false);
        scrapTool.SetActive(true);
        woodBase.SetActive(true);
        drillObject.SetActive(false);
        waterTanki.GetComponent<Animator>().Play("WaterFirstPos_anim");
        allJerseyAniParent.Play("MainJerseyFirstPos_anim");
        camAni.Play("CamFirstPos_anim");
        waterTanki.GetComponent<WaterTank>().enabled = false;
        gridOfJerseyColour.SetActive(false);
        infinityTutorial.SetActive(true);
        SprayColour.instate.gameObject.SetActive(false);
    }

    public void GRIDOfJerseyFirstSelectFN()
    {
        charCount++;
        ResetDots();
        //tutorialText.gameObject.SetActive(true);
        //tutorialText.text = "Scrape The Wood.";
        StartCoroutine(GRIDOfJerseyFirstSelectIE(1f));
    }
    IEnumerator GRIDOfJerseyFirstSelectIE(float takeTime) //jersey Grid (True)
    {
        yield return new WaitForSeconds(takeTime);

        gridOfJerseyFirstSelect.SetActive(true);
        scrapTool.SetActive(false);
    }

    public void JerseySelect(int jerseyBtnNo) // Which Jersey You Want ?? 
    {
        jerseyFinalNo = jerseyBtnNo;
        for (int i = 0; i < jerseyBtnNoGameobj.Length; i++)
        {
            if (i == jerseyBtnNo)
            {
                jerseyBase[i].SetActive(true);
                jerseyBtnNoGameobj[i].enabled = true;
                jerseyBtnNoGameobj[i].color = jerseyBackgroundColour;
                jerseyBtnNoGameobj[i].GetComponent<Outline>().effectColor = Color.green;
                jerseyBtnNoGameobj[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
            else
            {
                jerseyBtnNoGameobj[i].enabled = false;
                jerseyBtnNoGameobj[i].transform.GetChild(0).GetComponent<Image>().color = jerseyColour;
            }
        }
    }
    public void JerseySelectedBtn()
    {
        drilBool = true;
        gridOfJerseyFirstSelect.SetActive(false);
        drillObject.SetActive(true);

    }
    public void CuttingComplet()
    {
        charCount++;
        ResetDots();
        FXScript.instate.ConfettiStart();
        woodBase.SetActive(false);
        selectedJerseyIs.transform.GetChild(2).gameObject.SetActive(false);
        selectedJerseyIs.transform.GetChild(1).GetComponent<Animator>().Play("WoodOuterShape_anim");
        gridOfJerseyColour.SetActive(true);
        SprayColour.instate.gameObject.SetActive(true);

    }
    public void ColourIsSelected(int colourNo)
    {
        for (int i = 0; i < selectedColourBtnBorder.Length; i++)
        {
            if (i == colourNo)
            {
                selectedColourBtnBorder[i].SetActive(true);
            }
            else
            {
                selectedColourBtnBorder[i].SetActive(false);
            }
        }
        SprayColour.instate.GetComponent<MeshRenderer>().material = selectedBtnMaterialIs;
        var tex = SprayColour.instate.p3DPaintSphere.BlendMode;
        tex.Texture = selectedTextureIs;
        SprayColour.instate.p3DPaintSphere.BlendMode = tex;
        colourNoIs = colourNo;
    }
    public void ColourFinalBtn()
    {
        tutorialText.gameObject.SetActive(true);
        tutorialText.text = "Spray To Paint";

        SprayColour.instate.sprayBool = true;
        gridOfJerseyColour.SetActive(false);
        infinityTutorial.SetActive(true);

        //SaveManager.Instance.state.savedColourNo.Add(colourNoIs);
    }

    public void JerseyReadyForShower()
    {
        charCount++;
        ResetDots();
        StartCoroutine(WaterPosAni());
    }

    IEnumerator WaterPosAni()
    {
        yield return new WaitForSeconds(1.5f);
        camAni.Play("CamFocusWaterInsideWood_anim");
        allJerseyAniParent.Play("MainJerseyWaterTubPos_anim 1");
        waterTanki.GetComponent<Animator>().Play("WaterTank_anim");
        StartCoroutine(DownSwipe());
    }

    IEnumerator DownSwipe()
    {
        yield return new WaitForSeconds(1.5f);
        waterTanki.GetComponent<WaterTank>().enabled = true;
        waterTankeyBool = true;
        fingureTutorial.SetActive(true);
        fingureTutorial.GetComponent<Animator>().Play("FingureTutorial_anim");
    }

    public void AllJerseyIntoWaterAni()
    {
        allJerseyAniParent.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        selectedJerseyIs.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        selectedJerseyIs.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 0.361f);
        selectedJerseyIs.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 1f);
    }

    public void JerseyOutOfWaterAni()
    {
        FXScript.instate.ConfettiStart();
        allJerseyAniParent.Play("AllJerseyBackToPosition_anim");
        waterTanki.GetComponent<Animator>().Play("WaterBackToPos_anim");
        camAni.Play("CameraBackToPos_anim");
    }

    public void JrseyBackToPosition()
    {
        charCount++;
        ResetDots();
        fingureTutorial.SetActive(true);
        fingureTutorial.GetComponent<Animator>().Play("AllJerseyPartsTutorial_anim");
        selectedJerseyIs.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void AllStepsAreComplet()
    {
        charCount++;
        ResetDots();
        Debug.Log(jerseyFinalNo);
        SaveManager.Instance.state.savedColourNo.Add(colourNoIs);
        SaveManager.Instance.state.savedJerseyNo.Add(jerseyFinalNo);
        SaveManager.Instance.UpdateState();
        FXScript.instate.ConfettiStart();
        SaveManager.Instance.state.totalJerseyCount++;
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(2.5f);
        FactoryMainScript.instate.LoadNewScene(false);
    }

    public void ResetDots()
    {
        for (int i = 0; i < innerCircle.Length; i++)
        {
            innerCircle[i].color = colors[0];
        }
        for (int i = 0; i < charCount; i++)
        {
            innerCircle[i].color = colors[1];
        }
        if (charCount < innerCircle.Length)
            innerCircle[charCount].color = Color.white;
    }
}
