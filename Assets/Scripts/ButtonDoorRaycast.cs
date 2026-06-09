using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoorRaycast: MonoBehaviour
{
    [SerializeField] private int raylength = 5;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private ButtonDoorController raycastedObject;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "DoorButton";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | LayerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, raylength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<ButtonDoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey) && raycastedObject != null)
                {
                    raycastedObject.gameObject.SendMessage("PlayAnimation", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            CrosshairChange(false);
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}