using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TrapSelector : MonoBehaviour
{
    public static TrapSelector instance;
    public Sprite fireSprite;
    public Sprite mineSprite;
    public Sprite laserSprite;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    private GameObject[] _imageList;

    public Text text1;
    public Text text2;
    public Text text3;
    private Text[] _textList;

    private AudioSource _audioSource;
    public AudioClip keyPressedAudio;
    public int minPitch = 1;
    public int maxPitch = 3;

    private Dictionary<string, ITrap> Traps { get; set; } = new Dictionary<string, ITrap>();

    // Maximum numbers of traps in the array
    private const int MaxTraps = 3;
    public ITrap SelectedTrap { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        _imageList = new[] {image1, image2, image3};
        _textList = new[] {text1, text2, text3};
        _audioSource = GetComponent<AudioSource>();
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
            var trap = Random.Range(0, TrapGeneric.Instances.Length);
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

        SetVisualSelector();
    }

    private void Update()
    {
        foreach (var bind in Traps.Keys.Where(Input.GetKeyDown))
        {
            Debug.Log($"{bind}");
            SelectedTrap = Traps[bind];
            Debug.Log($"{SelectedTrap.Name()}");
            Debug.Log("AUDIO");
            _audioSource.pitch = Random.Range(minPitch, maxPitch);
            _audioSource.PlayOneShot(keyPressedAudio);
        }
    }

    private void SetVisualSelector()
    {
        var trapsKeys = new List<string>(Traps.Keys);
        Debug.Log(trapsKeys);
        for (var i = 0; i < MaxTraps; i++)
        {
            _imageList[i].GetComponent<Image>().sprite = Traps[trapsKeys[i]].Sprite();
            _textList[i].text = trapsKeys[i];
        }
    }
}