using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int xCoordinate;
    public int yCoordinate;
    public Material normal;
    public Material hover;

    private Renderer[] _objectRendererReference;
    private ITrap _activeTrap;
    private ParticleSystem _particles;

    // Start is called before the first frame update
    private void Start()
    {
        _particles = null;
        _activeTrap = null;
        _objectRendererReference = new Renderer[transform.childCount];
        for (var i = 0; i < transform.childCount; i++)
        {
            _objectRendererReference[i] = transform.GetChild(i).GetComponent<Renderer>();
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log($"{xCoordinate}{yCoordinate}");
        SetMaterial(hover);
    }

    private void OnMouseExit()
    {
        SetMaterial(_activeTrap == null ? normal : _activeTrap.Trapped());
    }

    private void ClearTrap()
    {
        try
        {
            _particles.Stop();
        }
        catch
        {
        }

        _particles = null;
        _activeTrap = null;
        SetMaterial(normal);
    }

    private void SetMaterial(Material m)
    {
        foreach (var rend in _objectRendererReference)
        {
            rend.material = m;
        }
    }

    private void OnMouseDown()
    {
        TileMatrixController.instance.TriggerTileClick(this.xCoordinate, this.yCoordinate);
        TrapSelector.instance.UpdateTraps();
    }

    public void SetTrap(ITrap trap)
    {
        if (_activeTrap != null) return;

        Debug.Log("Trap added");
        _activeTrap = trap;
        SetMaterial(_activeTrap.Trapped());
        try
        {
            _particles = Instantiate(_activeTrap.Particles(), transform, true);
            _particles.transform.localPosition = Vector3.zero;
            _particles.Play();
        }
        catch
        {
        }

        Invoke(nameof(ClearTrap), trap.Duration());
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (_activeTrap == null) return;
        LifeSystem.instance.TakeDamage(_activeTrap.Damage());
        _activeTrap = null;
    }
}