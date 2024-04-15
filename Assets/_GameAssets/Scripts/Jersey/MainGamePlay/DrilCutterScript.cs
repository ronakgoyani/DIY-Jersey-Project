using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using TMPro;

public class DrilCutterScript : MonoBehaviour
{
    [SerializeField]
    PathFollower pathFollower;
    [SerializeField] TextMeshProUGUI tapToContinueText;
    [SerializeField] float maxDistance;

    private void Start()
    {
        pathFollower.speed = 0;
       
    }
    public void OnEnable()
    {
        pathFollower.pathCreator = MainGameCanvasObject.instate.jPath[MainGameCanvasObject.instate.jerseyFinalNo];
        maxDistance = MainGameCanvasObject.instate.pathMaxDist[MainGameCanvasObject.instate.jerseyFinalNo];

        MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(true);
        MainGameCanvasObject.instate.tutorialText.text = "Tap To Continue";
    }
    void Update()
    {
        if (MainGameCanvasObject.instate.drilBool)
        {
            if (Input.GetMouseButton(0))
            {
                pathFollower.speed = 0.5f ;
                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
                CameraShake.instance.Shake();
                if (pathFollower.distanceTravelled > maxDistance)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    MainGameCanvasObject.instate.CuttingComplet();
                    gameObject.SetActive(false);
                    MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(false);

                }
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);

                MainGameCanvasObject.instate.tutorialText.gameObject.SetActive(true);
                pathFollower.speed = 0f;
                //CameraShake.instance.OnDisable();
            }
        }
    }
}
