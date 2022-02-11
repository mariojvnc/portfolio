package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Random;

public class Share {
    private String name;
    private double price;
    private List<ShareEvents> observers;

    public Share(String name) {
        this.name = name;
        observers = new ArrayList<>();
    }

    public void subscribe(ShareEvents e){
        if(e != null)
            observers.add(e);
    }
    public void unsubscribe(ShareEvents e){
        if(e != null)
            observers.remove(e);
    }

    public void simulate(){
        price = 22;
        double oldPrice = 22;
        Random rnd = new Random();
        for (LocalTime time = LocalTime.of(8, 0);
             time.isBefore(LocalTime.of(9,0));
             time = time.plusMinutes(1)) {

            oldPrice = price;
            if(rnd.nextInt(100) <= 90){
                double value = rnd.nextDouble() *1.5 + 0.5;
                price += value;
            } else {
                price *= 0.95;

                // observer informieren
                for(var observer : observers){
                    observer.ShareFalls(this,name, oldPrice, price, time);
                }
            }
        }
    }

}
