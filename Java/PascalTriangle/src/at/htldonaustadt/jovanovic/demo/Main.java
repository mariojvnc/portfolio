package at.htldonaustadt.jovanovic.demo;

import javax.security.auth.callback.PasswordCallback;
import java.util.Scanner;

public class Main {

    /*public static int getPascalValue(int k, int n) {
        System.out.println("k= " + k + ", n= " + n);
        if ( n > k )
            throw new IndexOutOfBoundsException();

        if ( n == 0 || k == n )
            return 1;

        return getPascalValue(k-1,n-1) + getPascalValue(k-1,n);
    }*/

    public static void main(String[] args) {
        PascalCalculator calculator = new PascalCalculator();
        try(Scanner scanner = new Scanner(System.in)) {
            System.out.print("Enter two k and n: ");
            int k = scanner.nextInt();
            int n = scanner.nextInt();
            long start = System.currentTimeMillis();
            System.out.println("P("+k+","+n+")="+calculator.getPascalValue(k,n));
            long end = System.currentTimeMillis();
            System.out.println("Time: " + (end - start) + "ms");
        }
    }
}
