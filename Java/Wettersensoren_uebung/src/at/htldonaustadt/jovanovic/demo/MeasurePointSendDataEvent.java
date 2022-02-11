package at.htldonaustadt.jovanovic.demo;

public interface MeasurePointSendDataEvent {
    void sendData(Object sender, Region region, double temperatur, int humidity);
}
