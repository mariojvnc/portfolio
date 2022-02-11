package at.htldonaustadt.jovanovic.demo;

import java.util.concurrent.SynchronousQueue;

public class Main {

    public static void main(String[] args) {
        Thread t1 = new Thread(new SqaureCalculator(20));
        Thread t2 = new Thread(new RootCalculator(30));

        //t1.setDaemon(true);
        //t2.setDaemon(true);

        t1.start();
        t2.start();
    }
}