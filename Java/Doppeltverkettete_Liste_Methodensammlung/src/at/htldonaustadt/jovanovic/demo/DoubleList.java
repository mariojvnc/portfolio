package at.htldonaustadt.jovanovic.demo;

import java.text.DecimalFormat;
import java.util.ArrayList;

public class DoubleList {
    private Node head, tail;

    public Node getHead() {
        return head;
    }

    public void setHead(Node head) {
        this.head = head;
    }

    public Node getTail() {
        return tail;
    }

    public void setTail(Node tail) {
        this.tail = tail;
    }

    public void add(double number) {
        Node node = new Node(number);

        if (head == null && tail == null){
            head = tail = node;
        } else {
            tail.setNext(node);
            node.setPrev(tail);
            tail = node;
        }
    }

    public int sizeOf() {
        int counter = 0;
        for (Node node = head; node != null; node = node.getNext()) {
            counter++;
        }
        return counter;
    }


    // 1. Methods where you have to run through the whole list

    //  1.1 string toString()
    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();

        for(Node node = head; node != null; node = node.getNext()){
            if(node != tail){
                builder.append(node.getNumber()).append(", ");
            } else {
                builder.append(node.getNumber());
            }
        }

        return builder.toString();
    }

    // 1.2 string toStringReverse()
    public String toStringReverse() {
        StringBuilder builder = new StringBuilder();

        for(Node node = tail; node != null; node = node.getPrev()){
            if(node != head){
                builder.append(node.getNumber()).append(", ");
            } else {
                builder.append(node.getNumber());
            }
        }

        return builder.toString();
    }

    // 1.3 int findMax()
    public int findMax() {
        double max = Double.MIN_VALUE;
        int index = 0;

        if(head == null && tail == null) {
            // empty list
            return -1;
        } else if (sizeOf() == 1) {
            return 0;
        }

        // more than 1 element

        for (Node node = head; node != null; node = node.getNext()) {
            if (node.getNumber() > max) {
                max = node.getNumber();
                index++;
            }
        }
        return index;
    }

    public double getMax() {
        double max = Double.MIN_VALUE;
        int index = 0;

        if(head == null && tail == null) {
            // empty list
            return max;
        } else if (sizeOf() == 1) {
            return head.getNumber();
        }

        // more than 1 element
        for (Node node = head; node != null; node = node.getNext()) {
            if (index == findMax()) {
                return node.getNumber();
            }
            index ++;
        }
        return max;
    }

    public double getMin() {
        double min = Double.MAX_VALUE;
        int index = 0;

        if(head == null && tail == null) {
            // empty list
            return min;
        } else if (sizeOf() == 1) {
            return head.getNumber();
        }

        // more than 1 element
        for (Node node = head; node != null; node = node.getNext()) {
            if (node.getNumber() < min) {
                min = node.getNumber();
                index++;
            }
        }
        return min;
    }

    // 1.5 getMinMax()
    public double[] getMinMax() {

        if(head == null && tail == null) {
            // empty list
            return new double[] {Double.MAX_VALUE, Double.MIN_VALUE};
        } else if (sizeOf() == 1) {
            return new double[] {head.getNumber(), head.getNumber()};
        }

        return new double[] {getMin(), getMax()};
    }

    public double getAverage() {
        double average = -1;
        double sum = 0;
        double elementCounter = 0;

        if(head == null && tail == null) {
            // empty list
            return average;
        } else if (sizeOf() == 1) {
            return head.getNumber();
        }


        // more than 1 element
        for(Node node = head; node != null; node = node.getNext()) {
            sum += node.getNumber();
            elementCounter++;
        }

        return sum / elementCounter;
    }

    public boolean contains(double value) {
        for(Node node = head; node != null; node = node.getNext()) {
            if(node.getNumber() == value)
                return true;
        }
        return false;
    }

    public void multiplicate(double factor) {
        if(head != null && tail != null) {
            // empty list
            return;
        } else {
            for(Node node = head; node != null; node = node.getNext()) {
                node.setNumber(node.getNumber() * factor);
            }
        }
    }

    public static DoubleList multiplicate(DoubleList list, double factor) {

        if(head != null && tail != null) {
            // empty list
            return list;
        } else {
            for(Node node = list.getHead(); node != null; node = node.getNext()) {
                node.setNumber(node.getNumber() * factor);
            }
        }

        return list;
    }
}
