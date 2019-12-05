using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    private Text mText;
    private string mExit, mInfo, mSwitchMaterial, mMagnifierGenerator;
    [HideInInspector]

    // Start is called before the first frame update
    void Start()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        mText = GetComponent<Text>();
        mExit = $"<b>*</b> Press the Second Button of the Left Controller to Exit ==> <b><color=red>Y</color></b>\n";
        mInfo = $"<b>*</b> You should take the <b><color=red>both</color></b> controller on\n";
        mSwitchMaterial = $"<b>*</b> Press the first button of the Right Controller to switch to the Stencil Method ==> <b><color=red>A</color></b>\n";
        mMagnifierGenerator = $"<b>*</b> Press the first button of the Left Controller to generate another magnifier at the initial position ==> <b><color=red>X</color></b>\n";

        mText.text =  mInfo + mExit + mSwitchMaterial + mMagnifierGenerator;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
