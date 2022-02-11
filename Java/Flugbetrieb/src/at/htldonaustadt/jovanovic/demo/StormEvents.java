package at.htldonaustadt.jovanovic.demo;

public interface StormEvents {
    // 1
    void newStorm(Object sender, TypeOfStorm storm, double x, double y);
}
