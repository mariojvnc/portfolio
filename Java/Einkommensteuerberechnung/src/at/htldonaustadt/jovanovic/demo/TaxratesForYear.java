package at.htldonaustadt.jovanovic.demo;

import java.text.NumberFormat;
import java.util.Locale;

public class TaxratesForYear {
    private double [] taxes;
    private double sum;
    private int year;

    public TaxratesForYear(double[] taxes, double sum, int year) {
        this.taxes = taxes;
        this.sum = sum;
        this.year = year;
    }
    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }
    public void setTaxes(double[] taxes) {
        this.taxes = taxes;
    }

    public void setSum(double sum) {
        this.sum = sum;
    }

    public double[] getTaxes() {
        return taxes;
    }

    public double getSum() {
        return sum;
    }

    @Override
    public String toString() {
        Locale locale = new Locale("de", "AT");
        NumberFormat currencyFormat = NumberFormat.getCurrencyInstance(locale);
        StringBuilder builder = new StringBuilder();
        int level = 0;
        builder.append(year).append(":\n");
        for(double element : taxes){
            builder.append("Tarifstufe ").append(String.valueOf(level)).append(": ").append(currencyFormat.format(element));
            builder.append("\n");
            level++;
        }
        builder.append("Summe: ");
        builder.append(currencyFormat.format(sum));
        builder.append("\n");
        return builder.toString();
    }
}
