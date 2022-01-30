using System;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    private const int MaxLivesNumber = 3;
    private bool _canTakeDamage;

    public Text lifeText;
    public GameObject gameOverText;

    // Heart images
    public Image heart1, heart2, heart3;
    private Image[] _hearts;

    private int _livesNumber;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        _canTakeDamage = true;
        _livesNumber = MaxLivesNumber;
        _hearts = new[] {heart1, heart2, heart3};
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void EnableDamage()
    {
        _canTakeDamage = true;
    }

    public void TakeDamage(int damage)
    {
        if (!_canTakeDamage) return;
        _livesNumber -= damage;
        _livesNumber = Math.Max(0, _livesNumber);
        //UpdateHearts();
        Debug.Log($"Remaining lives: {_livesNumber}");
        lifeText.text = _livesNumber.ToString();
        _canTakeDamage = false;
        Invoke(nameof(EnableDamage), 1.5f);
        if (_livesNumber > 0) return;
        gameOverText.SetActive(true);
        Time.timeScale = 0;
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