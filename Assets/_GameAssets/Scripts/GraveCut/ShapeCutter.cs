using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCutter : MonoBehaviour
{
    public GameObject stepUIGo;
    public GameObject tutorialGo;
    public PathFollower pathFollower;
    public float maxDistance;
    public GameObject sparkParticleGo;
    public CameraShake cameraShake;

    private bool canCut;

    private void OnEnable()
    {
        stepUIGo.SetActive(true);
        tutorialGo.SetActive(false);
        pathFollower.speed = 0;
        sparkParticleGo.SetActive(false);
    }

    public void OnSelectShape()
    {
        stepUIGo.SetActive(false);
        tutorialGo.SetActive(true);
        canCut = true;
    }

    private void Update()
    {
        if (!canCut)
            return;

        if (Input.GetMouseButton(0))
        {
            tutorialGo.SetActive(false);
            pathFollower.speed = 5;
            sparkParticleGo.SetActive(true);
            cameraShake.Shake();

            if (pathFollower.distanceTravelled >= maxDistance)
            {
                Controller.instance.CuttingStepComplete();
                canCut = false;
                sparkParticleGo.SetActive(false);
            }
        }
        else
        {
            tutorialGo.SetActive(true);
            pathFollower.speed = 0;
            sparkParticleGo.SetActive(false);
        }
    }
}
