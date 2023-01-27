using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OwlBehaviour : MonoBehaviour
{
    public Gradient gradient;
    private int playerRelation;
    private int money; //money

    public float value;
    [SerializeField] private GameManager gameManager;

    public GameObject backColor;
    public GameObject sliderColor;
    public GameObject owlSlider;

    [SerializeField] TextMeshPro owlText;


    void Start(){
        playerRelation = gameManager.playerOwlRelation;
        money = gameManager.money;
        checkPlayerRelation(playerRelation);
        checkPlayerResource(money);
    }


    public void checkPlayerResource(int money){
        value = money / 100.00f;
        sliderColor.GetComponent<Image>().color = colorFromGradient(value);
        owlSlider.GetComponent<Slider>().value = value;
    }
    public void checkPlayerRelation(int playerRelation){
        value = (playerRelation + 100) / 200.00f;
        backColor.GetComponent<SpriteRenderer>().color = colorFromGradient(value);
    }

    Color colorFromGradient (float value){
        return gradient.Evaluate(value);
    }

    public void setOwlChoices(string owlChoices){
        owlText.text = owlChoices;
    }


    public void addOwlRelations(int a){
        gameManager.sharkOwlRel += a;
        gameManager.owlFoxRel += a;
        gameManager.owlTurtleRel += a;
        gameManager.owlTeddyRel += a;
    }

    public void removeOwlRelations(int a){
        gameManager.sharkOwlRel -= a;
        gameManager.owlFoxRel -= a;
        gameManager.owlTurtleRel -= a;
        gameManager.owlTeddyRel -= a;
    }
}
