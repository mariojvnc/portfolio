package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Main {
    public static Map<String, Country> processCountry(HashMap<String, Country> countryHashMap, String country_name, int goalsCountry_1, int goalsCountry_2) {

        // Belarus-Frankreich
        if(!countryHashMap.containsKey(country_name)){
            // not in hashmap
            Country country = new Country(country_name);
            country.getGameResult(goalsCountry_1, goalsCountry_2);
            countryHashMap.put(country_name, country);
        } else {
            // country already in hashmap
            // --> increase countGoales
            Country country = countryHashMap.get(country_name);
            country.getGameResult(goalsCountry_1, goalsCountry_2);
        }
        return countryHashMap;
    }
    public static Map<String, Country> ReadFile(String filename) throws FileNotFoundException {
        Map<String, Country> countryHashMap = new HashMap<>();
        Scanner scanner = new Scanner(new File(filename));
        scanner.nextLine();
        scanner.nextLine();
        while(scanner.hasNext()){
            scanner.next();
            scanner.next();

            String [] countries = scanner.next().split("-");
            String [] result = scanner.next().split(":");

            int goalsCountry_1 = Integer.parseInt(result[0]);
            int goalsCountry_2 = Integer.parseInt(result[1]);

            if ( !countryHashMap.containsKey(countries[0]) )
                countryHashMap.put(countries[0], new Country(countries[0]));

            countryHashMap.get(countries[0]).getGameResult(goalsCountry_1, goalsCountry_2);

            if ( !countryHashMap.containsKey(countries[1]) )
                countryHashMap.put(countries[1], new Country(countries[1]));

            countryHashMap.get(countries[1]).getGameResult(goalsCountry_2, goalsCountry_1);
        }
        scanner.close();
        return countryHashMap;
    }
    public static void main(String[] args) throws FileNotFoundException {

        Map<String, Country> countryHashMap = ReadFile(("Matches Gruppe A.txt"));
        for ( var entry : countryHashMap.entrySet()) {
            System.out.println(entry.getValue());
        }

    }
}
