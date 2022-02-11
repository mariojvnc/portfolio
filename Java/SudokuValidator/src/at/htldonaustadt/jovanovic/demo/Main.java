package at.htldonaustadt.jovanovic.demo;

import java.util.HashSet;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);

        int[][] sudoku = new int[9][9];
        // Array einlesen
        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                int n = in.nextInt();
                sudoku[row][col] = n;
            }
        }

        if(checkArray(sudoku))
            System.out.println("true");
        else
            System.out.println("false");

    }

    private static boolean checkRow(int [][] sudoku){
        // row checker
        for(int row = 0; row < 9; row++)
            for(int col = 0; col < 8; col++)
                for(int col2 = col + 1; col2 < 9; col2++)
                    if(sudoku[row][col]==sudoku[row][col2])
                        return false;

        return true;
    }

    private static boolean checkColumn(int[][]sudoku){
        for(int col = 0; col < 9; col++)
            for(int row = 0; row < 8; row++)
                for(int row2 = row + 1; row2 < 9; row2++)
                    if(sudoku[row][col]==sudoku[row2][col])
                        return false;
        return true;
    }

    private static boolean checkGrid(int[][]sudoku){
        for(int row = 0; row < 9; row += 3)
            for(int col = 0; col < 9; col += 3)
                for(int pos = 0; pos < 8; pos++)
                    for(int pos2 = pos + 1; pos2 < 9; pos2++)
                        if(sudoku[row + pos%3][col + pos/3]==sudoku[row + pos2%3][col + pos2/3])
                            return false;

        return true;
    }

    private static boolean checkSum(int[][]sudoku){
        int sum = 0;
        for (int[] arr : sudoku)
            for(int i: arr)
                sum+=i;
        return sum == 405;
    }

    private static boolean checkArray(int[][]s){
        boolean[]checks = {
                checkRow(s),
                checkColumn(s),
                checkGrid(s),
                checkSum(s)
        };

        for(boolean check : checks) if(!check) return false;
        return true;
    }
}
