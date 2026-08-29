using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigManager : MonoBehaviour
{
    [Header("Dig")]
    [SerializeField] private Button buttonDig;
    [SerializeField] private AudioSource digSound;
    [SerializeField] private TMP_Text digText;

    private int counter = 0;

    private void Awake()
    {
        buttonDig.onClick.AddListener(OnDigClicked);
    }

    private void Start()
    {
        digText.text = counter.ToString();
    }

    private void OnDestroy()
    {
        buttonDig.onClick.RemoveListener(OnDigClicked);
    }

    private void OnDigClicked()
    {
        counter++;
        digText.text = counter.ToString();

        digSound.Play();
    }
}