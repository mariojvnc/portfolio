package at.htldonaustadt.jovanovic.demo;

import java.security.InvalidParameterException;

public class MyList {
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

    public void add(int number) {
        Node node = new Node(number);

        if (head == null && tail == null){
            head = node;
            tail = node;
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

    public int get(int index) {
        if (index < 0) {
            throw new InvalidParameterException();
        }

        int counter = 0;
        for (Node node = head; node != null; node = node.getNext()) {
            if (counter == index) {
                return node.getNumber();
            }
            counter++;
        }
        throw new IndexOutOfBoundsException();
    }

    public void removeLast() {
        // 1. no element
        if(head == null && tail == null)
            return;

        // 2. only 1 element
        if(head.getNext() == null) {
            head = null;
            tail = null;
            return;
        }

        // 3. more than one element
        tail = tail.getPrev();
        tail.setNext(null);
    }

    public boolean contains(int value) {
        if(head == null)
            return false;
        return contains(value, head);
    }
    // Checks, if current node (or next) contains value
    private boolean contains (int value, Node node) {
        if(node.getNumber() == value)
            return true; // Found node with value
        if(node.getNext() == null)
            return false; // End of list
        // Check if the next node contains value
        return contains(value, node.getNext());
    }

    // Output of list recursive
    public void print() {
        if (head == null)
            return;
        print(head);
    }

    private void print (Node node) {
        // System.out.print(node.getNumber() + " ");
        if(node.getNext() != null)
          print(node.getNext());
        System.out.print(node.getNumber() + " ");
    }

    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();
        Node node = head;
        while(node != null){
            if(node != tail)
                builder.append(node.getNumber()).append(" ");
            else
                builder.append(node.getNumber());
            node = node.getNext();
        }
        return builder.toString();
    }
}