package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) {
        Share share = new Share("Chaos AG");
        Investor investor_1 = new Investor("Mario");
        Investor investor_2 = new Investor("Schamma");

        share.subscribe(investor_1);
        share.subscribe(investor_2);

        share.simulate();
    }
}