using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject[] pregameGos;
    public GameObject[] ingameGos;
    public Animator transAnim;


    private void OnEnable()
    {
        for (int i = 0; i < pregameGos.Length; i++)
        {
            pregameGos[i].SetActive(true);
        }
        for (int i = 0; i < ingameGos.Length; i++)
        {
            ingameGos[i].SetActive(false);
        }
    }

    public void OnClickAccept()
    {
        StartCoroutine(IngameCO());
    }

    private IEnumerator IngameCO()
    {
        pregameGos[1].SetActive(false);
        transAnim.SetTrigger("trans");
        yield return new WaitForSeconds(1f);
        
        for (int i = 0; i < pregameGos.Length; i++)
        {
            pregameGos[i].SetActive(false);
        }
        for (int i = 0; i < ingameGos.Length; i++)
        {
            ingameGos[i].SetActive(true);
        }
    }
}
