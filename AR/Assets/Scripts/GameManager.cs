using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private List<GameObject> allBlocks;
    public GameObject[] levelPrefabs;

    private int currentLevel = 0;
    private bool isGameCompleted = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        ChangeScene("Menu");
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnLevelWasLoaded(int level)
    {
        isGameCompleted = false;

        if (SceneManager.GetActiveScene().name == "Game")
            CreateLevel();
    }

    private void CreateLevel()
    {
        if (currentLevel < levelPrefabs.Length)
            Instantiate(levelPrefabs[currentLevel]);

        else
            isGameCompleted = true;

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        allBlocks = new List<GameObject>();
        allBlocks.AddRange(blocks);
    }

    public void RemoveBlock(GameObject block)
    {
        if (allBlocks.Find(b=>b == block))
            allBlocks.Remove(block);

        if (allBlocks.Count == 0)
            Victory();
    }

    public void Victory()
    {
        currentLevel++;
        
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        
        for (int i = 0; i < blocks.Length; ++i)
            DestroyImmediate(blocks[i]);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < bullets.Length; ++i)
            DestroyImmediate(bullets[i]);

        CreateLevel();
    }

    private void Update()
    {
        if (isGameCompleted)
            ChangeScene("Menu");
    }
}
