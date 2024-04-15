using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JerseyPrefab : MonoBehaviour
{
    public List<Material> jerseyMaterial;
    public List<MeshRenderer> jerseyObject;
    public GameObject jerseyBase;
    public int colourIs;
    public Animator objTextAni;
    public TextMeshPro objText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Belt"))
        {
            jerseyBase.SetActive(true);
            objTextAni.gameObject.SetActive(false);
        }
        //Debug.Log(collision.gameObject.name);
    }
}
