﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscene : MonoBehaviour
{

    public void changeScene()
    {
        SceneManager.LoadScene("gameScene");
    }
    
}
