using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SharkBehaviour : MonoBehaviour
{
    public Gradient gradient;
    private int playerRelation;
    private int knights; //soldiers

    public float value;
    [SerializeField] private GameManager gameManager;

    public GameObject backColor;
    public GameObject sliderColor;
    public GameObject sharkSlider;

    [SerializeField] TextMeshPro sharkText;

    void Start(){
        playerRelation = gameManager.playerSharkRelation;
        knights = gameManager.knights;
        checkPlayerRelation(playerRelation);
        checkPlayerResource(knights);
    }


    public void checkPlayerResource(int knights){
        value = knights / 100.00f;
        sliderColor.GetComponent<Image>().color = colorFromGradient(value);
        sharkSlider.GetComponent<Slider>().value = value;
    }
    public void checkPlayerRelation(int playerRelation){
        value = (playerRelation + 100) / 200.00f;
        backColor.GetComponent<SpriteRenderer>().color = colorFromGradient(value);
    }

    Color colorFromGradient (float value){
        return gradient.Evaluate(value);
    }

   
    public void setSharkChoices(string sharkChoices){
        sharkText.text = sharkChoices;
    }

    public void addSharkRelations(int a){
        gameManager.sharkOwlRel += a;
        gameManager.sharkFoxRel += a;
        gameManager.sharkTurtleRel += a;
        gameManager.sharkTeddyRel += a;
    }

    public void removeSharkRelations(int a){
        gameManager.sharkOwlRel -= a;
        gameManager.sharkFoxRel -= a;
        gameManager.sharkTurtleRel -= a;
        gameManager.sharkTeddyRel -= a;
    }
}
