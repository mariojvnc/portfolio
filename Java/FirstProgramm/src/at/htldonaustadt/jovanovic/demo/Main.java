package at.htldonaustadt.jovanovic.demo;
import java.util.Random;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	    System.out.println("Hello World!");

	    int count, maxvalue;

	    System.out.println("How many numbers do you want? ");
        // int count = int.Parse(Console.ReadLine()); --> C#
        // System.In = Console.In (C#)
       try ( Scanner scanner = new Scanner(System.in) ) {
           count = scanner.nextInt();
           System.out.println("Maximum number: ");
           maxvalue = scanner.nextInt();
           //scanner.close();
       }

	    // Random number
        Random rnd = new Random();
        System.out.println("Random numbers:");

        // homework: enumerate all six numbers
        // 1. number: 45
        // 2. number: 12
        // and so on...
        for (int i = 0; i < count; i++){
            // from 1 to 45
            System.out.println(i+1 + ".number: " + rnd.nextInt(maxvalue)+1);
        }

    }
}
