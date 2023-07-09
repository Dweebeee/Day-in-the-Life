using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeScript : MonoBehaviour
{
    public bool startOnStart;

    public GameObject textPanel;
    public TextMeshProUGUI dialouge;
    public Image characterImage;
    public TextMeshProUGUI characterName;
    public List<Dialouge> dialouges;
    private bool talking = false;
    private bool interactable = false;
    private int currentLine = 0;

    public bool isPrincess = false;
    public bool isKnight = false;

    public CombatTransition combatTransition;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public PlayerShoot playerShoot;
    public MusicManager musicManager;
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        combatTransition= FindObjectOfType<CombatTransition>();
        playerCombat= FindObjectOfType<PlayerCombat>();
        playerShoot= FindObjectOfType<PlayerShoot>();
        Debug.Log(dialouges.Count);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }

    public void Update()
    {
        if (interactable == true)
        {
            if ((Input.GetButtonDown("Jump") || startOnStart) && talking == false)
            {
                textPanel.SetActive(true);
                talking = true;
                playerMovement.enabled = false;
                playerCombat.enabled = false;
                dialouge.text = dialouges[0].dialouge;
                characterImage.sprite = dialouges[0].characterImage;
                characterName.text = dialouges[0].characterName;
            }
            else if (Input.GetButtonDown("Jump") && talking == true)
            {
                currentLine += 1;
                //If no more dialoge
                if (currentLine >= dialouges.Count)
                {
                    // Stop
                    textPanel.SetActive(false);
                    talking = false;
                    currentLine = 0;
                    // Checks if the person that player is talking to is the princess
                    if (isPrincess)
                    {
                        interactable = false;
                        combatTransition.StartFade(0, 1);
                        PlayerForm.playingAsPrincess = true;
                        StartCoroutine(FadeIn());
                    }
                    else if (isKnight)
                    {
                        // In Battle, so enable battle stuff.
                        musicManager.StartBattleMusic();
                        playerMovement.enabled = true;
                        playerCombat.enabled = true;
                        playerShoot.enabled = true;
                        EnemyAI enemyAI = this.gameObject.GetComponentInParent<EnemyAI>();
                        enemyAI.combat = true;
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        playerMovement.enabled = true;
                        if (PlayerForm.playingAsPrincess == true)
                        {
                            playerCombat.enabled = true;
                            playerShoot.enabled = true;
                        }
                    }
                }
                else
                {
                    dialouge.text = dialouges[currentLine].dialouge;
                    characterImage.sprite = dialouges[currentLine].characterImage;
                    characterName.text = dialouges[currentLine].characterName;
                }
            }
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        combatTransition.TeleportPlayer();
        yield return new WaitForSeconds(0.5f);
        combatTransition.StartFade(1, 0);
    }
}
