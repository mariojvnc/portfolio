package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;

public class Investor implements ShareEvents{
    private String name;

    public Investor(String name) {
        this.name = name;
    }

    @Override
    public void ShareFalls(Object sender, String name, double oldPrice, double price, LocalTime time) {
        System.out.println(this.name + ": " + "Aktie " + name + " ist gefallen!" + "Alter Preis: " + oldPrice + "$ | Neuer Preis: " + price + " $ | Zeit: " + time);
    }
}
