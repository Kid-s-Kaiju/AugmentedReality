using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public Text score;
    private void Update()
    {
        score.text = GameManager.Instance.score.ToString();
    }

    public void GoToMenu()
    {
        GameManager.Instance.ChangeScene("Menu");
    }

    public void GoToNextLevel()
    {
        GameManager.Instance.currentLevel++;
        GameManager.Instance.CreateLevel();
    }

    public void RestartLevel()
    {
        GameManager.Instance.CreateLevel();
    }
}
