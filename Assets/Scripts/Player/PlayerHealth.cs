using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int Maxhealth = 10;
    [SerializeField] private float health;
    GameManager manager;
    [SerializeField] private Image healthUI;
    private PlayerAudio playerAudio;
    private void Start()
    {
        // Assign in inspector rather than in code
        playerAudio = GetComponent<PlayerAudio>();
        manager = FindAnyObjectByType<GameManager>();
        health = Maxhealth;
        SetUI();
    }

    public void TakeDamage()
    {
        health -= 10f;
        healthUI.fillAmount = health / Maxhealth;
        SetUI();
        if (health >= 50)
        {
            playerAudio.Dmg();
        }
        else if (health <= 50)
        {
            playerAudio.low();
        }
        if (health <= 0)
        {
            manager.ResetGame();
            gameObject.SetActive(false);
        }
    }
    void SetUI()
    {
        healthUI.fillAmount = health / Maxhealth;
    }
}
