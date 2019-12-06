using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR.OpenVR;
public class LockPosRotTracking : MonoBehaviour
{
    private bool rotationLock = false;
    private bool positionLock = false;

    private Quaternion startingRotation, currentRotation, rotationChange;
    private Vector3 startingPos, currentPos, posChange;
    private OVRCameraRig cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<OVRCameraRig>();
        startingRotation = Quaternion.identity;
        currentRotation = Quaternion.identity;
        rotationChange = Quaternion.identity;

        startingPos = Vector3.zero;
        currentPos = Vector3.zero;
        posChange = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("First" + cam.trackingSpace.localRotation);
        Debug.Log(positionLock);
        Debug.Log(rotationLock);

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            rotationLock = !rotationLock;

            startingRotation = cam.centerEyeAnchor.localRotation;
        }
        if (rotationLock)
        {
            currentRotation = cam.centerEyeAnchor.localRotation;
            rotationChange = startingRotation * Quaternion.Inverse(currentRotation);
            cam.trackingSpace.localRotation *= rotationChange;
            startingRotation = currentRotation;
            //cam.trackingSpace.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("Then" + cam.trackingSpace.localRotation);

        }
        else
        {
            cam.trackingSpace.eulerAngles = new Vector3(0, cam.trackingSpace.eulerAngles.y, 0);
        }


        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            positionLock = !positionLock;

            startingPos = cam.centerEyeAnchor.localPosition;
        }
        if (positionLock)
        {
            //currentPos = cam.centerEyeAnchor.localPosition;
            //Debug.Log("current Pos : " + currentPos);

            //Debug.Log("starting Pos : " + startingPos);
            //posChange = startingPos - currentPos;

            //cam.centerEyeAnchor.localPosition += posChange;
            //startingPos = currentPos;

            cam.trackingSpace.localPosition = -cam.centerEyeAnchor.localPosition;
        }
        else
        {
            cam.trackingSpace.localPosition = Vector3.zero;
        }
    }

}
