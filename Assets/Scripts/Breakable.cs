using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieaces;
    public float timeToBreak;
    public UnityEvent OnBreak;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in breakablePieaces)
        {
            go.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if(timer > timeToBreak)
        {
            foreach (GameObject go in breakablePieaces)
            {
                go.SetActive(true);
                go.transform.parent = null;
            }

            OnBreak?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
