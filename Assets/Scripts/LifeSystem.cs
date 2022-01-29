using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem Instance;
    private const int MaxLivesNumber = 3;
    private bool _canTakedamage;

    public Text lifeText;
    
    // Heart images
    public Image heart1, heart2, heart3;
    private Image[] _hearts;
    private int _livesNumber;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        _canTakedamage = true;
        _livesNumber = MaxLivesNumber;
        _hearts = new[] {heart1, heart2, heart3};
    }

    private void enableDamage()
    {
        _canTakedamage = true;
    }

    public void TakeDamage(int damage)
    {
        if(_canTakedamage)
        {
            _livesNumber -= damage;
            _livesNumber = Math.Max(0, _livesNumber);
            //UpdateHearts();
            Debug.Log($"Remaining lives: {_livesNumber}");
            lifeText.text = _livesNumber.ToString();
            _canTakedamage = false;
            Invoke("enableDamage", 3);
        }
       
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
