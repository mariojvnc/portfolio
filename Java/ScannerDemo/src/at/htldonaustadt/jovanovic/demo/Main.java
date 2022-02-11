package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Main {
    // demo: count jow many times
    public static void main(String[] args) {
        // Console.ReadLine() in C#
        // String s = scanner.nextLine();
        try (Scanner scanner = new Scanner(new File("input.txt"))){
            // scanner.useDelimiter(":");
            //noinspection InfiniteLoopStatement
            while(true){
                if (scanner.hasNextInt()){
                    int number = scanner.nextInt();
                    System.out.println("Integer: " + number);
                } else if (scanner.hasNextFloat()){
                    float number = scanner.nextFloat();
                    System.out.printf("Float number: %f%n", number);
                } else if (scanner.hasNext()){
                    String text= scanner.next();
                    System.out.println("Text: "+ text);
                }
            }
        } catch (FileNotFoundException e) {
            System.err.println(e.getMessage());
            e.printStackTrace();
        }
    }
}