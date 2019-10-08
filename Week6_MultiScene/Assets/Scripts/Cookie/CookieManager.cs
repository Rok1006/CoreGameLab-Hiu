using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    public int cookieCount;
    public Text cookieText;
    public GameObject cookie_P;
    public Button BakerButton;
    public Slider BakerSlider;

    float bakingTime;
    float bakingTimer;
    bool canBake;

    // Start is called before the first frame update
    void Start()
    {
        cookieCount = 0;
        bakingTime = 3;
        bakingTimer = 0;

        BakerButton.gameObject.SetActive(false);
        BakerSlider.gameObject.SetActive(false);
        canBake = true;

        ShowBaker(false);
        //cookieCount
    }

    // Update is called once per frame
    void Update()
    {
        if (cookieCount == 10)
        {
            ShowBaker(true);
        }
        if (!canBake)
        {

            bakingTimer += Time.deltaTime;
            BakerSlider.value = bakingTimer;

            BakerButton.interactable = false;

            if (bakingTimer >= bakingTime)
            {
                cookieCount += 20;
                cookieText.text = cookieCount.ToString();
                for (int i = 0; i < 20; i++)
                {
                    Instantiate(cookie_P, transform.position, Quaternion.identity);
                }
                canBake = true;
                bakingTimer = 0;
                BakerButton.interactable = true;
                BakerSlider.value = bakingTimer;
            }
        }
    }
    public void BakerClicked()
    {
        if (cookieCount >= 5)
        {


            canBake = false;
            cookieCount -= 5;
            cookieText.text = cookieCount.ToString();
        }
    }

    void ShowBaker(bool isShowing)
    {
        BakerButton.gameObject.SetActive(true);
        BakerSlider.gameObject.SetActive(true);
    }

    public void CookieClicked()
    {

        cookieCount++;
        cookieText.text = cookieCount.ToString();
        Instantiate(cookie_P, transform.position, Quaternion.identity);

    }
}
