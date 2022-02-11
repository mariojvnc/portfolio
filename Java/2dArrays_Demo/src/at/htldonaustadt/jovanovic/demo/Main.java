package at.htldonaustadt.jovanovic.demo;

import javax.rmi.ssl.SslRMIClientSocketFactory;

public class Main {

    public static void main(String[] args) {
        // 3 rows, 4 columns
        int[][] sales = {
                {30, 53, 43, 8},    // VW
                {12, 48, 5, 9},     // KIA
                {32, 65, 3, 1}      // Dacia
        };
        /*
        sales[0][0] = 30;
        sales[1][0] = 12;
        sales[2][0] = 32;

        sales[0][1] = 53;
        */

        // Aufgabe: Summiere alle Verkaufszahlen von KIA
        // System.out.println(sales.length); // Anzahl der Zeilen
        int sum_kia = 0;
        for(int i = 0; i < sales[1].length; i++){
            sum_kia+=sales[1][i];
        }
        print(sales);
        System.out.println("Summe KIAs: " + sum_kia);
        
        // Aufgabe: Summiere alle Verkaufszahlen von SUVs
        int sumSUV = 0;
        for(int row = 0; row < sales.length; row++){
            sumSUV+=sales[row][2];
        }

        System.out.println("Summe SUVs: " + sumSUV);
    }
    private static void print(int[][] arr){
        for(int row = 0; row < arr.length; row++){
            for(int col = 0; col < arr[row].length; col++){
                System.out.print(arr[row][col] + " ");
            }
            System.out.println();
        }
    }
}
