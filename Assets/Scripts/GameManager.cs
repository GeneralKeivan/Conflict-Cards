using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerSharkRelation;
    public int playerOwlRelation;
    public int playerFoxRelation;
    public int playerTurtleRelation;
    public int playerTeddyRelation;

    public int sharkOwlRel, sharkFoxRel, sharkTurtleRel, sharkTeddyRel;
    public int owlFoxRel, owlTurtleRel, owlTeddyRel;
    public int foxTurtleRel, foxTeddyRel;
    public int turtleTeddyRel;

    public GameObject shark, owl, fox, turtle, teddy;
    public int knights;
    public int money;
    public int trust;
    public int faith;
    public int food;

    public int returningKnights = 0;

    public bool riot = false, plague = false;


    [SerializeField] private GameObject pl, ri, al, tr, mr, bu, bd;
    [SerializeField] private GameObject mainGame, tutorial, endings, help;
    [SerializeField] private GameObject betrayEnd, deadEnd, surviveEnd, vassalEnd, destroyEnd;
    [SerializeField] private GameObject sharkCard, owlCard, foxCard, turtleCard, teddyCard, allCards;
    [SerializeField] private GameObject eventCard, resultCard;
    [SerializeField] private GameObject eventsHolder;

    [SerializeField] private GameObject chooseButton, nextEventButton, helpButton;
    [SerializeField] private GameObject music;
    
    public List<string> traits = new List<string>();

    public bool isEventInitiated = false;
    public bool choiceSelected = false;
    private bool helpBool = false;

    public int numOfFlippedCards = 0;
    public string chosenCard;
    public bool choiceMade = false;
    private string currentEvent;

    public List<int> eventsList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        playerSharkRelation     = -50;
        playerOwlRelation       = -25;
        playerFoxRelation       =  0;
        playerTurtleRelation    =  25;
        playerTeddyRelation     =  50;

        knights = 50;
        money = 50;
        trust = 50;
        faith = 50;
        food = 50;

        allCards.SetActive(false);
        eventCard.SetActive(false);
        resultCard.SetActive(false);

        mainGame.SetActive(false);
        endings.SetActive(false);
        tutorial.SetActive(true);
        helpButton.SetActive(false);

        for(int i = 0; i <= 4; i++){
            eventsList.Add(i);
        }

        chooseButton.SetActive(false);
        nextEventButton.SetActive(false);
    }

    void Update(){
        if(numOfFlippedCards == 5){
            chooseButton.SetActive(true);
        }
    }

    public void startGame(){
        tutorial.SetActive(false);
        mainGame.SetActive(true);
        endings.SetActive(false);
        helpButton.SetActive(true);
        startEvent();
    }
    
    public void startEvent(){
        numOfFlippedCards = 0;
        music.GetComponent<AudioSource>().pitch = 1;
        allCards.SetActive(false);
        eventCard.SetActive(true);
        resultCard.SetActive(false);

        chooseButton.SetActive(false);
        nextEventButton.SetActive(false);

        if(eventsList.Count == 0){
            SurvivedEnd();
            return;
        }

        //Something got wrong with the random number try to see what is wrong
        int randomNumber = Random.Range(0, eventsList.Count);

        switch(eventsList[randomNumber]){
            case 0: banditEvent(); break;
            case 1: locustEvent(); break;
            case 2: festivalEvent(); break;
            case 3: callForHelpEvent(); break;
            case 4: corruptPriestEvent(); break;
            case 5: enemyWeakenedEvent(); break;
            case 6: plagueCureEvent(); break;
            case 7: riotStoppedEvent(); break;
            case 8: angryPeopleEvent(); break;
            case 9: invasionImminentEvent(); break;
            case 10: attackedEvent(); break;
        }
        
    }

    void banditEvent(){
        eventsList.Remove(0);
        currentEvent = "bandit";
        eventsHolder.GetComponent<Bandits>().StartBanditEvent();
        BetweenEvents();
    }
    void locustEvent(){
        eventsList.Remove(1);
        currentEvent = "locust";
        eventsHolder.GetComponent<Locust>().StartLocustEvent();
        BetweenEvents();
    }
    void festivalEvent(){
        eventsList.Remove(2);
        currentEvent = "festival";
        eventsHolder.GetComponent<Festival>().StartFestivalEvent();
        BetweenEvents();
    }

    void callForHelpEvent(){
        eventsList.Remove(3);
        currentEvent = "callForHelp";
        eventsHolder.GetComponent<CallForHelp>().StartCallForHelpEvent();
        BetweenEvents();
    }
    void corruptPriestEvent(){
        eventsList.Remove(4);
        currentEvent = "corruptPriest";
        eventsHolder.GetComponent<CorruptPriest>().StartCorruptPriestEvent();
        BetweenEvents();
    }
    void enemyWeakenedEvent(){
        music.GetComponent<AudioSource>().pitch = 1.5f;
        eventsList.Remove(5);
        currentEvent = "enemyWeakened";
        eventsHolder.GetComponent<EnemyWeakened>().StartEnemyWeakenedEvent();
        BetweenEvents();
    }
    void plagueCureEvent(){
        eventsList.Remove(6);
        currentEvent = "plagueCure";
        eventsHolder.GetComponent<PlagueCure>().StartPlagueCureEvent();
        BetweenEvents();
    }
    void riotStoppedEvent(){
        music.GetComponent<AudioSource>().pitch = 0.5f;
        eventsList.Remove(7);
        currentEvent = "riotStopped";
        eventsHolder.GetComponent<RiotStopped>().StartRiotStoppedEvent();
        BetweenEvents();
    }
    void angryPeopleEvent(){
        music.GetComponent<AudioSource>().pitch = 0.75f;
        eventsList.Remove(8);
        currentEvent = "angryPeople";
        eventsHolder.GetComponent<AngryPeople>().StartAngryPeopleEvent();
        BetweenEvents();
    }
    void invasionImminentEvent(){
        music.GetComponent<AudioSource>().pitch = 2f;
        eventsList.Remove(9);
        currentEvent = "invasionImminent";
        eventsHolder.GetComponent<Invasion>().StartInvasionEvent();
        BetweenEvents();
    }
    void attackedEvent(){
        music.GetComponent<AudioSource>().pitch = 3f;
        eventsList.Remove(10);
        currentEvent = "attacked";
        eventsHolder.GetComponent<Attacked>().StartAttackedEvent();
        BetweenEvents();
    }


    public void addBanditsEvent(){
        eventsList.Add(0);
    }
    public void addCallForHelpEvent(){
        eventsList.Add(3);
    }
    public void addEnemyWeakened(){
        eventsList.Add(5);
    }
    public void addPlagueCureEvent(){
        eventsList.Add(6);
    }
    public void addRiotStoppedEvent(){
        eventsList.Add(7);
    }
    public void addAngryPeopleEvent(){
        eventsList.Add(8);
    }
    public void addInvasionImminent(){
        eventsList.Add(9);
    }
    public void addAttackedEvent(){
        eventsList.Add(10);
    }

    public void SurvivedEnd(){
        Debug.Log("You survived");
        mainGame.SetActive(false);
        endings.SetActive(true);
        surviveEnd.SetActive(true);
        helpButton.SetActive(true);
    }

    public void DestroyedEnd(){
        Debug.Log("Your land is gone");
        mainGame.SetActive(false);
        endings.SetActive(true);
        destroyEnd.SetActive(true);
        helpButton.SetActive(true);
    }

    public void VassalEnd(){
        Debug.Log("You got vassalized");
        mainGame.SetActive(false);
        endings.SetActive(true);
        vassalEnd.SetActive(true);
        helpButton.SetActive(true);
    }

    public void DeadEnd(){
        Debug.Log("You be dead");
        mainGame.SetActive(false);
        endings.SetActive(true);
        deadEnd.SetActive(true);
        helpButton.SetActive(true);
    }

    public void BetrayalEnd(){
        Debug.Log("You got betrayed");
        mainGame.SetActive(false);
        endings.SetActive(true);
        betrayEnd.SetActive(true);
        helpButton.SetActive(true);
    }

    public void BetweenEvents(){
        if(knights < 0){
            knights = 0;
        }
        else if(knights > 100){
            knights = 100;
        }

        if(money < 0){
            money = 0;
        }
        else if(money > 100){
            money = 100;
        }

        if(trust < 0){
            trust = 0;
        }
        else if(trust > 100){
            trust = 100;
        }

        if(faith < 0){
            faith = 0;
        }
        else if(faith > 100){
            faith = 100;
        }

        if(food < 0){
            food = 0;
        }
        else if(food > 100){
            food = 100;
        }

        if(playerSharkRelation <= -100 || playerOwlRelation <= -100 || playerFoxRelation <= -100 || playerTurtleRelation <= -100 || playerTeddyRelation <= -100){
            BetrayalEnd();
            return;
        }


        if(playerSharkRelation > 100){
            playerSharkRelation = 100;
        }
        if(playerOwlRelation > 100){
            playerOwlRelation = 100;
        }
        if(playerFoxRelation > 100){
            playerFoxRelation = 100;
        }
        if(playerTurtleRelation > 100){
            playerTurtleRelation = 100;
        }
        if(playerTeddyRelation > 100){
            playerTeddyRelation = 100;
        }

        if(plague){
            addPlagueCureEvent();
            plague = false;
        }
        if(riot){
            addRiotStoppedEvent();
            riot = false;
        }

        //startEvent();
        if(traits.Contains("Plague")){
            pl.SetActive(true);
        }
        else{
            pl.SetActive(false);
        }
        if(traits.Contains("Mercenaries")){
            mr.SetActive(true);
        }
        else{
            mr.SetActive(false);
        }
        if(traits.Contains("Trade Route")){
            tr.SetActive(true);
        }
        else{
            tr.SetActive(false);
        }
        if(traits.Contains("Riot")){
            ri.SetActive(true);
        }
        else{
            ri.SetActive(false);
        }
        if(traits.Contains("Less Bandits")){
            bd.SetActive(true);
        }
        else{
            bd.SetActive(false);
        }
        if(traits.Contains("More Bandits")){
            bu.SetActive(true);
        }
        else{
            bu.SetActive(false);
        }
        if(traits.Contains("Ally Indebted")){
            al.SetActive(true);
        }
        else{
            al.SetActive(false);
        }
    }

    public void setResultText(string text){
        allCards.SetActive(false);
        eventCard.SetActive(true);
        resultCard.SetActive(true);

        chooseButton.SetActive(false);
        nextEventButton.SetActive(true);

        resultCard.GetComponent<ResultCard>().setResultText(text);
    }

    public void showChoices(){
        allCards.SetActive(true);
        eventCard.SetActive(true);
        resultCard.SetActive(false);

        //chooseButton.SetActive(true);
        nextEventButton.SetActive(false);
    }

    public void choose(){
        if(choiceMade){
            switch(currentEvent){
                case "bandit": 
                    Bandits ev1 = eventsHolder.GetComponent<Bandits>();
                    switch(chosenCard){
                        case "shark": ev1.BanditShark(); break;
                        case "owl": ev1.BanditOwl(); break;
                        case "fox": ev1.BanditFox(); break;
                        case "turtle": ev1.BanditTurtle(); break;
                        case "teddy": ev1.BanditTeddy(); break;
                    }
                break;
                case "locust":
                    Locust ev2 = eventsHolder.GetComponent<Locust>();
                    switch(chosenCard){
                        case "shark": ev2.LocustShark(); break;
                        case "owl": ev2.LocustOwl(); break;
                        case "fox": ev2.LocustFox(); break;
                        case "turtle": ev2.LocustTurtle(); break;
                        case "teddy": ev2.LocustTeddy(); break;
                    }
                    break;
                case "festival":
                    Festival ev3 = eventsHolder.GetComponent<Festival>();
                    switch(chosenCard){
                        case "shark": ev3.FestivalShark(); break;
                        case "owl": ev3.FestivalOwl(); break;
                        case "fox": ev3.FestivalFox(); break;
                        case "turtle": ev3.FestivalTurtle(); break;
                        case "teddy": ev3.FestivalTeddy(); break;
                    }
                break;
                case "callForHelp":
                    CallForHelp ev4 = eventsHolder.GetComponent<CallForHelp>();
                    switch(chosenCard){
                        case "shark": ev4.CallForHelpShark(); break;
                        case "owl": ev4.CallForHelpOwl(); break;
                        case "fox": ev4.CallForHelpFox(); break;
                        case "turtle": ev4.CallForHelpTurtle(); break;
                        case "teddy": ev4.CallForHelpTeddy(); break;
                    }
                break;
                case "corruptPriest":
                    CorruptPriest ev5 = eventsHolder.GetComponent<CorruptPriest>();
                    switch(chosenCard){
                        case "shark": ev5.CorruptShark(); break;
                        case "owl": ev5.CorruptOwl(); break;
                        case "fox": ev5.CorruptFox(); break;
                        case "turtle": ev5.CorruptTurtle(); break;
                        case "teddy": ev5.CorruptTeddy(); break;
                    }
                break;
                case "enemyWeakened":
                    EnemyWeakened ev6 = eventsHolder.GetComponent<EnemyWeakened>();
                    switch(chosenCard){
                        case "shark": ev6.EnemyWeakenedShark(); break;
                        case "owl": ev6.EnemyWeakenedOwl(); break;
                        case "fox": ev6.EnemyWeakenedFox(); break;
                        case "turtle": ev6.EnemyWeakenedTurtle(); break;
                        case "teddy": ev6.EnemyWeakenedTeddy(); break;
                    }
                break;
                case "plagueCure":
                    PlagueCure ev7 = eventsHolder.GetComponent<PlagueCure>();
                    switch(chosenCard){
                        case "shark": ev7.PlagueCureShark(); break;
                        case "owl": ev7.PlagueCureOwl(); break;
                        case "fox": ev7.PlagueCureFox(); break;
                        case "turtle": ev7.PlagueCureTurtle(); break;
                        case "teddy": ev7.PlagueCureTeddy(); break;
                    }
                break;
                case "riotStopped":
                    RiotStopped ev8 = eventsHolder.GetComponent<RiotStopped>();
                    switch(chosenCard){
                        case "shark": ev8.RiotStoppedShark(); break;
                        case "owl": ev8.RiotStoppedOwl(); break;
                        case "fox": ev8.RiotStoppedFox(); break;
                        case "turtle": ev8.RiotStoppedTurtle(); break;
                        case "teddy": ev8.RiotStoppedTeddy(); break;
                    }
                break;
                case "angryPeople":
                    AngryPeople ev9 = eventsHolder.GetComponent<AngryPeople>();
                    switch(chosenCard){
                        case "shark": ev9.AngryPeopleShark(); break;
                        case "owl": ev9.AngryPeopleOwl(); break;
                        case "fox": ev9.AngryPeopleFox(); break;
                        case "turtle": ev9.AngryPeopleTurtle(); break;
                        case "teddy": ev9.AngryPeopleTeddy(); break;
                    }
                break;
                case "invasionImminent":
                    Invasion ev10 = eventsHolder.GetComponent<Invasion>();
                    switch(chosenCard){
                        case "shark": ev10.InvasionShark(); break;
                        case "owl": ev10.InvasionOwl(); break;
                        case "fox": ev10.InvasionFox(); break;
                        case "turtle": ev10.InvasionTurtle(); break;
                        case "teddy": ev10.InvasionTeddy(); break;
                    }
                break;
                case "attacked":
                    Attacked ev11 = eventsHolder.GetComponent<Attacked>();
                    switch(chosenCard){
                        case "shark": ev11.AttackedShark(); break;
                        case "owl": ev11.AttackedOwl(); break;
                        case "fox": ev11.AttackedFox(); break;
                        case "turtle": ev11.AttackedTurtle(); break;
                        case "teddy": ev11.AttackedTeddy(); break;
                    }
                break;
            }
        }
    }

    public void setUpNewEvent(){
        if(traits.Contains("Mercenaries")){
            if(money >= 5){
                money -= 5;
            }
            else{
                traits.Remove("Mercenaries");
            }
        }
        if(traits.Contains("Trade Route")){
            food += 10;
            money += 10;
            trust += 10;
        }
        if(traits.Contains("Riot")){
            money -= 10;
            trust -= 10;
        }
        if(traits.Contains("Less Bandits")){
            trust += 10;
            int rand = Random.Range(0, 101);
            if(rand >= 0 && rand <= 25){
                traits.Remove("Less Bandits");
                addBanditsEvent();
            }
        }
        if(traits.Contains("More Bandits")){
            trust -= 10;
            money -= 5;
            food -= 5;
        }
        if(traits.Contains("Priest Corruption")){
            faith -= 5;
        }

        if(playerSharkRelation > 60){
            knights += 10;
            playerSharkRelation -= 5;
        }
        else if(playerSharkRelation > 20){
            knights += 5;
            playerSharkRelation -= 0;
        }
        else if(playerSharkRelation > -20){
            knights += 0;
            playerSharkRelation -= 0;
        }
        else if(playerSharkRelation > -60){
            knights -= 5;
            playerSharkRelation += 0;
        }
        else{
            knights -= 10;
            playerSharkRelation += 5;
        }

        if(playerOwlRelation > 60){
            money += 10;
            playerOwlRelation -= 20;
        }
        else if(playerOwlRelation > 20){
            money += 5;
            playerOwlRelation -= 10;
        }
        else if(playerOwlRelation > -20){
            money += 0;
            playerOwlRelation -= 0;
        }
        else if(playerOwlRelation > -60){
            money -= 5;
            playerOwlRelation += 10;
        }
        else{
            money -= 10;
            playerOwlRelation += 20;
        }

        if(playerFoxRelation > 60){
            trust += 10;
            playerFoxRelation -= 10;
        }
        else if(playerFoxRelation > 20){
            trust += 5;
            playerFoxRelation -= 5;
        }
        else if(playerFoxRelation > -20){
            trust += 0;
            playerFoxRelation -= 0;
        }
        else if(playerFoxRelation > -60){
            trust -= 5;
            playerFoxRelation += 5;
        }
        else{
            trust -= 10;
            playerFoxRelation += 10;
        }

        if(playerTurtleRelation > 60){
            faith += 10;
            playerTurtleRelation -= 5;
        }
        else if(playerTurtleRelation > 20){
            faith += 5;
            playerTurtleRelation -= 5;
        }
        else if(playerTurtleRelation > -20){
            faith += 0;
            playerTurtleRelation -= 0;
        }
        else if(playerTurtleRelation > -60){
            faith -= 5;
            playerTurtleRelation += 5;
        }
        else{
            faith -= 10;
            playerTurtleRelation += 5;
        }

        if(playerTeddyRelation > 60){
            food += 10;
            playerTeddyRelation -= 20;
        }
        else if(playerTeddyRelation > 20){
            food += 5;
            playerTeddyRelation -= 10;
        }
        else if(playerTeddyRelation > -20){
            food += 0;
            playerTeddyRelation -= 0;
        }
        else if(playerTeddyRelation > -60){
            food -= 5;
            playerTeddyRelation += 10;
        }
        else{
            food -= 10;
            playerTeddyRelation += 20;
        }
        
        shark.GetComponent<SharkBehaviour>().checkPlayerResource(knights);
        owl.GetComponent<OwlBehaviour>().checkPlayerResource(money);
        fox.GetComponent<FoxBehaviour>().checkPlayerResource(trust);
        turtle.GetComponent<TurtleBehaviour>().checkPlayerResource(faith);
        teddy.GetComponent<TeddyBehaviour>().checkPlayerResource(food);

        shark.GetComponent<SharkBehaviour>().checkPlayerRelation(playerSharkRelation);
        owl.GetComponent<OwlBehaviour>().checkPlayerRelation(playerOwlRelation);
        fox.GetComponent<FoxBehaviour>().checkPlayerRelation(playerFoxRelation);
        turtle.GetComponent<TurtleBehaviour>().checkPlayerRelation(playerTurtleRelation);
        teddy.GetComponent<TeddyBehaviour>().checkPlayerRelation(playerTeddyRelation);


        eventCard.GetComponent<EventCard>().setEventText("Sample Text");
        resultCard.GetComponent<ResultCard>().setResultText("Sample Text");
        shark.GetComponent<SharkBehaviour>().setSharkChoices("Sample Text");
        owl.GetComponent<OwlBehaviour>().setOwlChoices("Sample Text");       
        fox.GetComponent<FoxBehaviour>().setFoxChoices("Sample Text");
        turtle.GetComponent<TurtleBehaviour>().setTurtleChoices("Sample Text");
        teddy.GetComponent<TeddyBehaviour>().setTeddyChoices("Sample Text");

        chosenCard = "";

        eventCard.GetComponent<EventCard>().ResetCard();
        resultCard.GetComponent<ResultCard>().ResetCard();
        sharkCard.GetComponent<ChoiceCard>().ResetCard();
        owlCard.GetComponent<ChoiceCard>().ResetCard();
        foxCard.GetComponent<ChoiceCard>().ResetCard();
        turtleCard.GetComponent<ChoiceCard>().ResetCard();
        teddyCard.GetComponent<ChoiceCard>().ResetCard();
        startEvent();
    }

    public void toggleHelp(){
        helpBool = !helpBool;
        help.SetActive(helpBool);
        mainGame.SetActive(!helpBool);
    }
    public void quitGame(){
        Application.Quit();
    }
}
