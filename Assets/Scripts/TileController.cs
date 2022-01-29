using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int xCoordinate;
    public int yCoordinate;
    public Material normal;
    public Material hover;

    private Renderer[] _objectRendererReference;
    private ITrap _activeTrap;

    // Start is called before the first frame update
    void Start()
    {
        _activeTrap = null;
        _objectRendererReference = new Renderer[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _objectRendererReference[i] = transform.GetChild(i).GetComponent<Renderer>();
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log($"{xCoordinate}{yCoordinate}");
        foreach (var rend in _objectRendererReference)
        {
            rend.material = hover;
        }
    }

    private void OnMouseExit()
    {
        foreach (var rend in _objectRendererReference)
        {
            rend.material = normal;
        }
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
                _activeTrap = null;
            }
        }
    }
}