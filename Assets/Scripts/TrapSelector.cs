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

    public Dictionary<string, ITrap> Traps { get; private set; }

    // Maximum numbers of traps in the array
    private const int MaxTraps = 3;
    public ITrap SelectedTrap { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Traps = new Dictionary<string, ITrap>();
        UpdateTraps();
        imageList = new GameObject[] {image1, image2, image3};
        textList = new Text[] {text1, text2, text3};
    }

    private void UpdateTraps()
    {
        Traps.Clear();
        SelectedTrap = null;
        // Generate random keybindings, 3 random chars given by their ascii code
        for (var i = 0; i < MaxTraps; i++)
        {
            var binding = $"{(char) Random.Range(97, 123)}";
            ITrap trap = null; // TODO: Select a random trap from a global array of all traps
            try
            {
                Traps.Add(binding, trap);
            }
            catch
            {
                i--;
            }
        }
    }

    private void Update()
    {
        foreach (var bind in Traps.Keys)
        {
            if (Input.GetKey(bind))
            {
                SelectedTrap = Traps[bind];
            }
        }
    }

    void setVisualSelector(Dictionary<string, ITrap> traps)
    {
        List<string> trapsKeys = new List<string>(traps.Keys);
        for (int i = 0; i < imageList.Length; i++)
        {
            imageList[i].GetComponent<Image>().sprite = traps[trapsKeys[i]].Sprite();
            textList[i].text = trapsKeys[i];
        }
    }
}