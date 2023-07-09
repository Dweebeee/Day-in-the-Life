using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerdie : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public MusicManager musicManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyAttack")
        {
            Debug.Log("ded");
            StartCoroutine(Die());
            playerSprite.enabled = false;
            musicManager.StopBattleMusic();
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
        
    }


}