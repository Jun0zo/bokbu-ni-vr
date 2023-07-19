using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    public UnityEvent OnTrigger;
    public UnityEvent OffTrigger;


    private void OnTriggerEnter(Collider other)
    {
        OnTrigger.Invoke();
        Debug.Log("!!!! in");
    }

    private void OnTriggerExit(Collider other)
    {
        OffTrigger.Invoke();
        Debug.Log("!!!! out");
    }
}
