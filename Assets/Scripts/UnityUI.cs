using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnityUI : MonoBehaviour
{
    public GameObject gameObject;
    public Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = gameObject.GetComponent<Text>().font.material.mainTexture;

    }
}
