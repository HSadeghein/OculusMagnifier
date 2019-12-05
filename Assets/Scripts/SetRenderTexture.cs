using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderTexture : MonoBehaviour
{
    private Material mLensMagnifierTransparent;
    public Material mStencilMaterial;
    public RenderTexture mLensRenderTexture;
    public Camera mMagnifierCamera;

    private bool mSwitchMaterial = false;
    // Start is called before the first frame update
    void Start()
    {
        mLensMagnifierTransparent = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mLensMagnifierTransparent.mainTexture = mLensRenderTexture;
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            mSwitchMaterial = !mSwitchMaterial;
        }
        if (mSwitchMaterial)
            GetComponent<MeshRenderer>().material = mStencilMaterial;
        else
            GetComponent<MeshRenderer>().material = mLensMagnifierTransparent;

    }
}
