using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Festival : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject eventCard;
    [SerializeField] private GameObject shark, owl, fox, turtle, teddy;

    public void StartFestivalEvent()
    {
        string text = "It is time for the annual festival. What kind a festival will it be?";
        eventCard.GetComponent<EventCard>().setEventText(text);

        text = "Go for a tournament.";
        shark.GetComponent<SharkBehaviour>().setSharkChoices(text);

        text = "No festival this time.The situation is not good for a festival";
        owl.GetComponent<OwlBehaviour>().setOwlChoices(text);
        
        text = "Lets just do the same as every year.";
        fox.GetComponent<FoxBehaviour>().setFoxChoices(text);
        
        text = "Lets hold a sermon.";
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices(text);

        text = "Lets hold a harvest festival."; 
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices(text);
    }

    public void FestivalShark(){

        if(gameManager.traits.Contains("Plague")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "Who holds a festival in the middle of a plague?";
            gameManager.setResultText(text);

            gameManager.knights -= 20;
        }
        else if(gameManager.traits.Contains("Riot")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "The riotters bombed the festival ground.";
            gameManager.setResultText(text);

            gameManager.knights -= 20;
            gameManager.money -= 20;
            gameManager.trust -= 20;  
        }
        else{
            gameManager.playerSharkRelation += 10;

            int randomNumber = Random.Range(1, 100);
            if(randomNumber > 50){
                string text = "The tournament was a failure. And a few knights died.";
                gameManager.setResultText(text);

                gameManager.knights -= 5;
            }
            else{
                string text = "The tournament was a success. A few people decided to become knights.";
                gameManager.setResultText(text);

                gameManager.knights += 10;
            }
        }
    }

    public void FestivalOwl(){
        if(gameManager.traits.Contains("Plague")){
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;

            string text = "That was a good idea to not hold a festival in the middle of a plague.";
            gameManager.setResultText(text);

            gameManager.money += 20;
            gameManager.trust += 10;
        }
        else if(gameManager.traits.Contains("Riot")){
            gameManager.playerSharkRelation += 10;
            gameManager.playerOwlRelation += 10;
            gameManager.playerFoxRelation += 10;
            gameManager.playerTurtleRelation += 10;
            gameManager.playerTeddyRelation += 10;

            string text = "That was a good idea. Who knows what the riotters might have done.";
            gameManager.setResultText(text);

            gameManager.money += 20;
            gameManager.trust -= 10;  
        }
        else{
            gameManager.playerOwlRelation += 10;

            string text = "The people didn't like that.";
            gameManager.setResultText(text);

            gameManager.money += 10;
            gameManager.trust -= 10;
            
        }
    }

    public void FestivalFox(){
        if(gameManager.traits.Contains("Plague")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "Who holds a festival in the middle of a plague?";
            gameManager.setResultText(text);

            gameManager.trust -= 20;
        }
        else if(gameManager.traits.Contains("Riot")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "The riotters bombed the festival ground.";
            gameManager.setResultText(text);

            gameManager.knights -= 20;
            gameManager.money -= 20;
            gameManager.trust -= 20;  
        }
        else{
            gameManager.playerFoxRelation += 10;

            int randomNumber = Random.Range(1, 100);
            if(randomNumber > 50){
                string text = "The festival failed.";
                gameManager.setResultText(text);

                gameManager.trust -= 10;
            }
            else{
                string text = "That was a nice festival.";
                gameManager.setResultText(text);

                gameManager.trust += 5;
            }
        }
    }

    public void FestivalTurtle(){
        if(gameManager.traits.Contains("Plague")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "Who holds a festival in the middle of a plague?";
            gameManager.setResultText(text);

            gameManager.trust -= 20;
        }
        else if(gameManager.traits.Contains("Riot")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "The riotters bombed the festival ground.";
            gameManager.setResultText(text);

            gameManager.knights -= 20;
            gameManager.money -= 20;
            gameManager.trust -= 20;  
        }
        else{
            gameManager.playerTurtleRelation += 10;

            int randomNumber = Random.Range(1, 100);
            if(randomNumber > 50){
                string text = "The sermon was a failure.";
                gameManager.setResultText(text);

                gameManager.faith -= 10;
            }
            else{
                string text = "The sermon was good.";
                gameManager.setResultText(text);

                gameManager.faith += 5;
            }
        }
    }

    public void FestivalTeddy(){
        if(gameManager.traits.Contains("Plague")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "Who holds a festival in the middle of a plague?";
            gameManager.setResultText(text);

            gameManager.trust -= 20;
        }
        else if(gameManager.traits.Contains("Riot")){
            gameManager.playerSharkRelation -= 10;
            gameManager.playerOwlRelation -= 10;
            gameManager.playerFoxRelation -= 10;
            gameManager.playerTurtleRelation -= 10;
            gameManager.playerTeddyRelation -= 10;

            string text = "The riotters bombed the festival ground.";
            gameManager.setResultText(text);

            gameManager.knights -= 20;
            gameManager.money -= 20;
            gameManager.trust -= 20;  
        }
        else{
            gameManager.playerTeddyRelation += 10;

            int randomNumber = Random.Range(1, 100);
            if(randomNumber > 50){
                string text = "The festival failed.";
                gameManager.setResultText(text);

                gameManager.food -= 10;
            }
            else{
                string text = "That was a nice festival.";
                gameManager.setResultText(text);

                gameManager.food += 5;
            }
        }
    }

}
