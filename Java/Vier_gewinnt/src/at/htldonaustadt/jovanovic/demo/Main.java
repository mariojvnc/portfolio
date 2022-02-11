package at.htldonaustadt.jovanovic.demo;

import java.io.CharConversionException;
import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class Main {

    public static String[][] createArray(){
        Scanner scanner = new Scanner(System.in);
        int rows = scanner.nextInt();
        int columns = scanner.nextInt();
        String[][] array = new String[rows][columns];
        scanner.nextLine();

        // fill array
        for (int row = 0; row < rows; row++){
            String line = scanner.nextLine();
            String[] token = line.split("[ ,]");
            System.out.println(line);
            System.arraycopy(token, 0, array[row], 0, columns);
        }

        return array;
    }

    public static String checkBoard(String[][] board){
        // Check Row
        int columnCounter = 1, rowCounter = 1;
   
        for(int row = 0; row < board.length; row++){
            for(int col = 0; col < board[row].length; col++){
                if(board[row][col].equals("_")){
                    continue;
                }

                // Check row
                for(int col2 = col+1; col2<=col+3;col2++){
                    if(board[row][col2].equals(board[row][col])){
                        columnCounter++;
                        if(columnCounter >= 4)
                            return board[row][col];
                    } else {
                        columnCounter = 1;
                    }

                }

                // Check down
                for (int row2 = row+1; row2 <= row +3; row2++){
                    if(board[row][col].equals(board[row2][col])){
                        rowCounter++;
                        if(rowCounter >= 4){
                            return board[row][col];
                        }
                    } else {
                        rowCounter = 1;
                    }
                }

                //

            }
        }

        return "None";
    }

    public static void main(String[] args) {
        String [][] board = createArray();
        String validator =  checkBoard(board);

        System.out.println(validator);
    }
}
