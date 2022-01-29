using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int xCoordinate;
    public int yCoordinate;
    public Color normal;
    public Color selected;
    
    private ITrap _activeTrap;

    // Start is called before the first frame update
    void Start()
    {
        _activeTrap = null;
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
        TileMatrixController.Instance.TriggerTileClick(this.xCoordinate, this.yCoordinate);
    }

    public void SetTrap(ITrap trap)
    {
        if (_activeTrap == null)
        {
            _activeTrap = trap;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_activeTrap != null)
            {
                LifeSystem.Instance.TakeDamage(_activeTrap.Damage());
            }
        }
    }
}