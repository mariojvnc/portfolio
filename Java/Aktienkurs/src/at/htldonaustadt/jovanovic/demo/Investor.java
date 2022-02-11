package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;

public class Investor implements ShareEvents {

    private String name;

    public Investor(String name) {
        this.name = name;
    }

    @Override
    public void sharePriceFalls(Object var1, LocalTime time, double price, String shareName) {
        System.out.println(name + ":\t Aktie" + shareName + " ist gesunken. Aktueller Preis: " + Math.round(price * 100.0) / 100.0 + "$" + "\t" + time);
    }
}
