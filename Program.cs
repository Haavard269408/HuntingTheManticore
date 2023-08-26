// hunting the manticore

//decalaring and assigning variables:
int cityMaxHealth = 15;
int mantiCoreMaxHealh = 10;
int round = 0;
int cityHealth = cityMaxHealth;
int mantiCoreHealh = mantiCoreMaxHealh;

string p1 = "Player 1";
string p2 = "Player 2";


//ask user inputm, and store it in a variable

int mantiPos = askForNumberInRange($"{p1} how far away from the city do you want to station the Manticore? ", 0, 100);

Console.Clear();

//player 2 turn
displayText($"{p2} it is your turn! ");
runGame();





void runGame()
{
    while (cityHealth > 0 && mantiCoreHealh > 0)
    {   
        
        // displays -------- 
        breakLine();
        updateRound();
        int canonRange = askForNumber($"{p2} Enter desired canon range: ");

        if (canonRange == mantiPos)
        {
            
            Console.WriteLine("The canon is expected to deal: "+ canonDamage() + " damage this round.");

            updateHealth();
            displayText("Direct hit");

        }
        else if (canonRange > mantiPos)
        {
            cityDamage();
            Console.WriteLine("The canon is expected to deal: " + canonDamage() + " damage this round.");
            Console.WriteLine("That round OVERSHOT the target.");
        }
        else
        {
            cityDamage();
            Console.WriteLine("The canon is expected to deal: " + canonDamage() + " damage this round.");
            Console.WriteLine("That round FELL SHORT the target.");
        }

       


    }
    Console.WriteLine("game over");
}




int canonDamage()
{
    for (int i = 0; i < round; i++)
    {
        if (round % 5 == 0 && round % 3 == 0) return 10;
        else if (round % 5 == 0)
        {
            return 3;
        }
        else if (round % 3 == 0) return 3;
    }
    return 1;
}



void updateRound()
{
    round++;
    Console.WriteLine($"STATUS: Round: {round} Cityhealth: {cityHealth} / {cityMaxHealth} Manticorehealth: {mantiCoreHealh}");
}




void updateHealth()
{
    cityDamage();
    mantiCoreHealh -= canonDamage();
 
    
}


int askForNumber(string text)
{
    Console.WriteLine(text);
    int num1 = Convert.ToInt32(Console.ReadLine());
    return num1;

}


void cityDamage()
{
    cityHealth -= 1;

}

string displayText(string text)
{
    Console.WriteLine(text);
    return text;
}

void breakLine()
{
    Console.WriteLine("----------------------------------------------------");
   
}

int askForNumberInRange(string text, int min, int max)
{

    while (true)
    {
        int num1 = askForNumber(text);

        if (num1 >= min && num1 <= max)
            return num1;

        else if (num1 <= min) Console.WriteLine("too low");
        else Console.WriteLine("too high");

    }
}