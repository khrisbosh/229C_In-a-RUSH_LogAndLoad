using System.Collections.Generic;
using UnityEngine;

public class WoodZoneChecker : MonoBehaviour
{
    public GameObject losePanel;

    private HashSet<GameObject> woodsInZone = new HashSet<GameObject>();
    private bool gameEnded = false;

    private void Start()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            woodsInZone.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameEnded) return;

        if (other.CompareTag("Wood"))
        {
            woodsInZone.Remove(other.gameObject);

            if (woodsInZone.Count <= 0)
            {
                LoseGame();
            }
        }
    }

    private void LoseGame()
    {
        gameEnded = true;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}