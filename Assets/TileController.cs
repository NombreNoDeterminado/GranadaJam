using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

}
