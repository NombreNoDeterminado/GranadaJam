using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TrapSelector : MonoBehaviour
{
    public static TrapSelector Instance;
    public Sprite fireSprite;
    public Sprite mineSprite;
    public Sprite laserSprite;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    private GameObject[] imageList;

    public Text text1;
    public Text text2;
    public Text text3;
    private Text[] textList;

    private AudioSource audioSource;
    public AudioClip keyPressedAudio;
    public int minPitch = 1;
    public int maxPitch = 3;

    public Dictionary<string, ITrap> Traps { get; private set; } = new Dictionary<string, ITrap>();

    // Maximum numbers of traps in the array
    private const int MaxTraps = 3;
    public ITrap SelectedTrap { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        imageList = new GameObject[] {image1, image2, image3};
        textList = new Text[] {text1, text2, text3};
        audioSource = GetComponent<AudioSource>();
        UpdateTraps();
    }

    public void UpdateTraps()
    {
        Traps.Clear();
        SelectedTrap = null;
        // Generate random keybindings, 3 random chars given by their ascii code
        for (var i = 0; i < MaxTraps; i++)
        {
            var binding = $"{(char) Random.Range(97, 123)}";
            int trap = Random.Range(0, TrapGeneric.Instances.Length);
            try
            {
                Traps.Add(binding, TrapGeneric.Instances[trap]);
                Debug.Log($"{binding} ${Traps[binding].Name()}");
            }
            catch
            {
                i--;
            }
        }

        setVisualSelector();
    }

    private void Update()
    {
        foreach (var bind in Traps.Keys)
        {
            if (Input.GetKeyDown(bind))
            {
                Debug.Log($"{bind}");
                SelectedTrap = Traps[bind];
                Debug.Log($"{SelectedTrap.Name()}");
                Debug.Log("AUDIO");
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(keyPressedAudio);
            }
        }
    }

    void setVisualSelector()
    {
        List<string> trapsKeys = new List<string>(Traps.Keys);
        Debug.Log(trapsKeys);
        for (int i = 0; i < MaxTraps; i++)
        {
            imageList[i].GetComponent<Image>().sprite = Traps[trapsKeys[i]].Sprite();
            textList[i].text = trapsKeys[i];
        }
    }
}