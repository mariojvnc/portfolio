package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Random;

public class Share {
    private double price;
    private String name;
    private List<ShareEvents> investors;

    public void buy(ShareEvents investor) {
        if (investor != null) {
            this.investors.add(investor);
        }
    }

    public void sell(ShareEvents investor) {
        this.investors.remove(investor);
    }

    public Share(String name) {
        this.name = name;
        this.investors = new ArrayList(5);
    }

    public void simulate() throws InterruptedException {
        LocalTime startTime = LocalTime.of(8, 0);
        LocalTime endTime = LocalTime.of(9, 0);
        this.price = 22.0D;
        Random rnd = new Random();

        for (LocalTime time = startTime; time.isBefore(endTime); time = time.plusMinutes(1)) {
            if (rnd.nextInt(100) < 90) {
                double randomValue = 0.5D + 1.5D * rnd.nextDouble();
                this.price += randomValue;
            } else {
                this.price *= 0.95D;
                for (ShareEvents investor : this.investors) {
                    investor.sharePriceFalls(this, time, this.price, this.name);
                }

                System.out.println();
            }

            Thread.sleep(50);
        }

        // ich bin cool :)

    }
}