using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCoin : MonoBehaviour
{
    public Text coinText;
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coin += HandleItems.isCoin;
        HandleItems.isCoin = 0;
        coinText.text = coin+"";
    }
}
