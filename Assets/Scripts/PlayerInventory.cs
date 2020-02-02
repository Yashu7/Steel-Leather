using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int Leather;
    public int Steel;
    public bool ourStats;
    public GameObject leatherCount;
    public GameObject steelCount;
    public int Gold;
    public int StartingGold;
    public GameObject goldCount;
    public int bonus = 0;

    public AudioClip insufficientResouceSound;
    public AudioClip addGoldSound;
    private AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        if (!ourStats)
        {
            Leather = 10;
            Steel = 10;
            StartingGold = 150;
        }

        Gold = StartingGold;
    }

    // Update is called once per frame
    void Update()
    {

        leatherCount = GameObject.Find("MyLeather");
        leatherCount.GetComponent<Text>().text = Leather.ToString();

        steelCount = GameObject.Find("MySteel");
        steelCount.GetComponent<Text>().text = Steel.ToString();

        goldCount = GameObject.Find("MyGold");
        goldCount.GetComponent<Text>().text = Gold.ToString();

        if(Input.GetKeyDown(KeyCode.S))
        {
                 Debug.Log("S pressed");
                BuySteel();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
                 Debug.Log("L pressed");
                BuyLeather();
        }
        
    }
   
    public int DeduceLeatherCost(int cost)
    {
        if(cost > Leather)
        {
            PlayInsufficienResourceWarning();
            return 0;
        }
        return Leather = Leather - cost;
    }

    private void PlayInsufficienResourceWarning()
    {
        Debug.Log("playing sound");
        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(insufficientResouceSound, 0.7F);
    }

    public int DeduceSteelCost(int cost)
    {
        if(cost > Steel)
        {
            PlayInsufficienResourceWarning();
            return 0;
        }
        return Steel = Steel - cost;
    }
    public void BonusMultiplayer(bool toAdd)
    {
        if (toAdd)
        {
            bonus++;
        }
        else
        {
            bonus = 0;
        }
    }
    public void AddGold(int prize)
    {
        Gold = Gold + (prize * bonus);

        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(addGoldSound, 0.7F);
    }
    public void DeduceGold(int prize)
    {
        if(Gold < 1) {
            //todo refactor to sepeate script
            Debug.Log("Load game over scene");
            SceneManager.LoadScene (sceneName:"GameOver");
        }
        Gold = Gold - prize;
    }
    public void BuyLeather()
    {
        
        if (HowMuchGold() >= 10)
        {
            DeduceGold(10);
            Leather++;
        }
        
    }
    public void BuySteel()
    {
        if (HowMuchGold() >= 10)
        {
            DeduceGold(10);
            Steel++;
        }
    }
    public int HowMuchGold()
    {
        return Gold;
    }
    public bool CanIForge(int LeatherCost,int SteelCost)
    {
        if(LeatherCost > Leather || SteelCost > Steel)
        {
            PlayInsufficienResourceWarning();
            // if(LeatherCost > Leather) {
            //     GameObject leatherDisplay = GameObject.Find("MyLeather");
            //     leatherDisplay.GetComponent<Text>().font.size +=2;
            //     //todo not enough leader on top of screen
            //     Invoke("RemoveLeaderWarning", 1.0f);
            // }
            // if(SteelCost > Steel) {
            //     GameObject steelDisplay = GameObject.Find("MySteel");
            //     steelDisplay.GetComponent<Text>().font.size +=2;
            //     //todo not enough leader on top of screen
            //     Invoke("RemoveSteelWarning", 1.0f);
            // }
            return false;
        }
        else
        {
            return true;
        }
    }

    // void RemoveSteelWarning()
    // {
    //     GameObject steelDisplay = GameObject.Find("MySteel");
    //             steelDisplay.GetComponent<Text>().font.size -=2;
    // }

    // void RemoveLeaderWarning()
    // {
    //     GameObject leatherDisplay = GameObject.Find("MyLeather");
    //     leatherDisplay.GetComponent<Text>().font.size -=2;
    // }

    public void SellLeather()
    {
        if (Leather > 0)
        {
            Leather--;
            Gold = Gold + 10;
        }
    }
    public void SellSteel()
    {
        if (Steel > 0)
        {
            Steel--;
            Gold = Gold + 10;
        }
    }
}
