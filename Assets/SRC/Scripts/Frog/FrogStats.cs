using System;
using UnityEngine;

public class FrogStats : MonoBehaviour
{
    public int _maxHealth;
    private int _health;
    private int _score;

    public Action<int> ScoreChanged;
    public Action<int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if(_health <= 0)
        {
            EndGameUI.instance.ActiveEndMenu();
            gameObject.SetActive(false);
        }
    }

    public void ScoreAdd(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
        Debug.Log("Муха съедена +1");
    }
}
