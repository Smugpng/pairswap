using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MainMenu : MonoBehaviour
{
    
    GameObject[] blocks;
    public float timer;
    public TextMeshProUGUI HighScore;
    // Start is called before the first frame update
    private void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        /*
         * Optimization, but not preferred: when it’s time to destroy blocks, can find them all then rather than in update.
         * Enemies are created in game manager in both main menu and actual level. 
           If logic is simple enough, could move it into main menu so that when each enemy is created, it can be added to an array rather than always looking for objects.
         * Alternatively, can check which level you are in when spawning enemies.
           If main menu, add it to the main menu array.Can assign a ref to main menu in the inspector.
           When determining which level, can use an int or something simple rather than comparing level name.
        */
        blocks = GameObject.FindGameObjectsWithTag("block");

        // Use invoke repeating rather than update to calculate timer
        timer += Time.deltaTime;
        DestroyBlocks();
    }
    void DestroyBlocks()
    {
        if (timer >= 30)
        {
            timer = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                Destroy(blocks[i]);
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    
 
}
