package at.htldonaustadt.jovanovic.demo;

import java.util.ArrayList;
import java.util.List;

public class Server implements MeasurePointSendDataEvent{
    private String name;
    private List<ServerRequestEvent> observer;
    private List<MeasurePoint> measurePoints;

    public void subscribe(ServerRequestEvent e){
        if(e != null)
            observer.add(e);
    }
    public void unsubscribe(ServerRequestEvent e){
        observer.remove(e);
    }

    public Server(String name) {
        this.name = name;
        observer = new ArrayList<>();
        measurePoints = new ArrayList<>();
    }

    public void simulate() throws InterruptedException {
        // server sends request to all measure points (-> observer!)
        while(true){

            for(var m : observer){
                m.newRequest(this);
            }
           /* observer.forEach( measurepoint -> {
                measurepoint.newRequest(this, "New Request from server " + name);
            });*/

            Thread.sleep(3000);

            // if observer list is empty -> break
            if(observer.isEmpty()){
                measurePoints.forEach(System.out::println);
                break;
            }
        }
    }

    @Override
    public void sendData(Object sender, Region region, double temperatur, int humidity) {
        if(sender instanceof MeasurePoint measurePoint){
            unsubscribe(measurePoint);
            measurePoints.add(measurePoint);
            System.out.println(measurePoint);
        }
        System.out.println(region + ":" + temperatur + "°C" + ", " + humidity + "%");
    }
}
