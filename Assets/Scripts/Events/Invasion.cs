using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartInvasionEvent()
    {
        string text = "The enemy is gathering its troops to invade you. You need to do something and fast.";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Attack them before they can gather their troops.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "Hold a war council.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Try to negotiate peace.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Maybe they are gathering the troops for something else and it is not for attacking us so lets not do anything.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You decide to surrender to save as many people as possible."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void InvasionShark(){
        if(gameManager.knights >= 20){
            gameManager.playerSharkRelation += 10;
            string text = "You manage to attack them and destroy their army before they can gather their troops.";
            gameManager.setResultText(text);

            gameManager.trust += 30;

            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(10);

            gameManager.addEnemyWeakened();
        }
        else{
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;
            string text = "Your army wasn't strong enough and gets destroyed.";
            gameManager.setResultText(text);

            gameManager.trust -= 10;
            gameManager.knights = 0;

            gameManager.shark.GetComponent<SharkBehaviour>().removeSharkRelations(10);
            gameManager.addEnemyWeakened();
        }
    }

    public void InvasionOwl(){
        if(gameManager.knights >= 20 && gameManager.money > 10 && gameManager.food > 10 && gameManager.trust > 10 && gameManager.faith > 10 && gameManager.playerSharkRelation >= 30 && gameManager.playerOwlRelation >= 30 && gameManager.playerFoxRelation >= 30 && gameManager.playerTurtleRelation >= 30 && gameManager.playerTeddyRelation >= 30){
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;
            string text = "You raise an army and conscript people for it too. And you manage to defend against the invasion.";
            gameManager.setResultText(text);

            gameManager.trust += 30;
            gameManager.money += 30;
            gameManager.knights += 30;
            gameManager.food += 30;
            gameManager.faith += 30;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(20);
            gameManager.addEnemyWeakened();
        }
        else{
            gameManager.playerSharkRelation -= 20;
            gameManager.playerOwlRelation -= 20;
            gameManager.playerFoxRelation -= 20;
            gameManager.playerTurtleRelation -= 20;
            gameManager.playerTeddyRelation -= 20;
            string text = "You manage to create an army and even conscript people for it but some of the members of your council did not cooperate with you so your army wasn't good enough and now you are just a vassal.";
            gameManager.setResultText(text);

            gameManager.trust = 1;
            gameManager.money = 1;
            gameManager.knights = 1;
            gameManager.food = 1;

            gameManager.owl.GetComponent<OwlBehaviour>().removeOwlRelations(10);
            gameManager.VassalEnd();
        }

    }

    public void InvasionFox(){
        if(gameManager.money >= 20){
            gameManager.playerFoxRelation += 20;
            string text = "You send them some Tributes and after a some negotiating you manage to achieve peace and get a trade route going.";
            gameManager.setResultText(text);

            gameManager.trust += 20;
            gameManager.money -= 20;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);

            gameManager.traits.Add("Trade Route");
        }
        else if(gameManager.food >= 20){
            gameManager.playerFoxRelation += 20;
            string text = "You send them some Tributes and after a some negotiating you manage to achieve peace and get a trade route going.";
            gameManager.setResultText(text);

            gameManager.trust += 20;
            gameManager.food -= 20;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);

            gameManager.traits.Add("Trade Route");
        }
        else if(gameManager.knights >= 20){
            gameManager.playerFoxRelation += 20;
            string text = "You show them your might and you manage to scare them into achieving peace.";
            gameManager.setResultText(text);

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);
        }
        else{
            gameManager.playerFoxRelation -= 20;
            string text = "You couldn't get a peace treaty.";
            gameManager.setResultText(text);

            gameManager.trust -= 20;

            gameManager.fox.GetComponent<FoxBehaviour>().removeFoxRelations(20);
            gameManager.addAttackedEvent();
        }
    }

    public void InvasionTurtle(){
        if(gameManager.knights >= 10){
            gameManager.playerTurtleRelation -= 10;
            string text = "Letting that opportunity go might not be a good idea.";
            gameManager.setResultText(text);

            gameManager.trust -= 5;
            gameManager.faith -= 5;

            gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);

            gameManager.addAttackedEvent();
        }

    }

    public void InvasionTeddy(){
        gameManager.playerSharkRelation -= 20;
        gameManager.playerOwlRelation -= 20;
        gameManager.playerFoxRelation -= 20;
        gameManager.playerTurtleRelation -= 20;
        gameManager.playerTeddyRelation -= 20;
        string text = "You just surrender? Lets hope you can escape this vassalization someday.";
        gameManager.setResultText(text);

        gameManager.trust = 1;
        gameManager.money = 1;
        gameManager.knights = 1;
        gameManager.food = 1;

        gameManager.VassalEnd();

        gameManager.teddy.GetComponent<TeddyBehaviour>().removeTeddyRelations(10);

    }

}
