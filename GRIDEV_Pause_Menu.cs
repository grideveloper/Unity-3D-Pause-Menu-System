//--------------------------------------
//created by grigamedevelopment.com.tr
//BURAK KARADAG / karadagburak1881@gmail.com
//-----------------------------------------

//ADD INSIDE YOUR CLASS
    AudioSource playerAudioSource;
    [SerializeField] AudioClip playerPauseMenuAudioClip;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject[] deactivatedGOs;
    [SerializeField] MonoBehaviour[] deactivatedScripts;
    public bool isPaused = false;

    private void OnEnable()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        pauseMenuUI.SetActive(false);
    }

    private void OnDisable()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                foreach (var script in deactivatedScripts)
                {
                    script.enabled = false;
                }

                foreach (var GOs in deactivatedGOs)
                {
                    GOs.SetActive(false);
                }
                playerAudioSource.pitch = 1;
                playerAudioSource.loop = true;
                playerAudioSource.spatialBlend = 1;
                playerAudioSource.clip = playerPauseMenuAudioClip;
                playerAudioSource.Play();
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseMenuUI.SetActive(true);
            }
            else
            {
                foreach (var script in deactivatedScripts)
                {
                    script.enabled = true;
                }
                foreach (var GOs in deactivatedGOs)
                {
                    GOs.SetActive(true);
                }
                playerAudioSource.clip = null;
                playerAudioSource.loop = false;
                playerAudioSource.spatialBlend = 0;
                Time.timeScale = 1f;
                pauseMenuUI.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ContinueGame()
    {
        foreach (var script in deactivatedScripts)
        {
            script.enabled = true;
        }
        foreach (var GOs in deactivatedGOs)
        {
            GOs.SetActive(true);
        }
        playerAudioSource.loop = false;
        playerAudioSource.spatialBlend = 0;
        playerAudioSource.clip = null;
        isPaused = false;
        playerAudioSource.Stop();
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

//---THEN CONNECT WITH YOUR MOVEMENT SYSTEM---\\