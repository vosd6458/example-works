package base;

import java.util.Scanner;
import java.util.Random;

public class DiceRollerScript {

	public static void main(String[] args) {
		boolean programRunning = true; //used to keep the program running
		
		int maxRoll = 0;//#of sides
		int minRoll = 0;//always 0
		int numberOfRolls;//how many dice to roll
		int result = 0;//result of roll
		int resultTotal = 0;//if multiple dice are rolled used to get total
		int mod = 0;//add to total if playing a game with modifiers like D&D
		String choice = "";//used for switch system
		Random random = new Random();//used to random die roll
		Scanner scanner = new Scanner (System.in);//input
		
		
		while (programRunning == true){
			//reset roll and result
			numberOfRolls = 0;
			maxRoll = 0;
			result = 0;
			resultTotal = 0;
			mod = 0;
			
			//roller can roll or exit
			System.out.println("Would you like to 'roll' or 'exit'");
			choice = scanner.next();
			switch (choice){
			//roll system
			case "roll":
			System.out.println("What type of die do you want to roll?");
			maxRoll = scanner.nextInt();
			System.out.println("How many d-" + maxRoll + " do you want to roll?");
			numberOfRolls = scanner.nextInt();
			//for loop to roll multiple dice.
			for (int i=0; i<numberOfRolls; i++){
			result = random.nextInt(maxRoll) +1;
			resultTotal += result;
			System.out.println("You rolled a " + result);
			}
			//geting mod input
			System.out.println("Aditional modifier amount?");
			mod = scanner.nextInt();
			//roll total without mod
			System.out.println("Your roll total is " + resultTotal);
			resultTotal += mod;
			//roll total with mod
			System.out.println("Modified total is " + resultTotal);
			break;
			//end program
			case "exit":
				programRunning = false;
				break;
			}
		}
	}
}






