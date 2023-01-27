using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiotStopped : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartRiotStoppedEvent()
    {
        string text = "The riots have been going on for a while and you really need to do something about it.";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Just kill anyone who is even remotely connected to the riots.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "Try to fix the problem at its roots. So talk to the leaders of the riots and see why they are riotting.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Try to talk to the riotters and reach a compromise.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Say the riotters are going against the teachings of the church and kill them.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "Try to accomodate their demands."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void RiotStoppedShark(){
        gameManager.playerSharkRelation += 10;
        string text = "That just made everyone so angry that they got violent and killed you. Violently";
        
        gameManager.setResultText(text);

        gameManager.DeadEnd();
    }

    public void RiotStoppedOwl(){
        if(gameManager.food >= 10){
            gameManager.playerOwlRelation += 10;
            string text = "See that wasn't so hard. They just wanted food.";
            gameManager.setResultText(text);

            gameManager.food -= 10;
            gameManager.trust += 10;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);

            gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Riot"));
        }
        else{
            gameManager.playerOwlRelation -= 10;
            string text = "They just wanted food. You didn't have any. So there are still riots";
            gameManager.setResultText(text);

            gameManager.trust -= 10;

            gameManager.owl.GetComponent<OwlBehaviour>().removeOwlRelations(10);

            gameManager.addRiotStoppedEvent();
        }
    }

    public void RiotStoppedFox(){
        gameManager.playerFoxRelation += 10;
        string text = "So you give them some food and they stop riotting.";
        gameManager.setResultText(text);

        gameManager.food -= 5;
        gameManager.trust += 5;

        gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);
        
        gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Riot"));
    }

    public void RiotStoppedTurtle(){
        gameManager.playerTurtleRelation += 10;
        string text = "That just made everyone so angry that they got violent and killed you. Violently";
        
        gameManager.setResultText(text);

        gameManager.DeadEnd();
    }

    public void RiotStoppedTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "So you give them some food and they stop riotting.";
        gameManager.setResultText(text);

        gameManager.food -= 5;
        gameManager.trust += 5;

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);
        
        gameManager.traits.RemoveAt(gameManager.traits.IndexOf("Riot"));
    }

}
