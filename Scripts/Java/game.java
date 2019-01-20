package tictaktoe;

import java.util.Scanner;

public class game {

	public static void main(String[] args) {
		char board [][] = {{'1','2','3'},{'4','5','6'},{'7','8','9'}};
		boolean game = true;
		boolean player1 = true;
		boolean player2 = false;
		int row = 0;
		int col = 0;
		Scanner scanner = new Scanner (System.in);
		
		
		while (game = true){
			
			while (player1 == true){
				System.out.println("enter row");
				row = scanner.nextInt();
				System.out.println("enter col");
				col = scanner.nextInt();
				if (board[row][col] == 'o'){
					System.out.println("space is taken enter new space");
				} else {
				board [row][col] = 'x';
				for (int i = 0; i < board.length; i++) {
				    for (int j = 0; j < board[i].length; j++) {
				        System.out.print(board[i][j] + " ");
				    }
				    System.out.println();
				}

				player1 = false;
				player2 = true;
				}
			}
			while (player2 == true){
				System.out.println("enter row");
				row = scanner.nextInt();
				System.out.println("enter col");
				col = scanner.nextInt();
				if (board[row][col] == 'x'){
					System.out.println("space is taken enter new space");
				} else {
				board [row][col] = 'o';
				for (int i = 0; i < board.length; i++) {
				    for (int j = 0; j < board[i].length; j++) {
				        System.out.print(board[i][j] + " ");
				    }
				    System.out.println();
				}
				player1 = true;
				player2 = false;
				}
			}
		}
	}
}
