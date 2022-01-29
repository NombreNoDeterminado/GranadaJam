using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem Instance;
    private const int MaxLivesNumber = 3;
    
    // Heart images
    public Image heart1, heart2, heart3;
    private Image[] _hearts;
    private int _livesNumber;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        _livesNumber = MaxLivesNumber;
        _hearts = new[] {heart1, heart2, heart3};
    }

    public void TakeDamage(int damage)
    {
        _livesNumber -= damage;
        _livesNumber = Math.Max(0, _livesNumber);
        UpdateHearts();
        Debug.Log($"Remaining lives: {_livesNumber}");
    }

    private void UpdateHearts()
    {
        for (var i = 0; i < _livesNumber; i++)
        {
            _hearts[i].enabled = true;
        }

        for (var i = _livesNumber; i < MaxLivesNumber; i++)
        {
            _hearts[i].enabled = false;
        }
    }
}
