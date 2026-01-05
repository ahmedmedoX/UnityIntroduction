using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class UI_Manager_Script : MonoBehaviour
{
    enum UI_State
    {
        Menu,
        Settings_Display,
        Settings_Audio,
        Settings_Controls
    };
    //public TMP_InputField input_Field;
    //public UnityEngine.UI.Slider slide;
    public UnityEngine.UI.Button Display_Button;
    public GameObject Menu_Buttons;
    public GameObject Settings_Panel;
    public GameObject Display_Panel;
    public GameObject Audio_Panel;
    public GameObject Controls_Panel;
    UI_State State = UI_State.Menu;
    bool first_selection = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();
    }
    public void OnClick(int ID)
    {
        switch (ID)
        {
            case -1: {
                    StartGame();
                    break;}
            case 0: { State = UI_State.Menu;
                    ShowMenu();
                    break;}
            case 1: { State = UI_State.Settings_Display;
                    ShowDisplaySettings();
                    break;}
            case 2: { State = UI_State.Settings_Audio;
                    ShowAudioSettings();
                    break;}
            case 3: { State = UI_State.Settings_Controls;
                    ShowControlsSettings();
                    break;}
            case 99: {
                    Exit();
                    break; }
        }
        Debug.Log(State);
    }
    void StartGame()
    {
        SceneManager.LoadScene("2D-PlatfromerScene");
    }
    void ShowMenu()
    {
        first_selection = true;
        Menu_Buttons.SetActive(true);
        Settings_Panel.SetActive(false);
    }
    void ShowDisplaySettings()
    {
        Menu_Buttons.SetActive(false);
        Settings_Panel.SetActive(true);
        Display_Panel.SetActive(true);
        Audio_Panel.SetActive(false);
        Controls_Panel.SetActive(false);
        if (first_selection)
        {
            first_selection = false;
            EventSystem.current.SetSelectedGameObject(Display_Button.gameObject);
        }
    }
    void ShowAudioSettings()
    {
        Display_Panel.SetActive(false);
        Audio_Panel.SetActive(true);
        Controls_Panel.SetActive(false);
    }
    void ShowControlsSettings()
    {
        Display_Panel.SetActive(false);
        Audio_Panel.SetActive(false);
        Controls_Panel.SetActive(true);
    }
    void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}