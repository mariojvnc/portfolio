package at.htldonaustadt.jovanovic.demo;

public class SqaureCalculator implements Runnable{
    final private int MAX_VALUE;

    public SqaureCalculator (int max){
        MAX_VALUE = max;
    }

    @Override
    public void run() {
        for (int i = 0; i < MAX_VALUE; i++) {
            System.out.println(i + " * " + i + " ->" + Math.sqrt(i));
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
