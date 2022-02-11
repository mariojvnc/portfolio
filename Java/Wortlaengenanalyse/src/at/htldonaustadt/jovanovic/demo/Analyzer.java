package at.htldonaustadt.jovanovic.demo;

import java.util.ArrayList;
import java.util.List;

public class Analyzer implements Runnable{

    // Event

    private List<Thread> threads;
    private List<String> filepaths;

    public Analyzer(){
        threads = new ArrayList<>();
    }

    public void analyzeAllFiles(){
        filepaths.forEach(filepath -> {
            Thread thread = new Thread(new Words(filepath));
            threads.add(thread);
        });
    }

    @Override
    public void run() {
        // Hier werden alle Threads gestartet
    }
}