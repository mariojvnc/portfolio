package at.htldonaustadt.jovanovic.demo;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class MeasurePoint implements ServerRequestEvent {
    private Region region;
    private double temperatur;
    private int humidity;
    private static Random random = new Random();

    private List<MeasurePointSendDataEvent>observer;
    public void subscribe(MeasurePointSendDataEvent e){
        if(e != null)
            observer.add(e);
    }
    public void unsubscribe(MeasurePointSendDataEvent e){
        observer.remove(e);
    }

    public MeasurePoint(Region region) {
        temperatur =  -20 + (40 - (-20)) * random.nextDouble();
        humidity = random.nextInt(101);
        observer = new ArrayList<>();
        this.region = region;
    }

    @Override
    public void newRequest(MeasurePointSendDataEvent server) {
        // we want to send back data, if we get a request -> event!
        System.out.println("Measure point in Region " + region.toString() + " got a new message from server");

            server.sendData(this, region, temperatur, humidity);

        }

    @Override
    public String toString() {
        return region + ":" + temperatur + "°C" + ", " + humidity + "%";
    }
}
