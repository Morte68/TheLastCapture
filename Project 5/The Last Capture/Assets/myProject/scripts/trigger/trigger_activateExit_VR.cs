using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_activateExit_VR : UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable
{
    protected override void Grab()
    {
        GetComponent<trigger_activateExit>().Interact();
    }
}
