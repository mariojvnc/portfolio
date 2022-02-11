package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) {
        MyList list = new MyList();

        list.add(7);
        list.add(3);
        list.add(5);
        list.add(6);
        list.add(92);

        System.out.println(list);

        list.print();
    }
}
