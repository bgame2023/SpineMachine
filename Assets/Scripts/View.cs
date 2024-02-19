using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class View : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCoinWin;
    [SerializeField] TextMeshProUGUI textCoinBet;
    [SerializeField] TextMeshProUGUI textCoinBanlance;
    [SerializeField] TextMeshProUGUI textMessenger;

    public void SetTextCoinWin(int coinWin)
    {
        textCoinWin.text = "" + coinWin.ToString("N0");
    }

    public void SetTextCoinBet(int coinbet)
    {
        textCoinBet.text = "" + coinbet.ToString("N0");
    }

    public void SetTextCoinBalance(int coinBalance)
    {
        textCoinBanlance.text = "" + coinBalance.ToString("N0");
    }

    public void SetTextMessenger(string message)
    {
        textMessenger.text = message;
    }

}
