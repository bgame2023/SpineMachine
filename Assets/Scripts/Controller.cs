using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private Column[] columns;
    [SerializeField] private Model model;
    [SerializeField] private View view;
    [SerializeField] private Helper helper;
    [SerializeField] private EventSystem eventSystem;

    private int coinbet = 1000;


    private void Awake()
    {

        view.SetTextMessenger("Readly!!!!!"); 
        view.SetTextCoinBet(coinbet);
        view.SetTextCoinWin(0);
        foreach (Column column in columns)
        {
            column.SetUp(model.moveDuration + model.spacingTime * 3);
        }

    }
    public void EventStart()
    {
        eventSystem.enabled = false;
        view.SetTextCoinWin(0);
        view.SetTextMessenger("is spinning.....");
        int balance = Data.Instance.GetCoinBalance();
        helper.EffectChangeNumber(view.SetTextCoinBalance, balance, balance - coinbet, 0.5f);
        balance -= coinbet;
        Data.Instance.SaverCoinBalance(balance);
        view.SetTextCoinBalance(balance);
        StartCoroutine(CallSpine());
    }
    private IEnumerator CallSpine()
    {
        
        foreach (Column column in columns)
        {
           
            float speed = Random.Range(50f, 60f);
            column.Spine(speed);
            yield return new WaitForSeconds(model.spacingTime);

        }
        yield return new WaitForSeconds(model.moveDuration + 3*model.spacingTime);
        StartCoroutine(CheckResult());
    }
    public IEnumerator CheckResult()
    {
        List<int> result = new List<int>();
        foreach (Column column in columns)
        {
            for (int i = 0; i < column.GetResult().Length; i++)
            {
                result.Add(column.GetResult()[i]);
            }
        }
        List<int[]> listCorrect = new List<int[]>();

        foreach (int[] index in model.DataSetAnswers())
        {
            bool allEqual = index.All(i => result[i] == result[index[0]]);
            if (allEqual)
            {
                Debug.Log(string.Join(" ", index));
                listCorrect.Add(index);
            }
        }

        int numberCorrect = listCorrect.Count();

        for(int i = 0; i< numberCorrect; i++)
        {
          
            for (int j =0; j < columns.Length; j++)
            {
                Debug.Log("effect:" + result[listCorrect[i][j]]);
                columns[j].PlayEffect(result[listCorrect[i][j]]);
            }
            yield return new WaitForSeconds(0.5f);
        }
        int balance = Data.Instance.GetCoinBalance();
        if (numberCorrect > 0)
        {
            view.SetTextMessenger("YOU WIN!");
            int coinWin = coinbet * numberCorrect + coinbet;
            view.SetTextCoinWin(coinWin);
            helper.EffectChangeNumber(view.SetTextCoinBalance, balance, balance + coinWin, 0.5f);

            balance += coinWin;
            Data.Instance.SaverCoinBalance(balance);
            view.SetTextCoinBalance(balance);
        }
        else
        {
            view.SetTextMessenger("YOU LOSE!");
        }
        if(coinbet > balance)
        {
            coinbet = balance;
            view.SetTextCoinBet(balance);
        }
        eventSystem.enabled = true;
    }

    public void EventUpBet()
    {
        coinbet = Mathf.Min(coinbet += model.unitBet, model.maxBet);
        view.SetTextCoinBet(coinbet);
    }
    public void EventDownBet()
    {
        coinbet = Mathf.Max(coinbet -= model.unitBet, model.minBet);
        view.SetTextCoinBet(coinbet);
    }

    public void EventAutoBet()
    {
        coinbet = Mathf.Min(model.unitBet, coinbet);
        view.SetTextCoinBet(coinbet);
    }
    public void EventMaxBet()
    {
        coinbet = Mathf.Min(model.maxBet, Data.Instance.GetCoinBalance());
        view.SetTextCoinBet(coinbet);
    }


}
