using UnityEngine;
using TMPro;

public class UserInformation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text showNameText;
    public bool NameEntered = false;
    public int MaximumLettersLength;
    private int currentcount = 0;
    public AudioManager audioManager;
    public void Start()
    {
        ShowPlayerName();
    }

    public void ShowPlayerName()
    {
        if(currentcount < MaximumLettersLength)
        {
            string playerName = nameInput.text;
            currentcount ++;
            audioManager.PlayMusic(0, false);
            if (!string.IsNullOrEmpty(playerName))
            {
                showNameText.text = playerName;
            }
            else
            {
                showNameText.text = "Enter your name!";
                NameEntered = false;
            }
            NameEntered = true;
        }
    }
    void OnEnable()
    {
        NameEntered = false;
        currentcount = 0;
    }
}
