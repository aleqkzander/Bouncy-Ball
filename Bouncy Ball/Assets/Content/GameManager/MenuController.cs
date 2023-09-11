using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject NameMenu;
    public GameObject MainMenu;
    public TMP_InputField NameInput;

    private void Awake()
    {
        string playerName = PlayerPrefs.GetString("name");
        //if (playerName != string.Empty) { NameMenu.SetActive(false); MainMenu.SetActive(true); }
        //else { NameMenu.SetActive(true); MainMenu.SetActive(false); }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("name", NameInput.text);
        NameMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
