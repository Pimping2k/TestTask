using TMPro;
using UnityEngine;

public class CharacterDeathBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject mainScore;
    [SerializeField] private TextMeshProUGUI deathTextScore;
    public int score;
    private void Start()
    {
        deathPanel.SetActive(false);
        mainScore.SetActive(true);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            Time.timeScale = 0f;
            deathTextScore.text = $"Your score: {PlayerPrefs.GetInt("Score")}";
            mainScore.SetActive(false);
            deathPanel.SetActive(true);
        }
    }
}
