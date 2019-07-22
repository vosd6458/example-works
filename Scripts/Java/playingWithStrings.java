/*Created by Daniel Vos
 * Last Updated on July 22, 2019
 */
package playingWithStrings;

import java.util.Scanner;

public class playingWithStrings {

	public static void main(String[] args) {
		boolean programRunning = true; //used to keep the while loop going until program exit
		
		int userNumberInput = 0; //var for the number user will input
		char numberToRemove = '0'; //character number that the user wants removed
		String refrenceNumber = "";//used to aid in removal of number
		String switchAction = "";//string to add control to the program
		StringBuilder newNumberString = new StringBuilder();//used in the conversion of the user inputed int to a string
		Scanner scanner = new Scanner (System.in);
		
		while (programRunning == true){
			//reset of the variables 
			userNumberInput = 0;
			numberToRemove = '0';
			refrenceNumber = "";
			
			//program instructions
			System.out.println("What would you like to do? \"run\" the program or \"exit\"?" );
			switchAction = scanner.next();
			
			switch(switchAction){
			
			case "run":
			System.out.println("Enter a number");
			userNumberInput = scanner.nextInt();
			refrenceNumber = Integer.toString(userNumberInput);//converts user's int to string
			System.out.println("enter a number to remove");
			numberToRemove = scanner.next().charAt(0);
			
			
			System.out.println("Starting Number");
			//for loop checks each position for number/character to be removed and removes it
			for (int i = 0; i<refrenceNumber.length(); i++){
				System.out.print(refrenceNumber.charAt(i));
				
				if (refrenceNumber.charAt(i) != numberToRemove){
					newNumberString.append(refrenceNumber.charAt(i));//replaces number with nothing example removing 2: 123 to 13
				}
			}
			System.out.println();
			System.out.println("new string " + newNumberString);
			
			newNumberString.delete(0, newNumberString.length());
			break;
			
			case "exit":
				programRunning = false;
			break;	
			}
		}
		
	}

}
