using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [Header ("Game Objects")]
    public GameObject MenuGameObject;
    public GameObject SpecialThanksGameObject;
    public GameObject MultiplayerMenuGameObject;
    public GameObject TitleCamera;
    public GameObject TestLevelSelectMenuGameObject;
    public GameObject WelcomeMessageGameObject;
    public GameObject OptionsMenuGameObject;
    public GameObject LoadingScreenGameObject;
    
    [Header ("Audio Sources")]
    public AudioSource PlaceholderMenuConfirm;
    public AudioSource PlaceholderMenuBack;
    
    // Option menu
    public void GoToOptionsMenu()
    {
        MenuGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        SpecialThanksGameObject.SetActive(false);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuConfirm.Play();
        OptionsMenuGameObject.SetActive(true);
    }

    //Back to Main Menu
    public void GoToMenu()
    {
        MenuGameObject.SetActive(true);
        TitleCamera.SetActive(true);
        SpecialThanksGameObject.SetActive(false);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(false);
    }

    // Test Level select screen
    public void TestLevelSelect()
    {
        MenuGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        SpecialThanksGameObject.SetActive(false);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(true);
    }



    // Go To Welcome Message
    public void GoToWelcomeMessage()
    {
        MenuGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        SpecialThanksGameObject.SetActive(false);
        WelcomeMessageGameObject.SetActive(true);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(false);
    }

    // Multiplayer
    public void GoToMultiplayer()
    {
        MenuGameObject.SetActive(false);
        MultiplayerMenuGameObject.SetActive(true);
        SpecialThanksGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(false);

    }

    // Quickplay
    public void Quickplay()
    {
        MenuGameObject.SetActive(false);
        MultiplayerMenuGameObject.SetActive(false);
        SpecialThanksGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(false);
        LoadingScreenGameObject.SetActive(true);



    }
    // Special Thanks screen
    public void GoToSpecThanks()
    {
        MenuGameObject.SetActive(false);
        SpecialThanksGameObject.SetActive(true);
        TitleCamera.SetActive(true);
        WelcomeMessageGameObject.SetActive(false);
        PlaceholderMenuBack.Play();
        OptionsMenuGameObject.SetActive(false);
        TestLevelSelectMenuGameObject.SetActive(false);
    }

    // Quit Game
    public void QuitToDesktop()
    {
        Debug.Log("Quitting to Desktop...");
        Application.Quit();
    }

    // Developer Commentary level Load
    public void LoadDevCommentaryLevel()
    {

    }
}
