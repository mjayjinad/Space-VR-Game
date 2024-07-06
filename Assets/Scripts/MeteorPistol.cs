using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particle;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;
    private bool rayActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable xRGrabInteractable = GetComponent<XRGrabInteractable>();

        xRGrabInteractable.activated.AddListener(x => StartShooting());
        xRGrabInteractable.deactivated.AddListener(x => StopShooting());
    }

    private void Update()
    {
        if (rayActivate)
            RaycastCheck();
    }

    public void StartShooting()
    {
        particle.Play();
        rayActivate = true;
    }

    public void StopShooting()
    {
        particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate= false;
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool HasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if (HasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
