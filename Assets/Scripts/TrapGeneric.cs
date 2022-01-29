using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapGeneric : MonoBehaviour, ITrap
{
    private const int NumberOfTotalTraps = 5;
    
    public Sprite trapSprite;
    public int trapDamage;
    public float trapDuration;
    public int trapSize;
    public bool trapOrientation;
    public string trapName;
    public int trapId;
    public static ITrap[] Instances = new ITrap[NumberOfTotalTraps];

    private void Awake()
    {
        try
        {
            Instances[trapId] = this;
            Debug.Log($"Trap ${trapName} instanced");
        }
        catch
        {
            Debug.Log($"{trapId}/{Instances.Length}");
        }

    }

    public int Damage()
    {
        return trapDamage;
    }

    public float Duration()
    {
        return trapDuration;
    }

    public int Size()
    {
        return trapSize;
    }

    public bool Orientation()
    {
        return trapOrientation;
    }

    public Sprite Sprite()
    {
        return trapSprite;
    }

    public string Name()
    {
        return trapName;
    }
}