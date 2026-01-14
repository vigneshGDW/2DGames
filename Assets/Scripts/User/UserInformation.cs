using UnityEngine;
using TMPro;

public class UserInformation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text showNameText;
    public bool NameEntered = false;
    public void Start()
    {
        ShowPlayerName();
    }

    public void ShowPlayerName()
    {
        string playerName = nameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            showNameText.text = playerName;
            NameEntered = true;
        }
        else
        {
            showNameText.text = "Enter your name!";
            NameEntered = false;
        }
    }
}
