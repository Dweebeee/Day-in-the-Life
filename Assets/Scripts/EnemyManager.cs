using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyAttack;
    public CombatWaveManager combatWaveManager;

    public PlayerBullet playerBullet;
    // Start is called before the first frame update
    void Awake()
    {
        enemyAttack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            Debug.Log("AttackHit");

            // Increments the number of enemies killed, and may start the next wave.
            combatWaveManager.enemyKilled();

            // Delete Knight object
            Destroy(transform.parent.gameObject);
            // asks playerbullet to delete the bullet shot ; assuming there was a bullet shot
            //playerBullet.DestroyBullet();
        }
    }
}
