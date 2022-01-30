using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    private const int MaxLivesNumber = 3;
    private bool _canTakeDamage;


    public AudioSource S;
    public AudioClip GameOverAudio;
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
        UpdateHearts();
        Debug.Log($"Remaining lives: {_livesNumber}");
        //lifeText.text = _livesNumber.ToString();
        _canTakeDamage = false;
        Invoke(nameof(EnableDamage), 1.5f);
        if (_livesNumber > 0) return;
        gameOverText.SetActive(true);
        Timer.instance.Working = false;
        S.clip = GameOverAudio;
        S.Play();
        goToMainSceneDelay();

    }


    public void goToMainScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void goToMainSceneDelay()
    {
        Invoke("goToMainScene", 3f);
    }



    private void UpdateHearts()
    {
        for (var i = _livesNumber; i < MaxLivesNumber; i++)
        {
            Color emptyHeart = Color.black;
            emptyHeart.a = 0.5f;
            _hearts[i].color = emptyHeart;
        }
    }
}