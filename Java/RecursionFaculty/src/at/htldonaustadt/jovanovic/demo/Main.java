package at.htldonaustadt.jovanovic.demo;

import java.math.BigInteger;
import java.sql.SQLOutput;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        try (Scanner scanner = new Scanner(System.in)) {
            System.out.println("Gib n ein: ");
            BigInteger n = BigInteger.valueOf(scanner.nextInt());
            System.out.println(faculty(n));
        }
    }

    private static BigInteger faculty(BigInteger n) {
        // 1. Abbruchsbedingung
        if (n == 0)
            return 1;

        // 2. rekursiver Aufruf
        return faculty(n-1) * n;
    }
}
