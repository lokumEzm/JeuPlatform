using System.Collections;
using UnityEngine;

public class Record : MonoBehaviour
{
    public GameObject newRecord;
    public GameObject noRecord;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newRecord.SetActive(false);
        noRecord.SetActive(false);
    }

    public void NewRecord()
    {
        newRecord.SetActive(true);

        StartCoroutine(RecordTimer());
    }

    public void NoRecord()
    {
        noRecord.SetActive(true);

        StartCoroutine(RecordTimer());
    }
    
     IEnumerator RecordTimer()
    {
        yield return new WaitForSeconds(4);
        newRecord.SetActive(false);
         noRecord.SetActive(false);
        GameManager.Instance.finishLevel.Invoke();
    }
}
