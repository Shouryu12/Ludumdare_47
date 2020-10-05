using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button pauseBtn, playBtn;
    public static GUI instance;

    void Awake ()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(this);

        pauseScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(Pause);
        playBtn.onClick.AddListener(Resume);
    }

    void Pause ()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void Resume ()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
