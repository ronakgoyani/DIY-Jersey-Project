using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1MachineStartQue : MonoBehaviour
{
    [SerializeField] Animator m1MachineAni;
    [SerializeField] GameObject framePrefab;
    [SerializeField] float setTime;
    [SerializeField] Transform m1JerseyPos;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Jersey")
        //{
        //    FactoryGameControll.instate.frameParent = other.transform;
        //    m1MachineAni.Play("M1HandleAni_anim");

        //}
        if (other.gameObject.tag == "Jersey")
        {
            //FactoryGameControll.instate.frameParent = other.transform;
            m1MachineAni.Play("M1HandleAni_anim");
            StartCoroutine(StopHere(other));
        }
    }
    IEnumerator StopHere(Collider that)
    {
        yield return new WaitForSeconds(setTime);
        GameObject frame = Instantiate(framePrefab, that.transform);
        frame.transform.position = m1JerseyPos.position;
        frame.transform.eulerAngles = m1JerseyPos.eulerAngles;
    }
}
