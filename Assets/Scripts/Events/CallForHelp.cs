using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallForHelp : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    public void StartCallForHelpEvent()
    {
        string text = "The lord of another territory has requested your help.\nYour common enemy has decided to send an army their way.\nAfter they fall, you will be next.\nWhat do you do?";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "You send an army to help immediately.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "You send an army and resources to ambush the enemy while they are attacking your ally";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "You try to negotiate with the enemy to stop the attack";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Who cares about them? You have better things to do.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You decide to help them and send them some resources."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void CallForHelpShark(){

        int randomNumber = Random.Range(1, 100);
        if(randomNumber >= 50){
            gameManager.playerSharkRelation += 10;
            string text = "You managed to push back the enemy.";
            gameManager.setResultText(text);

            gameManager.returningKnights = gameManager.knights;
            gameManager.knights = 0;

            gameManager.addEnemyWeakened();
            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(10);
        }
        else{
            gameManager.playerSharkRelation -= 10;
            string text = "Your army was defeated.";
            gameManager.setResultText(text);

            gameManager.knights -= 20;

            gameManager.addInvasionImminent();
            gameManager.shark.GetComponent<SharkBehaviour>().removeSharkRelations(10);
        }
        
    }

    public void CallForHelpOwl(){
        gameManager.playerOwlRelation += 10;

        string text = "You pushed back the enemy and now your allies are indebted to you.";
        gameManager.setResultText(text);

        gameManager.money -= 5;
        gameManager.food -= 5;
        gameManager.knights -= 20;
        gameManager.returningKnights = 20;

        gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);
        gameManager.traits.Add("Ally Indebted");
        
    }

    public void CallForHelpFox(){

        if(gameManager.knights >= 20){
            gameManager.playerFoxRelation += 10;
            string text = "The negotiations were successful";
            gameManager.setResultText(text);

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);
        }
        else{
            string text = "The negotiations failed.";
            gameManager.setResultText(text);

            gameManager.addCallForHelpEvent();
        }
    
    }

    public void CallForHelpTurtle(){
        int randomNumber = Random.Range(1, 100);
        if(randomNumber >= 50){
            gameManager.playerTurtleRelation += 10;

            string text = "Your allies managed to win the war.";
            gameManager.setResultText(text);

            gameManager.turtle.GetComponent<TurtleBehaviour>().addTurtleRelations(10);
            gameManager.addEnemyWeakened();
        }
        else{
            string text = "Your allies are gone. You are next.";
            gameManager.setResultText(text);

            gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);
            gameManager.addInvasionImminent();
        }
    }

    public void CallForHelpTeddy(){
        
        gameManager.playerTeddyRelation += 10;

        int randomNumber = Random.Range(1, 100);
        string text = "They are greatful for the resources";
        gameManager.setResultText(text);

        gameManager.food -= 10;
        gameManager.money -= 10;

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);
    
        gameManager.traits.Add("Ally Indebted");
    }

}
