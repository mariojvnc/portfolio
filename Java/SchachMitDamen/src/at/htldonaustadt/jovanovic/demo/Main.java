package at.htldonaustadt.jovanovic.demo;

import java.util.ArrayList;
import java.util.List;

class Queen{
    private final int x;
    private final int y;

    public Queen(int x, int y) {
        this.x = x; // starts at 1 and ends at 8
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }
}

public class Main {

    public static void main(String[] args) {
        List<Queen>board = new ArrayList<>();
        board.add(new Queen(2, 4)); // 1
        board.add(new Queen(2, 8)); // 2
        board.add(new Queen(4, 2)); // 3
        board.add(new Queen(5, 8)); // 4

       checkBoard(board);
    }

    public static void checkBoard(List<Queen>board){
        for (var queen_1 : board) {
            for (var queen_2 : board) {
                if (queen_1 != queen_2) {
                    if (queen_1.getX() == queen_2.getX() ||
                            queen_1.getY() == queen_2.getY() ||
                            queen_1.getX() - queen_1.getY() == queen_2.getX() - queen_2.getY() ||
                            (Math.abs(queen_1.getX() - queen_2.getX()) == Math.abs(queen_1.getY() - queen_2.getY()))
                    )
                        System.out.println("X: "+ queen_1.getX() + " Y: " + queen_1.getY() + " and " + "X: " + queen_2.getX() + " Y: " + queen_2.getY() + " beat each other");
                }
            }
        }
    }
}
