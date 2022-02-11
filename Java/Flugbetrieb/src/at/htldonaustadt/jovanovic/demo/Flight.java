package at.htldonaustadt.jovanovic.demo;
import lombok.*;
import lombok.experimental.NonFinal;

import java.lang.reflect.GenericDeclaration;
import java.text.DecimalFormat;
import java.time.LocalTime;

@AllArgsConstructor
@Getter

public class Flight implements /* 2. */ StormEvents, Runnable {
    private final LocalTime startTime;
    private final int flightDuration;
    private final String type;
    private final String name;
    private final double x_start;
    private final double y_start;
    private final double x_landing;
    private final double y_landing;

    private double x_current;
    private double y_current;

    public void fly () throws InterruptedException {
        DecimalFormat df = new DecimalFormat("#.###");
        for (LocalTime time = startTime; time.isBefore(startTime.plusMinutes(flightDuration)); time = time.plusMinutes(15))
        {
            System.out.println(name + " auf " + df.format(x_current) +"/" + df.format(y_current));

            double x_step = Math.round(15.0 / flightDuration * (x_landing - x_start));
            double y_step = Math.round(15.0 / flightDuration * (y_landing - y_start));

            x_current += x_step;
            y_current += y_step;

            Thread.sleep(1000);
        }
    }

    // Eventhandler
    @Override
    public void newStorm(TypeOfStorm storm, double x, double y) {
        System.out.println("UNWETTERWARNUNG auf " + x + "/" + y + " | " + storm.toString());
    }

    @Override
    public void run() {
        try {
            fly();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
