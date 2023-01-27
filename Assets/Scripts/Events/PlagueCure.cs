using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueCure : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartPlagueCureEvent()
    {
        string text = "You need to do something about the plague.";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Just kill the people who have the plague and burn down their houses.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "Gather all the doctors in the realm and try to make a cure.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Quarantine the people for now and try to find a cure.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Lets just pray.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "Give money to people so they don't go outside for a while until the plague is over."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void PlagueCureShark(){
        gameManager.playerSharkRelation += 10;
        string text = "Well that solved the plague.";
        
        gameManager.setResultText(text);

        gameManager.trust -= 10;

        gameManager.shark.GetComponent<SharkBehaviour>().removeSharkRelations(10);
        
        gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Plague"));
    }

    public void PlagueCureOwl(){
        gameManager.playerOwlRelation += 10;
        string text = "That took some resources but the cure is found.";
        gameManager.setResultText(text);

        gameManager.money -= 10;

        gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);

        gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Plague"));
    }

    public void PlagueCureFox(){
        gameManager.playerFoxRelation -= 10;
        string text = "This wasn't something to put for another time.";
        gameManager.setResultText(text);

        gameManager.trust -= 5;

        gameManager.fox.GetComponent<FoxBehaviour>().removeFoxRelations(10);
        
        gameManager.addPlagueCureEvent();
    }

    public void PlagueCureTurtle(){
        gameManager.playerTurtleRelation += 10;
        float randomNumber = Random.Range(1, 100);
        if(randomNumber >= 50){
            string text = "The plague went away.Was it the praying or just a coincidence? Well the church is saying they did it anyways.";
            gameManager.setResultText(text);

            gameManager.trust += 10;
            gameManager.faith += 10;

            gameManager.turtle.GetComponent<TurtleBehaviour>().addTurtleRelations(10);

            gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Plague"));
        }
        else{
            string text = "Only if praying was gonna work to solve all your problems.";
            gameManager.setResultText(text);

            gameManager.trust -= 10;
            gameManager.faith -= 10;

            gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);

            gameManager.addPlagueCureEvent();
        }

    }

    public void PlagueCureTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "Thanks to people not going out, the plague went away.";
        gameManager.setResultText(text);

        gameManager.money -= 10;

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);

        gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Plague"));
    }

}
