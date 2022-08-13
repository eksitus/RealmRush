using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalace = 150;

    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI winText;

    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalace;
        winText.enabled = false;
    }


    private void Update()
    {
        DisplayCurrency();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        if (currentBalance >= 400)
        {
            Win();
            Invoke("ReloadScene", 1f);
        }
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance<0)
        {
            Lose();
            Invoke("ReloadScene" ,1f);
        }
        
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void DisplayCurrency()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    void Win()
    {
        winText.text = "You Win!";
        winText.enabled = true;
    }

    void Lose()
    {
        winText.text = "You Lose!";
        winText.enabled = true;
    }
}
