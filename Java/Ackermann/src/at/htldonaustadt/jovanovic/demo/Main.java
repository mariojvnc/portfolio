package at.htldonaustadt.jovanovic.demo;

import java.math.BigInteger;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        AckermannCalculator ackermannCalculator = new AckermannCalculator();
        try (Scanner scanner = new Scanner(System.in)){
            System.out.println("m: ");
            BigInteger m = BigInteger.valueOf(scanner.nextInt());
            System.out.println("n: ");
            BigInteger n = BigInteger.valueOf(scanner.nextInt());
            System.out.println( "ackermann(" + m + "," + n + ")=" + ackermannCalculator.ackermann(m,n) );

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
