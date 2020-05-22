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

        GameObject tracker = GameObject.Find("LevelTarget");
    }

    public void GoToMenu()
    {
        GameManager.Instance.ChangeScene("Menu");        
    }

    public void GoToNextLevel()
    {
        GameManager.Instance.currentLevel++;
        if (GameManager.Instance.currentLevel < 4)
            GameManager.Instance.CreateLevel();
        else
            GoToMenu();
    }

    public void RestartLevel()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        for (int i = 0; i < blocks.Length; ++i)
            DestroyImmediate(blocks[i]);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < bullets.Length; ++i)
            DestroyImmediate(bullets[i]);

        GameObject tracker = GameObject.Find("LevelTarget");

        for (int i = 0; i < tracker.transform.childCount; ++i)
        {
            DestroyImmediate(tracker.transform.GetChild(i).gameObject);
        }

        GameManager.Instance.CreateLevel();
    }
  
}
