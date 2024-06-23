using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class data1 : MonoBehaviour
{
    public Text text;
    public Text text2;
    public Text text3;
    public Text text5;
    public InputField dataStart;
    public InputField dataFinish;
    public int dniostalis;

    void Start()
    {
        if (PlayerPrefs.HasKey("StartDate"))
        {
            string savedDate = PlayerPrefs.GetString("StartDate");
            dataStart.text = savedDate;
        }

        if (PlayerPrefs.HasKey("FinishDate"))
        {
            int savedFinishDate = PlayerPrefs.GetInt("FinishDate");
            dataFinish.text = savedFinishDate.ToString();
        }
        
    }

    void Update()
    {

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public void Rogden()
    {
        DateTime nowDate = DateTime.Now;
        string format = "dd.MM.yyyy";
        DateTime startDate = DateTime.ParseExact(dataStart.text, format, System.Globalization.CultureInfo.InvariantCulture);
        PlayerPrefs.SetString("StartDate", startDate.ToString(format));

        int finishDateInYears = int.Parse(dataFinish.text);
        PlayerPrefs.SetInt("FinishDate", finishDateInYears);
        PlayerPrefs.Save();

        DateTime finishDate = startDate.AddYears(finishDateInYears);

        TimeSpan interval1 = nowDate - startDate;
        TimeSpan interval2 = finishDate - nowDate;
        TimeSpan interval3 = finishDate - startDate;

        dniostalis = interval2.Days;

        text.text = interval1.Days.ToString();
        text2.text = interval3.Days.ToString();
        text3.text = interval2.Days.ToString();
        text5.text = "Вот столько дней осталось";
    }

    public void Rogden2() 
    { 
        int milli = 1000000;
        int dohod = milli/dniostalis;
        string dohodtext = dohod.ToString();
        text5.text = "Требуемый доход";
        text3.text = dohodtext+"$ / в день";
    }
    
}

