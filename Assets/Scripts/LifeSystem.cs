using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem Instance;
    
    private const int MaxLivesNumber = 3;

    private int _livesNumber;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        _livesNumber = MaxLivesNumber;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        _livesNumber -= damage;
        _livesNumber = Math.Max(0, _livesNumber);
    }
}
