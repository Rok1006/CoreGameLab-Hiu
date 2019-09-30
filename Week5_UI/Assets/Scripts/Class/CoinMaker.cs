using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMaker : MonoBehaviour
{
    public GameObject coin_P;
    int coinCount;
    public Slider coinSlider;
    int maxCoin;
    public InputField InputField;

    // Start is called before the first frame update
    void Start()
    {
        maxCoin = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateCoin()
    {
        Instantiate(coin_P, new Vector2(Random.Range(-6f, 6f), 5), Quaternion.identity);
        coinCount++;

        coinSlider.value = coinCount;

        Debug.Log(coinCount);

        if (coinCount > maxCoin)
        {
            RemoveCoin();
        }


    }
    public void RemoveCoin()
    {

        GameObject[] allCoins;
        allCoins = GameObject.FindGameObjectsWithTag("Coin");
        if (allCoins.Length >= 1) //dont destroy nothing there
        {
            int randomCoin = Random.Range(0, allCoins.Length - 1);    //always minus 1
            Destroy(allCoins[randomCoin]);
            coinCount--;
        }
        coinSlider.value = coinCount;
    }

    public void SliderUpdate()
    {
        // Debug.Log(coinSlider.value);
        if (coinSlider.value > coinCount)
        {
            CreateCoin();
        }
        else if (coinSlider.value < coinCount)
        {
            RemoveCoin();
        }

    }
    public void TextUpdate()
    {
        Debug.Log(InputField.text);
        if (InputField.text == "bonus")
        {
            maxCoin = 50;
            coinSlider.maxValue = 50;
            //coinSlider.value = 50;
            //coinCount = 50;

            int difference = maxCoin - coinCount;
            for (int i = 0; i <= difference; i++)
            {
                CreateCoin();
            }
            InputField.text = "";
        }
        else if (InputField.text == "blue")
        {
            coin_P.GetComponent<SpriteRenderer>().color = Color.blue;
            InputField.text = "";
        }
        else if (InputField.text == "rainbow")
        {
            GameObject[] allCoins;
            allCoins = GameObject.FindGameObjectsWithTag("Coin");
            for (int i = 0; i <= allCoins.Length - 1; i++)
            {
                allCoins[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
            InputField.text = "";


        }

    }
}
