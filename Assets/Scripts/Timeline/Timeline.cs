using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    [SerializeField]
    float timerDelay;

    [SerializeField]
    List<GameObject> listOfObjectActives = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayActive(timerDelay));
    }

    IEnumerator DelayActive(float timer)
    {
        yield return new WaitForSeconds(timer);
        foreach(var obj in listOfObjectActives)
        {
            obj.GetComponent<MonoBehaviour>().enabled = true;
        }
    }

}
