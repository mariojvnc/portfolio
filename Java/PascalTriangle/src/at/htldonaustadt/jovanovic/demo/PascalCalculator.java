package at.htldonaustadt.jovanovic.demo;

import java.util.HashMap;
import java.util.Map;

public class PascalCalculator {
    // Memoizaton
    // Wir speichern bereits berechnete Werte ab
    //                                 k    n
    //private int [][] memory = new int[100][100];

    // Besser sind Hashmaps.
    // k, n -> P(k, n)
    //           "k n" -> P(k,n)
    private Map<String, Integer> memory = new HashMap<>();
    private static String createKey(int k, int n) {
        return k+"_"+n;
    }

    public int getPascalValue(int k, int n) {
        String key = createKey(k, n);
        if(memory.containsKey(key)) {
           return memory.get(key);
        }
        /*if (memory[k][n] != 0) {
            // P(k, n) wurde bereits berechnet
            return memory[k][n];
        }*/
        System.out.println("k= " + k + ", n= " + n);
        if ( n > k )
            throw new IndexOutOfBoundsException();

        if ( n == 0 || k == n )
            return 1;

        int p1 = getPascalValue(k - 1, n-1);
        if( memory.containsKey(k-1)) {

        }
        // memory[k-1][n-1] = p1; // Speichern des Resultats
        int p2 = getPascalValue(k -1, n);
        //memory[k-1][n] = p2; // Speichern des Resultats
        memory.put(key, p1+p2);
        return p1+p2;

        //return getPascalValue(k-1,n-1) + getPascalValue(k-1,n);
    }
}
