package at.htldonaustadt.jovanovic.demo;

public class RootCalculator implements Runnable{
    final private int MAX_VALUE;

    public RootCalculator (int max){
        MAX_VALUE = max;
    }
    @Override
    public void run() {
        for (int i = 0; i < MAX_VALUE; i++) {
            System.out.println(i + " -> " + Math.sqrt(i));
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
