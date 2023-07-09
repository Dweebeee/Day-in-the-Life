using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPopup : MonoBehaviour
{
    public GameObject targetPoint;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        popup.transform.position = targetPoint.transform.position;
        popup.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        popup.SetActive(false);
    }
}
