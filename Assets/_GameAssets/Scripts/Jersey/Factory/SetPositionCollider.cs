using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetPositionCollider : MonoBehaviour
{
    public int jerseyPosNo = 0;
    [SerializeField] Animator truckAni;
    [SerializeField] List<Transform> setPositionJerseyList = new List<Transform>();
    [SerializeField] List<GameObject> allDestroyObject = new List<GameObject>();
    [SerializeField] GameObject cloudFX;

    private void Start()
    {
        cloudFX.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jersey")
        {
            IncreaseDecreaseCoin.instate.Increse(SaveManager.Instance.state.increaseNo);
            StartCoroutine(SetPosition(other.transform));
            
            other.GetComponent<JerseyPrefab>().objText.text = "$ " + SaveManager.Instance.state.increaseNo;

        }
        allDestroyObject.Add(other.gameObject);
    }

    IEnumerator SetPosition(Transform pos)
    {
        float currentTime = 0;
        float duration = 0.5f;
        Vector3 currentPos = pos.position;
        Vector3 currentRotation = pos.eulerAngles;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            pos.position = Vector3.Lerp(currentPos, setPositionJerseyList[jerseyPosNo].position, currentTime / duration);
            yield return null;
        }

        pos.GetComponent<JerseyPrefab>().objTextAni.gameObject.SetActive(true);
        pos.GetComponent<JerseyPrefab>().objTextAni.Play("FirstFactoryCoin_anim");

        jerseyPosNo++;
        pos.eulerAngles = currentRotation;
        if (jerseyPosNo == setPositionJerseyList.Count)
        {
            jerseyPosNo = 0;
            truckAni.Play("Truck_anim");
            for (int i = 0; i < allDestroyObject.Count; i++)
            {
                float timeIs = 1.5f;
                StartCoroutine(cloudFXFN(timeIs));
                Destroy(allDestroyObject[i]);
            }
            allDestroyObject.Clear();
        }
    }

    IEnumerator cloudFXFN(float timeIs)
    {
        cloudFX.SetActive(true);
        yield return new WaitForSeconds(timeIs);
        cloudFX.SetActive(false);
    }
}
