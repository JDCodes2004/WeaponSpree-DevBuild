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
    public GameObject ThanksforPlayingScreenGameObject;
    public GameObject SurveyButtonGameObject;
    public GameObject DevelopmentNewsGameObject;
    
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
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);
        DevelopmentNewsGameObject.SetActive(false);
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
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);
        DevelopmentNewsGameObject.SetActive(false);
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
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);
        DevelopmentNewsGameObject.SetActive(false);
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
        SurveyButtonGameObject.SetActive(false);
        DevelopmentNewsGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);
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
        DevelopmentNewsGameObject.SetActive(false);
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);

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
        DevelopmentNewsGameObject.SetActive(false);
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);

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
        SurveyButtonGameObject.SetActive(false);
        ThanksforPlayingScreenGameObject.SetActive(false);
        DevelopmentNewsGameObject.SetActive(false);
    }

    // Thanks for Playing screen
    public void ThanksForPlaying()
    {
        MenuGameObject.SetActive(false);
        SpecialThanksGameObject.SetActive(false);
        TitleCamera.SetActive(true);
        WelcomeMessageGameObject.SetActive(false);
        OptionsMenuGameObject.SetActive(false);
        SurveyButtonGameObject.SetActive(true);
        ThanksforPlayingScreenGameObject.SetActive(true);
        DevelopmentNewsGameObject.SetActive(true);
    }

    // Developer Commentary level Load
    public void OpenSurveyLink()
    {
        Application.OpenURL("https://forms.gle/yPvmSmYHa8ehXhLS6");
        Application.Quit();
    }

    public void KeepUpToDateLink()
    {
        Application.OpenURL("https://jdgames2004.itch.io/fps-project-im-working-on");
        Application.Quit();
    }
}
