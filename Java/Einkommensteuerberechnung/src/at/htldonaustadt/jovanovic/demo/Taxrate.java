package at.htldonaustadt.jovanovic.demo;

public class Taxrate {
    private int taxClass;
    private double min, max;
    private double taxrate_2021;
    private double taxrate_2022; // in %

    public Taxrate(int taxClass, double min, double max, double taxrate_2021, double taxrate_2022) {
        this.min = min;
        this.taxClass = taxClass;
        this.max = max;
        this.taxrate_2021 = taxrate_2021;
        this.taxrate_2022 = taxrate_2022;
    }
    public void setTaxClass(int taxClass) {
        this.taxClass = taxClass;
    }

    public int getTaxClass() {
        return taxClass;
    }
    public void setMin(double min) {
        this.min = min;
    }

    public void setMax(double max) {
        this.max = max;
    }

    public double getMin() {
        return min;
    }

    public double getMax() {
        return max;
    }

    public double getTaxrate_2021() {
        return taxrate_2021;
    }

    public double getTaxrate_2022() {
        return taxrate_2022;
    }

    @Override
    public String toString() {
        return
                "Steuerklasse: " + taxClass + '\'' +
                ", min=" + min +
                ", max=" + max +
                ", 2021: =" + taxrate_2021 + "%"+
                ", 2022: =" + taxrate_2022 +"%";
    }
}
