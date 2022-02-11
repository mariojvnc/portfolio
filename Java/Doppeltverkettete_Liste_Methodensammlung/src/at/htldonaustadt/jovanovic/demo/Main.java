package at.htldonaustadt.jovanovic.demo;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        DoubleList list = new DoubleList();

        list.add(3.4);
        list.add(6);
        list.add(4.4);
        list.add(632.4);
        list.add(13.4);
        list.add(32.4);

        // 1. Methods where you have to run through the whole list

        //  1.1 string toString()
        System.out.println("toString()\n" + list + "\n");

        // 1.2 string toStringReverse()
        System.out.println("toStringReverse()\n" + list.toStringReverse() + "\n");

        // 1.3 int findMax()
        System.out.println("findMax()\n" + list.findMax() + "\n");

        // 1.4 double getMax()
        System.out.println("getMax()\n" + list.getMax() + "\n");

        // 1.5 getMinMax()
        System.out.println("getMinMax()\n" + Arrays.toString(list.getMinMax()) + "\n");

        // 1.6 double getAverage()
        System.out.println("getAverage()\n" + list.getAverage() + "\n");

        // 1.7 bool contains(double value)
        System.out.println("contains(6)\n" + list.contains(6));
        System.out.println("contains(5.5)\n" + list.contains(5.5) + "\n");

        // 1.8 void multiplicate(double factor)
        System.out.println("multiplicate(2)");
        System.out.println("before: " + list);
        list.multiplicate(2);
        System.out.println("after: " + list + "\n");



    }
}