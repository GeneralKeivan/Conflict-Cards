using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FoxBehaviour : MonoBehaviour
{
    public Gradient gradient;
    private int playerRelation;
    private int trust; //trust

    public float value;
    [SerializeField] private GameManager gameManager;

    public GameObject backColor;
    public GameObject sliderColor;
    public GameObject foxSlider;

    [SerializeField] TextMeshPro foxText;


    void Start(){
        playerRelation = gameManager.playerFoxRelation;
        trust = gameManager.trust;
        checkPlayerRelation(playerRelation);
        checkPlayerResource(trust);
    }


    public void checkPlayerResource(int trust){
        value = trust / 100.00f;
        sliderColor.GetComponent<Image>().color = colorFromGradient(value);
        foxSlider.GetComponent<Slider>().value = value;
    }
    public void checkPlayerRelation(int playerRelation){
        value = (playerRelation + 100) / 200.00f;
        backColor.GetComponent<SpriteRenderer>().color = colorFromGradient(value);
    }

    Color colorFromGradient (float value){
        return gradient.Evaluate(value);
    }

    public void setFoxChoices(string foxChoices){
        foxText.text = foxChoices;
    }

    public void addFoxRelations(int a){
        gameManager.sharkFoxRel += a;
        gameManager.owlFoxRel += a;
        gameManager.foxTurtleRel += a;
        gameManager.foxTeddyRel += a;
    }

    public void removeFoxRelations(int a){
        gameManager.sharkFoxRel -= a;
        gameManager.owlFoxRel -= a;
        gameManager.foxTurtleRel -= a;
        gameManager.foxTeddyRel -= a;
    }
}
