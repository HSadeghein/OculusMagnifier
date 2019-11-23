using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabble : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            Debug.Log("Both");
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.1f && collidingObject)

            {

                GrabObject();

            }

            if (!(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.1f) && objectInHand)

            {

                ReleaseObject();

            }
   
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabble")
        {
            collidingObject = other.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabble")
        {
            collidingObject = null;
        }
    }


    public void GrabObject()

    {

        objectInHand = collidingObject;

        objectInHand.transform.SetParent(this.transform);

        objectInHand.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void ReleaseObject()

    {

        objectInHand.GetComponent<Rigidbody>().isKinematic = false;

        objectInHand.transform.SetParent(null);

        objectInHand = null;

    }


}
