using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeypad : MonoBehaviour
{

    public AudioSource audioSource;
    public GameObject menu;
    private bool isShowing = false;

    void OnMouseDown()
    {
        audioSource.Play();
        isShowing = true;
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(isShowing);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("q"))
        {
            isShowing = false;
            menu.SetActive(isShowing);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
