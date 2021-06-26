using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : Animals
{

    public GameObject ActionObject;
    public Text ActionText;


    public Cat()
    {
        sound = "Meow!";
        animalType = "Cat";
        animalColor = Color.white;
        Debug.Log("1st Cat constructor called");
    }


    public Cat(string newSound, string newAnimalType, Color newAnimalColor) : base(newSound, newAnimalType, newAnimalColor)
    {
        Debug.Log("2nd Cat constructor called");
    }

    public void Start()
    {
        ActionObject.gameObject.SetActive(false);
    }



    public override void GiveSound()
    {
        base.GiveSound();
        Jump();
    }

    void Jump()
    {
        ActionText.text = "Jump Move!";
        ActionObject.gameObject.SetActive(true);
        Debug.Log("Jump move!");
    }


    private void Update()
    {
        ClickHandler(GiveSound);
    }

}
