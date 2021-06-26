using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : Animals
{

    public GameObject ActionObject;
    public Text ActionText;

    public Mouse()
    {
        sound = "Peeeeee!";
        animalType = "Mouse";
        animalColor = Color.black;
        Debug.Log("1st Cat constructor called");
    }


    public Mouse(string newSound, string newAnimalType, Color newAnimalColor) : base(newSound, newAnimalType, newAnimalColor)
    {
        Debug.Log("2nd Cat constructor called");
    }

    private void Start()
    {
        ActionObject.gameObject.SetActive(false);
    }


    public override void GiveSound() // POLYMORPHISM
    {
        base.GiveSound();
        MoveBack();
    }

    void MoveBack()
    {
        ActionText.text = "MoveBack move!";
        ActionObject.gameObject.SetActive(true);
        Debug.Log("Moveback move!");
    }

    private void Update() // ABSTRACTION
    {
        ClickHandler(GiveSound);
    }

}
