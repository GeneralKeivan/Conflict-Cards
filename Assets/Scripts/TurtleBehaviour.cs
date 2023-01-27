using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurtleBehaviour : MonoBehaviour
{
    public Gradient gradient;
    private int playerRelation;
    private int faith; //faith

    public float value;
    [SerializeField] private GameManager gameManager;

    public GameObject backColor;
    public GameObject sliderColor;
    public GameObject turtleSlider;

    [SerializeField] TextMeshPro turtleText;


    void Start(){
        playerRelation = gameManager.playerTurtleRelation;
        faith = gameManager.faith;
        checkPlayerRelation(playerRelation);
        checkPlayerResource(faith);
    }


    public void checkPlayerResource(int faith){
        value = faith / 100.00f;
        sliderColor.GetComponent<Image>().color = colorFromGradient(value);
        turtleSlider.GetComponent<Slider>().value = value;
    }
    public void checkPlayerRelation(int playerRelation){
        value = (playerRelation + 100) / 200.00f;
        backColor.GetComponent<SpriteRenderer>().color = colorFromGradient(value);
    }

    Color colorFromGradient (float value){
        return gradient.Evaluate(value);
    }

    public void setTurtleChoices(string turtleChoices){
        turtleText.text = turtleChoices;
    }

    public void addTurtleRelations(int a){
        gameManager.sharkTeddyRel += a;
        gameManager.owlTeddyRel += a;
        gameManager.foxTurtleRel += a;
        gameManager.turtleTeddyRel += a;
    }

    public void removeTurtleRelations(int a){
        gameManager.sharkTeddyRel -= a;
        gameManager.owlTeddyRel -= a;
        gameManager.foxTurtleRel -= a;
        gameManager.turtleTeddyRel -= a;
    }
}
