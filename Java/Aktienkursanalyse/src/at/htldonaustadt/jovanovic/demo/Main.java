package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.time.LocalDate;
import java.util.Scanner;

public class Main {
    public static Share readFile (String filename, String delimeter){

        Share shares = new Share();

        try (Scanner scanner = new Scanner(new File(filename))){
            String firstline = scanner.nextLine();
            scanner.useDelimiter(delimeter);
            // timestamp,open,high,low,close,volume
            // 2018-03-02,91.5800,93.1500,90.8600,93.0500,32830389

            while(scanner.hasNextLine()){
                String [] parts = scanner.nextLine().split(delimeter);

                shares.add(new ShareValue(
                        LocalDate.parse(parts[0]),
                        Float.parseFloat(parts[1]),
                        Float.parseFloat(parts[2]),
                        Float.parseFloat(parts[3]),
                        Float.parseFloat(parts[4]),
                        Float.parseFloat(parts[5])));
            }
            scanner.close();


        } catch (Exception e){
            e.printStackTrace();
        }

        return shares;
    }
    public static void main(String[] args) {
        final String filename = "daily_MSFT.csv";
        Share shares = readFile(filename, ",");
        System.out.println(shares);
    }
}
