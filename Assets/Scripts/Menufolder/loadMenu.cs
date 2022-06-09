using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{
    public void loaderMenu(int index)
    {
        SceneManager.LoadScene(index);
    }
}
