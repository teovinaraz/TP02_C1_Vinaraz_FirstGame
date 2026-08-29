using TMPro;
using UnityEngine;
using UnityEngine.UI;

//● En la misma escena del TP01, plantear un menú principal y un menú de pausa de un juego.
//● Menú principal: Debe tener los botones:
//○ Play: Inicia el juego.
//○ Settings Panel: Abre el panel de settings con los siguientes componentes:
//■ Un Slider de velocidad para el Jugador 1.
//● Con un texto que diga el valor actual.
//■ Un Slider de velocidad para el Jugador 2.
//● Con un texto que diga el valor actual.
//■ Botón de Back: Vuelve al menú principal.
//○ Credits Panel: Muestra quién lo desarrolló y de donde provienen los assets integrados en el
//juego.
//○ Exit: Cierra el programa. (Si está en el editor de Unity, debe parar el Play).
//● Menú de Pausa: Debe tener los botones: Continue, Settings, Credits, Exit
//● Al apretar Escape, se activa o desactiva la pausa.
//● Debe tener por lo menos los siguientes componentes:
//○ El valor del slider de “Settings Panel” debe ser el valor de velocidad del jugador.
//○ No debe haber imágenes primitivas. Integrar sprites tanto para la UI como para los jugadores

public class UIManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private Movement playerOne;
    [SerializeField] private Movement playerTwo;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonCredits;
    [SerializeField] private Button buttonExit;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button buttonPauseContinue;
    [SerializeField] private Button buttonPauseSettings;
    [SerializeField] private Button buttonPauseCredits;
    [SerializeField] private Button buttonPauseExit;

    [Header("Gameplay")]
    [SerializeField] private GraphicRaycaster digRaycaster;

    [Header("Player Speed")]
    [SerializeField] private Slider sliderPlayerOneSpeed;
    [SerializeField] private TMP_Text sliderValuePlayerOneSpeed;
    [SerializeField] private Slider sliderPlayerTwoSpeed;
    [SerializeField] private TMP_Text sliderValuePlayerTwoSpeed;

    [Header("Settings")]
    [SerializeField] private Button buttonSettingsBack;

    [Header("Credits")]
    [SerializeField] private Button buttonCreditsBack;

    private bool isPlaying = false;
    private bool settingsFromPause = false;
    private bool creditsFromPause = false;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnPlayClicked);
        buttonSettings.onClick.AddListener(OnSettingsClicked);
        buttonCredits.onClick.AddListener(OnCreditsClicked);
        buttonExit.onClick.AddListener(OnExitClicked);

        buttonPauseContinue.onClick.AddListener(OnPauseContinueClicked);
        buttonPauseSettings.onClick.AddListener(OnPauseSettingsClicked);
        buttonPauseCredits.onClick.AddListener(OnPauseCreditsClicked);
        buttonPauseExit.onClick.AddListener(OnExitClicked);

        buttonSettingsBack.onClick.AddListener(OnSettingsBackClicked);
        buttonCreditsBack.onClick.AddListener(OnCreditsBackClicked);

        sliderPlayerOneSpeed.onValueChanged.AddListener(OnPlayerOneSpeed);
        sliderPlayerTwoSpeed.onValueChanged.AddListener(OnPlayerTwoSpeed);
    }

    private void Start()
    {
        Time.timeScale = 0f;

        digRaycaster.enabled = false;

        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1f)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void OnDestroy()
    {
        buttonPlay.onClick.RemoveListener(OnPlayClicked);
        buttonSettings.onClick.RemoveListener(OnSettingsClicked);
        buttonCredits.onClick.RemoveListener(OnCreditsClicked);
        buttonExit.onClick.RemoveListener(OnExitClicked);

        buttonPauseContinue.onClick.RemoveListener(OnPauseContinueClicked);
        buttonPauseSettings.onClick.RemoveListener(OnPauseSettingsClicked);
        buttonPauseCredits.onClick.RemoveListener(OnPauseCreditsClicked);
        buttonPauseExit.onClick.RemoveListener(OnExitClicked);

        buttonSettingsBack.onClick.RemoveListener(OnSettingsBackClicked);
        buttonCreditsBack.onClick.RemoveListener(OnCreditsBackClicked);

        sliderPlayerOneSpeed.onValueChanged.RemoveListener(OnPlayerOneSpeed);
        sliderPlayerTwoSpeed.onValueChanged.RemoveListener(OnPlayerTwoSpeed);
    }

    private void OnPlayClicked()
    {
        isPlaying = true;

        mainMenuPanel.SetActive(false);
        digRaycaster.enabled = true;

        Time.timeScale = 1f;
    }

    private void OnSettingsClicked()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);

        settingsFromPause = false;
    }

    private void OnCreditsClicked()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);

        creditsFromPause = false;
    }

    private void OnSettingsBackClicked()
    {
        settingsPanel.SetActive(false);

        if (settingsFromPause)
            pausePanel.SetActive(true);
        else
            mainMenuPanel.SetActive(true);
    }

    private void OnCreditsBackClicked()
    {
        creditsPanel.SetActive(false);

        if (creditsFromPause)
            pausePanel.SetActive(true);
        else
            mainMenuPanel.SetActive(true);
    }

    private void OnPauseContinueClicked()
    {
        pausePanel.SetActive(false);
        digRaycaster.enabled = true;

        Time.timeScale = 1f;
    }

    private void OnPauseSettingsClicked()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);

        settingsFromPause = true;
    }

    private void OnPauseCreditsClicked()
    {
        pausePanel.SetActive(false);
        creditsPanel.SetActive(true);

        creditsFromPause = true;
    }

    private void OnPlayerOneSpeed(float value)
    {
        playerOne.MovSpeed = value;
        sliderValuePlayerOneSpeed.text = value.ToString("F2");
    }

    private void OnPlayerTwoSpeed(float value)
    {
        playerTwo.MovSpeed = value;
        sliderValuePlayerTwoSpeed.text = value.ToString("F2");
    }

    private void OnExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}