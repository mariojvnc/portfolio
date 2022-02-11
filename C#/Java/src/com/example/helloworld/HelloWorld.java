package com.example.helloworld;
import java.util.*;

public class HelloWorld {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        System.out.println("Mario hat sein erstes Java Hello World am 19.11.2020 erstellt!");

        System.out.println("Erste Zahl: ");
        int a = sc.nextInt();
        System.out.println("Zweite Zahl: ");
        int b = sc.nextInt();

        int sum = a+b;
        System.out.println(a + " + " + b + " = " + sum);
    }
}
