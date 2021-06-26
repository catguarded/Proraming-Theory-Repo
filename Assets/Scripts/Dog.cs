using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog : Animals
{
    public GameObject ActionObject;
    public Text ActionText;


    public Dog()
    {
        sound = "Woof!";
        animalType = "Dog";
        animalColor = Color.red;
        Debug.Log("1st Cat constructor called");
    }


    public Dog(string newSound, string newAnimalType, Color newAnimalColor) : base(newSound, newAnimalType, newAnimalColor)
    {
        Debug.Log("2nd Cat constructor called");
    }


    private void Start()
    {
        ActionObject.gameObject.SetActive(false);
    }


    public override void GiveSound()
    {
        base.GiveSound();
        MoveTail();
    }

    void MoveTail()
    {
        ActionText.text = "Move tail!";
        ActionObject.gameObject.SetActive(true);
        Debug.Log("Tail move!");
    }


    private void Update()
    {
        ClickHandler(GiveSound);
    }

}
