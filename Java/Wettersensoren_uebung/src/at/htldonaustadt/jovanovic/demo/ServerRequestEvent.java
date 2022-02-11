package at.htldonaustadt.jovanovic.demo;

public interface ServerRequestEvent {
    void newRequest(MeasurePointSendDataEvent s);
}
