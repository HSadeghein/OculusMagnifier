using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SetChild : MonoBehaviour
{



    private bool isDone = false;
    private Transform rightHand, leftHand;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        rightHand = this.GetComponent<Transform>().Find("hand_right");
        leftHand = this.GetComponent<Transform>().Find("hand_left");
        if (leftHand != null && rightHand != null && !isDone)
        {
            this.GetComponent<Transform>().Find("GrabberRight").transform.position = new Vector3(0, 0, 0);
            this.GetComponent<Transform>().Find("GrabberRight").transform.parent = rightHand.transform;
            this.GetComponent<Transform>().Find("GrabberLeft").transform.position = new Vector3(0, 0, 0);
            this.GetComponent<Transform>().Find("GrabberLeft").transform.parent = leftHand.transform;
            isDone = true;
        }

    }


}
