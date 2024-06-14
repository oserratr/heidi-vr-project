using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    static int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        int iLevel = 0;
        foreach (GameObject level in levels)
        {
            level.SetActive(iLevel == LevelManager.level);
            iLevel++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.frameCount == 300) {
            NextLevel();
        }*/
    }

    static public void NextLevel()
    {
        level++;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
