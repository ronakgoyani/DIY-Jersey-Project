using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXScript : MonoBehaviour
{
    public static FXScript instate;

    public GameObject confetti;

    private void Awake()
    {
        instate = this;
    }

    private void Start()
    {
        confetti.SetActive(false);
    }

    public void ConfettiStart()
    {
        StartCoroutine(ConfettiEnumerator());
    }

    IEnumerator ConfettiEnumerator()
    {
        confetti.SetActive(true);
        yield return new WaitForSeconds(2);
        confetti.SetActive(false);
    }
}
