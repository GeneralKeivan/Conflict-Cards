using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPeople : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    public void StartAngryPeopleEvent()
    {
        string text = "The people are starving. If you don't do something about it, they might riot. So do something";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "You send the knights to beat up anyone who is against you.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "You decide to send knights to distribute food between the people.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "You distribute the food to the people but you put some fillers like wood chips and the ruined crops in the distributed food.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "You have the church make a huge pot of food and distribute it amongst the people.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You give the people some of the stored food to calm them down."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void AngryPeopleShark(){
        gameManager.playerSharkRelation += 10;
        gameManager.playerOwlRelation -= 20;
        gameManager.playerFoxRelation -= 20;
        gameManager.playerTurtleRelation -= 20;
        gameManager.playerTeddyRelation -= 20;

        string text = "Well even if they were not going to riot, they are now.";
        gameManager.setResultText(text);

        gameManager.trust = 0;

        gameManager.shark.GetComponent<SharkBehaviour>().removeSharkRelations(20);

        gameManager.addRiotStoppedEvent();
    }

    public void AngryPeopleOwl(){
        gameManager.playerOwlRelation += 10;
        string text = "The people have calmed down but they are a bit angry.";
        gameManager.setResultText(text);

        gameManager.food -= 10;

        gameManager.owl.GetComponent<OwlBehaviour>().removeOwlRelations(20);   

        gameManager.traits.Add("Riot");
        gameManager.riot = true;

    }

    public void AngryPeopleFox(){
        gameManager.playerSharkRelation -= 20;
        gameManager.playerOwlRelation -= 20;
        gameManager.playerFoxRelation += 10;
        gameManager.playerTurtleRelation -= 20;
        gameManager.playerTeddyRelation -= 20;

        string text = "Just hope that wont come back to bite you anytime soon.";
        gameManager.setResultText(text);

        gameManager.food -= 5;
        gameManager.trust -= 20;

        gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);

        gameManager.traits.Add("Plague");
        gameManager.plague = true;
    
    }

    public void AngryPeopleTurtle(){
        gameManager.playerTurtleRelation += 10;
        string text = "Well that pissed off the commoners.";
        gameManager.setResultText(text);

        gameManager.trust += 10;
        gameManager.food -= 10;
        gameManager.faith += 10;

        gameManager.turtle.GetComponent<TurtleBehaviour>().addTurtleRelations(10);
    }

    public void AngryPeopleTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "You should have done that in the first place.";
        gameManager.setResultText(text);

        gameManager.trust += 10;
        gameManager.food -= 10;

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);
    }

}
