﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureController : MonoBehaviour
{
    public GameObject[] picturesArray;   // 8 pictures/objects.
    public GameObject loseText;

    public int pictureSelected;   // Maybe these need to be -1 too? This shouldn't affect things.
    public int correctPicture;
    public int keyPressed = -1; // Not sure if it should stay as -1.
    public int points = 0;
    public int lives = 3; // Does counting from 0 affect this?

    public bool pictureAnswer = false;

    public Text scoreTextNumber;
    public Text Displaylives;

    public Text keyDisplayText1;    // There is alot of these and thus a better way should be done during the polish stage.
    public Text keyDisplayText2;
    public Text keyDisplayText3;
    public Text keyDisplayText4;
    public Text keyDisplayText5;
    public Text keyDisplayText6;
    public Text keyDisplayText7;
    public Text keyDisplayText8;

    private AudioSource audioSource;

    public AudioClip wrongChoice;
    public AudioClip correctChoice;

    public bool controlsActive = true;
    public bool WrongChoiceBool = false;

    public IEnumerator pictureDisplayTime;      // Should this be public? // Even when public it is not viewable in the inspector.

    void Start()
    {
        WrongChoiceBool = false;

        controlsActive = true;

        pictureDisplayTime = WaitAndPrint(5f); // This affects the time. If I change the ait time, the length of time between the picture changes will change.
        StartCoroutine(pictureDisplayTime);
        Reset();

        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator WaitAndPrint(float waitTime) // Should this be called WaitAndPrint?
    {
        //waitTime = 5f; // This affects the time. If I change the ait time, the length of time between the picture changes will change.

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Reset();
            pictureSelected = Random.Range(0, picturesArray.Length);
            correctPicture = pictureSelected;
            picturesArray[pictureSelected].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Displaylives.text = lives.ToString();
        if (controlsActive == true)
        {
            Controls();
            scoreTextNumber.text = points.ToString();
        }
    }

    public void Controls()
    {
        if (Input.GetButtonDown("Key1"))
        {
            print("Key 1 has been pressed");
            keyPressed = 0;
            keyDisplayText1.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 1 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key2"))
        {
            print("Key 2 has been pressed");
            keyPressed = 1;
            keyDisplayText2.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 2 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key3"))
        {
            print("Key 3 has been pressed");
            keyPressed = 2;
            keyDisplayText3.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 3 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key4"))
        {
            print("Key 4 has been pressed");
            keyPressed = 3;
            keyDisplayText4.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 4 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key5"))
        {
            print("Key 5 has been pressed");
            keyPressed = 4;
            keyDisplayText5.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 5 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key6"))
        {
            print("Key 6 has been pressed");
            keyPressed = 5;
            keyDisplayText6.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 6 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key7"))
        {
            print("Key 7 has been pressed");
            keyPressed = 6;
            keyDisplayText7.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 7 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        if (Input.GetButtonDown("Key8"))
        {
            print("Key 8 has been pressed");
            keyPressed = 7;
            keyDisplayText8.GetComponent<Text>().color = Color.green;
            if (keyPressed == correctPicture) { pictureAnswer = true; print("key 8 correct answer achieved!"); CorrectChoiceaudio(); Reset(); }
            else
            {
                WrongKeyaudio();
                print("Decrease lives by 1."); LifeCounter();
            }
        }

        //else { keyPressed = -1; }
        return; // Is this needed?
    }

    private void WrongKeyaudio()
    {
        audioSource.clip = wrongChoice;
        audioSource.Play();
        WrongChoiceBool = true;
        print("FUCKING WrongChoiceBool");
        // What if Reset was called at the end of this method too?
    }

    private void CorrectChoiceaudio()
    {
        audioSource.clip = correctChoice;
        audioSource.Play();
        points++;
        print("increase points " + points);
    }

    void LifeCounter()
    {
        --lives;
        print(lives);
        if (lives <= 0)
        {
            if (WrongChoiceBool == true) { Invoke("Reset", 1.0f); Lose(); }
        }
    }

    void Lose()
    {
        print("Reset points");
        points = 0;

        loseText.SetActive(true);
        controlsActive = false;
        // Should reset be called here?
    }

    void Reset()
    {
        keyPressed = -1;
        picturesArray[pictureSelected].SetActive(false);
        WrongChoiceBool = false;

        keyDisplayText1.GetComponent<Text>().color = Color.black;
        keyDisplayText2.GetComponent<Text>().color = Color.black;
        keyDisplayText3.GetComponent<Text>().color = Color.black;
        keyDisplayText4.GetComponent<Text>().color = Color.black;
        keyDisplayText5.GetComponent<Text>().color = Color.black;
        keyDisplayText6.GetComponent<Text>().color = Color.black;
        keyDisplayText7.GetComponent<Text>().color = Color.black;
        keyDisplayText8.GetComponent<Text>().color = Color.black;
    }

}
