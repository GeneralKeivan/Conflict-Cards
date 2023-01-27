using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locust : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;
    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    public void StartLocustEvent()
    {
        string text = "The crop fields have been hit by locusts.\n And now there is a food shortage";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "You send your knights to distribute stored food between everyone.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        if(gameManager.traits.Contains("Ally Indebted")){
            text = "You ask your ally for help and they help you.";
        }
        else if(gameManager.traits.Contains("Trade Route")){
            text = "You get food from the traders.";
        }
        else{
            text = "You decide to hold a conference and see what is the best course of action to take";
        }
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        if(gameManager.traits.Contains("Ally Indebted")){
            text = "You ask your ally for help and they help you.";
        }
        else if(gameManager.traits.Contains("Trade Route")){
            text = "You get food from the traders.";
        }
        else{
            text = "You buy food from nearby territories to solve the food shortage.";
        }
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "This is a test from god and the people must go through it.\n The nobles of course can pay to get food but the commoners can't.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "It is important to help the people as much as possible and send food to the people."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void LocustShark(){
        gameManager.playerSharkRelation += 10;
        string text = "The people are happy.";
        gameManager.setResultText(text);

        gameManager.trust += 10;
        gameManager.food -= 20;

        gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(10);
    }

    public void LocustOwl(){
        gameManager.playerOwlRelation += 10;
        if(gameManager.traits.Contains("Ally Indebted")){
            string text = "Good thing you had allies.";
            gameManager.setResultText(text);

            gameManager.trust += 20;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(20);
        }
        else if(gameManager.traits.Contains("Trade Route")){
            string text = "Having a trade route is really helpful at times";
            gameManager.setResultText(text);

            gameManager.trust += 20;
            gameManager.money += 5;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(20);
        }
        else{
            string text = "That took too long and people are getting angry.";
            gameManager.setResultText(text);

            gameManager.trust -= 20;

            gameManager.owl.GetComponent<OwlBehaviour>().removeOwlRelations(20);

            gameManager.addAngryPeopleEvent();
        }
    }

    public void LocustFox(){
        gameManager.playerFoxRelation += 10;
        if(gameManager.traits.Contains("Ally Indebted")){
            string text = "Good thing you had allies.";
            gameManager.setResultText(text);

            gameManager.trust += 20;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);
        }
        else if(gameManager.traits.Contains("Trade Route")){
            string text = "Having a trade route is really helpful at times";
            gameManager.setResultText(text);

            gameManager.trust += 20;
            gameManager.money += 5;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);
        }
        else{
            string text = "You managed to solve the shortage.";
            gameManager.setResultText(text);

            gameManager.trust += 10;
            gameManager.money -= 10;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);
        }
    }

    public void LocustTurtle(){
        gameManager.playerTurtleRelation += 10;
        string text = "Well that pissed off the commoners.";
        gameManager.setResultText(text);

        gameManager.trust -= 20;
        gameManager.food -= 5;
        gameManager.money += 10;
        gameManager.faith -= 20;

        gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(20);

        gameManager.addAngryPeopleEvent();
    }

    public void LocustTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "You saved a lot of people.";
        gameManager.setResultText(text);

        gameManager.trust += 20;
        gameManager.food -= 20;

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);
    }

}
