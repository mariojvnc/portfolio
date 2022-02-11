package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) {
        FlightControl flightControl = new FlightControl();
        flightControl.load("Flugplan20191026.csv");
        Thread simulateThread = new Thread(flightControl);
        simulateThread.start();
    }
}