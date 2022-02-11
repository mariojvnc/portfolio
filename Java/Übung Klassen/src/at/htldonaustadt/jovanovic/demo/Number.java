package at.htldonaustadt.jovanovic.demo;

public class Number {
    private int number;

    public Number(int _number){
        number = _number;
    }

    public int getNumber(){
        return number;
    }

    public void setNumber(int _number){
        number = _number;
    }

    // Erstelle in der Klasse Zahl eine nicht-statische Methode die für eine bestimmte Zahl n das kleine
    // Einmaleins auf der Konsole ausgibt und probiere sie im Main für verschiedene Zahlen aus.
    public void theLittleOne(int n) {
        theLittleOne_static(n);
    }

    public static void theLittleOne_static (int n){
        for (int x = 1; x <= n; x++) {
            for (int y = 1; y <= n; y++) {
                System.out.println(x + " x " + y + " = " + (x*y));
            }
            System.out.println();
        }
    }

    public boolean isLeapYear(int year){

        // a) Ein Jahr ist kein Schaltjahr, wenn die Jahreszahl nicht durch 4 teilbar ist.
        // b) Ein Jahr ist ein Schaltjahr, wenn die Jahreszahl durch 4, aber nicht durch 100 teilbar ist.
        // c) Ein Jahr ist ebenfalls ein Schaltjahr, wenn die Jahreszahl durch 4, durch 100 und durch 400 teilbar ist

        if ((year % 4) == 0)
        {
            if ((year % 100) == 0)
            {
                return (year % 400) == 0;
            }
            else
                return true;
        }
        return false;
    }

    public int getCrossSum(int number){
        int sum = 0;
        while (number != 0) {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    public int getProdcutSum(int number){
        int product = 1;
        while (number != 0) {
            product = product * (number % 10);
            number = number / 10;
        }
        return product;
    }

    public boolean isMagic(int number){
        // Finde alle "magic" Zahlen von 0 bis 1000 bei denen die Summe aus der Quersumme und
        // dem Querprodukt gleich der ursprünglichen Zahl ist
        return getCrossSum(number) + getProdcutSum(number) == number;
    }

    @Override
    public String toString() {
        return "Number{" +
                "number=" + number +
                '}';
    }
}