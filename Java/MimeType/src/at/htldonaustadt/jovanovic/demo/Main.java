package at.htldonaustadt.jovanovic.demo;

import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int N = in.nextInt(); // Number of elements which make up the association table.
        int Q = in.nextInt(); // Number Q of file names to be analyzed.
        HashMap<String, String> extToMimeType = new HashMap<>();

        for (int i = 0; i < N; i++) {
            String EXT = in.next().toLowerCase(Locale.ROOT); // file extension
            String MT = in.next(); // MIME type.
            extToMimeType.put(EXT, MT);
        }
        in.nextLine();
        for (int i = 0; i < Q; i++) {
            String FNAME = in.nextLine().toLowerCase(Locale.ROOT); // One file name per line.

            String extension = FNAME.substring(FNAME.lastIndexOf('.') + 1);
            if(!FNAME.contains(".") || !extToMimeType.containsKey(extension)){
                System.out.println("UNKNOWN");
            } else {
                System.out.println(extToMimeType.get(extension));
            }
        }

        // Write an answer using System.out.println()
        // To debug: System.err.println("Debug messages...");w


        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
        //System.out.println("UNKNOWN");
    }
}