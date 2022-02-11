package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;

public interface ShareEvents {
    void ShareFalls(Object sender, String name, double oldPrice, double price, LocalTime time);
}
