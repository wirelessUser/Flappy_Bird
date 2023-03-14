using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //#region   Mycode
    //public static MenuController instance;
    //[SerializeField]
    //private GameObject[] birds;

    //private bool isRedBirdUnlocked, isGreenBirdUnlocked;
    //void Start()
    //{
    //    birds[GameController.instance.GetSelectedBird()].SetActive(true);


    //    CheckIfBirdsAreUnlocked();


    //}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }

    //}

    //// Update is called once per frame
    //void CheckIfBirdsAreUnlocked()
    //{
    //    if (GameController.instance.IsRedBirdUnlocked()==1)
    //    {
    //        isRedBirdUnlocked = true;
    //    }

    //    if (GameController.instance.IsGreenBirdUnlocked()==1)
    //    {
    //        isGreenBirdUnlocked = true;
    //    }
    //}

    //public void ChangeBird()
    //{
    //    if (GameController.instance.GetSelectedBird()==0)
    //    {
    //        if (isGreenBirdUnlocked)
    //        {
    //            birds[0].SetActive(false);

    //            GameController.instance.SetSlectedBird(1);
    //            birds[GameController.instance.GetSelectedBird()].SetActive(true);
    //        }
    //    }
    //    else if (GameController.instance.GetSelectedBird()==1)
    //    {
    //        if (isRedBirdUnlocked)
    //        {
    //            birds[1].SetActive(false);
    //            GameController.instance.SetSlectedBird(2);
    //            birds[GameController.instance.GetSelectedBird()].SetActive(true);
    //        }
    //        else
    //        {
    //            birds[1].SetActive(false);
    //            GameController.instance.SetSlectedBird(0);
    //            birds[GameController.instance.GetSelectedBird()].SetActive(true);
    //        }
    //    }
    //    else if (GameController.instance.GetSelectedBird() == 2)
    //    {

    //           birds[2].SetActive(false);
    //            GameController.instance.SetSlectedBird(0);
    //            birds[GameController.instance.GetSelectedBird()].SetActive(true);

    //    }

    //}

    //#endregion

    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;

    public void PlayGame()
    {
        SceneFader.instance.FadeIn("GamePlay");
    }
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void CheckIfBirdsAreUnlocked()
    {
        if (GameController.instance.IsRedBirdUnlocked() == 1)
        {
            isRedBirdUnlocked = true;
        }

        if (GameController.instance.IsGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnlocked = true;
        }
    }


    public void ChangeBird()
    {

        if (GameController.instance.GetSelectedBird() == 0)
        {

            if (isGreenBirdUnlocked)
            {
                birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(1);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }

        }
        else if (GameController.instance.GetSelectedBird() == 1)
        {

            if (isRedBirdUnlocked)
            {

                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(2);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);

            }
            else
            {

                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);

            }

        }
        else if (GameController.instance.GetSelectedBird() == 2)
        {
            birds[2].SetActive(false);
            GameController.instance.SetSelectedBird(0);
            birds[GameController.instance.GetSelectedBird()].SetActive(true);
        }

    }
} //class
