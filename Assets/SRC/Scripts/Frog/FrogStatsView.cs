using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrogStatsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTMP;
    [SerializeField] private TMP_Text _healthTMP;

    FrogStats _frogStats;

    private void Start()
    {
        _frogStats = GetComponent<FrogStats>();

        UpdateHealthTMP(_frogStats._maxHealth);

        _frogStats.ScoreChanged += UpdateScoreTMP;
        _frogStats.HealthChanged += UpdateHealthTMP;
    }

    private void UpdateHealthTMP(int health)
    {
        _healthTMP.text = health.ToString();
    }

    private void UpdateScoreTMP(int score)
    {
        _scoreTMP.text = score.ToString();
    }
}
