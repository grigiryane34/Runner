using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private CoinManager _coinManager;

    private PrefsValue<int> currentLevel = new PrefsValue<int>("Level", 1);

    public int CurrentLevel
    {
        get => currentLevel.Value;
        set => currentLevel.Value = value;
    }

    private void Awake()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevel < SceneManager.sceneCountInBuildSettings && currentScene != CurrentLevel)
        {
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(CurrentLevel);
        }
    }

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next >= 4)
            next = 0;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            CurrentLevel = next;
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
        }
    }
}