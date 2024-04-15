using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySticker : MonoBehaviour
{
    public GameObject selectUIGo;
    public GameObject TutorialGo;
    public Animator anim;

    private bool canSwipe;
    private Vector3 startPos;
    private Vector3 endPos;

    private void OnEnable()
    {
        selectUIGo.SetActive(true);
        TutorialGo.SetActive(false);
        canSwipe = false;
    }

    public void OnSelected()
    {
        selectUIGo.SetActive(false);
        TutorialGo.SetActive(true);
        canSwipe = true;
    }

    private void Update()
    {
        if (!canSwipe)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;

            if (startPos.x - endPos.x < 0f)
            {
                //Debug.Log("Right");
            }
            else
            {
                TutorialGo.SetActive(false);
                canSwipe = false;
                StartCoroutine(SwipeCo());
            }
        }
    }

    private IEnumerator SwipeCo()
    {
        anim.SetTrigger("apply");
        yield return new WaitForSeconds(3f);
        Controller.instance.StickerStepComplete();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
