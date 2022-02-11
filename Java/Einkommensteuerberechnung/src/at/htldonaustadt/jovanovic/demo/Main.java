package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.text.NumberFormat;
import java.util.*;

/*
*
*  Er macht bei mir irgendwie die Zahlen größer - ich nehme an, es ist ein Formatierungsfehler.
*  Eine Lösung hab ich dennoch nicht gefunden :(
*
* */


public class Main {
    public static TaxratesForYear calculateTaxesForYear(double annualsalary, List<Taxrate>taxrates, int year){
        int countTaxClass = 0;
        int counter = 0;
        double[]taxvalues = new double[7];
        double[]actualTax = new double[7];
        double subtotal = annualsalary;
        double restbalance = 0;
        while(true){
            double difference_MAX_MIN = taxrates.get(countTaxClass).getMax() - taxrates.get(countTaxClass).getMin();
            restbalance = subtotal - difference_MAX_MIN;
            if(restbalance > 0){
                // greater than 0 (+)
                subtotal = restbalance;
                taxvalues[countTaxClass] = difference_MAX_MIN;
            } else {
                // lower than 0 (-)
                taxvalues[countTaxClass] = subtotal;
                if(year <= 2021){
                    actualTax[countTaxClass] = taxvalues[countTaxClass] * taxrates.get(countTaxClass).getTaxrate_2021();
                } else {
                    actualTax[countTaxClass] = taxvalues[countTaxClass] * taxrates.get(countTaxClass).getTaxrate_2022();
                }
                break;
            }

            // Calculate tax percentages
            if(year <= 2021){
                actualTax[countTaxClass] = taxvalues[countTaxClass] * taxrates.get(countTaxClass).getTaxrate_2021();
            } else {
                actualTax[countTaxClass] = taxvalues[countTaxClass] * taxrates.get(countTaxClass).getTaxrate_2022();
            }
            counter++;

            countTaxClass++;
        }
        double[] shortArr = new double[counter];
        System.arraycopy(actualTax, 0, shortArr, 0, counter);
        return new TaxratesForYear(shortArr, Arrays.stream(actualTax).sum(), year);
    }

    public static void calculateAndOutputSavings(TaxratesForYear first, TaxratesForYear second){
        Locale locale = new Locale("de", "AT");
        NumberFormat currencyFormat = NumberFormat.getCurrencyInstance(locale);
        System.out.println(first);
        System.out.println(second);
        System.out.println("Ersparnis: " + currencyFormat.format(Math.abs(first.getSum() - second.getSum())));
    }

    public static void main(String[] args) {
        // Read File
        List<Taxrate> taxrates = new ArrayList<>(7);
        Scanner scanner = null;
        Scanner input = new Scanner(System.in);
        try {
            scanner = new Scanner(new File("input.txt"));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        //Scanner input = new Scanner(System.in);
        assert scanner != null;
        scanner.useDelimiter(",");
        int countTaxRates = 7;
        int taxClass = 0;
        while(scanner.hasNext()){
            taxrates.add(new Taxrate(taxClass, scanner.nextDouble(), scanner.nextDouble(), scanner.nextDouble(), scanner.nextDouble()));
            taxClass++;
        }
        scanner.close();

        System.out.print("Jahresgehalt: € ");
        double annualSalary = input.nextDouble();
        System.out.print("Erstes Jahr: ");
        int firstYear = input.nextInt();
        System.out.print("Zweites Jahr: ");
        int secondYear = input.nextInt();
        System.out.println();

        TaxratesForYear firstYearTaxrates = calculateTaxesForYear(annualSalary, taxrates, firstYear);
        TaxratesForYear secondYearTaxrates = calculateTaxesForYear(annualSalary, taxrates, secondYear);

        calculateAndOutputSavings(firstYearTaxrates, secondYearTaxrates);
    }
}