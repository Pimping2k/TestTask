using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] UIElementsBehaviour uiElement;
    [SerializeField] ScoreManager scoreManager;
    public float hp;
    private int inc = 0;

    private void Update()
    {
        if (hp <= 0)
        {
            CharacterWin.enemiesCount--;
            Debug.Log("ENEMY IS DEAD");
            inc++;
            scoreManager.IncrementScore(inc);
            Destroy(gameObject);
        }
    }

    public void DecreaseHP(float damage)
    {
        hp -= damage;
    }
}
