using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOrigin : MonoBehaviour
{
    private Vector3 mOriginPos;
    // Start is called before the first frame update
    void Start()
    {
        mOriginPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            this.transform.position = mOriginPos;
        }
    }
}
