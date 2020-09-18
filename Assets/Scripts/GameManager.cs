using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //FUCK
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // public void Save()
    //{
    //    PlayerPrefs.SetInt("points", points);
    //    PlayerPrefs.SetInt("highScore", highScore);
    //    print("SCORE SAVED");
    //}

 //   void Load()
   // {
   //     PlayerPrefs.GetInt("points", points);
   //     PlayerPrefs.GetInt("highScore", highScore);
    //    highScoreNumber.text = highScore.ToString();
   // }

}
