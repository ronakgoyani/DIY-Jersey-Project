using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2MachineStartQue : MonoBehaviour
{
    [SerializeField] Animator m2MachineAni;
    [SerializeField] GameObject packingPrefab;
    [SerializeField] Transform m2JerseyPos;
    [SerializeField] float setTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jersey")
        {
            //FactoryGameControll.instate.packingBoxParent = other.transform;
            m2MachineAni.Play("M2MachineStartQue_anim");
            StartCoroutine(provideTime());
        }

        IEnumerator provideTime()
        {
            yield return new WaitForSeconds(setTime);
            GameObject box = Instantiate(packingPrefab, other.transform);
            box.transform.position = m2JerseyPos.position;
            box.transform.localEulerAngles = new Vector3(180, 0, 180);
        }
    }
}
