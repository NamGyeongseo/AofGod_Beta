using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public void ToggleClick()
    {
        Debug.Log("Button Clicked!"); // µð¹ö±ë ·Î±×
      
        SceneManager.LoadScene("1111_Main");
    }                 
}
