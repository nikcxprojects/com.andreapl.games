using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private int count;
    private GameObject _gameRef;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject records;

    [Space(10)]
    [SerializeField] GameObject pause;

    [Space(10)]
    [SerializeField] Text countText;

    private void Awake()
    {
        Block.OnBlockCollided += () =>
        {
            countText.text = $"{++count}";
        };
    }


    private void Start()
    {
        OpenMenu();
    }

    public void OpenRecords()
    {
        records.SetActive(true);
        menu.SetActive(false);
    }

    public void SetPause(bool IsPause)
    {
        Time.timeScale = IsPause ? 0.0f : 1.0f;
        pause.SetActive(IsPause);
    }

    public void StartGame()
    {
        count = 0;
        countText.text = $"{count}";

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);
        game.SetActive(true);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1.0f;
        pause.SetActive(false);

        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        records.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);
    }
}
