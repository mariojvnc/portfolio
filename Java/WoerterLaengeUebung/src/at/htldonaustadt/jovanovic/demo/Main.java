package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args){
        TextAnalyzer analyzer_1 = new TextAnalyzer("data1.txt");
        TextAnalyzer analyzer_2 = new TextAnalyzer("data3.txt");
        TextAnalyzer analyzer_3 = new TextAnalyzer("data3.txt");

        DataCombiner combiner = new DataCombiner();

        // Subscribe to event
        analyzer_1.subscribe(combiner);
        analyzer_2.subscribe(combiner);
        analyzer_3.subscribe(combiner);

        // Start Threads
        Thread thread_analyzer_1 = new Thread(analyzer_1);
        Thread thread_analyzer_2 = new Thread(analyzer_2);
        Thread thread_analyzer_3 = new Thread(analyzer_3);

        thread_analyzer_1.start();
        thread_analyzer_2.start();
        thread_analyzer_3.start();

        // Wait until all Threads are finished
        try {
            thread_analyzer_1.join();
            thread_analyzer_2.join();
            thread_analyzer_3.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // All threads successfully finished! -> output data
        System.out.println(combiner);
    }
}