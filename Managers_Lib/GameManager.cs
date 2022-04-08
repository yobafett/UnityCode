using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image gameBackground;
    public static GameManager Instance { get; private set; }
    private int _score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void Exit() => Application.Quit();

    public void AddScore(int value = 10)
    {
        _score += value;
        UIManager.Instance.UpdateScore(_score);
    }

    public int GetScore() => _score;

    public bool ReduceScore(int value)
    {
        if (value > _score)
            return false;

        _score -= value;
        UIManager.Instance.UpdateScore(_score);
        return true;
    }

    public void SetBgSprite(Sprite sprite) => gameBackground.sprite = sprite;
}