package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) throws InterruptedException {
        Server server = new Server("Tirol Server 3000");

        MeasurePoint measurePoint_1 = new MeasurePoint(Region.Bischofsmuetze_und_Hochwurzen);
        MeasurePoint measurePoint_2 = new MeasurePoint(Region.Dachstein);
        MeasurePoint measurePoint_3 = new MeasurePoint(Region.Radstadt);
        MeasurePoint measurePoint_4 = new MeasurePoint(Region.Schladming);

        server.subscribe(measurePoint_1);
        server.subscribe(measurePoint_2);
        server.subscribe(measurePoint_3);
        server.subscribe(measurePoint_4);

        server.simulate();
    }
}