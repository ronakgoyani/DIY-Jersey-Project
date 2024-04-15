using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3MachineStartQue : MonoBehaviour
{
    [SerializeField] Animator m3MachineAni;
    [SerializeField] Material giftMaterial;
    [SerializeField] float timepause;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jersey")
        {
            //FactoryGameControll.instate.packingBoxPos = other.transform;
            m3MachineAni.Play("M3MachineStartQue_anim");
            StartCoroutine(ProvideTime(other));
            
            //FactoryGameControll.instate.packingBox.transform.GetChild(0).gameObject.SetActive(true);
            //StartCoroutine(colourChangeOfMesh());
        }
    }

    IEnumerator ProvideTime(Collider other)
    {
        yield return new WaitForSeconds(timepause);
        other.transform.GetChild(11).GetComponent<MeshRenderer>().material = giftMaterial;
        other.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
    }
}
