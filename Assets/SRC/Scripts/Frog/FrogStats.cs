using UnityEngine;

public class FrogStats : MonoBehaviour
{
    private float _health;
    private int _score;

    public void ApplyDamage(float damage)
    {
        _health -= damage;
    }

    public void ScoreAdd(int score)
    {
        _score += score;
        Debug.Log("Муха съедена +1");
    }
}
