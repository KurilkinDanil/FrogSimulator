using UnityEngine;

public class AddScoreEffect : EatEffect
{
    [SerializeField] private int _scoreAdded;
    public override void Eat(FrogStats frogStats)
    {
        frogStats.ScoreAdd(_scoreAdded);
    }
}
