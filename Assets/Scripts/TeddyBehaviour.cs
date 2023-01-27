using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeddyBehaviour : MonoBehaviour
{
    public Gradient gradient;
    private int playerRelation;
    private int food; //food

    public float value;
    [SerializeField] private GameManager gameManager;

    public GameObject backColor;
    public GameObject sliderColor;
    public GameObject teddySlider;

    [SerializeField] TextMeshPro teddyText;


    void Start(){
        playerRelation = gameManager.playerTeddyRelation;
        food = gameManager.food;
        checkPlayerRelation(playerRelation);
        checkPlayerResource(food);
    }


    public void checkPlayerResource(int food){
        value = food / 100.00f;
        sliderColor.GetComponent<Image>().color = colorFromGradient(value);
        teddySlider.GetComponent<Slider>().value = value;
    }
    public void checkPlayerRelation(int playerRelation){
        value = (playerRelation + 100) / 200.00f;
        backColor.GetComponent<SpriteRenderer>().color = colorFromGradient(value);
    }

    Color colorFromGradient (float value){
        return gradient.Evaluate(value);
    }

    public void setTeddyChoices(string teddyChoices){
        teddyText.text = teddyChoices;
    }


    public void addTeddyRelations(int a){
        gameManager.sharkTurtleRel += a;
        gameManager.owlTurtleRel += a;
        gameManager.foxTurtleRel += a;
        gameManager.turtleTeddyRel += a;
    }

    public void removeTeddyRelations(int a){
        gameManager.sharkTurtleRel -= a;
        gameManager.owlTurtleRel -= a;
        gameManager.foxTurtleRel -= a;
        gameManager.turtleTeddyRel -= a;
    }
}
