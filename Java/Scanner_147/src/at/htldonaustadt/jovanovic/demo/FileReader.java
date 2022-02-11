package at.htldonaustadt.jovanovic.demo;

import java.util.*;

public class FileReader {
    // Class variable
    String Path;
    float average_decimal_numbers, average_integer_numbers, sum_decimal_numbers;
    int countOfFalseBooleans, countOfTrueBooleans, sum_integer_numbers;
    Map <String, Integer> colorToCount = new HashMap<>();
    // float [] array_decimal_numbers;

    // Constructor
    public FileReader(String path){
        Path = path;
    }

    // Method
    public void ReadFile(){
        try (Scanner scanner = new Scanner(Path)){
            //noinspection InfiniteLoopStatement
            while (true){
                if (scanner.hasNextInt()){ // Int
                    sum_integer_numbers += scanner.nextInt();
                } else if (scanner.hasNextFloat()){ // Float
                    sum_decimal_numbers += scanner.nextFloat();
                } else if (scanner.hasNext()){ // Strings
                    String text = scanner.next();
                    if (text.equals("false")){
                        countOfFalseBooleans++;
                    } else if (text.equals("true")){
                        countOfTrueBooleans++;
                    } else if (colorToCount.containsKey(text /*color*/)) {

                        // Increase the count of a color, if it is already contained in the dictionary
                        // .put = .add (C#)
                        colorToCount.put(text, colorToCount.get(text) + 1);
                    } else {
                        // Add new color and set the count to one
                        colorToCount.put(text, 1);
                    }
                }
            }
        }
    }

    public static double calculateSD(double[] numArray)
    {
        double sum = 0.0, standardDeviation = 0.0;
        int length = numArray.length;

        for(double num : numArray) {
            sum += num;
        }

        double mean = sum/length;

        for(double num: numArray) {
            standardDeviation += Math.pow(num - mean, 2);
        }

        return Math.sqrt(standardDeviation/length);
    }

    public void OutputAllData(){

    }
}