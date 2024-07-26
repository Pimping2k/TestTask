using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWin : MonoBehaviour
{
    [SerializeField] public GameObject[] enemies;
    [SerializeField] GameObject winScreen;
    public static int enemiesCount;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesCount = enemies.Length;
    }
    private void Update()
    {

        if (enemiesCount<=0)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);
        }
    }
}
