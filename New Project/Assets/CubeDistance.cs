using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CubeDistance : MonoBehaviour
{

    public TextMeshProUGUI objective;

    public GameObject cube;
    private bool cubeOn = false;
    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, cube.transform.position);
        Debug.Log(distance);
        if (distance < 2.5f && !cubeOn)
        {
            objective.text = "";
            Invoke("GameWon", 1f);
        }
        else if(distance >= 3)
        {
            objective.color = new Color32(255, 0, 0, 255);
            objective.text = "X";
            cubeOn = false;
        }
    }

    private void GameWon()
    {
        if (Vector3.Distance(transform.position, cube.transform.position) < 2.5f)
        {
            objective.color = new Color32(0, 255, 0, 255);
            objective.text = "V";
            cubeOn = true;
        }
    }
}
