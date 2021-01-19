using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ButtonsHandler : MonoBehaviour
{
    public AudioSource click;
    public AudioSource denied;
    public AudioSource granted;
    public GameObject menu;
    public GameObject door;
    public GameObject newDoor;
    public Light doorLight;
    private bool cooldown = false;
    private bool open = false;
    private List<int> code=new List<int>();
    private List<int> correctCode = new List<int> { 1, 4, 1, 0 };

    public void GetNumber(int number)
    {
        if (!cooldown)
        {
            code.Add(number);
            click.Play();
            Invoke("ResetCooldown", 0.5f);
            cooldown = true;
        }
        
    }

    public void CheckCode()
    {
        if (!open)
        {
            if (correctCode.SequenceEqual(code))
            {
                granted.Play();
                open = true;
                Cursor.lockState = CursorLockMode.Locked;
                menu.SetActive(false);
                code.Clear();
                Destroy(door);
                newDoor.SetActive(true);
                doorLight.color = Color.green;
            }
            else
            {
                code.Clear();
                denied.Play();
            }
        }
        
    }

    public void CloseKeypad()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        code.Clear();
    }

    private void ResetCooldown()
    {
        cooldown = false;
    }
}
