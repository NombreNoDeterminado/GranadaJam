using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{

    public Color normal;
    public Color selected;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = selected;
    }
    
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = normal;
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
