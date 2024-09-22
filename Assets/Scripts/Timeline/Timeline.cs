using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    [SerializeField]
    float timerDelayActive;

    [SerializeField]
    float timerDelayBehaviour;

    [SerializeField]
    GameObject[] objectActives;

    [SerializeField]
    GameObject[] objectActiveBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in objectActiveBehaviour)
        {
            obj.GetComponent<MonoBehaviour>().enabled = false;

        }
        StartCoroutine(DelayActive(timerDelayActive));
        StartCoroutine(DelayMonobehaviour(timerDelayBehaviour));
    }

    IEnumerator DelayActive(float timer)
    {
        if(objectActives.Length > 0)
        {
            yield return new WaitForSeconds(timer);
            foreach (var obj in objectActives)
            {
                obj.SetActive(true);
            }
        }
        
    }

    IEnumerator DelayMonobehaviour(float timer)
    {
        if(objectActiveBehaviour.Length > 0)
        {
            yield return new WaitForSeconds(timer);
            foreach (var obj in objectActiveBehaviour)
            {
                obj.GetComponent<MonoBehaviour>().enabled = true;

            }

        }
        
    }

}
