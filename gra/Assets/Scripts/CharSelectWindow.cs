using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;
using CodeMonkey;

public class CharSelectWindow : MonoBehaviour
{
    private Text PointsAmount;
    private string input;
    private void Awake()
    {
        //ResetPoints();
        int point = GetPoints();
        PointsAmount = transform.Find("PointsAmount").GetComponent<Text>();
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MainMenu); };
        transform.Find("player1").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene);  };
        transform.Find("player2").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene1);
            }
            else
            {
                CMDebug.TextPopupMouse("Niewystarczająca ilość monet");
            }
        };
        transform.Find("player3").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene2);
            }
            else
            {
                CMDebug.TextPopupMouse("Niewystarczająca ilość monet");
            }
        };
        transform.Find("player4").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene3);
            }
            else
            {
                CMDebug.TextPopupMouse("Niewystarczająca ilość monet");
            }
        };
        transform.Find("player5").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene4);
            }
            else
            {
                CMDebug.TextPopupMouse("Niewystarczająca ilość monet");
            }
        };
        transform.Find("player6").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene5);
            }
            else
            {
                CMDebug.TextPopupMouse("Niewystarczająca ilość monet");
            }
        };
    }

    private void Start()
    {
        PointsAmount.text = "Ilość monet: " + GetPoints().ToString();
    }

    public static int GetPoints()
    {
        return PlayerPrefs.GetInt("Points");
    }

    public void AddPoints(string wpisane)
    {
        int sum = 0;
        int x = 0;
        double y = 0;
        int check = 0;
        input = wpisane;    
        int submit;
        int.TryParse(input, out submit);
        string submit1 = submit.ToString();
        int lenght = submit1.Length;

        if(lenght != 6)
        {
            CMDebug.TextPopupMouse("Wprowadzono nieprawidłowy kod.");
        }
        else
        {
            for (int i = 0; i<lenght; i++)
            {
                y = Char.GetNumericValue(submit1, i);
                x = Convert.ToInt32(y);
                sum += x;
            }
            check = Convert.ToInt32(Char.GetNumericValue(submit1, lenght - 2));
            if (sum != 24)
            {
                CMDebug.TextPopupMouse("Wprowadzono nieprawidłowy kod.");
            }
            else if ( sum == 24 && check == 3)
            {
                int point = PlayerPrefs.GetInt("Points");
                point += 100;
                PlayerPrefs.SetInt("Points", point);
                PlayerPrefs.Save();
                Loader.Load(Loader.Scene.CharSelect);
            }
            else if (sum == 24 && check == 4)
            {
                int point = PlayerPrefs.GetInt("Points");
                point += 150;
                PlayerPrefs.SetInt("Points", point);
                PlayerPrefs.Save();
                Loader.Load(Loader.Scene.CharSelect);
            }
            else if (sum == 24 && check == 5)
            {
                int point = PlayerPrefs.GetInt("Points");
                point += 200;
                PlayerPrefs.SetInt("Points", point);
                PlayerPrefs.Save();
                Loader.Load(Loader.Scene.CharSelect);
            }
        }
    }

    public static void SubPoints()
    {
        int point = PlayerPrefs.GetInt("Points");
        point -= 10;
        PlayerPrefs.SetInt("Points", point);
        PlayerPrefs.Save();
    }
    public static void ResetPoints()
    {
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();
    }

}
