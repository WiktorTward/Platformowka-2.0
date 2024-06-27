using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;
    public GameObject deathPanel;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            if (deathPanel != null) deathPanel.SetActive(true);
            Debug.Log("MAN IS DEAD!");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
