using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _currentScore;
    [SerializeField] private int _requiredScoreToWin;
    public Action<int> OnScoreChange;

    public int CurrentScore { get => _currentScore; }
    public int RequiredScoreToWin { get => _requiredScoreToWin; }

    public void UpdateScore(int additionalScore)
    {
        _currentScore += additionalScore;
        if(_currentScore >= _requiredScoreToWin)
        {
            _currentScore = _requiredScoreToWin;
        }

        OnScoreChange?.Invoke(_currentScore);
    }
}
