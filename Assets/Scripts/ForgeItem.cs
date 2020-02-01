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
        
    }
    void ButtonClicked()
    {
       
        if (GameObject.FindWithTag("Clicked"))
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
            }
            
        }

        




    }

     private void PlayHit()
    {
        Debug.Log("playing sound");
        anvilHitSoundSource = GetComponent<AudioSource>();
        anvilHitSoundSource.PlayOneShot(anvilHitSoundClip, 0.7F);
    }

}
