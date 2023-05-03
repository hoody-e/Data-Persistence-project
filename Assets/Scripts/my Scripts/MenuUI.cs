using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI bestTitle;
    // Start is called before the first frame update
    void Start()
    {
        if (UserData.Instance != null) { UserData.Instance.Load(); }
        if (UserData.Instance.userName != null)
        {
            inputName.text = UserData.Instance.userName;
            inputName.Select();
        }
        inputName.onEndEdit.AddListener(GetInput);
        bestTitle.text = $"Best Score: {UserData.Instance.highestName} : {UserData.Instance.highestPt}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {        
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        UserData.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void GetInput(string input)
    {
        UserData.Instance.userName = input;
    }
}
