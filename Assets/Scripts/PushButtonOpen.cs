using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PushButtonOpen : MonoBehaviour
{
    public Animator animator;
    public string boolName = "Open";
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleOpen());
    }

    private void ToggleOpen()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
    }
}