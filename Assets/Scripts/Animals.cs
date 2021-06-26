using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animals : MonoBehaviour
{

    #region Parameters

    public string sound;
    private string m_animalType;
    public Color animalColor;

    public Text AnimalSoundText;
    public Text AnimalActionText;
    public GameObject AnimalSoundObject;
    public GameObject ActionObject2;

    #endregion

    public string animalType
    {
        get { return m_animalType; } // getter returns backing field
        set
        {
            if (value.Length > 10)
            {
                Debug.LogError("Name is too long!");
            }
            else
            {
                m_animalType = value; // original setter now in if/else statement
            }
        }
     
    }

    Ray ray;
    RaycastHit hit;

    public delegate void GiveSoundPass();
    public GiveSoundPass m_method_to_call;




    public Animals()
    {
        sound = "Aaaa!";
        m_animalType = "animaal";
        animalColor = Color.red;
        Debug.Log("1st constructor called");

    }


    public Animals(string newSound, string newAnimalType, Color newAnimalColor)
    {
        sound = newSound;
        m_animalType = newAnimalType;
        animalColor = newAnimalColor;
        
        Debug.Log("2nd constructor called");
    }


    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = animalColor;

        m_method_to_call = GiveSound;
        AnimalSoundObject.gameObject.SetActive(false);

    }

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = animalColor;
    }



    public virtual void GiveSound() // POLYMORPHISM
    {
        Debug.Log("The " + m_animalType + " gives " + sound + " sound");
    }


    public void Greet()
    {
        Debug.Log("Hello I am an animal");
    }


    public void ClickHandler(GiveSoundPass method)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == animalType)
        {
            if (Input.GetMouseButtonDown(0))
            {
                method();
                AssignText();
                AnimalSoundObject.gameObject.SetActive(true);
            }

            if(Input.GetMouseButtonUp(0))
            {
                AnimalSoundObject.gameObject.SetActive(false);
                ActionObject2.gameObject.SetActive(false);
            }

        }
    }


    public void AssignText()
    {

        AnimalSoundText.text = sound;
    }

}
