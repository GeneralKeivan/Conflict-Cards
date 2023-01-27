using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartAttackedEvent()
    {
        string text = "The enemy is attacking you there really isn't much you can do.";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "You send your knights to kill them";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "Maybe hire people to help you.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Ask the people to take up arms.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Only god can help you now.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You try to give them some tribute so they stop attacking you."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void AttackedShark(){
        if(gameManager.knights >= 80 && gameManager.playerSharkRelation >= 50){
            string text = "You somehow manage to defend against the enemy.";
            gameManager.setResultText(text);

            gameManager.SurvivedEnd();
        }
        else{
            string text = "You go for one last valiant defense but in the end, your army falls.";
            gameManager.setResultText(text);

            gameManager.DestroyedEnd();
        }

    }

    public void AttackedOwl(){
        if((gameManager.money >= 80 || gameManager.traits.Contains("Mercenaries")) && gameManager.playerOwlRelation >= 50){
            string text = "You hire as many people as you can and you manage to survive.";
            gameManager.setResultText(text);

            gameManager.SurvivedEnd();
        }
        else{
            string text = "You hire as many people as you could, but it is not enough. You are now part of history.";
            gameManager.setResultText(text);

            gameManager.DestroyedEnd();
        }
    }

    public void AttackedFox(){
        if(gameManager.trust >= 80 && gameManager.playerFoxRelation >= 50){
            string text = "The people of the land are with you and they all pick up arms to defend their homes. With the help of the people, you manage to survive against all odds.";
            gameManager.setResultText(text);

            gameManager.SurvivedEnd();
        }
        else{
            string text = "The people take up arms. But not with you and against you. They take you down and give you to the enemy general.";
            gameManager.setResultText(text);

            gameManager.DestroyedEnd();
        }
    }

    public void AttackedTurtle(){
        if(gameManager.faith >= 80 && gameManager.playerTurtleRelation >= 50){
            string text = "The priests manage to summon a miracle that destroys the enemy army.";
            gameManager.setResultText(text);

            gameManager.SurvivedEnd();
        }
        else{
            string text = "You pray to god. But god does not answer.";
            gameManager.setResultText(text);

            gameManager.DestroyedEnd();
        }

    }

    public void AttackedTeddy(){
        if(gameManager.food >= 80 && gameManager.playerTeddyRelation >= 50){
            string text = "The reason they were attacking you was for food in the first place so by giving them the food, they back off.";
            gameManager.setResultText(text);

            gameManager.SurvivedEnd();
        }
        else{
            string text = "You try to give them food so they stop attacking. But the food was not enough.";
            gameManager.setResultText(text);

            gameManager.DestroyedEnd();
        }
    }

}
