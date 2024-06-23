using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneON : MonoBehaviour
{

    public void Money()
    {
        SceneManager.LoadScene("GoldScene");
    }
    public void AntiMoney()
    {
        SceneManager.LoadScene("SampleScene");
    }


}

