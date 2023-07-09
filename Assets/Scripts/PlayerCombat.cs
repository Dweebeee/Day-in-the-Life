using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject player;
    public GameObject playerAttack;

    public bool enabledAtStart = false;

    private bool attackOnCooldown = false;

    public float AttackDelay;
    public float AttackDuration;
    public float AttackCooldown;
    // Start is called before the first frame update
    void Awake()
    {
        playerAttack.SetActive(false);
        this.enabled = enabledAtStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackOnCooldown == false)
            {
                Debug.Log("Player attacking");
                StartCoroutine(PlayerAttack());
            }
        }
    }

    IEnumerator PlayerAttack()
    {
        attackOnCooldown= true;
        // Initial attack delay
        yield return new WaitForSeconds(AttackDelay);
        // Enable attack box
        playerAttack.SetActive(true);
        // wait attackTime
        yield return new WaitForSeconds(AttackDuration);
        // Disable attack box
        playerAttack.SetActive(false);
        // attackCooldown
        yield return new WaitForSeconds(AttackCooldown);
        attackOnCooldown= false;
    }
}
