using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Text timer;
    private float _time;

    public bool Working { get; set; }

    // Start is called before the first frame update
    public void Start()
    {
        instance = this;
        Working = true;
        _time = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Working) return;
        _time += Time.deltaTime;
        timer.text = $"{Mathf.FloorToInt(_time / 60)}:${Mathf.FloorToInt(_time) % 60}";
    }
}