using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    public static int coin;

    void Start()
    {
        CoinTexts = GetComponent<Text>();
        coin = PlayerPrefs.GetInt("coins", coin);
    }

    void Update()
    {
        CoinTexts.text = coin.ToString();
    }
}
