using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatTransition : MonoBehaviour
{
    public GameObject player;
    public GameObject blackPanel;
    public GameObject teleportPoint;
    public GameObject mainCamera;
    public GameObject cameraPoint;
    public PlayerMovement playerMovement;

    [SerializeField] private bool fadeOnLoad;
    [SerializeField] private float alphaStart;
    [SerializeField] private float alphaEnd;
    public float fadeSpeed = 1;

    private bool fade = false;

    // Start is called before the first frame update
    void Start()
    {
        if (fadeOnLoad)
        {
            blackPanel.SetActive(true);
            StartCoroutine(Fade(1, 0));
        }
    }

    public void StartFade(float alphaStart, float alphaEnd)
    {
        StartCoroutine(Fade(alphaStart, alphaEnd));
    } 

    IEnumerator Fade(float alphaStart, float alphaEnd)
    {
        Image image = blackPanel.GetComponent<Image>();
        image.canvasRenderer.SetAlpha(alphaStart);
        image.CrossFadeAlpha(alphaEnd, 1, false);
        yield return null;
    }

    public void TeleportPlayer()
    {
        //player.transform.position = teleportPoint.transform.position;
        //player.transform.rotation = teleportPoint.transform.rotation;
        //mainCamera.transform.position = cameraPoint.transform.position;
        SceneManager.LoadScene(2);
    }
}
