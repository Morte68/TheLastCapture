using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLamp_VR : UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable
{
    protected override void Grab()
    {
        GetComponent<ButtonLamp>().Interact();
    }
}
