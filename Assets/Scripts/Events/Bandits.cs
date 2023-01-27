using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandits : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartBanditEvent()
    {
        string text = "Some bandits have been ravaging your lands and burning your fields.\n They demand money from you. \n What do you do?";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "You send your knights to kill them";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "You surround them with your knights and then negotiate and hire them as mercenaries";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "You give them the money";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "You don't give in to the bandit demands";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You accept the bandit demands"; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void BanditShark(){
        gameManager.playerSharkRelation += 10;
        if(gameManager.knights >= 20 && gameManager.food > 0){
            string text = "Your knights defeat and kill the bandits";
            gameManager.setResultText(text);

            gameManager.money -= 5;
            gameManager.food -= 5;
            gameManager.trust += 10;

            gameManager.knights -= 20;
            gameManager.returningKnights = 20;

            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(10);
        }
        else if(gameManager.knights < 20){
            string text = "Your knights got killed by the bandits";
            gameManager.setResultText(text);

            gameManager.trust -= 5;
            gameManager.money -= 5;
            gameManager.food -= 5;
            gameManager.knights = 0;

            gameManager.shark.GetComponent<SharkBehaviour>().removeSharkRelations(10);
        }

        else{
            string text = "Your knights got killed by the bandits";
            gameManager.setResultText(text);

            gameManager.trust += 5;
            gameManager.returningKnights = gameManager.knights;
            gameManager.knights = 0;

            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(5);
        }
    }

    public void BanditOwl(){
        gameManager.playerOwlRelation += 10;
        string text = "You got the bandits as mercenaries.";
        gameManager.setResultText(text);

        gameManager.trust += 5;
        gameManager.money -= 10;
        gameManager.knights -= 10;
        gameManager.returningKnights += 20;

        gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(10);

        gameManager.traits.Add("Mercenaries");
    }

    public void BanditFox(){
        gameManager.playerFoxRelation += 10;
        if(gameManager.knights >= 20){
            string text = "You scare them away with your might.";
            gameManager.setResultText(text);

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(10);

            gameManager.traits.Add("Less Bandits");
        }
        else{
            string text = "You scare them away with your might.";
            gameManager.setResultText(text);

            gameManager.trust -= 5;
            gameManager.money -= 20;

            gameManager.fox.GetComponent<FoxBehaviour>().removeFoxRelations(10);

            gameManager.addBanditsEvent();
        }
    }

    public void BanditTurtle(){
        gameManager.playerTurtleRelation += 10;
        string text = "You just left the bandits to do whatever they want to do. And they killed your people and burned your farms.";
        gameManager.setResultText(text);

        gameManager.trust -= 10;
        gameManager.food -= 5;

        gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);

        gameManager.addBanditsEvent();
    }

    public void BanditTeddy(){
        gameManager.playerTeddyRelation += 10;
        string text = "They'll use that money to gain more bandits. Lets hope you can beat them then.";
        gameManager.setResultText(text);

        gameManager.trust -= 5;
        gameManager.money -= 20;

        gameManager.teddy.GetComponent<TeddyBehaviour>().removeTeddyRelations(10);

        gameManager.traits.Add("More Bandits");

        gameManager.addBanditsEvent();
    }

}
