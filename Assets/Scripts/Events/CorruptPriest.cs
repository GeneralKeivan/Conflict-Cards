using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptPriest : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartCorruptPriestEvent()
    {
        string text = "You find out that a high priest has been stealing part of the money people have been donating to the church. What should you do?";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Public execution.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "You send him on an expedition with the knights.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "If he gives you a cut of the money, you'll look the other way.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "You have a talk with the head priest.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You expose his crimes and ask the people to judge him."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void CorruptShark(){
        gameManager.playerSharkRelation += 10;
        string text = "That made the people happy.\nThe church not so much.";
        gameManager.setResultText(text);

        gameManager.trust += 5;
        gameManager.faith -= 5;

        gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);
    }

    public void CorruptOwl(){

        if(gameManager.knights >= 5){
            gameManager.playerOwlRelation += 10;
            string text = "Well accidents happen on these kinds of expeditions.";
            gameManager.setResultText(text);

            gameManager.knights -= 5;
            gameManager.returningKnights += 5;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);
        }
        else if(gameManager.traits.Contains("Mercenaries")){
            gameManager.playerOwlRelation += 10;
            string text = "Well accidents happen on these kinds of expeditions.";
            gameManager.setResultText(text);

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);
        }
        else{
            gameManager.playerOwlRelation += 10;
            string text = "You don't have that many knights so you just \"send\" him to a remote village to cure the people.";
            gameManager.setResultText(text);

            gameManager.trust += 5;
            gameManager.faith += 5;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);
        }

    }

    public void CorruptFox(){
        gameManager.playerFoxRelation += 10;
        float randomNumber = Random.Range(0, 100);
        if(randomNumber >= 50){
            string text = "You do the deal and no one finds out.";
            gameManager.setResultText(text);

            gameManager.money += 5;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);
        }
        else{
            string text = "Someone spreads the news about this deal and it makes the people mad.";
            gameManager.setResultText(text);

            gameManager.trust -= 5;
            gameManager.money += 5;
            gameManager.faith -= 5;

            gameManager.fox.GetComponent<FoxBehaviour>().removeFoxRelations(10);

            gameManager.traits.Add("Priest Corruption");

            if(gameManager.traits.Contains("Riot")){
                gameManager.trust -= 10;
                gameManager.fox.GetComponent<FoxBehaviour>().removeFoxRelations(10);
            }

        }
    }

    public void CorruptTurtle(){
        gameManager.playerTurtleRelation += 10;
        string text = "You ask the head priest to solve this problem.The offending priest is banished to a church far away from the capital. While on the way, he is attacked and is now out of the picture.";
        gameManager.setResultText(text);

        gameManager.turtle.GetComponent<TurtleBehaviour>().addTurtleRelations(10);

    }

    public void CorruptTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "Well the people didn't like that their donations were being used for someones personal use..";
        gameManager.setResultText(text);

        gameManager.trust += 10;
        gameManager.faith -= 10;

        gameManager.traits.Add("Priest Corruption");

        gameManager.teddy.GetComponent<TeddyBehaviour>().addTeddyRelations(10);
        gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);

    }

}
