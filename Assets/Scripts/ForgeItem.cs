using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeItem : MonoBehaviour
{
    public Button forge;
    public GameObject currentPart;
    public GameObject gameGenerator;
    public Animator anim;

    public AudioClip anvilHitSoundClip;
    private AudioSource anvilHitSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        forge = gameObject.GetComponent<Button>();
        forge.onClick.AddListener(ButtonClicked);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
                 Debug.Log("E pressed");
                Forge();
        }
    
    }
    void ButtonClicked()
    {

        if (GameObject.FindWithTag("Clicked"))
        {

            Forge();
            
        }

    }

    private void Forge() 
    {
        anim.SetTrigger("ForgeClicked");

            currentPart = GameObject.FindWithTag("Clicked");

            gameGenerator = GameObject.FindWithTag("Player");
            if (gameGenerator.GetComponent<PlayerInventory>().CanIForge(currentPart.GetComponent<PartBehaviour>().ReturnLeather(), currentPart.GetComponent<PartBehaviour>().ReturnSteel()))
            {
                gameGenerator.GetComponent<PlayerInventory>().DeduceLeatherCost(currentPart.GetComponent<PartBehaviour>().ReturnLeather());
                
                gameGenerator.GetComponent<PlayerInventory>().DeduceSteelCost(currentPart.GetComponent<PartBehaviour>().ReturnSteel());
                
                //fix part - notify slot
                currentPart.GetComponent<PartBehaviour>().Fix();

                PlayHit();
                currentPart.tag = "Job";
            }

            if(!gameGenerator.GetComponent<PlayerInventory>().CanIForge(currentPart.GetComponent<PartBehaviour>().ReturnLeather(),0))
                {
                StartCoroutine(notEnoughLeather());
            }
            if (!gameGenerator.GetComponent<PlayerInventory>().CanIForge(0, currentPart.GetComponent<PartBehaviour>().ReturnSteel()))
            {
                StartCoroutine(notEnoughSteel());
            }

        }
    }

     public IEnumerator notEnoughLeather()
        {
        GameObject.Find("AmountOfLeather").GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.5F);
        GameObject.Find("AmountOfLeather").GetComponent<Text>().color = Color.green;
    }
    public IEnumerator notEnoughSteel()
    {
        GameObject.Find("AmountOfSteel").GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.5F);
        GameObject.Find("AmountOfSteel").GetComponent<Text>().color = Color.green;
    }








    private void PlayHit()
    {
        Debug.Log("playing sound");
        anvilHitSoundSource = GetComponent<AudioSource>();
        anvilHitSoundSource.PlayOneShot(anvilHitSoundClip, 0.7F);
    }

}

