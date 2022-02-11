package at.htldonaustadt.jovanovic.demo;

import java.time.LocalTime;

public class Flight implements Runnable, StormEvent{
    private LocalTime start;
    private LocalTime end;
    private int duration;
    private String name;
    private Kind kind;
    private double xStart, yStart, xLanding, yLanding, xCurrent, yCurrent;
    private boolean reagularLanding;

    public LocalTime getStart() {
        return start;
    }

    public void setStart(LocalTime start) {
        this.start = start;
    }

    public LocalTime getEnd() {
        return end;
    }

    public void setEnd(LocalTime end) {
        this.end = end;
    }

    public int getDuration() {
        return duration;
    }

    public void setDuration(int duration) {
        this.duration = duration;
    }

    public Kind getKind() {
        return kind;
    }

    public void setKind(Kind kind) {
        this.kind = kind;
    }

    public double getxStart() {
        return xStart;
    }

    public void setxStart(double xStart) {
        this.xStart = xStart;
    }

    public double getyStart() {
        return yStart;
    }

    public void setyStart(double yStart) {
        this.yStart = yStart;
    }

    public double getxLanding() {
        return xLanding;
    }

    public void setxLanding(double xLanding) {
        this.xLanding = xLanding;
    }

    public double getyLanding() {
        return yLanding;
    }

    public void setyLanding(double yLanding) {
        this.yLanding = yLanding;
    }

    public double getxCurrent() {
        return xCurrent;
    }

    public void setxCurrent(double xCurrent) {
        this.xCurrent = xCurrent;
    }

    public double getyCurrent() {
        return yCurrent;
    }

    public void setyCurrent(double yCurrent) {
        this.yCurrent = yCurrent;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Flight(LocalTime start, int duration, String name, Kind kind, double xStart, double yStart, double xLanding, double yLanding) {
        this.start = start;
        this.end = start.plusMinutes(duration);
        this.duration = duration;
        this.name = name;
        this.kind = kind;
        this.xStart = xStart;
        this.xCurrent = xStart;
        this.yCurrent = yStart;
        this.yStart = yStart;
        this.xLanding = xLanding;
        this.yLanding = yLanding;
    }

    public void fly() {
        reagularLanding = true;
        for (LocalTime time = start;
             time.isBefore(end) && reagularLanding /* bzw fliegt normal*/;
             time = time.plusMinutes(15))
        {
            System.out.println(name + " auf " + xCurrent + "/" + yCurrent);
            double xStep = 15.0 / duration * (xLanding - xStart);
            double yStep = 15.0 / duration * (yLanding - yStart);

            xCurrent += xStep;
            yCurrent += yStep;

            try {
                Thread.sleep(250);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        if(reagularLanding)
            System.out.println(name + " gelandet auf " + xCurrent + "/" + yCurrent);
    }

    @Override
    public String toString() {
        return "Flight{" +
                "start=" + start +
                ", end=" + end +
                ", duration=" + duration +
                ", kind=" + kind +
                ", xStart=" + xStart +
                ", yStart=" + yStart +
                ", xLanding=" + xLanding +
                ", yLanding=" + yLanding +
                '}';
    }

    @Override
    public void run() {
        fly();
    }

    @Override
    public void newStorm(Object sender, double xStorm, double yStorm) {
        double distance = Math.abs(Math.sqrt(Math.pow(xCurrent, 2) + Math.pow(yCurrent, 2)));
        if (reagularLanding /* wenn es in der luft ist*/ && distance < 4) {
            reagularLanding = false;
            System.out.println(name + " landed because of a Storm nearby at " + xStorm + "/" + yStorm);
        }
        if(sender instanceof FlightControl){
             ((FlightControl) sender).unsubscribe(this);
        }
    }
}
