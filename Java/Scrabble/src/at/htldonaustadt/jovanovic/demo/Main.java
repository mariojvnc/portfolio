package at.htldonaustadt.jovanovic.demo;

import javax.xml.crypto.dsig.keyinfo.KeyValue;
import java.util.*;

public class Main {

    public static <TypeKey> void main(String[] args) {
        Scanner in = new Scanner(System.in);

        List<String> words = new ArrayList<>();

        int N = in.nextInt();
        if (in.hasNextLine()) {
            in.nextLine();
        }
        for (int i = 0; i < N; i++) {
            String W = in.nextLine();
            words.add(W);
        }
        String LETTERS = in.nextLine();

        // Write an answer using System.out.println()
        // To debug: System.err.println("Debug messages...");

        HashMap<Character, Integer> alphabet = generateAlphabet();

        // Step 1: Check if a word can be generated from the given letters
        List<String>foundWords = new ArrayList<>();
        for(var word : words){
            if(validWord(word, LETTERS.toCharArray())){
                foundWords.add(word);
            }
        }

        // Step 2: Get points of a certain word
        // The word that scores the most points using the available letters (1 to 7 letters).
        // The word must belong to the dictionary.
        // Each letter must be used at most once in the solution.
        // There is always a solution.
        HashMap<String, Integer> wordToPoints = new HashMap<>();
        for(var word : foundWords){
            // Go through each character, look in HashMap how many points it has and add up
            int sum = 0;
            for(char character : word.toCharArray()){
                sum+= alphabet.get(character);
            }
            wordToPoints.put(word, sum);
        }

        int maxValueInMap=(Collections.max(wordToPoints.values()));

        /*for( element : foundWords){
            if (eleme.)
        }*/

        System.out.println("invalid word");
    }
    private static void printHashMap(HashMap<String, Integer>hashMap){
        for (var name: hashMap.keySet()) {
            String key = name.toString();
            String value = hashMap.get(name).toString();
            System.out.println(key + " " + value);
        }
    }
    private static boolean validWord(String word, char[] letters)
    {
        char[] lettersCopy = letters.clone();
        Arrays.sort(lettersCopy);
        for(char c : word.toCharArray())
        {
            if(Arrays.binarySearch(lettersCopy, c) < 0)
                return false;
        }
        return true;
    }
    private static  HashMap<Character, Integer>generateAlphabet(){
        HashMap<Character, Integer> alphabet = new HashMap<Character, Integer>();
        alphabet.put('e', 1);
        alphabet.put('a', 1);
        alphabet.put('i', 1);
        alphabet.put('o', 1);
        alphabet.put('n', 1);
        alphabet.put('r', 1);
        alphabet.put('t', 1);
        alphabet.put('l', 1);
        alphabet.put('s', 1);
        alphabet.put('u', 1);

        alphabet.put('d', 2);
        alphabet.put('g', 2);

        alphabet.put('b', 3);
        alphabet.put('c', 3);
        alphabet.put('m', 3);
        alphabet.put('p', 3);

        alphabet.put('f', 4);
        alphabet.put('h', 4);
        alphabet.put('v', 4);
        alphabet.put('w', 4);
        alphabet.put('y', 4);

        alphabet.put('k', 5);

        alphabet.put('j', 8);
        alphabet.put('x', 8);

        alphabet.put('q', 10);
        alphabet.put('z', 10);

        return alphabet;
    }
}
