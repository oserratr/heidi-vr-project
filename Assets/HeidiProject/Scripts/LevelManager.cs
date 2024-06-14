using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    static int level = 0;
    static LevelManager instance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level: " + level);

        instance = this;

        int iLevel = 0;
        foreach (GameObject level in levels)
        {
            Debug.Log(iLevel == LevelManager.level);
            level.SetActive(iLevel == LevelManager.level);
            iLevel++;

        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.frameCount == 500)
        {
            NextLevel();
        }*/

    }

    static public void NextLevel()
    {
        level = (level + 1) % instance.levels.Length;


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }
}
