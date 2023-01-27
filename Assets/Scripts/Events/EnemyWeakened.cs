using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakened : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;

    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    // Start is called before the first frame update
    public void StartEnemyWeakenedEvent()
    {
        string text = "The enemy has been weakened you can probably attack them and take them out. What do you do?";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Hurry and attack them.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "Hold a war council.";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Try to vassalize the enemy.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "We are not in a situation to attack them.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "You think about all the poor people of the other country that will get hurt in case of an attack. So you don't attack them."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void EnemyWeakenedShark(){
        gameManager.playerSharkRelation += 20;
        if(gameManager.knights >= 10){
            string text = "You defeat their army and conquer their land.";
            gameManager.setResultText(text);

            gameManager.money += 30;
            gameManager.food += 30;
            gameManager.trust += 30;

            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(20);
        }
        else{
            string text = "You destroy their army but can't conquer their land";
            gameManager.setResultText(text);

            gameManager.trust += 20;
            gameManager.knights /= 2;

            gameManager.shark.GetComponent<SharkBehaviour>().addSharkRelations(10);
            gameManager.addEnemyWeakened();
        }
    }

    public void EnemyWeakenedOwl(){
        if(gameManager.knights >= 10 && gameManager.money > 5 && gameManager.food > 5 && gameManager.trust > 5 && gameManager.faith > 10 && gameManager.playerSharkRelation >= 20 && gameManager.playerOwlRelation >= 20 && gameManager.playerFoxRelation >= 20 && gameManager.playerTurtleRelation >= 20 && gameManager.playerTeddyRelation >= 20){
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;
            string text = "You get help from all parts of your council and create a large army and attack and destroy the enemy.";
            gameManager.setResultText(text);

            gameManager.trust += 30;
            gameManager.money += 30;
            gameManager.knights += 30;
            gameManager.food += 30;
            gameManager.faith += 30;

            gameManager.owl.GetComponent<OwlBehaviour>().addOwlRelations(20);
        }
        else{
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;
            string text = "You get help from all parts of your council to create a large army but some of them don't help you so the army isn't enough and your army is now damaged.";
            gameManager.setResultText(text);

            gameManager.trust /= 2;
            gameManager.money /= 2;
            gameManager.knights /= 2;
            gameManager.food /= 2;
            gameManager.faith /= 2;

            gameManager.owl.GetComponent<OwlBehaviour>().removeOwlRelations(10);
            gameManager.addEnemyWeakened();
        }

    }

    public void EnemyWeakenedFox(){
        int randomNumber = Random.Range(1, 100);
        if(randomNumber >= 50){
            gameManager.playerFoxRelation += 20;
            string text = "You manage to vassalize them.";
            gameManager.setResultText(text);

            gameManager.trust += 30;
            gameManager.money += 30;
            gameManager.knights += 30;
            gameManager.food += 30;

            gameManager.fox.GetComponent<FoxBehaviour>().addFoxRelations(20);

            gameManager.traits.Add("Less Bandits");
        }
        else{
            string text = "You can't vassalize them.";
            gameManager.setResultText(text);

            gameManager.addEnemyWeakened();
        }
    }

    public void EnemyWeakenedTurtle(){
        if(gameManager.knights >= 10){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;
            string text = "Letting that opportunity go might not be a good idea.";
            gameManager.setResultText(text);

            gameManager.turtle.GetComponent<TurtleBehaviour>().removeTurtleRelations(10);

        }
        else{
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;
            string text = "You didn't have enough knights so it was a good idea to not do anything at this time.";
            gameManager.setResultText(text);

            gameManager.turtle.GetComponent<TurtleBehaviour>().addTurtleRelations(10);
        }

    }

    public void EnemyWeakenedTeddy(){
        gameManager.playerSharkRelation -= 10;
        gameManager.playerOwlRelation -= 10;
        gameManager.playerFoxRelation -= 10;
        gameManager.playerTurtleRelation -= 10;
        gameManager.playerTeddyRelation -= 10;
        string text = "You should think more about your own people.";
        gameManager.setResultText(text);

        gameManager.trust -= 10;

        gameManager.teddy.GetComponent<TeddyBehaviour>().removeTeddyRelations(10);
    }

}
