using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string triggerTag;
    public UnityEvent<GameObject> OnEnterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == triggerTag)
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
